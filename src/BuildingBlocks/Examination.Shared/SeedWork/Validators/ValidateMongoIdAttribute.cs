using Examination.Shared.SeedWork.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.SeedWork.Validators
{
    public class ValidateMongoIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (ObjectId.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success;
            }
            if (value.IsList())
            {
                var listValues = value as List<string>;
                if (listValues.Any(x => (ObjectId.TryParse(x, out _) == false)))
                {
                    return new ValidationResult($"{validationContext.MemberName} không đúng định dạng.");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult($"{validationContext.MemberName} không đúng định dạng.");
        }
    }
}
