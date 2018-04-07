using System;
using System.IO;

namespace NetAssist.Domain.Services
{
    public class FilePathHelper : IPathHelper
    {
        public virtual string GetDirectoryPath(string path)
        {
            return GetDirectoryPath(path, IsFileSystemPath(path));
        }

        public virtual string GetDirectoryPath(string path, bool fileSystem)
        {
            return GetDirectoryPath(path, fileSystem, appendSlash: false);
        }

        public virtual string GetDirectoryPath(string path, bool fileSystem, bool appendSlash)
        {
            return GetDirectoryPathInternal(path, fileSystem, appendSlash);
        }

        private static string GetDirectoryPathInternal(string path, bool fileSystem, bool appendSlash)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            DetermineCharsToAdjust(fileSystem, out char slashToReplace, out char newSlash);

            path = Path.GetDirectoryName(path).Replace(slashToReplace, newSlash);

            if (appendSlash && !path.EndsWith(newSlash.ToString()))
                path = string.Concat(path, newSlash);

            return path;
        }

        public virtual string Combine(params string[] paths)
        {
            return Combine(fileSystem: false, paths: paths);
        }

        public virtual string Combine(bool fileSystem, params string[] paths)
        {
            return CombineInternal(fileSystem, paths);
        }

        private static string CombineInternal(bool fileSystem, params string[] paths)
        {
            if (paths == null || paths.Length == 0)
                throw new ArgumentNullException(nameof(paths));

            DetermineCharsToAdjust(fileSystem, out char slashToReplace, out char newSlash);

            return Path.Combine(paths).Replace(slashToReplace, newSlash);
        }

        private static void DetermineCharsToAdjust(bool fileSystem, out char slashToReplace, out char newSlash)
        {
            // NOTE: DirectorySeparatorChar = '\\'
            //       AltDirectorySeparatorChar  = '/'

            slashToReplace = fileSystem ? Path.AltDirectorySeparatorChar : Path.DirectorySeparatorChar;
            newSlash = fileSystem ? Path.DirectorySeparatorChar : Path.AltDirectorySeparatorChar;
        }

        private static void DetermineCharsToAdjust(string path, out char slashToReplace, out char newSlash)
        {
            DetermineCharsToAdjust(IsFileSystemPath(path), out slashToReplace, out newSlash);
        }

        private static bool IsFileSystemPath(string path)
        {
            return path?.Contains(Path.DirectorySeparatorChar.ToString()) ?? false;
        }

        public virtual string UniqueFileName(string path)
        {
            string uniqueId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            string fileName = string.Concat(
                Path.GetFileNameWithoutExtension(path),
                "_",
                uniqueId.Substring(uniqueId.Length - 10),
                Path.GetExtension(path));

            return Combine(GetDirectoryPath(path), fileName);
        }

        // Ref - https://stackoverflow.com/a/35218619
        public virtual string GetAbsolutePath(string relativePath, string basePath)
        {
            if (relativePath == null)
                return null;

            relativePath = CleanForAbsolutePath(relativePath);

            if (basePath == null)
                basePath = Path.GetFullPath("."); // quick way of getting current working directory
            else
                basePath = GetAbsolutePath(basePath, null); // to be REALLY sure

            string path;
            // specific for windows paths starting on \ - they need the drive added to them.
            if (!Path.IsPathRooted(relativePath) || "\\".Equals(Path.GetPathRoot(relativePath)))
            {
                if (relativePath.StartsWith(Path.DirectorySeparatorChar.ToString()))
                    path = Path.Combine(basePath, relativePath.TrimStart(Path.DirectorySeparatorChar));
                else
                    path = Path.Combine(basePath, relativePath);
            }
            else
                path = relativePath;

            // resolves any internal "..\" to get the true full path.
            return Path.GetFullPath(path);
        }

        private static string CleanForAbsolutePath(string path)
        {
            return path.SetNullToEmpty()?.Replace("/", "\\");
        }

        public virtual string CleanFileName(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            path = path.Trim();
            string fileName = $"{Path.GetFileNameWithoutExtension(path).Replace(".", "_").Replace(" ", "_")}{Path.GetExtension(path)}";
            return Combine(GetDirectoryPath(path), fileName);
        }

        public virtual string SetupAbsoluteFilePath(string baseDirectory, params string[] paths)
        {
            string path = Combine(paths);
            path = GetAbsolutePath(path, baseDirectory);
            Directory.CreateDirectory(GetDirectoryPath(path));
            return path;
        }
    }
}
