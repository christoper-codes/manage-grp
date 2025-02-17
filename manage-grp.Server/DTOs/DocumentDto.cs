namespace manage_grp.Server.DTOs
{
    public class DocumentDto
    {
        public int? Id { get; set; }

        public int DocumentRequirementId { get; set; }

        public string Name { get; set; }

        public string MimeType { get; set; }

        public long Size { get; set; }

        public byte[]? Content { get; set; }

        public string? Description { get; set; }

        public string Path { get; set; }

        public bool? IsActive { get; set; }
    }
}