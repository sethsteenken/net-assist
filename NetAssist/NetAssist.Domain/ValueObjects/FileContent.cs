using NetAssist.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetAssist.Domain
{
    public class FileContent : ValueObject<FileContent>
    {
        protected FileContent() { }

        public FileContent(string fileName) : this(fileName, 0)
        {

        }

        public FileContent(string fileName, int contentLength) : this(fileName, contentLength, ContentTypeHelper.GetMIMEType(fileName))
        {
        }

        public FileContent(string fileName, int contentLength, string contentType)
        {
            Guard.Begin().IsNotNull(fileName, nameof(fileName)).IsNotNull(contentType, nameof(contentType))
                .IsPositive(contentLength, nameof(contentLength)).Check();


            Extension = Path.GetExtension(fileName).Replace(".", "").ToLower();
            FileName = fileName;
            ContentType = contentType.Trim().ToLower();
            ContentLength = contentLength;
        }

        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public int ContentLength { get; private set; }
        public string Extension { get; private set; }

        public bool IsImage => ImageExtensions.Any(e => string.Compare(e, Extension, StringComparison.InvariantCultureIgnoreCase) == 0);
        public static IReadOnlyList<string> ImageExtensions = new List<string>() { "jpg", "jpeg", "png", "gif" };
    }
}
