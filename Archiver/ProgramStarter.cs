using System;

namespace Archiver
{
    public class ProgramStarter : IProgramStarter
    {
        private readonly IFileListingService _fileListingService;
        private readonly IZipFileFactory _zipFileFactory;

        public ProgramStarter(IFileListingService fileListingService, IZipFileFactory zipFileFactory)
        {
            _fileListingService = fileListingService;
            _zipFileFactory = zipFileFactory;
        }

        public void Run()
        {
            Console.WriteLine("Archiver version 1.0");

            var validFiles = _fileListingService.GetValidFiles();
            _zipFileFactory.Archive(validFiles);
        }
    }
}