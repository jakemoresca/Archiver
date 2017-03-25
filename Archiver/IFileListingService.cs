using System.Collections.Generic;

namespace Archiver
{
    public interface IFileListingService
    {
        IEnumerable<string> GetValidFiles();
    }
}
