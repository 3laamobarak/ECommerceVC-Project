
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDTOs;

namespace ECommerceApplication.Validators
{
    public static class GenericValidator
    {
        public static ValidationResultDTO Validate<T>(T dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();
            var validationResultDto = new ValidationResultDTO();

            bool isValid = Validator.TryValidateObject(dto, context, results, true);

            if (!isValid)
            {
                validationResultDto.Success = false;

                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        if (!validationResultDto.Errors.ContainsKey(memberName))
                            validationResultDto.Errors[memberName] = new List<string>();

                        validationResultDto.Errors[memberName].Add(validationResult.ErrorMessage);
                    }
                }
            }

            return validationResultDto;
        }
    }
}