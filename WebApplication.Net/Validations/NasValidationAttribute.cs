using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;

namespace WebApplication.Net.Validations
{
	public class NasValidationAttribute : ValidationAttribute, IClientModelValidator
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null) 
			{
				return ValidationResult.Success;
			}
	
			string nas = value.ToString();
	
			if (nas.Length != 9)
			{
				return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
			}
			
			int s = 0;
			for (int i=0; i < 9; i++)
			{
				int x = nas[i] - '0';
				s += (i % 2) != 0 ? (x << 1 > 9 ? (x << 1) - 9 : x << 1) : x;
			}
			
			return (s % 10) == 0 ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
		}		
		
		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
		{
			yield return new ModelClientValidationRule("nasvalidation", FormatErrorMessage(context.ModelMetadata.PropertyName));
		}

	}
}