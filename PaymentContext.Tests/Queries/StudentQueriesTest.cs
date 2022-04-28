using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private IList<Student> _students;

        public StudentQueriesTest()
        {
            for(var i = 0; i<= 10; i++) 
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));

            }
        }
        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists() 
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();


            Assert.AreEqual(null, student);
        }
        [TestMethod]
        public void ShouldReturnStudentWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();


            Assert.AreNotEqual(null, student);
        }
    }
}
