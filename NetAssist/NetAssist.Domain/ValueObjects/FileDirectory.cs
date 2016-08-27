using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class FileDirectory : ValueObject<FileDirectory>
    {
        public FileDirectory(string path)
        {
            Guard.Begin().IsNotNull(path, nameof(path)).Check();
            this.Path = path;
        }
        public string Path { get; private set; }
    }
}
