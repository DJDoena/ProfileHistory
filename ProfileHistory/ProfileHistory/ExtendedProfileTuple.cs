namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    partial class ProfileProcessor
    {
        private sealed class ExtendedProfileTuple : ProfileTuple
        {
            public String CleanedProfileXml { get; }

            public Int32 HashCode { get; }

            public ExtendedProfileTuple(FileInfo fileInfo, String profileXml)
                : base(fileInfo, profileXml)
            {
                CleanedProfileXml = GetCleanedProfile(ProfileXml);

                HashCode = CleanedProfileXml.GetHashCode();
            }

            public ProfileTuple Simplify()
                => (new ProfileTuple(FileInfo, ProfileXml));

            private static String GetCleanedProfile(String rawProfileXml)
            {
                DVD cleanedProfile = DVDProfilerSerializer<DVD>.FromString(rawProfileXml, Collection.DefaultEncoding);

                cleanedProfile.LastEditedSpecified = false;
                cleanedProfile.ProfileTimestamp = new DateTime(0);

                String cleanedProfileXml = DVDProfilerSerializer<DVD>.ToString(cleanedProfile, Collection.DefaultEncoding);

                return (cleanedProfileXml);
            }
        }
    }
}