using System.IO;

namespace NetAssist.Domain.Services
{
    public class WindowsAbsoluteFileStorage : WindowsFileStorage, IFileStorage
    {
        private readonly string _contentRootAbsolutePath;

        public WindowsAbsoluteFileStorage(IPathHelper pathHelper, string contentRootAbsolutePath)
            : base(pathHelper)
        {
            _contentRootAbsolutePath = contentRootAbsolutePath;
        }

        protected override string GetFullPath(string relativePath)
        {
            string path = PathHelper.CleanFileName(PathHelper.GetAbsolutePath(relativePath, _contentRootAbsolutePath));
            string directory = PathHelper.GetDirectoryPath(path);

            if (!Directory.Exists(directory) && !File.Exists(directory))
                Directory.CreateDirectory(directory);

            return path;
        }
    }
}
