using EntityFrameworkDemoProject.Data;
using EntityFrameworkDemoProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemoProject.Tests
{
    public class TestBase
    {
        protected AppDbContext context;

        [SetUp]
        public void InitDb()
        {
            DbContextOptionsBuilder builder = new();
            builder.UseSqlServer("Server=VINOD-HPP\\SQLEXPRESS;Database=jecrc_ef_demo;Integrated Security=True;TrustServerCertificate=True;");
            context = new(builder.Options);

            // initial seed data
            context.Database.ExecuteSqlRaw("INSERT INTO EMPLOYEES values ('8f2e7d9c-5a3b-46f1-9d8e-7c2f5b0a3e1d', 'Shyam Sundar', 'shaym.sundar@xmpl.com', 45600)");
            context.Database.ExecuteSqlRaw("INSERT INTO EMPLOYEES values ('c4e7b8f1-9a2d-4c6e-8b5f-3a7d9e2c1b4a', 'John Doe', 'john.doe@xmpl.com', 23600)");
        }

        [TearDown]
        public void CleanUp()
        {
            context.Database.ExecuteSqlRaw("DELETE FROM EMPLOYEES");
        }
    }
}
