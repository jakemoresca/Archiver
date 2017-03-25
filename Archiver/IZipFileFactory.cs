using System.Collections.Generic;

namespace Archiver
{
    public interface IZipFileFactory
    {
        void Archive(IEnumerable<string> fileNames);
    }
}
