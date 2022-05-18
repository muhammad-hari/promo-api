using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Promo.Data.Entities;
using Web.Promo.Data.Repository;
using Web.Promo.Domain.Helpers;
using Web.Promo.Domain.Model;

namespace Web.Promo.Application.Commands
{
    public class PromoCommand : IPromoCommand
    {
        #region Private Members

        private readonly IPromoRepository promos;

        #endregion

        public PromoCommand(IPromoRepository promos)
          =>  this.promos = promos;

        public async Task<RestHelper<PromosModel>> CreateAsync(PromosModel promo)
        {
            // Add validation here
            var result = promo.PromoValidation();
            if (result.Success)
            {
                if (promos.GetByCode(promo.Code) != null)
                {
                    result.ErrorCode = "10";
                    result.Message = "Please try again, Promo exist!";
                    return result;
                }
                else
                {
                    await promos.CreateAsync(new Promos() 
                    { 
                        Code = promo.Code,
                        Name = promo.Name,
                        Description = promo.Description,
                        PromoType = promo.PromoType,
                        StartDate = promo.StartDate,
                        EndDate = promo.EndDate,
                        Type = promo.Type,  
                        Value = promo.Value,
                        CreatedBy = promo.CreatedBy ?? "system",
                        CreatedDate = promo.CreatedDate ?? DateTime.Now,    
                        UpdatedBy = promo.UpdatedBy ?? "system",
                        UpdatedDate = promo.UpdatedDate ?? DateTime.Now,
                    });

                    result.Success = true;
                    result.ErrorCode = String.Empty;
                    result.Message = $"Promo created!, the query operation was successful";
                    result.Data = promo;
                }
            }

            return result;
        }

        public async Task<RestHelper<bool>> DeleteAsync(int promoId, string deleteBy)
        {
            var result = new RestHelper<bool>()
            {
                Success = true,
                ErrorCode = String.Empty,
            };

            var currentData = promos.Get(promoId);
            if (currentData != null)
            {
                currentData.IsDeleted = true;
                currentData.UpdatedDate = DateTime.Now;
                currentData.UpdatedBy = deleteBy;
                await promos.UpdateAsync(currentData);

                result.Success = true;
                result.ErrorCode = String.Empty;
                result.Message = $"Promo deleted!, the query operation was successful";
                result.Data = true;
            }
            else
            {
                result.Success = false;
                result.ErrorCode = String.Empty;
                result.Message = $"Cannot find any data with id: {promoId}, the query operation was successful";
            }

            return result;
        }

        public async Task<RestHelper<PromosModel>> UpdateAsync(PromosModel promo)
        {
            // Add validation here
            var result = promo.PromoValidation();
            if (result.Success)
            {
                if (promos.GetByCode(promo.Code) != null)
                {
                    result.ErrorCode = "10";
                    result.Message = "Please try again, Promo exist!";
                    return result;
                }
                else
                {
                    await promos.UpdateAsync(new Promos()
                    {
                        Id = promo.Id,
                        Code = promo.Code,
                        Name = promo.Name,
                        Description = promo.Description,
                        PromoType = promo.PromoType,
                        StartDate = promo.StartDate,
                        EndDate = promo.EndDate,
                        Type = promo.Type,
                        Value = promo.Value,
                        CreatedBy = promo.CreatedBy ?? "system",
                        CreatedDate = promo.CreatedDate ?? DateTime.Now,
                        UpdatedBy = promo.UpdatedBy ?? "system",
                        UpdatedDate = promo.UpdatedDate ?? DateTime.Now,
                    });

                    result.Success = true;
                    result.ErrorCode = String.Empty;
                    result.Message = $"Promo updated!, the query operation was successful";
                    result.Data = promo;
                }
            }

            return result;
        }
    }
}
