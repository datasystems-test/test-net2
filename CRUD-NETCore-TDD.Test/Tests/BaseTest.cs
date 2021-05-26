using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUD_NETCore_TDD.Infra.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CRUD_NETCore_TDD.Test.Tests
{
    public class BaseTest
    {
        protected MyContext ctx;
        public BaseTest(MyContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected MyContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MyContext>();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            MyContext dbContext = new MyContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        // Add inside BaseTest.cs
        protected void CheckError<T>(AbstractValidator<T> validator, int ErrorCode, T vm)
        {
            var val = validator.Validate(vm);
            Assert.true(val.IsValid);

            if (!val.IsValid)
            {
                bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
                Assert.true(hasError);
            }
        }
    }
}
