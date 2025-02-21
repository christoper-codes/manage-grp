using manage_grp.Server.Models;

using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Data.DbSeeders
{
    public static class SeedPermissions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Entity = "Municipality", Action = "Read", AllowedHierarchyLevels = new[] { "State" } },
                new Permission { Id = 2, Entity = "Municipality", Action = "Create", AllowedHierarchyLevels = new[] { "State" } },
                new Permission { Id = 3, Entity = "Municipality", Action = "Update", AllowedHierarchyLevels = new[] { "State" } },
                new Permission { Id = 4, Entity = "Municipality", Action = "Delete", AllowedHierarchyLevels = new[] { "State" } },

                new Permission { Id = 5, Entity = "Dependency", Action = "Read", AllowedHierarchyLevels = new[] { "Municipality" } },
                new Permission { Id = 6, Entity = "Dependency", Action = "Create", AllowedHierarchyLevels = new[] { "Municipality" } },
                new Permission { Id = 7, Entity = "Dependency", Action = "Update", AllowedHierarchyLevels = new[] { "Municipality" } },
                new Permission { Id = 8, Entity = "Dependency", Action = "Delete", AllowedHierarchyLevels = new[] { "Municipality" } },

                new Permission { Id = 9, Entity = "Area", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 10, Entity = "Area", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 11, Entity = "Area", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 12, Entity = "Area", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 13, Entity = "AreaServiceType", Action = "Read", AllowedHierarchyLevels = new[] { "Area" } },
                new Permission { Id = 14, Entity = "AreaServiceType", Action = "Create", AllowedHierarchyLevels = new[] { "Area" } },
                new Permission { Id = 15, Entity = "AreaServiceType", Action = "Update", AllowedHierarchyLevels = new[] { "Area" } },
                new Permission { Id = 16, Entity = "AreaServiceType", Action = "Delete", AllowedHierarchyLevels = new[] { "Area" } },

                new Permission { Id = 17, Entity = "User", Action = "Read", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 18, Entity = "User", Action = "Create", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 19, Entity = "User", Action = "Update", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 20, Entity = "User", Action = "Delete", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },

                new Permission { Id = 21, Entity = "Role", Action = "Read", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 22, Entity = "Role", Action = "Create", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 23, Entity = "Role", Action = "Update", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 24, Entity = "Role", Action = "Delete", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },

                new Permission { Id = 25, Entity = "Position", Action = "Read", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 26, Entity = "Position", Action = "Create", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 27, Entity = "Position", Action = "Update", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 28, Entity = "Position", Action = "Delete", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },

                new Permission { Id = 29, Entity = "Contact", Action = "Read", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 30, Entity = "Contact", Action = "Create", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 31, Entity = "Contact", Action = "Update", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 32, Entity = "Contact", Action = "Delete", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },

                new Permission { Id = 33, Entity = "Address", Action = "Read", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 34, Entity = "Address", Action = "Create", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 35, Entity = "Address", Action = "Update", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },
                new Permission { Id = 36, Entity = "Address", Action = "Delete", AllowedHierarchyLevels = new[] { "State", "Municipality", "Dependency", "Area" } },

                new Permission { Id = 37, Entity = "BudgetaryKeyDocumentType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 38, Entity = "BudgetaryKeyDocumentType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 39, Entity = "BudgetaryKeyDocumentType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 40, Entity = "BudgetaryKeyDocumentType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 41, Entity = "BudgetKeyDefault", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 42, Entity = "BudgetKeyDefault", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 43, Entity = "BudgetKeyDefault", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 44, Entity = "BudgetKeyDefault", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 45, Entity = "BudgetaryKey", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 46, Entity = "BudgetaryKey", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 47, Entity = "BudgetaryKey", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 48, Entity = "BudgetaryKey", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 49, Entity = "ResourceDistributionDocumentType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 50, Entity = "ResourceDistributionDocumentType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 51, Entity = "ResourceDistributionDocumentType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 52, Entity = "ResourceDistributionDocumentType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 53, Entity = "ResourceType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 54, Entity = "ResourceType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 55, Entity = "ResourceType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 56, Entity = "ResourceType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 57, Entity = "ResourceDistribution", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 58, Entity = "ResourceDistribution", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 59, Entity = "ResourceDistribution", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 60, Entity = "ResourceDistribution", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 61, Entity = "TenderType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 62, Entity = "TenderType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 63, Entity = "TenderType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 64, Entity = "TenderType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 65, Entity = "TenderFundingSource", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 66, Entity = "TenderFundingSource", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 67, Entity = "TenderFundingSource", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 68, Entity = "TenderFundingSource", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 69, Entity = "TenderStatus", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 70, Entity = "TenderStatus", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 71, Entity = "TenderStatus", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 72, Entity = "TenderStatus", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 73, Entity = "TenderPriceType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 74, Entity = "TenderPriceType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 75, Entity = "TenderPriceType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 76, Entity = "TenderPriceType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 77, Entity = "TenderDocumentType", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 78, Entity = "TenderDocumentType", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 79, Entity = "TenderDocumentType", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 80, Entity = "TenderDocumentType", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } },

                new Permission { Id = 81, Entity = "Tender", Action = "Read", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 82, Entity = "Tender", Action = "Create", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 83, Entity = "Tender", Action = "Update", AllowedHierarchyLevels = new[] { "Dependency" } },
                new Permission { Id = 84, Entity = "Tender", Action = "Delete", AllowedHierarchyLevels = new[] { "Dependency" } }

            );
        }
    }
}