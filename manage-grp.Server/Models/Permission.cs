namespace manage_grp.Server.Models
{
    public class Permission
    {       
        public int? Id { get; set; }

        public string Entity { get; set; }

        public string Action { get; set; }

        public string[] AllowedHierarchyLevels { get; set; }
    }
}
