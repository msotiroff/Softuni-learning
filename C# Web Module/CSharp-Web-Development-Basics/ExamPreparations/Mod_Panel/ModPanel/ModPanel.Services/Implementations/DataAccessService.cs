namespace ModPanel.Services.Implementations
{
    using ModPanel.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class DataAccessService
    {
        protected readonly ModPanelDbContext db;

        public DataAccessService(ModPanelDbContext db)
        {
            this.db = db;
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
