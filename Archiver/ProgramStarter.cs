using log4net;
using System;
using System.Linq;

namespace Archiver
{
    public class ProgramStarter : IProgramStarter
    {
        private readonly IFileListingService _fileListingService;
        private readonly IZipFileFactory _zipFileFactory;
        private static readonly ILog log = LogManager.GetLogger(typeof(ProgramStarter));

        public ProgramStarter(IFileListingService fileListingService, IZipFileFactory zipFileFactory)
        {
            _fileListingService = fileListingService;
            _zipFileFactory = zipFileFactory;
        }

        public void Run()
        {
            Console.WriteLine("Archiver version 1.0");

            log.Info("Getting valid files");
            var validFiles = _fileListingService.GetValidFiles();
            
            foreach(var validFile in validFiles)
            {
                log.Info(validFile);
            }
            log.Info("Total Files: " + validFiles.Count());

            _zipFileFactory.Archive(validFiles);
        }
    }
}