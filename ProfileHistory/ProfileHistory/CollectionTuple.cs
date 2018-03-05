namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;
    using DVDProfilerXML.Version400;

    internal class CollectionTuple
    {
        public FileInfo FileInfo { get; }

        public Collection Collection { get; }

        public CollectionTuple(String fileName, Collection collection)
        {
            FileInfo = new FileInfo(fileName);

            Collection = collection;
        }
    }
}