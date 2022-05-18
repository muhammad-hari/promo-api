using System;
using System.Collections.Generic;
using Web.Promo.Data.Entities;

namespace Web.Promo.Domain.Model
{
    public class PromosModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PromoType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; } = null!;
        public int Value { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public PromosModel(Promos promo)
        {
            this.Id = promo.Id;
            this.Code = promo.Code;
            this.Name = promo.Name;
            this.Description = promo.Description;
            this.PromoType = promo.PromoType;
            this.StartDate = promo.StartDate;
            this.EndDate = promo.EndDate;
            this.Type = promo.Type;
            this.Value = promo.Value;
            this.CreatedDate = promo.CreatedDate;
            this.CreatedBy = promo.CreatedBy;
            this.UpdatedDate = promo.UpdatedDate;
            this.UpdatedBy = promo.UpdatedBy;
            this.IsDeleted = promo.IsDeleted;
        }
    }
}
