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
        internal IEnumerable<CollectionTuple> Get(IEnumerable<String> files)
        {
            IEnumerable<CollectionTuple> collections = GetCollections(files);

            IEnumerable<CollectionTuple> validCollections = collections.Where(t => t.Collection?.DVDList?.Length > 0);

            return (validCollections);
        }

        private static IEnumerable<CollectionTuple> GetCollections(IEnumerable<String> files)
        {
            foreach (String file in files)
            {
                Collection collection = TryGetCollection(file);

                yield return (new CollectionTuple(file, collection));
            }
        }

        internal static Collection TryGetCollection(String file)
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