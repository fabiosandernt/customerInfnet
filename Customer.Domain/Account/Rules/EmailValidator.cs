using Customer.Domain.Account.ValueObject;
using FluentValidation;
using System.Text.RegularExpressions;


namespace Customer.Domain.Account.Rules
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public EmailValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(BeAEmailValid).WithMessage("Email inválido");
        }
        private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);

    }
}
