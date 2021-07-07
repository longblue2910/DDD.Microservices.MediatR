using Domain.Infrastructures.Handlers.Commands;
using FluentValidation;

namespace API.Validations
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Không được để trống tên Role.");
        }
    }
}
