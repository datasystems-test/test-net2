using System;
using System.Collections.Generic;
using System.Text;
using CRUD_NETCore_TDD.Infra.Models;
using Xunit;
using CRUD_NETCore_TDD.Infra.Repositories;
using CRUD_NETCore_TDD.Infra.Validations;
using System.Linq;
 
namespace CRUD_NETCore_TDD.Test.Tests
{
    public class PostUserTest: BaseTest
    {
        #region THEORY
        #endregion
        #region FACT
        //[Fact]
        //public void Fact_PostUser_NoClassNoRepository ()
        //{
        //    // EXAMPLE
        //    var user = new User("LUCIANO PEREIRA", 33, true);

        //    // REPOSITORY
        //    ctx.User.Add(user);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal(1, user.Id);
        //}

        //[Fact]
        //public void Fact_PostUser_NoRepository()
        //{
        //    // EXAMPLE
        //    var user = new User(0, "LUCIANO PEREIRA", 33, true);

        //    // REPOSITORY
        //    ctx.User.Add(user);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal(1, user.Id);
        //}

        [Fact]
        public void Fact_PostUser_NoValidation()
        {
            // EXAMPLE
            var user = new User(1, "PABLO SALMON", 20, true);

            // REPOSITORY
            user = new UserRepository(ctx).Post(user);

            // ASSERT
            Assert.Equal(1, user.Id);
        }

        [Fact]
        public void Fact_PostUser()
        {
            // EXAMPLE
            var user = new User(1, "LUCIANO PEREIRA", 33, true);

            var val = new PostUserValidator().Validate(user);

            // ASSERT
            Assert.True(val.IsValid);

            if (val.IsValid)
            {
                // REPOSITORY
                user = new UserRepository(ctx).Post(user);

                // ASSERT
                Assert.Equal(1, user.Id);///1
            }
        }
        #endregion

        //#region THEORY
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        //[InlineData("LUCIANO PEREIRA")]
        //public void Theory_PostUser_Name_NoValidation(string Name)
        //{
        //    var user = new User
        //    {
        //        Name = Name
        //    };

        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);
        //}

        //#endregion

        //#region THEORY
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        //[InlineData("LUCIANO PEREIRA")]
        //public void Theory_PostUser_Name_Validation(string Name)
        //{
        //    var user = new User
        //    {
        //        Name = Name
        //    };

        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);
        //}

        //#endregion

        #region THEORY
        [Theory]
        [InlineData("", 101)]//LUCIANO PEREIRA
        
        [InlineData("LUCIANO PEREIRA", 101)]//,101
       
        public void Theory_PostUser_Name(string Name, int ErrorCode)
        {
            var user = new User
            {
                Name = Name
            };
            CheckError(new PostUserValidator(), ErrorCode, user);
        }

        [Theory]
        [InlineData(33, 102)]//-1,102
       // [InlineData(0, 102)]//0,102
        //[InlineData(0, 102)]//33,102
        public void Theory_PostUser_Age(int Age, int ErrorCode)
        {
            var user = new User
            {
                Age = Age
            };

            CheckError(new PostUserValidator(), ErrorCode, user);
        }

        #endregion

    }
}
