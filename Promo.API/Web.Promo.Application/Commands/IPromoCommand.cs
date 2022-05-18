using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Promo.Domain.Helpers;
using Web.Promo.Domain.Model;

namespace Web.Promo.Application.Commands
{
    public interface IPromoCommand
    {
        Task<RestHelper<PromosModel>> CreateAsync(PromosModel promo);
        Task<RestHelper<bool>> DeleteAsync(int promoId, string deleteBy);
        Task<RestHelper<PromosModel>> UpdateAsync(PromosModel promo);
    }
}
