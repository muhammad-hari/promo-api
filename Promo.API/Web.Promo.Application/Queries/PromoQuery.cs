using Web.Promo.Data.Repository;
using Web.Promo.Domain.Helpers;
using Web.Promo.Domain.Model;

namespace Web.Promo.Application.Queries
{
    public class PromoQuery : IPromoQuery
    {
        #region Private Members

        private readonly IPromoRepository promos;

        #endregion

        public PromoQuery(IPromoRepository promos)
        {
            this.promos = promos;
        }

        public RestHelper<List<PromosModel?>> GetByRange(DateTime? startDate, DateTime? endDate, string orderBy = "desc")
        {
            var result = new RestHelper<List<PromosModel?>>
            {
                Success = true,
                ErrorCode = String.Empty,
                Message = $"Data not found!, the query operation was successful",
            };

            var promo = promos.GetByRange(startDate, endDate, orderBy);

            if (promo != null)
            {
                result.Data = new List<PromosModel?>();

                foreach (var item in promo)
                {
                    result.Data.Add(new PromosModel(item!));
                }

                result.Success = true;
                result.ErrorCode = String.Empty;
                result.Message = $"Data found {promo.Count()}!, the query operation was successful";
            }

            return result;
        }

        public RestHelper<PromosModel?> GetByCode(string code)
        {
            var result = new RestHelper<PromosModel?>
            {
                Success = true,
                ErrorCode = String.Empty,
                Message = $"Data not found!, the query operation was successful",
            };

            if (string.IsNullOrEmpty(code))
            {
                result.ErrorCode = "01";
                result.Message = "Please try again, parameter slug is required";
                result.Success = false;

                return result;
            }

            var promo = promos.GetByCode(code);

            if (promo != null)
            {
                result.Data = new PromosModel(promo!);
                result.Success = true;
                result.ErrorCode = String.Empty;
                result.Message = $"Data found!, the query operation was successful";
            }

            return result;
        }

        public RestHelper<PromosModel?> GetByID(int? id)
        {
            var result = new RestHelper<PromosModel?>
            {
                Success = true,
                ErrorCode = String.Empty,
                Message = $"Data not found!, the query operation was successful",
            };

            if (!id.HasValue)
            {
                result.ErrorCode = "01";
                result.Message = "Please try again, parameter id is required";
                result.Success = false;

                return result;
            }

            var catalogue = promos.Get(id.Value);

            if (catalogue != null)
            {
                result.Data = new PromosModel(catalogue!);
                result.Success = true;
                result.ErrorCode = String.Empty;
                result.Message = $"Data found!, the query operation was successful";
            }

            return result;
        }
    }
}
