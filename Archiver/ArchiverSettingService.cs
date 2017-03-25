using System;
using System.Configuration;

namespace Archiver
{
    public class ArchiverSettingService : IArchiverSettingService
    {
        private const string DaysToRetainKey = "DaysToRetain";
        private const string FileExtensionRegexPatternKey = "FileExtensionRegexPattern";
        private const string FilePathToRunKey = "FilePathToRun";
        private const string ArchiveFullNameKey = "ArchiveFullName";

        public int DaysToRetain
        {
            get
            {
                var appSettings = ConfigurationManager.AppSettings;

                try
                {
                    return Convert.ToInt32(appSettings[DaysToRetainKey]);
                }
                catch (Exception)
                {
                    throw new ConfigurationErrorsException("DaysToRetainKey settings not found.");
                }
            }
        }

        public string FileExtensionRegexPattern
        {
            get
            {
                var appSettings = ConfigurationManager.AppSettings;

                try
                {
                    return appSettings[FileExtensionRegexPatternKey].ToString();
                }
                catch (Exception)
                {
                    throw new ConfigurationErrorsException("FileExtensionRegexPatternKey settings not found.");
                }
            }
        }

        public string FilePathToRun
        {
            get
            {
                var appSettings = ConfigurationManager.AppSettings;

                try
                {
                    return appSettings[FilePathToRunKey].ToString();
                }
                catch (Exception)
                {
                    throw new ConfigurationErrorsException("FilePathToRunKey settings not found.");
                }
            }
        }

        public string ArchiveFullName
        {
            get
            {
                var appSettings = ConfigurationManager.AppSettings;

                try
                {
                    return appSettings[ArchiveFullNameKey].ToString();
                }
                catch (Exception)
                {
                    throw new ConfigurationErrorsException("ArchiveFullNameKey settings not found.");
                }
            }
        }
    }
}
