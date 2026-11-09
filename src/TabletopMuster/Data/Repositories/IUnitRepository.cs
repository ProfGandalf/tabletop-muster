using TabletopMuster.Models;

namespace TabletopMuster.Data {
    public interface IUnitRepository {
        Task<IEnumerable<Unit>> GetAllUnitsAsync();
        Task<Unit?> GetUnitByIdAsync(int id);
        Task AddUnitAsync(Unit unit);
        Task SaveChangesAsync();
    }
}