namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;
    using DoenaSoft.ToolBox.Generics;
    using DVDProfilerXML.Version400;

    internal partial class ProfileProcessor
    {
        private sealed class ExtendedProfileTuple : ProfileTuple
        {
            public String CleanedProfileXml { get; }

            public Int32 HashCode { get; }

            public ExtendedProfileTuple(FileInfo fileInfo, String profileXml)
                : base(fileInfo, profileXml)
            {
                this.CleanedProfileXml = GetCleanedProfile(this.ProfileXml);

                this.HashCode = this.CleanedProfileXml.GetHashCode();
            }

            public ProfileTuple Simplify()
                => (new ProfileTuple(this.FileInfo, this.ProfileXml));

            private static String GetCleanedProfile(String rawProfileXml)
            {
                DVD cleanedProfile = XmlSerializer<DVD>.FromString(rawProfileXml, Collection.DefaultEncoding);

                cleanedProfile.LastEditedSpecified = false;
                cleanedProfile.ProfileTimestamp = new DateTime(0);

                String cleanedProfileXml = XmlSerializer<DVD>.ToString(cleanedProfile, Collection.DefaultEncoding);

                return (cleanedProfileXml);
            }
        }
    }
}