using System.IO;

namespace NetAssist.Domain
{
    public class FileData : ValueObject<FileData>
    {
        protected FileData() { }

        public FileData(MemoryStream ms, string fileName, string contentType) : this (ms?.ToArray(), fileName, contentType)
        {

        }

        public FileData(byte[] data, string fileName, string contentType)
        {
            Data = data;
            FileName = fileName.SetEmptyToNull();
            ContentType = contentType.SetEmptyToNull();
        }

        public byte[] Data { get; private set; }
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
    }
}
