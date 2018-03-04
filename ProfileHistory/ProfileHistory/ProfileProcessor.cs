namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    internal sealed partial class ProfileProcessor
    {
        private static readonly IEqualityComparer<ExtendedProfileTuple> _EqualityComparer;

        private Dictionary<DVD, List<ExtendedProfileTuple>> _Profiles;

        static ProfileProcessor()
        {
            _EqualityComparer = new ProfileEqualityComparer();
        }

        internal Dictionary<DVD, IEnumerable<ProfileTuple>> GetChangedProfiles(String path, IntPtr handle)
        {
            _Profiles = new Dictionary<DVD, List<ExtendedProfileTuple>>();

            List<String> collectionFiles = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly).ToList();

            IEnumerable<CollectionTuple> collections = (new CollectionsGetter()).Get(collectionFiles);

            AddProfiles(collections, handle, collectionFiles.Count);

            Dictionary<DVD, IEnumerable<ProfileTuple>> result = Convert();

            return (result);
        }

        private void AddProfiles(IEnumerable<CollectionTuple> collections, IntPtr handle, Int32 maximum)
        {
            using (ProgressBarHandler progress = new ProgressBarHandler(handle))
            {
                progress.Start(maximum);

                foreach (CollectionTuple tuple in collections)
                {
                    AddProfiles(tuple);

                    progress.Update();
                }

                progress.Close();
            }
        }

        private void AddProfiles(CollectionTuple tuple)
        {
            IEnumerable<DVD> validProfiles = tuple.Collection.DVDList.Where(p => p != null);

            foreach (DVD profile in validProfiles)
            {
                AddProfiles(profile, tuple.FileName);
            }
        }

        private void AddProfiles(DVD profile, String fileName)
        {
            String rawProfileXml = DVDProfilerSerializer<DVD>.ToString(profile, Collection.DefaultEncoding);

            ExtendedProfileTuple tuple = new ExtendedProfileTuple(fileName, rawProfileXml);

            if (_Profiles.TryGetValue(profile, out List<ExtendedProfileTuple> otherVersions) == false)
            {
                _Profiles.Add(profile, new List<ExtendedProfileTuple>() { tuple });

                return;
            }

            if (otherVersions.Contains(tuple, _EqualityComparer) == false)
            {
                otherVersions.Add(tuple);
            }
        }

        private Dictionary<DVD, IEnumerable<ProfileTuple>> Convert()
        {
            Dictionary<DVD, IEnumerable<ProfileTuple>> result = new Dictionary<DVD, IEnumerable<ProfileTuple>>(_Profiles.Count);

            foreach (KeyValuePair<DVD, List<ExtendedProfileTuple>> kvp in _Profiles)
            {
                if (kvp.Value.Count > 1)
                {
                    String newestXml = kvp.Value.Last().ProfileXml;

                    DVD newest = DVDProfilerSerializer<DVD>.FromString(newestXml, Collection.DefaultEncoding);

                    result.Add(newest, kvp.Value.Select(t => new ProfileTuple(t.FileName, t.ProfileXml)).ToList());
                }
            }

            return (result);
        }
    }
}