using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.DTOs
{
    public class TenderDto
    {
        public int? Id { get; set; }

        public int? AreaServiceTypeId { get; set; }

        public int? TenderTypeId { get; set; }

        public int? TenderStatusId { get; set; }

        public int? TenderPriceTypeId { get; set; }

        public int? TenderFundingSourceId { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Observation { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsActive { get; set; }

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<ResourceDistributionTenderDto>? ResourceDistributionTendersDtos { get; set; } = new List<ResourceDistributionTenderDto>();

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<TenderDocumentTypeTenderDto>? DocumentTypesDto { get; set; } = new List<TenderDocumentTypeTenderDto>();

        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<FileGroupDto> FileGroupsDto { get; set; } = new List<FileGroupDto>();

        public List<IFormFile> FilesDto { get; set; } = new List<IFormFile>();
    }
}