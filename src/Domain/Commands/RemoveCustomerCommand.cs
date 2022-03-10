using System;
using Domain.Commands.Validations;

namespace Domain.Commands
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}