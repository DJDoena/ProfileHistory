namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using DVDProfilerHelper;

    public static class Program
    {
        readonly static String _SettingsPath;

        readonly static String _SettingsFile;

        private static Settings _Settings;

        static Program()
        {
            String appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            _SettingsPath = Path.Combine(appData, "Doena Soft.", "ProfileHistory");

            _SettingsFile = Path.Combine(_SettingsPath, "settings.xml");
        }

        internal static Settings Settings
            => _Settings;

        [STAThread]
        public static void Main()
        {
            CreateSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            SaveSetting();
        }

        private static void CreateSettings()
        {
            if (File.Exists(_SettingsFile))
            {
                TryGetSettings();
            }

            if (_Settings == null)
            {
                _Settings = new Settings();
            }

            if (_Settings.DefaultValues == null)
            {
                _Settings.DefaultValues = new DefaultValues();
            }
        }

        private static void TryGetSettings()
        {
            try
            {
                _Settings = DVDProfilerSerializer<Settings>.Deserialize(_SettingsFile);
            }
            catch
            { }
        }

        private static void SaveSetting()
        {
            try
            {
                if (Directory.Exists(_SettingsPath) == false)
                {
                    Directory.CreateDirectory(_SettingsPath);
                }

                DVDProfilerSerializer<Settings>.Serialize(_SettingsFile, _Settings);
            }
            catch
            { }
        }
    }
}