namespace WizMail.Services.Implementations
{
    using WizMail.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class DataAccessService
    {
        protected readonly WizMailDbContext db;

        public DataAccessService(WizMailDbContext db)
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
