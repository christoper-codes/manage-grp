namespace manage_grp.Server.DTOs
{
    public class ResourceDistributionTenderDto
    {
        public int? Id { get; set; }

        public int TenderId { get; set; }

        public int ResourceDistributionId { get; set; }

        public bool IsActive { get; set; }
    }
}
