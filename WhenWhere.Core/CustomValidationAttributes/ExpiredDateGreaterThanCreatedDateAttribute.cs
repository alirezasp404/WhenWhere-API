using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenWhere.Core.CustomValidationAttributes
{
    public class ExpiredDateGreaterThanCreatedDateAttribute : ValidationAttribute
    {
        private readonly string _createdDate;

        public ExpiredDateGreaterThanCreatedDateAttribute(string createdDate)
        {
            _createdDate = createdDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
            {
                throw new ArgumentNullException($"The ExpiredAt Property is null.");
            }
            var expiredDate = (DateTime)value;
            var createdDateProperty = validationContext.ObjectType.GetProperty(_createdDate);

            if (createdDateProperty == null)
            {
                throw new ArgumentException($"Property {_createdDate} not found.");
            }

            var createdDateValue = (DateTime)createdDateProperty.GetValue(validationContext.ObjectInstance);

            if (expiredDate <= createdDateValue)
            {
                return new ValidationResult($"The {validationContext.DisplayName} must be greater than {_createdDate}.");
            }

            return ValidationResult.Success;
        }
    }

}
