namespace manage_grp.Server.DTOs
{
    public class FileGroupDto
    {
        public int Id { get; set; }

        public int? DocumentRequirementId { get; set; }

        public List<FileDetailDto> FileDetailsDto { get; set; } = new List<FileDetailDto>();
    }

    public class FileDetailDto
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
    }
}