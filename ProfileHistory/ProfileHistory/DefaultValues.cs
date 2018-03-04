namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;

    public class DefaultValues
    {
        private String _WinMergePath;

        public String WinMergePath
        {
            get
            {
                if (String.IsNullOrEmpty(_WinMergePath))
                {
                    String x86Path = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

                    if (String.IsNullOrEmpty(x86Path))
                    {
                        return (@"%ProgramFiles%\WinMerge\WinMergeU.exe");
                    }
                    else
                    {
                        return (@"%ProgramFiles(x86)%\WinMerge\WinMergeU.exe");
                    }
                }

                return (_WinMergePath);
            }
            set => _WinMergePath = value;
        }

        public String ProfilesFolder { get; set; }
    }
}