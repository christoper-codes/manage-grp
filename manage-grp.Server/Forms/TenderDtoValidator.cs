using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class TenderDtoValidator : AbstractValidator<TenderDto>
{
    public TenderDtoValidator(DependencyService dependencyService, ContactService contactService, AreaServiceTypeService areaServiceTypeService,
        TenderTypeService TenderTypeService, TenderStatusService tenderStatusService, TenderPriceTypeService tenderPriceTypeService, TenderFundingSourceService tenderFundingSourceService)
    {
        RuleFor(x => x.TenderFundingSourceId)
            .ValidateTenderFundingSourceIdField(tenderFundingSourceService);

        RuleFor(x => x.AreaServiceTypeId)
            .ValidateAreaServiceTypeIdField(areaServiceTypeService);

        RuleFor(x => x.TenderTypeId)
            .ValidateTenderTypeIdField(TenderTypeService);
        
        RuleFor(x => x.TenderStatusId)
            .ValidateTenderStatusIdField(tenderStatusService);
        
        RuleFor(x => x.TenderStatusId)
            .ValidateTenderPriceTypeIdField(tenderPriceTypeService);

        RuleFor(x => x.Key)
            .ValidateStringField("Clave", 255);
        
        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 100);

        RuleFor(x => x.PublicationDate)
            .ValidateDateField("Fecha de Publicación");
    }
}   