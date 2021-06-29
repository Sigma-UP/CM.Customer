using FluentValidation;
namespace CustomerLib.Entities.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerLib.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.LastName)
                .NotNull()
                .WithMessage("Last name cannot be null.");
            RuleFor(customer => customer.Addresses)
                .NotNull().WithMessage("Address list cannot be null.")
                .Must(address => address.Count > 0).WithMessage("Address list cannot be empty.");
            RuleForEach(customer => customer.Addresses).SetValidator(new AddressValidator());
            RuleFor(customer => customer.Notes)
                .NotNull().WithMessage("Notes list cannot be null.")
                .Must(notes => notes.Count > 0 ).WithMessage("Notes list cannot be empty.");
            RuleForEach(customer => customer.Addresses).NotNull().WithMessage("Note cannot be empty");
        }
    }
}
