using Microsoft.EntityFrameworkCore;
using manage_grp.Server.Models;
using manage_grp.Server.Data.Contexts;
using System.Text.Json;

public static class DbSeeders
{
    public static void Seed(AppDbContext context)
    {
        // Seed states
        if (!context.States.Any()) 
        {
            var states = new List<State>();

            var now = DateTime.UtcNow;

            for (int i = 1; i <= 10; i++)
            {
                states.Add(new State
                {
                    ExternalStateId = i.ToString(),
                    Name = $"Estado {i}",
                    Abbreviation = $"E{i}",
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.States.AddRange(states);
            context.SaveChanges();
        }


        // Seed municipalities
        if (!context.Municipalities.Any())
        {
            var now = DateTime.UtcNow;
            var states = context.States.ToList();

            if (!states.Any()) return;

            var municipalities = new List<Municipality>();

            int municipalityKey = 1000;

            foreach (var state in states)
            {
                for (int i = 1; i <= 2; i++)
                {
                    municipalities.Add(new Municipality
                    {
                        StateId = (int)state.Id!,
                        ExternalMunicipalityId = (municipalityKey++).ToString(),
                        Name = $"Municipio {i} de {state.Name}",
                        Abbreviation = $"MUN{i}{state.Id}",
                    });
                }
            }

            context.Municipalities.AddRange(municipalities);
            context.SaveChanges();
        }

        // Seed dependencies
        if (!context.Dependencies.Any())
        {
            var now = DateTime.UtcNow;
            var municipalities = context.Municipalities.ToList();

            if (!municipalities.Any()) return;

            var dependencies = new List<Dependency>();

            foreach (var municipality in municipalities)
            {
                for (int i = 1; i <= 2; i++)
                {
                    dependencies.Add(new Dependency
                    {
                        MunicipalityId = (int)municipality.Id!,
                        Name = $"Dependencia {i} de {municipality.Name}",
                        Acronym = $"DEP{i}{municipality.Id}",
                        Rfc = $"RFC{i}{municipality.Id}XYZ",
                        IsActive = true,
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            context.Dependencies.AddRange(dependencies);
            context.SaveChanges();
        }

        // Seed DocumentTypes
        if (!context.BudgetaryKeyDocumentTypes.Any())
        {
            var now = DateTime.UtcNow;
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var documentTypes = new List<BudgetaryKeyDocumentType>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 2; i++)
                {
                    documentTypes.Add(new BudgetaryKeyDocumentType
                    {
                        DependencyId = (int)dependency.Id!,
                        Name = $"Tipo de Documento {i} de {dependency.Name}",
                        Description = $"Descripción del Tipo de Documento {i} de {dependency.Name}",
                        Mandatory = true,
                        IsActive = true,
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            context.BudgetaryKeyDocumentTypes.AddRange(documentTypes);
            context.SaveChanges();
        }
        
        if (!context.ResourceDistributionDocumentTypes.Any())
        {
            var now = DateTime.UtcNow;
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var documentTypes = new List<ResourceDistributionDocumentType>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 2; i++)
                {
                    documentTypes.Add(new ResourceDistributionDocumentType
                    {
                        DependencyId = (int)dependency.Id!,
                        Name = $"Tipo de Documento {i} de {dependency.Name}",
                        Description = $"Descripción del Tipo de Documento {i} de {dependency.Name}",
                        Mandatory = true,
                        IsActive = true,
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            context.ResourceDistributionDocumentTypes.AddRange(documentTypes);
            context.SaveChanges();
        }

        // Seed Positions
        if (!context.Positions.Any())
        {
            var now = DateTime.UtcNow;
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var positions = new List<Position>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 5; i++)
                {
                    positions.Add(new Position
                    {
                        DependencyId = (int)dependency.Id!,
                        Name = $"Posición {i} de {dependency.Name}",
                        Abbreviation = $"POS{i}{dependency.Id}",
                        Description = $"Descripción de la posición {i} de {dependency.Name}",
                        IsActive = true,
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            context.Positions.AddRange(positions);
            context.SaveChanges();
        }

        // Seed Contacts
        if (!context.Contacts.Any())
        {
            var now = DateTime.UtcNow;
            var positions = context.Positions.Include(p => p.Dependency).ToList();

            if (!positions.Any()) return;

            var contacts = new List<Contact>();

            foreach (var position in positions)
            {
                for (int i = 1; i <= 2; i++)
                {
                    contacts.Add(new Contact
                    {
                        DependencyId = position.DependencyId,
                        PositionId = (int)position.Id!,
                        FirstName = $"FirstName{i}",
                        MiddleName = $"MiddleName{i}",
                        PaternalLastName = $"PaternalLastName{i}",
                        MaternalLastName = $"MaternalLastName{i}",
                        Email = $"email{i}@example.com",
                        Phone = $"555-010{i}",
                        IsActive = true,
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }

        // Seed Areas
        if (!context.Areas.Any())
        {
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var now = DateTime.UtcNow;
            var areas = new List<Area>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 2; i++) // Crear 2 áreas por dependencia
                {
                    areas.Add(new Area
                    {
                        DependencyId = (int)dependency.Id!,
                        Name = $"Area Name {i} - {dependency.Name}",
                        Acronym = $"Acr{i}",
                        Description = $"Description for Area {i} in {dependency.Name}"
                    });
                }
            }

            context.Areas.AddRange(areas);
            context.SaveChanges();
        }

        // Seed BudgetaryKeys
        if (!context.BudgetaryKeys.Any())
        {
            var dependencies = context.Dependencies.ToList();
            var contacts = context.Contacts.ToList();

            if (!dependencies.Any() || !contacts.Any()) return;

            var now = DateTime.UtcNow;
            var budgetaryKeys = new List<BudgetaryKey>();

            foreach (var dependency in dependencies)
            {
                var contact = contacts.FirstOrDefault(c => c.DependencyId == dependency.Id);
                if (contact == null) continue;

                for (int i = 1; i <= 3; i++)
                {
                    var keyObject = new
                    {
                        value1 = new { key = "AQ", value = 12 },
                        value2 = new { key = "AB", value = 11 },
                        value3 = new { key = "CD", value = 412 },
                        value4 = new { key = "CS", value = 23 },
                        value5 = new { key = "GD", value = 467 }
                    };

                    budgetaryKeys.Add(new BudgetaryKey
                    {
                        DependencyId = (int)dependency.Id!,
                        Key = JsonSerializer.Serialize(keyObject),
                        Amount = 10000m + (i * 5000),
                        Concept = $"Concept {i} for {dependency.Name}",
                        ContactId = (int)contact.Id!,
                        Description = $"Description for Budgetary Key {i} in {dependency.Name}"
                    });
                }
            }

            context.BudgetaryKeys.AddRange(budgetaryKeys);
            context.SaveChanges();
        }

        // Seed ResourceTypes
        if (!context.ResourceTypes.Any())
        {
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var now = DateTime.UtcNow;
            var resourceTypes = new List<ResourceType>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 2; i++)
                {
                    resourceTypes.Add(new ResourceType
                    {
                        DependencyId = (int)dependency.Id!,
                        Name = $"Resource Type {i} - {dependency.Name}",
                        Description = $"Description for Resource Type {i} in {dependency.Name}"
                    });
                }
            }

            context.ResourceTypes.AddRange(resourceTypes);
            context.SaveChanges();
        }
    }
}