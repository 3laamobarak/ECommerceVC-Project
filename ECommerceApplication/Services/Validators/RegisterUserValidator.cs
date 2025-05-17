
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDTOs;

namespace ECommerceApplication.Validators
{
    public static class RegisterUserValidator
    {
        public static RegistrationResultDTO Validate(RegisterUserDto dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();
            var registrationResult = new RegistrationResultDTO();

            bool isValid = Validator.TryValidateObject(dto, context, results, true);

            if (!isValid)
            {
                registrationResult.Success = false;

                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        if (!registrationResult.Errors.ContainsKey(memberName))
                            registrationResult.Errors[memberName] = new List<string>();

                        registrationResult.Errors[memberName].Add(validationResult.ErrorMessage);
                    }
                }
            }

            return registrationResult;
        }
    }

}


