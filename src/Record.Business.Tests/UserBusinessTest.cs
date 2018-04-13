using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Record.Entities;

namespace Record.Business.Tests
{
    /// <summary>
    /// Summary description for UserBusinessTest
    /// </summary>
    [TestClass]
    public class UserBusinessTest
    {

        [TestMethod]
        public void SaveUser_Test()
        {
            //Test for debug
            UserEntity user = new UserEntity
            {
                Email = "rafael.teste@teste.com",
                Department = "Dev",
                Name = "Rafael",
                WorkPhone = "11-9999-9999",
                Password = "153215"
            };

            Assert.AreEqual(true, UserBusiness.SaveUser(user));        
        }
    }
}
