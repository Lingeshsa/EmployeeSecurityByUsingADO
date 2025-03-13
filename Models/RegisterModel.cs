using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeSecurityByUsingADO.Models
{

//    FirstName, LastName, DateOfBirth, Gender, PhoneNumber, EmailAddress, 
//Address, State, City, Username, Password
    public class RegisterModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required, Phone]
        public string phoneNumber { get; set; }
        [Required, EmailAddress]
        public string emailAddress { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string userName { get; set; }

        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string password { get; set; }
    }
}
