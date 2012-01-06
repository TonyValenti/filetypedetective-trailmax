namespace FileTypeDetective
{


    /// <summary>
    /// Little data structure to hold information about file types. 
    /// Holds information about binary header at the start of the file
    /// </summary>
    public class FileType
    {
        public byte?[] header { get; private set; }    // most of the times we only need first 8 bytes, but sometimes extend for 16
        public int headerOffset { get; private set; }
        public string extension { get; private set; }
        public string mime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> class.
        /// Default construction with the header offset being set to zero by default
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, string extension, string mime)
        {
            this.header = header;
            this.extension = extension;
            this.mime = mime;
            this.headerOffset = 0;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> struct.
        /// Takes the details of offset for the header
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="offset">The header offset - how far into the file we need to read the header</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, int offset, string extension, string mime)
        {
            this.header = null;
            this.header = header;
            this.headerOffset = offset;
            this.extension = extension;
            this.mime = mime;
        }


        public override bool Equals(object other)
        {
            if (!base.Equals(other)) return false;

            if (!(other is FileType)) return false;

            FileType otherType = (FileType)other;

            if (this.header != otherType.header) return false;
            if (this.headerOffset != otherType.headerOffset) return false;
            if (this.extension != otherType.extension) return false;
            if (this.mime != otherType.mime) return false;


            return true;
        }

        public override string ToString()
        {
            return extension;
        }
    }
}
