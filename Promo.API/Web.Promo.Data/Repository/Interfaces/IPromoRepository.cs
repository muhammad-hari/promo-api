using Web.Promo.Data.Entities;

namespace Web.Promo.Data.Repository
{
    public interface IPromoRepository
    {
        IQueryable<Promos?> GetByRange(DateTime? startDate = null, DateTime? endDate = null, string orderBy = "desc");
        Promos? Get(int id);
        Promos? GetByCode(string code);
        Task<Promos?> CreateAsync(Promos promo);
        Task<Promos?> UpdateAsync(Promos promo);
        Task<bool> DeleteAsync(int id);
    }
}
