using manage_grp.Server.Models;
using manage_grp.Server.Context;
using manage_grp.Server.Dominian.Interfaces;

namespace manage_grp.Server.Dominian.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<State> GetAll()
        {
            return _context.States.ToList();
        }

        public State GetById(int id)
        {
            return _context.States.Find(id);
        }

        public State Save(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return state;
        }

        public State Update(int id, State state)
        {
            var existingState = _context.States.Find(id);
            if (existingState != null)
            {
                _context.Entry(existingState).CurrentValues.SetValues(state);
                _context.Entry(existingState).Property(x => x.CreatedAt).IsModified = false;
                _context.SaveChanges();
            }

            return existingState;
        }

        public State Delete(int id)
        {
            var state = _context.States.Find(id);
            if (state != null)
            {
                _context.States.Remove(state);
                _context.SaveChanges();
            }

            return state;
        }

    }
}
