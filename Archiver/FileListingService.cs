using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Archiver
{
    public class FileListingService : IFileListingService
    {
        private readonly IArchiverSettingService _archiverSettingsService;

        public FileListingService(IArchiverSettingService archiverSettingsService)
        {
            _archiverSettingsService = archiverSettingsService;
        }

        public IEnumerable<string> GetValidFiles()
        {
            var filePathToRun = _archiverSettingsService.FilePathToRun;
            var fileExtensionRegexPattern = _archiverSettingsService.FileExtensionRegexPattern;
            var numberOfDaysToRetain = _archiverSettingsService.DaysToRetain;
            var oldestDateToRetain = DateTime.UtcNow.AddDays(-numberOfDaysToRetain);

            var filePatternMatches = Directory.GetFiles(filePathToRun)
                .Where(path => Regex.Match(path, fileExtensionRegexPattern).Success
                && File.GetLastWriteTimeUtc(path) >= oldestDateToRetain);

            return filePatternMatches;
        }
    }
}
