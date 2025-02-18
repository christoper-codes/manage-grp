using manage_grp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace manage_grp.Server.DTOs
{
    public class BudgetaryKeyDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public string Key { get; set; }

        public decimal Amount { get; set; }

        public string Concept { get; set; }

        public int ContactId { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<BudgetaryKeyDocumentTypeBudgetaryKeyDto>? DocumentTypesDto { get; set; }

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<FileGroupDto> FileGroupsDto { get; set; } = new List<FileGroupDto>();

        public List<IFormFile> FilesDto { get; set; } = new List<IFormFile>();
    }
}