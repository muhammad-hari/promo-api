using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.Promo.Data.Context;
using Web.Promo.Data.Entities;

namespace Web.Promo.Data.Repository
{
    public class PromoRepository : IPromoRepository
    {
        #region Private Members

        /// <summary>
        /// A single instance from <see cref="PromoDbContext"/>
        /// </summary>
        private readonly PromoDbContext DbContext;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public PromoRepository(PromoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Promos?> CreateAsync(Promos promo)
        {
            try
            {
                DbContext.Promos.Add(promo!);
                await DbContext.SaveChangesAsync();
                return promo;
            }
            catch (SqlException ex)
            {
                // Pass log here
                Debug.WriteLine(ex.Message);
                return default;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var promo = await DbContext.Promos.Where(v => v.Id == id && !v.IsDeleted).FirstOrDefaultAsync();
                if (promo == null)
                    return false;

                DbContext.Promos.Remove(promo);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                // Pass log here
                Debug.WriteLine(ex.Message);
                return default;
            }
        }

        public Promos? Get(int id)
        => DbContext.Promos.Where(v => v.Id == id && !v.IsDeleted).AsNoTracking().FirstOrDefault();

        public Promos? GetByCode(string code)
        => DbContext.Promos.Where(v => v.Code.ToLower() == code.ToLower() && !v.IsDeleted).FirstOrDefault();

        public IQueryable<Promos?> GetByRange(DateTime? startDate = null, DateTime? endDate = null, string orderBy = "desc")
        {
            IQueryable<Promos?> promo = DbContext.Promos;

            if (startDate == null && endDate == null)
            {
                if (orderBy.ToLower() == "desc")
                    promo = DbContext.Promos.Where(v => !v.IsDeleted).AsNoTracking().OrderByDescending(x => x.CreatedDate);
                else
                    promo = DbContext.Promos.Where(v => !v.IsDeleted).AsNoTracking().OrderBy(x => x.CreatedDate);

                return promo;
            }
            else
            {
                if (orderBy.ToLower() == "desc")
                    promo = DbContext.Promos.Where(v => v.CreatedDate >= startDate && v.CreatedDate <= endDate && !v.IsDeleted).AsNoTracking().OrderByDescending(x => x.CreatedDate);
                else
                    promo = DbContext.Promos.Where(v => v.CreatedDate >= startDate && v.CreatedDate <= endDate && !v.IsDeleted).AsNoTracking().OrderBy(x => x.CreatedDate);
                return promo;
            }
        }

        public async Task<Promos?> UpdateAsync(Promos promo)
        {
            try
            {
                DbContext.Promos.Update(promo!);
                await DbContext.SaveChangesAsync();
                return promo;
            }
            catch (SqlException ex)
            {
                // Pass log here
                Debug.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
