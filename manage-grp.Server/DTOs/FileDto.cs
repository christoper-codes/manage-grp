namespace manage_grp.Server.DTOs
{
    public class FileDto
    {
        public string OriginalFileName { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public long FileSize { get; set; }

        public string ContentType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
