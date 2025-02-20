using FluentValidation;
using Humanizer;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Domain.Interfaces.External;
using manage_grp.Server.Domain.Repositories;
using manage_grp.Server.Domain.Repositories.External;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories;
using manage_grp.Server.Repositories.Interfaces;
using manage_grp.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Configurations of the application
builder.Services.AddControllers();

// Configurations of Endpoints and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurations of the Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Connection"))
);

// Configurations of Identity and Authorization
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Confdigurations of JWT
bool.TryParse(configuration["JWT:ValidateAudience"], out bool validateAudience);
bool.TryParse(configuration["JWT:ValidateIssuer"], out bool validateIssuer);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = configuration["JWT:Audience"],
            ValidateAudience = validateAudience,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateIssuer = validateIssuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:IssuerSigningKey"])
            )
        };
    });

// Registering External Services
builder.Services.Configure<DipomexDto>(builder.Configuration.GetSection("Dipomex"));

// Registering Services and Repositories

builder.Services.AddScoped<IDipomexRepository, DipomexRepository>();
builder.Services.AddScoped<DipomexService>();

builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<StateService>();

builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddScoped<MunicipalityService>();

builder.Services.AddScoped<IDependencyRepository, DependencyRepository>();
builder.Services.AddScoped<DependencyService>();
builder.Services.AddValidatorsFromAssemblyContaining<DependencyDtoValidator>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserLoginDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RefreshTokenDtoValidator>();

builder.Services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();
builder.Services.AddScoped<JwtTokenService>();

builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<PositionService>();
builder.Services.AddValidatorsFromAssemblyContaining<PositionDtoValidator>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddValidatorsFromAssemblyContaining<ContactDtoValidator>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddValidatorsFromAssemblyContaining<AddressDtoValidator>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddValidatorsFromAssemblyContaining<AddressDtoValidator>();

builder.Services.AddScoped<IBudgetaryKeyDocumentTypeRepository, BudgetaryKeyDocumentTypeRepository>();
builder.Services.AddScoped<BudgetaryKeyDocumentTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<BudgetaryKeyDocumentTypeDtoValidator>();

builder.Services.AddScoped<IBudgetaryKeyRepository, BudgetaryKeyRepository>();
builder.Services.AddScoped<BudgetaryKeyService>();
builder.Services.AddValidatorsFromAssemblyContaining<BudgetaryKeyDtoValidator>();

builder.Services.AddScoped<IBudgetaryKeyDocumentTypeBudgetaryKeyRepository, BudgetaryKeyDocumentTypeBudgetaryKeyRepository>();
builder.Services.AddScoped<BudgetaryKeyDocumentTypeBudgetaryKeyService>();

builder.Services.AddScoped<IResourceDistributionDocumentTypeRepository, ResourceDistributionDocumentTypeRepository>();
builder.Services.AddScoped<ResourceDistributionDocumentTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<ResourceDistributionDocumentTypeDtoValidator>();

builder.Services.AddScoped<IDocumentRequirementRepository, DocumentRequirementRepository>();
builder.Services.AddScoped<DocumentRequirementService>();
builder.Services.AddValidatorsFromAssemblyContaining<DocumentTypeRequirementDtoValidator>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddValidatorsFromAssemblyContaining<DocumentDtoValidator>();

builder.Services.AddScoped<IBudgetKeyDefaultRepository, BudgetKeyDefaultRepository>();
builder.Services.AddScoped<BudgetKeyDefaultService>();
builder.Services.AddValidatorsFromAssemblyContaining<BudgetKeyDefaultDtoValidator>();

builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<AreaService>();
builder.Services.AddValidatorsFromAssemblyContaining<AreaDtoValidator>();

builder.Services.AddScoped<IAreaServiceTypeRepository, AreaServiceTypeRepository>();
builder.Services.AddScoped<AreaServiceTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<AreaServiceTypeDtoValidator>();

builder.Services.AddScoped<IResourceDistributionRepository, ResourceDistributionRepository>();
builder.Services.AddScoped<ResourceDistributionService>();
builder.Services.AddValidatorsFromAssemblyContaining<ResourceDistributionDtoValidator>();

builder.Services.AddScoped<IResourceDistributionDocumentTypeResourceDistributionRepository, ResourceDistributionDocumentTypeResourceDistributionRepository>();
builder.Services.AddScoped<ResourceDistributionDocumentTypeResourceDistributionService>();

builder.Services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
builder.Services.AddScoped<ResourceTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<ResourceTypeDtoValidator>();

builder.Services.AddScoped<ITenderTypeRepository, TenderTypeRepository>();
builder.Services.AddScoped<TenderTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderTypeDtoValidator>();

builder.Services.AddScoped<ITenderFundingSourceRepository, TenderFundingSourceRepository>();
builder.Services.AddScoped<TenderFundingSourceService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderFundingSourceDtoValidator>();

builder.Services.AddScoped<ITenderStatusRepository, TenderStatusRepository>();
builder.Services.AddScoped<TenderStatusService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderStatusDtoValidator>();

builder.Services.AddScoped<ITenderPriceTypeRepository, TenderPriceTypeRepository>();
builder.Services.AddScoped<TenderPriceTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderPriceTypeDtoValidator>();

builder.Services.AddScoped<ITenderDocumentTypeRepository, TenderDocumentTypeRepository>();
builder.Services.AddScoped<TenderDocumentTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderDocumentTypeDtoValidator>();

builder.Services.AddScoped<ITenderRepository, TenderRepository>();
builder.Services.AddScoped<TenderService>();
builder.Services.AddValidatorsFromAssemblyContaining<TenderDtoValidator>();

builder.Services.AddScoped<ITenderDocumentTypeTenderRepository, TenderDocumentTypeTenderRepository>();
builder.Services.AddScoped<TenderDocumentTypeTenderService>();

builder.Services.AddScoped<IResourceDistributionTenderRepository, ResourceDistributionTenderRepository>();
builder.Services.AddScoped<ResourceDistributionTenderService>();

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<FileService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

//Ejecution of Seeders
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbSeeders.Seed(dbContext);
}


app.UseDefaultFiles();
app.UseStaticFiles();

// Configurations of Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapIdentityApi<User>();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();