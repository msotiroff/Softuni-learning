namespace Notes.Services.Implementations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityValidationService
    {
        protected bool ValidateModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            
            return isValid;
        }
    }
}
