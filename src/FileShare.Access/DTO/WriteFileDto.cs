namespace FileShare.Access.DTO
{
    public class WriteFileDto : FileShareDto
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Contents { get; set; }
    }
}