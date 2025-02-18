namespace manage_grp.Server.DTOs
{
    public class AreaServiceTypeDto
    {
        public int? Id { get; set; }

        public int? AreaId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }
    }
}