using Domain.Excepcions;
using System.Text.RegularExpressions;

namespace Domain.ValueObject
{
    public class ContactoEmail
    {
        public ContactoEmail() { }
        public string Email { get; private set; }
        public ContactoEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new BadRequestException("Debe ingresar un Email.");
            }
            if (!ValidateEmail(email))
            {
                throw new BadRequestException("Debe ingresar un Email valido.");
            }
            Email = email;
        }
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
