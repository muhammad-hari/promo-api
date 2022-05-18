using Web.Promo.Data.Entities;
using Web.Promo.Domain.Model;

namespace Web.Promo.Domain.Helpers
{
    public static class RestValidation
    {
        public static RestHelper<PromosModel> PromoValidation(this PromosModel promo)
        {
            // add validation here

            return new RestHelper<PromosModel>()
            {
                Success = true,
            };
        }
    }
}
