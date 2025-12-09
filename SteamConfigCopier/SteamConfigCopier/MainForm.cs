using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SteamConfigCopier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Wire events here instead of using the Designer
            this.Load += MainForm_Load;
            btnRun.Click += btnRun_Click;
            btnRefreshIds.Click += btnRefreshIds_Click;
            btnDeleteSelected.Click += btnDeleteSelected_Click;

            // SteamID list interactions
            lstSteamIds.DoubleClick += lstSteamIds_DoubleClick;
            lstSteamIds.KeyDown += lstSteamIds_KeyDown;

            // Buttons that use selected SteamID
            btnUseAsSource.Click += (s, e) =>
            {
                if (lstSteamIds.SelectedItem != null)
                    txtSourceId.Text = lstSteamIds.SelectedItem.ToString();
            };

            btnAddToDest.Click += (s, e) =>
            {
                if (lstSteamIds.SelectedItem != null)
                {
                    var id = lstSteamIds.SelectedItem.ToString();
                    // avoid duplicates
                    if (!txtDestIds.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Any(x => x.Trim() == id))
                    {
                        if (txtDestIds.Text.Length > 0)
                            txtDestIds.AppendText(Environment.NewLine);
                        txtDestIds.AppendText(id);
                    }
                }
            };
            // Clear all destination IDs
            btnClearDest.Click += (s, e) =>
            {
                txtDestIds.Clear();
            };
        }

        // -------------------------------
        //   FORM LOAD – auto detect Steam
        // -------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            string steamPath = GetSteamPathFromRegistry();

            if (!string.IsNullOrEmpty(steamPath))
            {
                txtSteamPath.Text = steamPath;
                lblStatus.Text = "Steam path detected.";
            }
            else
            {
                lblStatus.Text = "Could not auto-detect Steam path. Enter manually.";
            }

            RefreshSteamIdList();
        }

        // -------------------------------
        //   COPY CONFIG BUTTON
        // -------------------------------
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Working...";

                string steamPath = txtSteamPath.Text.Trim();
                string sourceId = txtSourceId.Text.Trim();
                bool dryRun = chkDryRun.Checked;
                bool backup = chkBackup.Checked;

                if (string.IsNullOrWhiteSpace(steamPath) || string.IsNullOrWhiteSpace(sourceId))
                {
                    lblStatus.Text = "Please fill Steam path and source ID.";
                    return;
                }

                string userdataPath = GetUserdataPath();
                if (userdataPath == null)
                {
                    lblStatus.Text = "userdata folder not found under Steam path.";
                    return;
                }

                string sourceFolder = Path.Combine(userdataPath, sourceId);

                if (!Directory.Exists(sourceFolder))
                {
                    lblStatus.Text = "Source SteamID folder does not exist.";
                    return;
                }

                var destIds = txtDestIds.Text
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => id.Trim())
                    .Where(id => id.Length > 0)
                    .ToList();

                if (destIds.Count == 0)
                {
                    lblStatus.Text = "No destination SteamIDs specified.";
                    return;
                }

                AppendLog($"Starting copy from {sourceId} to {destIds.Count} destination(s). " +
                          $"DryRun={dryRun}, Backup={backup}");

                foreach (var destId in destIds)
                {
                    string destFolder = Path.Combine(userdataPath, destId);
                    AppendLog($"Processing destination SteamID {destId}");

                    if (Directory.Exists(destFolder))
                    {
                        if (backup && !dryRun)
                        {
                            BackupFolder(destFolder, userdataPath);
                        }

                        if (!dryRun)
                        {
                            AppendLog($"Deleting {destFolder}");
                            Directory.Delete(destFolder, true);
                        }
                        else
                        {
                            AppendLog($"[DRY RUN] Would delete {destFolder}");
                        }
                    }
                    else
                    {
                        AppendLog($"Destination folder {destFolder} does not exist (will be created).");
                    }

                    if (!dryRun)
                    {
                        AppendLog($"Copying {sourceFolder} -> {destFolder}");
                        CopyDirectory(sourceFolder, destFolder);
                    }
                    else
                    {
                        AppendLog($"[DRY RUN] Would copy {sourceFolder} -> {destFolder}");
                    }
                }

                RefreshSteamIdList();

                lblStatus.Text = dryRun ? "Done (dry run, no changes)." : "Done.";
                AppendLog("Copy operation completed.");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                AppendLog("ERROR: " + ex);
            }
        }

        // -------------------------------
        //   REFRESH STEAM ID LIST
        // -------------------------------
        private void btnRefreshIds_Click(object sender, EventArgs e)
        {
            RefreshSteamIdList();
        }

        private void RefreshSteamIdList()
        {
            lstSteamIds.Items.Clear();

            string userdataPath = GetUserdataPath();
            if (userdataPath == null)
            {
                AppendLog("Cannot refresh SteamIDs: userdata path not found.");
                return;
            }

            try
            {
                var dirs = Directory.GetDirectories(userdataPath)
                                    .Select(Path.GetFileName)
                                    .OrderBy(x => x);

                foreach (var id in dirs)
                {
                    // Skip backup folder or any system folders starting with _
                    if (id.StartsWith("_"))
                        continue;

                    lstSteamIds.Items.Add(id);
                }

                AppendLog("SteamID list refreshed.");
            }
            catch (Exception ex)
            {
                AppendLog("ERROR while refreshing SteamIDs: " + ex);
            }
        }

        // -------------------------------
        //   DELETE SELECTED STEAMID CONFIG
        // -------------------------------
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            string userdataPath = GetUserdataPath();
            if (userdataPath == null)
            {
                lblStatus.Text = "userdata folder not found.";
                return;
            }

            if (lstSteamIds.SelectedItem == null)
            {
                lblStatus.Text = "Select a SteamID in the list.";
                return;
            }

            string id = lstSteamIds.SelectedItem.ToString();
            string folder = Path.Combine(userdataPath, id);
            bool dryRun = chkDryRun.Checked;
            bool backup = chkBackup.Checked;

            if (!Directory.Exists(folder))
            {
                lblStatus.Text = "Selected SteamID folder does not exist.";
                return;
            }

            AppendLog($"Requested delete of SteamID {id}. DryRun={dryRun}, Backup={backup}");

            if (backup && !dryRun)
            {
                BackupFolder(folder, userdataPath);
            }

            if (!dryRun)
            {
                Directory.Delete(folder, true);
                AppendLog($"Deleted folder {folder}");
                lblStatus.Text = $"Deleted config for SteamID {id}.";
            }
            else
            {
                AppendLog($"[DRY RUN] Would delete folder {folder}");
                lblStatus.Text = $"Dry run: would delete {id}.";
            }

            RefreshSteamIdList();
        }

        // -------------------------------
        //   REGISTRY + PATH HELPERS
        // -------------------------------
        private string GetSteamPathFromRegistry()
        {
            string path = null;

            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Valve\Steam"))
                {
                    if (key != null)
                        path = key.GetValue("InstallPath") as string;
                }

                if (!string.IsNullOrEmpty(path))
                    return path;

                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    if (key != null)
                        path = key.GetValue("SteamPath") as string;
                }

                return string.IsNullOrEmpty(path) ? "" : path;
            }
            catch
            {
                return "";
            }
        }

        private string GetUserdataPath()
        {
            var steamPath = txtSteamPath.Text.Trim();
            if (string.IsNullOrWhiteSpace(steamPath))
                return null;

            var userdataPath = Path.Combine(steamPath, "userdata");
            return Directory.Exists(userdataPath) ? userdataPath : null;
        }

        // -------------------------------
        //   BACKUP + COPY HELPERS
        // -------------------------------
        private void BackupFolder(string folderPath, string userdataPath)
        {
            if (!Directory.Exists(folderPath))
                return;

            string backupsRoot = Path.Combine(userdataPath, "_backups");
            Directory.CreateDirectory(backupsRoot);

            string folderName = Path.GetFileName(folderPath.TrimEnd(Path.DirectorySeparatorChar));
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string destBackup = Path.Combine(backupsRoot, $"{folderName}_{timestamp}");

            AppendLog($"Backing up {folderPath} -> {destBackup}");
            CopyDirectory(folderPath, destBackup);
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory not found: " + sourceDir);

            Directory.CreateDirectory(destDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                string newDestDir = Path.Combine(destDir, subdir.Name);
                CopyDirectory(subdir.FullName, newDestDir);
            }
        }

        // -------------------------------
        //   STEAMID LIST COPY HELPERS
        // -------------------------------
        private void lstSteamIds_DoubleClick(object sender, EventArgs e)
        {
            CopySelectedSteamIdToClipboard();
        }

        private void lstSteamIds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedSteamIdToClipboard();
                e.Handled = true;
            }
        }

        private void CopySelectedSteamIdToClipboard()
        {
            if (lstSteamIds.SelectedItem == null)
                return;

            string id = lstSteamIds.SelectedItem.ToString();
            Clipboard.SetText(id);

            lblStatus.Text = $"Copied SteamID {id} to clipboard.";
            AppendLog($"Copied SteamID {id} to clipboard.");
        }

        // -------------------------------
        //   LOGGING
        // -------------------------------
        private void AppendLog(string message)
        {
            if (txtLog == null)
                return;

            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }

        // Keep this if designer wired lblLog.Click to something
        private void lblLog_Click(object sender, EventArgs e)
        {
            // no-op
        }
    }
}
