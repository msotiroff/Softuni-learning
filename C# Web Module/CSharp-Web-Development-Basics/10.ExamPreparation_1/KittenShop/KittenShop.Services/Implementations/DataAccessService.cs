namespace KittenShop.Services.Implementations
{
    using KittenShop.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class DataAccessService
    {
        protected readonly KittenShopDbContext db;

        public DataAccessService()
        {
            this.db = new KittenShopDbContext();
        }

        protected bool ValidateModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            
            return isValid;
        }
    }
}
