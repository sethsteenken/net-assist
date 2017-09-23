using System.Collections.Generic;
using System.IO;

namespace NetAssist.Domain
{
    public interface IFileStorage
    {
        string GetFullPath(string relativePath);
        string GetFullPath(string relativePath, bool createDirectoryIfAbsent);
        string GenerateUniqueFileName(string path);
        string Save(Stream stream, string directory, string fileName);
        IReadOnlyList<FileContent> GetFiles(string directoryPath);
        IReadOnlyList<FileContent> GetFiles(string directoryPath, ResultListFilter resultsFilter, out int total);
        IReadOnlyList<FileDirectory> GetDirectories(string path);
        string GetFileName(string path);
        string Read(string path);
    }
}
