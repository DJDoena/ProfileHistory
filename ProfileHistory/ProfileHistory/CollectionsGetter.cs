namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    internal sealed class CollectionsGetter
    {
        internal IEnumerable<CollectionTuple> Get(List<String> files)
        {
            IEnumerable<CollectionTuple> collections = GetCollections(files);

            IEnumerable<CollectionTuple> validCollections = collections.Where(t => t.Collection?.DVDList?.Length > 0);

            return (validCollections);
        }

        private static IEnumerable<CollectionTuple> GetCollections(List<String> files)
        {
            files.Sort(CompareFile);

            foreach (String file in files)
            {
                Collection collection = TryGetCollection(file);

                yield return (new CollectionTuple(file, collection));
            }
        }

        private static Int32 CompareFile(String left, String right)
        {
            FileInfo leftFI = new FileInfo(left);

            FileInfo rightFI = new FileInfo(right);

            Int32 compare = leftFI.LastWriteTimeUtc.CompareTo(rightFI.LastWriteTimeUtc);

            return (compare);
        }

        private static Collection TryGetCollection(String file)
        {
            try
            {
                Collection collection = DVDProfilerSerializer<Collection>.Deserialize(file);

                return (collection);
            }
            catch
            {
                return (null);
            }
        }
    }
}