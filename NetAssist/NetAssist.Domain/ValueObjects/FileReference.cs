namespace NetAssist.Domain
{
    public class FileReference : ValueObject<FileReference>
    {
        protected FileReference() { }

        public FileReference(string directory, string filename, string fullPath) : this(directory, fullPath, new FileContent(filename))
        {

        }

        public FileReference(string directory, string fullPath, FileContent fileContent)
        {
            Directory = directory;
            FullPath = fullPath;
            File = fileContent;
        }

        public string Directory { get; private set; }
        public string FullPath { get; private set; }
        public FileContent File { get; private set; }

        public override string ToString()
        {
            return FullPath;
        }
    }
}
