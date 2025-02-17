namespace manage_grp.Server.DTOs
{
    public class BudgetKeyDefaultDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public string Key { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public bool Mandatory { get; set; }
    }
}
