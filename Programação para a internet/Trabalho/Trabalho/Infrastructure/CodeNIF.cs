using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Infrastructure
{
    public class CodeNIF : ValidationAttribute
    {

            protected override ValidationResult IsValid(object nif, ValidationContext validationContext)
            {

            int max = 9;
            int n = 11;
                if (nif != null)
                {

                    string NIF = nif.ToString();
                    NIF = NIF.Trim();
                    NIF = NIF.Replace(" ", string.Empty);
                    if (NIF.Length >= max)
                    {
                        int checkSum = 0;
                        int m = 2;
                        for (int i = 0; i < max-1; i++)
                        {
                            checkSum += m * (int)NIF[i];
                            m++;
                        }

                        checkSum = checkSum % n;

                        if (checkSum.ToString() == NIF[max-1].ToString())
                        {
                            return ValidationResult.Success;
                        }
                    }
                }




                return new ValidationResult(ErrorMessage ?? "O NIF apresentado está incorreto. Tente Novamente!");
            }

        
    }
}
