
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTest()
        {

            _name = new Name("Bruce", "Wayne");
            _document = new Document("23788364068", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Wayne Corp", _email);

            _subscription.AddPayment(payment);

            _student.AddSubcription(_subscription);
            _student.AddSubcription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubcription(_subscription);;

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Wayne Corp", _email);

            _subscription.AddPayment(payment);
            _student.AddSubcription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
