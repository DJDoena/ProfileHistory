namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.IO;
    using DVDProfilerXML.Version400;

    internal class CollectionTuple
    {
        public String FileName { get; }

        public Collection Collection { get; }

        public CollectionTuple(String fileName, Collection collection)
        {
            FileName = (new FileInfo(fileName)).Name;

            Collection = collection;
        }
    }
}