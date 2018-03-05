namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
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

        internal Dictionary<DVD, IEnumerable<ProfileTuple>> GetChangedProfiles(String path, Control host)
        {
            _Profiles = new Dictionary<DVD, List<ExtendedProfileTuple>>();

            List<String> collectionFiles = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly).ToList();

            IEnumerable<CollectionTuple> collections = (new CollectionsGetter()).Get(collectionFiles);

            AddProfiles(collections, host, collectionFiles.Count);

            Dictionary<DVD, IEnumerable<ProfileTuple>> profiles = Convert();

            return (profiles);
        }

        private void AddProfiles(IEnumerable<CollectionTuple> collections, Control host, Int32 maximum)
        {
            using (ProgressBarHandler progress = new ProgressBarHandler(host))
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
                AddProfiles(profile, tuple.FileInfo);
            }
        }

        private void AddProfiles(DVD profile, FileInfo fileInfo)
        {
            String rawProfileXml = DVDProfilerSerializer<DVD>.ToString(profile, Collection.DefaultEncoding);

            ExtendedProfileTuple tuple = new ExtendedProfileTuple(fileInfo, rawProfileXml);

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
            Dictionary<DVD, IEnumerable<ProfileTuple>> profiles = new Dictionary<DVD, IEnumerable<ProfileTuple>>(_Profiles.Count);

            foreach (KeyValuePair<DVD, List<ExtendedProfileTuple>> kvp in _Profiles)
            {
                if (kvp.Value.Count > 1)
                {
                    String newestXml = kvp.Value.Last().ProfileXml;

                    DVD newest = DVDProfilerSerializer<DVD>.FromString(newestXml, Collection.DefaultEncoding);

                    IEnumerable<ProfileTuple> profileList = kvp.Value.Select(p => p.Simplify()).ToList();

                    profiles.Add(newest, profileList);
                }
            }

            return (profiles);
        }
    }
}