using FluentValidation;

namespace CustomerLib.Entities.Validators
{
    class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).NotNull().WithMessage("Line1 cannot be null");
            RuleFor(address => address.City).NotNull().WithMessage("City cannot be null");
            RuleFor(address => address.PostalCode).NotNull().WithMessage("PostalCode cannot be null");
            RuleFor(address => address.State).NotNull().WithMessage("State cannot be null");
            RuleFor(address => address.Country).NotNull().WithMessage("Country cannot be null");
        }
    }
}
