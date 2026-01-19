# bruterlabx
bruterlabx brute easy


**Required NuGet Packages:**
1. Renci.SshNet (for SSH/SFTP)
2. FluentFTP (for FTP)

**To install the packages, run these commands in Package Manager Console:**
```powershell
Install-Package SSH.NET
Install-Package FluentFTP
```

**Features of the GUI application:**

1. **Multi-protocol support**: SSH, SFTP, and FTP
2. **Modern dark UI** with intuitive controls
3. **Real-time results display** with color-coded status
4. **Parallel processing** with configurable thread count
5. **Attack statistics** (attempts/success count)
6. **Export functionality** to save results
7. **Configurable delay** between attempts
8. **Option to continue** after finding valid credentials
9. **Server banner grabbing** for each protocol
10. **Start/Stop control** during attack execution

**Usage:**
1. Enter target hostname/IP
2. Select protocol (SSH/SFTP/FTP)
3. Browse for username and password files
4. Configure threads and delay
5. Click "Start Attack"
6. Monitor results in real-time
7. Export successful credentials when found

The application maintains all the functionality from your console version while adding a user-friendly interface and extended protocol support.
