namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using DoenaSoft.ToolBox.Generics;
    using DVDProfilerXML.Version400;

    internal sealed partial class ProfileProcessor
    {
        private static readonly IEqualityComparer<ExtendedProfileTuple> _EqualityComparer;

        private readonly Boolean _IgnoreOldProfiles;

        private readonly List<String> _Filters;

        private Dictionary<DVD, List<ExtendedProfileTuple>> _Profiles;

        static ProfileProcessor()
        {
            _EqualityComparer = new ProfileEqualityComparer();
        }

        public ProfileProcessor(Boolean ignoreOldProfiles, String flagSetFile)
        {
            _IgnoreOldProfiles = ignoreOldProfiles;

            _Filters = (String.IsNullOrEmpty(flagSetFile) == false) ? GetFilters(flagSetFile) : new List<String>(0);
        }

        private static List<String> GetFilters(String flagSetFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(flagSetFile, Encoding.GetEncoding(1252)))
                {
                    List<String> filters = new List<String>();

                    while (sr.EndOfStream == false)
                    {
                        filters.Add(sr.ReadLine());
                    }

                    return (filters);
                }
            }
            catch
            {
                return (new List<String>(0));
            }
        }

        internal Dictionary<DVD, IEnumerable<ProfileTuple>> GetChangedProfiles(String path, Control host)
        {
            _Profiles = new Dictionary<DVD, List<ExtendedProfileTuple>>();

            List<String> collectionFiles = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly).ToList();

            collectionFiles.Sort(CompareFile);

            if ((_IgnoreOldProfiles) && (collectionFiles.Count > 0))
            {
                this.InitializeDictionary(collectionFiles[collectionFiles.Count - 1]);
            }

            IEnumerable<CollectionTuple> collections = (new CollectionsGetter()).Get(collectionFiles);

            this.AddProfiles(collections, host, collectionFiles.Count);

            Dictionary<DVD, IEnumerable<ProfileTuple>> profiles = this.Convert();

            return (profiles);
        }

        private static Int32 CompareFile(String left, String right)
        {
            FileInfo leftFI = new FileInfo(left);

            FileInfo rightFI = new FileInfo(right);

            Int32 compare = leftFI.LastWriteTimeUtc.CompareTo(rightFI.LastWriteTimeUtc);

            return (compare);
        }

        private void InitializeDictionary(String collectionFile)
        {
            Collection collection = CollectionsGetter.TryGetCollection(collectionFile);

            if (collection == null)
            {
                return;
            }

            IEnumerable<DVD> profiles = GetProfiles(collection);

            foreach (DVD profile in profiles)
            {
                if ((_Filters.Count == 0) || (_Filters.Contains(profile.ID)))
                {
                    _Profiles[profile] = new List<ExtendedProfileTuple>();
                }
            }
        }

        private void AddProfiles(IEnumerable<CollectionTuple> collections, Control host, Int32 maximum)
        {
            using (ProgressBarHandler progress = new ProgressBarHandler(host))
            {
                progress.Start(maximum);

                foreach (CollectionTuple tuple in collections)
                {
                    this.AddProfiles(tuple);

                    progress.Update();
                }

                progress.Close();
            }
        }

        private void AddProfiles(CollectionTuple tuple)
        {
            IEnumerable<DVD> validProfiles = GetProfiles(tuple.Collection);

            foreach (DVD profile in validProfiles)
            {
                this.AddProfiles(profile, tuple.FileInfo);
            }
        }

        private static IEnumerable<DVD> GetProfiles(Collection collection)
            => (collection.DVDList?.Where(p => p != null) ?? Enumerable.Empty<DVD>());

        private void AddProfiles(DVD profile, FileInfo fileInfo)
        {
            if (_Profiles.TryGetValue(profile, out List<ExtendedProfileTuple> otherVersions) == false)
            {
                this.TryAddProfile(profile, fileInfo);

                return;
            }

            ExtendedProfileTuple tuple = CreateExtendedProfileTuple(profile, fileInfo);

            if (otherVersions.Contains(tuple, _EqualityComparer) == false)
            {
                otherVersions.Add(tuple);
            }
        }

        private void TryAddProfile(DVD profile, FileInfo fileInfo)
        {
            if ((_IgnoreOldProfiles) || ((_Filters.Count > 0) && (_Filters.Contains(profile.ID) == false)))
            {
                return;
            }

            ExtendedProfileTuple tuple = CreateExtendedProfileTuple(profile, fileInfo);

            _Profiles.Add(profile, new List<ExtendedProfileTuple>() { tuple });
        }

        private static ExtendedProfileTuple CreateExtendedProfileTuple(DVD profile, FileInfo fileInfo)
        {
            String rawProfileXml = XmlSerializer<DVD>.ToString(profile, Collection.DefaultEncoding);

            ExtendedProfileTuple tuple = new ExtendedProfileTuple(fileInfo, rawProfileXml);

            return (tuple);
        }

        private Dictionary<DVD, IEnumerable<ProfileTuple>> Convert()
        {
            Dictionary<DVD, IEnumerable<ProfileTuple>> profiles = new Dictionary<DVD, IEnumerable<ProfileTuple>>(_Profiles.Count);

            foreach (KeyValuePair<DVD, List<ExtendedProfileTuple>> kvp in _Profiles)
            {
                if (kvp.Value.Count > 1)
                {
                    String newestXml = kvp.Value.Last().ProfileXml;

                    DVD newest = XmlSerializer<DVD>.FromString(newestXml, Collection.DefaultEncoding);

                    IEnumerable<ProfileTuple> profileList = kvp.Value.Select(p => p.Simplify()).ToList();

                    profiles.Add(newest, profileList);
                }
            }

            return (profiles);
        }
    }
}