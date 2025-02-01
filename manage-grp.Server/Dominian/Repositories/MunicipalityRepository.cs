using manage_grp.Server.Context;
using manage_grp.Server.Dominian.Interfaces;
using manage_grp.Server.Models;

namespace manage_grp.Server.Dominian.Repositories
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly AppDbContext _context;

        public MunicipalityRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Municipality> GetAll()
        {
            return _context.Municipalities.ToList();
        }

        public Municipality GetById(int id)
        {
            return _context.Municipalities.Find(id);
        }

        public Municipality Save(Municipality municipality)
        {
            _context.Municipalities.Add(municipality);
            _context.SaveChanges();
            return municipality;
        }

        public Municipality Update(int id, Municipality municipality)
        {
            var existingmunicipality = _context.Municipalities.Find(id);
            if (existingmunicipality != null)
            {
                _context.Entry(existingmunicipality).CurrentValues.SetValues(municipality);
                _context.Entry(existingmunicipality).Property(x => x.CreatedAt).IsModified = false;
                _context.SaveChanges();
            }

            return existingmunicipality;
        }

        public Municipality Delete(int id)
        {
            var municipality = _context.Municipalities.Find(id);
            if (municipality != null)
            {
                _context.Municipalities.Remove(municipality);
                _context.SaveChanges();
            }

            return municipality;
        }
    }
}
