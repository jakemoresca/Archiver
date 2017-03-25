using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Archiver
{
    public class ZipFileFactory : IZipFileFactory
    {
        private readonly IArchiverSettingService _archiverSettingService;

        public ZipFileFactory(IArchiverSettingService archiverSettingService)
        {
            _archiverSettingService = archiverSettingService;
        }

        public void Archive(IEnumerable<string> fileNames)
        {
            var filePathToRun = _archiverSettingService.FilePathToRun;
            var archiveFullName = _archiverSettingService.ArchiveFullName;

            DeletePreviousArchiveIfExisting(archiveFullName);

            Console.WriteLine(string.Format("Creating Archive: {0}", archiveFullName));
            using (var zipToOpen = new FileStream(archiveFullName, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    Console.WriteLine("Adding Files...");
                    foreach (var fileName in fileNames)
                    {
                        AddFileToArchive(fileName, archive);
                    }
                    Console.WriteLine("Done Adding Files.");
                }
            }
        }

        private void DeletePreviousArchiveIfExisting(string archiveFullName)
        {
            try
            {
                Console.WriteLine(string.Format("Trying to delete archive: {0}", archiveFullName));
                File.Delete(archiveFullName);
                Console.WriteLine("Successfully Deleted Archive File.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Cannot delete archive. Reason: {0}", ex.Message));
            }
        }

        private void AddFileToArchive(string fileName, ZipArchive archive)
        {
            try
            {
                Console.WriteLine(string.Format("Trying to add file: {0}", fileName));
                archive.CreateEntryFromFile(fileName, Path.GetFileName(fileName), CompressionLevel.Optimal);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Cannot add file to archive. Reason: {0}", ex.Message));
            }
        }
    }
}
