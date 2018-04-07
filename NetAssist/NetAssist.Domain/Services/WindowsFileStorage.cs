using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetAssist.Domain
{
    public class WindowsFileStorage : IFileStorage
    {
        private readonly IPathHelper _pathHelper;

        public WindowsFileStorage(IPathHelper pathHelper)
        {
            _pathHelper = pathHelper;
        }

        protected virtual IPathHelper PathHelper => _pathHelper;

        protected virtual string GetFullPath(string relativePath)
        {
            relativePath = _pathHelper.CleanFileName(relativePath.SetNullToEmpty().Replace("/", @"\"));

            if (!Directory.Exists(relativePath) && !File.Exists(relativePath))
                Directory.CreateDirectory(relativePath);

            return relativePath;
        }

        protected virtual FileReference BuildFileReferenceResponse(string path, long size)
        {
            return new FileReference(_pathHelper.GetDirectoryPath(path), path, new FileContent(Path.GetFileName(path), (int)size));
        }

        public virtual bool Exists(string path)
        {
            return File.Exists(GetFullPath(path));
        }

        public virtual FileReference Save(Stream stream, string path, bool overwrite = false)
        {
            path = GetFullPath(path);
            if (File.Exists(path) && !overwrite)
                path = _pathHelper.UniqueFileName(path);

            long size;

            using (Stream file = File.Create(path))
            {
                stream.CopyTo(file);
                size = file.Length;
            }

            return BuildFileReferenceResponse(path, (int)size);
        }

        public virtual FileReference Save(string content, string path, bool overwrite = false)
        {
            path = GetFullPath(path);
            if (File.Exists(path) && !overwrite)
                path = _pathHelper.UniqueFileName(path);

            File.WriteAllText(path, content);

            return BuildFileReferenceResponse(path, (int)new FileInfo(path).Length);
        }

        public virtual FileReference Publish(string localFilePath, string path, bool overwrite = false)
        {
            path = GetFullPath(path);

            if (!File.Exists(localFilePath))
                throw new FileNotFoundException(localFilePath);

            if (File.Exists(path) && !overwrite)
                path = _pathHelper.UniqueFileName(path);

            File.Copy(localFilePath, path);

            return BuildFileReferenceResponse(path, (int)new FileInfo(path).Length);
        }

        public virtual Stream Load(string path)
        {
            return new FileStream(GetFullPath(path), FileMode.Open);
        }

        public virtual string ReadContent(string path)
        {
            return File.ReadAllText(GetFullPath(path));
        }

        public virtual void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public virtual IReadOnlyList<FileDirectory> GetDirectories(string path)
        {
            var directories = new List<FileDirectory>();
            if (string.IsNullOrWhiteSpace(path))
                return directories;

            var directoryPaths = Directory.GetDirectories(GetFullPath(path));
            foreach (var directoryPath in directoryPaths)
            {
                var directory = new DirectoryInfo(directoryPath);
                directories.Add(new FileDirectory(Path.Combine(path, directory.Name)));
            }

            return directories;
        }

        public virtual IReadOnlyList<FileContent> GetFiles(string path)
        {
            var files = new List<FileContent>();
            if (string.IsNullOrWhiteSpace(path))
                return files;

            var filePaths = Directory.GetFiles(GetFullPath(path));
            if (filePaths.HasItems<string>())
            {
                foreach (var filePath in filePaths)
                {
                    var file = new FileInfo(filePath);
                    files.Add(new FileContent(_pathHelper.Combine(path, file.Name), (int)file.Length));
                }
            }
            return files;
        }

        public virtual IReadOnlyList<FileContent> GetFiles(string path, ResultListFilter resultsFilter, out int total)
        {
            var files = GetFiles(path);
            if (resultsFilter != null)
                files = files.AsQueryable().PagedAndSorted(resultsFilter.Paging, resultsFilter.Sorting, out total).ToList();
            else
                total = files.Count;

            return files;
        }
    }
}
