namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    partial class ProfileProcessor
    {
        private sealed class ExtendedProfileTuple : ProfileTuple
        {
            public String CleanedProfileXml { get; }

            public Int32 HashCode { get; }

            public ExtendedProfileTuple(String fileName, String profileXml)
                : base(fileName, profileXml)
            {
                CleanedProfileXml = GetCleanedProfile(ProfileXml);

                HashCode = CleanedProfileXml.GetHashCode();
            }

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