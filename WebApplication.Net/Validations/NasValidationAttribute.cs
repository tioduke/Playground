using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
		
		public void AddValidation(ClientModelValidationContext context)
		{
			MergeAttribute(context.Attributes, "data-val", "true");
			MergeAttribute(context.Attributes, "data-val-remote", FormatErrorMessage(context.ModelMetadata.PropertyName));
			MergeAttribute(context.Attributes, "data-val-remote-url", "nasvalidation");
		}

		private  bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
		{
			if (attributes.ContainsKey(key))
			{
				return false;
			}

			attributes.Add(key, value);
			return true;
		}
	}
}