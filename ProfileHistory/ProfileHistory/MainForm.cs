namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnReadMeToolStripMenuItemClick(Object sender, EventArgs e)
        { }

        private void OnCheckForUpdatesToolStripMenuItemClick(Object sender, EventArgs e)
        {
            const String ProfileHistory = "ProfileHistory";

            OnlineAccess.Init("Doena Soft.", ProfileHistory);

            OnlineAccess.CheckForNewVersion("http://doena-soft.de/dvdprofiler/3.9.0/versions.xml", this, ProfileHistory, GetType().Assembly, false);
        }

        private void OnAboutToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox(GetType().Assembly))
            {
                aboutBox.ShowDialog();
            }
        }

        private void OnWinMergeLinkLabelLinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
        {
            String argument = "http://winmerge.org/";

            if (Thread.CurrentThread.CurrentUICulture.Name.StartsWith("de"))
            {
                argument += "?lang=de";
            }

            Process.Start(argument);
        }

        private void OnProfileFolderButtonClick(Object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = Texts.ProfileFolderDialogDescription;
                fbd.ShowNewFolderButton = false;

                if ((String.IsNullOrEmpty(ProfileFolderTextBox.Text) == false) && (Directory.Exists(ProfileFolderTextBox.Text)))
                {
                    fbd.SelectedPath = ProfileFolderTextBox.Text;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    ProfileFolderTextBox.Text = fbd.SelectedPath;

                    Program.Settings.DefaultValues.ProfilesFolder = fbd.SelectedPath;
                }
            }
        }

        private void OnWinMergeButtonClick(Object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = "WinMergeU.exe|WinMergeU.exe";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Title = Texts.WinMergeDialogDescription;
                ofd.InitialDirectory = (new FileInfo(Environment.ExpandEnvironmentVariables(WinMergeTextBox.Text))).DirectoryName;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    WinMergeTextBox.Text = ofd.FileName;

                    Program.Settings.DefaultValues.WinMergePath = ofd.FileName;
                }
            }
        }

        private void OnCheckProfileHistoryButtonClick(Object sender, EventArgs e)
        {
            if (CheckPreconditions() == false)
            {
                return;
            }

            Dictionary<DVD, IEnumerable<ProfileTuple>> changedProfiles = (new ProfileProcessor()).GetChangedProfiles(ProfileFolderTextBox.Text, Handle);
        }

        private Boolean CheckPreconditions()
        {
            if (Directory.Exists(ProfileFolderTextBox.Text) == false)
            {
                MessageBox.Show(MessageBoxTexts.FolderDoesNotExist, MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return (false);
            }

            if (File.Exists(Environment.ExpandEnvironmentVariables((WinMergeTextBox.Text))) == false)
            {
                MessageBox.Show(this, MessageBoxTexts.WinMergeMissingWarning, MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (true);
        }

        private void OnFormLoad(Object sender, EventArgs e)
        {
            ProfileFolderTextBox.Text = Program.Settings.DefaultValues.ProfilesFolder;

            WinMergeTextBox.Text = Program.Settings.DefaultValues.WinMergePath;
        }
    }
}