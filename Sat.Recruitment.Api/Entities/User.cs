using Sat.Recruitment.Api.Models.Enums;
using Sat.Recruitment.Api.Utilities;
using System;

namespace Sat.Recruitment.Api.Entities
{
    public class User
    {
        public User()
        {
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }

        /// <summary>
        /// Validates User required/valid fields
        /// </summary>
        /// <returns>string with errors</returns>
        public string ValidateErrors()
        {
            string errors = null;

            if (Name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (Email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (Address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (Phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";
            //Validate if Email is valid
            if (!Email.ValidateEmail())
                errors = errors + " The Email field is not valid";

            return errors;
        }
        public void CalculateMoney()
        {
            switch (UserType)
            {
                case UserType.Normal:
                    if (Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        var gif = Money * percentage;
                        Money += gif;
                    }
                    if (Money < 100 && Money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = Money * percentage;
                        Money += gif;
                    }
                    break;
                case UserType.SuperUser:
                    if (Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = Money * percentage;
                        Money += gif;
                    }
                    break;
                case UserType.Premium:
                    if (Money > 100)
                    {
                        var gif = Money * 2;
                        Money += gif;
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name},{Email},{Phone},{Address},{UserType},{Money}";
        }
    }
}
