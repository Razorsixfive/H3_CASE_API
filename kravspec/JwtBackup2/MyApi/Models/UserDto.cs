using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebFramework.Api;

namespace MyApi.Models
{
    public class UserDto : BaseDto<UserDto, User>, IValidatableObject
    {
        public int Contact_TypeID { get; set; }
        public int AddreseID { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName.Equals("test", StringComparison.OrdinalIgnoreCase))
                yield return new ValidationResult("Username can not be Test", new[] { nameof(UserName) });
            if (Password.Equals("123456"))
                yield return new ValidationResult("Password could not be 123456", new[] { nameof(Password) });
            if (Gender == GenderType.Male && Age > 30)
                yield return new ValidationResult("Gentlemen are not valid for more than 30 years", new[] { nameof(Gender), nameof(Age) });
        }
    }
}
