using System.Collections.Generic;
using System.IO;

namespace NetAssist.Domain
{
    public interface IFileStorage
    {
        bool Exists(string path);
        FileReference Save(Stream stream, string path, bool overwrite = false);
        FileReference Save(string content, string path, bool overwrite = false);
        FileReference Publish(string localFilePath, string path, bool overwrite = false);
        string ReadContent(string path);
        Stream Load(string path);
        void Delete(string path);
        IReadOnlyList<FileContent> GetFiles(string path);
        IReadOnlyList<FileContent> GetFiles(string path, ResultListFilter resultsFilter, out int total);
        IReadOnlyList<FileDirectory> GetDirectories(string path);
    }
}
