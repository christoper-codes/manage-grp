using Microsoft.EntityFrameworkCore;
using manage_grp.Server.Models;
using manage_grp.Server.Data.Contexts;

public static class DbSeeders
{
    public static void Seed(AppDbContext context)
    {
        // Seed states
        if (!context.States.Any()) 
        {
            var states = new List<State>();

            var now = DateTime.UtcNow;

            for (int i = 1; i <= 20; i++)
            {
                states.Add(new State
                {
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
                for (int i = 1; i <= 5; i++)
                {
                    municipalities.Add(new Municipality
                    {
                        StateId = (int)state.Id!,
                        MunicipalityKey = municipalityKey++,
                        Name = $"Municipio {i} de {state.Name}",
                        Abbreviation = $"MUN{i}{state.Id}",
                        Latitude = 19.4326,
                        Longitude = -99.1332,
                    });
                }
            }

            context.Municipalities.AddRange(municipalities);
            context.SaveChanges();
        }

        //Seed dependencies
        if (!context.Dependencies.Any())
        {
            var now = DateTime.UtcNow;
            var municipalities = context.Municipalities.ToList();

            if (!municipalities.Any()) return;

            var dependencies = new List<Dependency>();

            foreach (var municipality in municipalities)
            {
                for (int i = 1; i <= 5; i++)
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

        if (!context.DocumentTypes.Any())
        {
            var now = DateTime.UtcNow;
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var documentTypes = new List<DocumentType>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 2; i++)
                {
                    documentTypes.Add(new DocumentType
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

            context.DocumentTypes.AddRange(documentTypes);
            context.SaveChanges();
        }

        if (!context.Positions.Any())
        {
            var now = DateTime.UtcNow;
            var dependencies = context.Dependencies.ToList();

            if (!dependencies.Any()) return;

            var positions = new List<Position>();

            foreach (var dependency in dependencies)
            {
                for (int i = 1; i <= 10; i++)
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

    }
}
