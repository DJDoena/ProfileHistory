namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;

    internal class ProfileTuple
    {
        public FileInfo FileInfo { get; }

        public String ProfileXml { get; }

        public ProfileTuple(FileInfo fileInfo, String profileXml)
        {
            FileInfo = fileInfo;

            ProfileXml = profileXml;
        }
    }
}