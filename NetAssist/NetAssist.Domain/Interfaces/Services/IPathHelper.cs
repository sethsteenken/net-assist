namespace NetAssist.Domain
{
    public interface IPathHelper
    {
        string GetDirectoryPath(string path);
        string GetDirectoryPath(string path, bool fileSystem);
        string GetDirectoryPath(string path, bool fileSystem, bool appendSlash);
        string Combine(params string[] paths);
        string Combine(bool fileSystem, params string[] paths);
        string GetAbsolutePath(string relativePath, string basePath);
        string SetupAbsoluteFilePath(string baseDirectory, params string[] paths);
        string CleanFileName(string path);
        string UniqueFileName(string path);
    }
}
