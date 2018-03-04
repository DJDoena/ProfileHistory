namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;

    internal class ProfileTuple
    {
        public String FileName { get; }

        public String ProfileXml { get; }

        public ProfileTuple(String fileName, String profileXml)
        {
            FileName = (new FileInfo(fileName)).Name;

            ProfileXml = profileXml;
        }
    }
}