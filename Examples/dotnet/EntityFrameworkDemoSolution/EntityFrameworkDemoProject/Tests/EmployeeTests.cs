using EntityFrameworkDemoProject.Models;
using NUnit.Framework;

namespace EntityFrameworkDemoProject.Tests
{
    public class EmployeeTests: TestBase
    {
        [Test]
        public void ValidEmployeeData_ShouldBeInserted()
        {
            // Arrange
            Employee emp = new()
            {
                Name = "Kiran Kumar",
                Salary = 45000,
                Email = "kiran.kumar@xmpl.com"
            };

            // Act
            context.Employees.Add(emp);
            context.SaveChanges();

            // Assert
            Assert.That(context.Employees.Count, Is.EqualTo(3));
        }

        [Test]
        public void UpdateSalary_ShouldWork()
        {
            Employee emp = new()
            {
                Id = new Guid("8f2e7d9c-5a3b-46f1-9d8e-7c2f5b0a3e1d"),
                Name = "Shaym Sundar KC",
                Email = "shyam.sundar@xmpl.com",
                Salary = 56000
            };

            context.Employees.Update(emp);
            context.SaveChanges();

            var emp2 = context.Employees.FirstOrDefault(
                e => e.Id.ToString() == "8f2e7d9c-5a3b-46f1-9d8e-7c2f5b0a3e1d");

            Assert.That(emp.Salary, Is.EqualTo(56000));
            Assert.That(emp.Name, Is.EqualTo("Shaym Sundar KC"));
        }
    }
}
