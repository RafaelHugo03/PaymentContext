
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray();}}

        public void AddSubcription(Subscription subscription)
        {
            var hasSubctriptionActive = false;

            foreach(var sub in _subscriptions) 
            {
                if(sub.Active)
                    hasSubctriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubctriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa!")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payments", "Essa assinatura não possui pagamentos"));

        }
    }
}
