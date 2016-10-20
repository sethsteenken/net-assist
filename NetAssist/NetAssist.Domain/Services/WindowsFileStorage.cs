using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetAssist.Domain
{
    public class WindowsFileStorage : IFileStorage
    {
        protected int UniqueMaxCount { get; set; } = 200;

        public virtual string GetFullPath(string relativePath)
        {
            return GetFullPath(relativePath, createIfAbsent: true);
        }

        public virtual string GetFullPath(string relativePath, bool createIfAbsent)
        {
            relativePath.SetNullToEmpty(trim: true);

            if (createIfAbsent && !Directory.Exists(relativePath))
                Directory.CreateDirectory(relativePath);

            return relativePath;
        }

        public virtual string GenerateUniqueFileName(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            if (!File.Exists(path))
                return path;

            var directory = Path.GetDirectoryName(path);
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var fileIndex = 0;

            do
            {
                if (fileIndex > UniqueMaxCount) //infinite loop check
                    throw new IndexOutOfRangeException("Unique file creation out of range.");

                fileIndex++;
                path = Path.Combine(directory, $"{fileName}_{fileIndex}{extension}");
            }
            while (File.Exists(path));

            return path;
        }

        public virtual string Save(Stream stream, string directory, string fileName)
        {
            return Save(stream, directory, null, fileName);
        }

        public virtual string Save(Stream stream, string directory, string subpath, string fileName)
        {
            var storagePath = GetFullPath(Path.Combine(directory.SetNullToEmpty(), subpath.SetNullToEmpty()));
            var filePath = GenerateUniqueFileName(Path.Combine(storagePath, CleanFileName(fileName)));

            using (Stream file = File.Create(filePath))
            {
                stream.CopyTo(file);
            }

            return Path.GetFileName(filePath);
        }

        public virtual IReadOnlyList<FileContent> GetFiles(string directoryPath)
        {
            var files = new List<FileContent>();
            if (string.IsNullOrWhiteSpace(directoryPath))
                return files;

            var filePaths = Directory.GetFiles(GetFullPath(directoryPath));
            if (filePaths.HasItems<string>())
            {
                foreach (var filePath in filePaths)
                {
                    var file = new FileInfo(filePath);
                    files.Add(new FileContent(Path.Combine(directoryPath, file.Name), (int)file.Length));
                }
            }
            return files;
        }

        public virtual IReadOnlyList<FileDirectory> GetDirectories(string path)
        {
            var directories = new List<FileDirectory>();
            if (string.IsNullOrWhiteSpace(path))
                return directories;

            var directoryPaths = Directory.GetDirectories(GetFullPath(path));
            if (directoryPaths.HasItems<string>())
            {
                foreach (var directoryPath in directoryPaths)
                {
                    var directory = new DirectoryInfo(directoryPath);
                    directories.Add(new FileDirectory(Path.Combine(path, directory.Name)));
                }
            }

            return directories;
        }

        public virtual IReadOnlyList<FileContent> GetFiles(string directoryPath, ResultListFilter resultsFilter, out int total)
        {
            var files = GetFiles(directoryPath);
            if (resultsFilter != null)
                files = files.AsQueryable().PagedAndSorted(resultsFilter.Paging, resultsFilter.Sorting, out total).ToList();
            else
                total = files.Count;

            return files;
        }

        public virtual string GetFileName(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            return new FileInfo(GetFullPath(path)).Name;
        }

        protected virtual string CleanFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            fileName = fileName.Trim();
            return $"{Path.GetFileNameWithoutExtension(fileName).Replace(".", "_").Replace(" ", "_")}{Path.GetExtension(fileName)}";
        }
    }
}
