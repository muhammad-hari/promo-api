using Web.Promo.Domain.Helpers;
using Web.Promo.Domain.Model;

namespace Web.Promo.Application.Queries
{
    public interface IPromoQuery
    {
        RestHelper<List<PromosModel?>> GetByRange(DateTime? startDate, DateTime? endDate, string orderBy = "desc");
        RestHelper<PromosModel?> GetByCode(string code);
        RestHelper<PromosModel?> GetByID(int? id);
    }
}
