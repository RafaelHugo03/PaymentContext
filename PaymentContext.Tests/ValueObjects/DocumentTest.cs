using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid() 
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);   
        }

        [TestMethod]
        public void ShouldReturnSuccesWhenCNPJIsValid() 
        {
            var doc = new Document("34110468000150", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid() 
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        } 

        [TestMethod]
        public void ShouldReturnSuccesWhenCPFIsValid() 
        {
            var doc = new Document("23788364068", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
