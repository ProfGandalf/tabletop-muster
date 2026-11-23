using Microsoft.EntityFrameworkCore;
using TabletopMuster.Models;

namespace TabletopMuster.Data.Repositories {
    public class UnitRepository : IUnitRepository {
        private readonly TabletopContext _context;

        public UnitRepository(TabletopContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> GetAllUnitsAsync() {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit?> GetUnitByIdAsync(int id) {
            return await _context.Units.FindAsync(id);
        }

        public async Task AddUnitAsync (Unit unit) {
            await _context.Units.AddAsync(unit);
        }
        public async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }
    }
}