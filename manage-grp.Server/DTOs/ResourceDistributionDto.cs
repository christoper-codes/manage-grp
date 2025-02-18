using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.DTOs
{
    public class ResourceDistributionDto
    {
        public int? Id { get; set; }

        public int? AreaId { get; set; }

        public int? BudgetaryKeyId { get; set; }

        public int? ResourceTypeId { get; set; }

        public string RequestNumber { get; set; }

        public string ResourceNumber { get; set; }

        public string Concept { get; set; }

        public decimal Amount { get; set; }

        public DateTime RequestDate { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Observations { get; set; }

        public bool? IsActive { get; set; }

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<ResourceDistributionDocumentTypeResourceDistributionDto>? DocumentTypesDto { get; set; }

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<FileGroupDto> FileGroupsDto { get; set; } = new List<FileGroupDto>();

        public List<IFormFile> FilesDto { get; set; } = new List<IFormFile>();
    }
}