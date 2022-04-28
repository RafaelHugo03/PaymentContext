using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string EmailAdress{ get; private set; }

        public Email(string emailAdress)
        {
            EmailAdress = emailAdress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(EmailAdress, "Email.EmailAddres", "E-mail inválido"));
        }
    }
}
