namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
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
        public static void Main(String[] args)
        {
            TrySetLanguage(args);

            try
            {
                CreateSettings();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                SaveSetting();
            }
            catch (Exception ex)
            {
                TryWriteErrorFile(ex);
            }
        }

        private static void TrySetLanguage(String[] args)
        {
            String firstArg = args.FirstOrDefault()?.ToLower();

            switch (firstArg)
            {
                case "/de":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de");

                        break;
                    }
                case "/en":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");

                        break;
                    }
            }
        }

        private static void TryWriteErrorFile(Exception ex)
        {
            try
            {
                ExceptionXml xml = new ExceptionXml(ex);

                String temp = Path.GetTempPath();

                String file = Path.Combine(temp, "ProfileHistoryError.xml");

                DVDProfilerSerializer<ExceptionXml>.Serialize(file, xml);

                MessageBox.Show(String.Format(MessageBoxTexts.CriticalError, ex.Message, file), MessageBoxTexts.CriticalErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }
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
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, _SettingsFile, ex.Message), MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, _SettingsFile, ex.Message), MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}