using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidatorException(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
