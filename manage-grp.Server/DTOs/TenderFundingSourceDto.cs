namespace manage_grp.Server.DTOs
{
    public class TenderFundingSourceDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}