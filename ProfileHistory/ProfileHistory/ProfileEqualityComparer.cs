namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;

    partial class ProfileProcessor
    {
        private sealed class ProfileEqualityComparer : IEqualityComparer<ExtendedProfileTuple>
        {
            public Boolean Equals(ExtendedProfileTuple left, ExtendedProfileTuple right)
                => (left.CleanedProfileXml == right.CleanedProfileXml);

            public Int32 GetHashCode(ExtendedProfileTuple tuple)
                => (tuple.HashCode);
        }
    }
}