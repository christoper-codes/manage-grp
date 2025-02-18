using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Helpers;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using manage_grp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class ResourceDistributionDocumentType
    {
        public int? Id { get; set; }

        public int DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Mandatory { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<ResourceDistributionDocumentTypeResourceDistribution>? ResourceDistributionDocumentTypeResourceDistributions { get; set; } = new List<ResourceDistributionDocumentTypeResourceDistribution>();
    }
}