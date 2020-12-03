using FluentValidation;
using PaninApi.Abstractions.Dtos;

namespace PaninApi.WebApi.Validators
{
    public class InputStudentClassDtoValidator : AbstractValidator<InputStudentClassDto>
    {
        public InputStudentClassDtoValidator()
        {
            RuleFor(_ => _.Class).InclusiveBetween(1, 5);
            RuleFor(_ => _.Section).MinimumLength(1).MaximumLength(5);
        }
    }
}