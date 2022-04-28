using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Rafael";
            command.LastName = "Evangelista";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "123456789";
            command.BoletoNumber = "12354789";
            command.PaymentNumber = "12345";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "NCORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "asdasd";
            command.Number = "1234";
            command.Neighborhood = "asfafa";
            command.City = "fdafsdf";
            command.State = "gdsd";
            command.Country = "dsgfs";
            command.ZipCode = "sdffds";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}


