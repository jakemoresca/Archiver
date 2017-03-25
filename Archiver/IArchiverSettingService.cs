namespace Archiver
{
    public interface IArchiverSettingService
    {
        int DaysToRetain { get; }
        string FileExtensionRegexPattern { get; }
        string FilePathToRun { get; }
        string ArchiveFullName { get; }
    }
}
