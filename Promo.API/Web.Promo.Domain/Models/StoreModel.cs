using System;
using System.Collections.Generic;
using Web.Promo.Data.Entities;

namespace Web.Promo.Domain.Model
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public StoreModel(Store store)
        {
            this.Id = store.Id;
            this.Code = store.Code;
            this.Name = store.Name;
            this.CreatedDate = store.CreatedDate;
            this.CreatedBy = store.CreatedBy;
            this.UpdatedDate = store.UpdatedDate;
            this.UpdatedBy = store.UpdatedBy;
            this.IsDeleted = store.IsDeleted;
        }
    }
}
