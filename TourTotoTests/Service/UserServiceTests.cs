using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourToto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;
using TourToto.Builder;
using TourToto.Model.DataAccessObject;

namespace TourToto.Service.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        private UserService service;
        private int lastWrittenId;
        private UserService retrievedUser;

        public UserServiceTests()
        {
            UserDao dao = new UserDao();
            this.service = new UserService(dao);
        }

        [TestMethod()]
        public void register_and_get()
        {
            registerUser();
            getUserTest_validId();
            updateUser();
            //testDelete();
        }

        public void registerUser()
        {
            UserBuilder builder = new UserBuilder();
            UserService user = builder
                            .SetCredentials(1)
                            .SetName("Entity thijs werkt")
                            .SetEmail("test@gmail.com")
                            .SetPassword("pasword")
                            .Build();
            int result = service.Add(user);
            lastWrittenId = result;
            Assert.IsTrue(result > 0);
        }

        public void getUserTest_validId()
        {
            UserService actual = service.Get(lastWrittenId);
            UserBuilder builder = new UserBuilder();
            UserService expected = builder
                            .SetCredentials(1)
                            .SetName("Entity thijs werkt")
                            .SetEmail("test@gmail.com")
                            .SetPassword("pasword")
                            .Build();
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Email, actual.Email);

            retrievedUser = actual;

            Console.WriteLine(actual.ToString());
        }

        public void updateUser()
        {
            try
            {
                retrievedUser.Name = "updatenaam";
                service.Update(retrievedUser);

                UserService updatedUser = service.Get(retrievedUser.Id);

                Assert.AreEqual(updatedUser.Name, "updatenaam");
            }
            catch (Exception e)
            {
                Console.WriteLine("test stacktrace: " + e.StackTrace);
            }
        }

        public void testDelete()
        {
            bool result = service.Delete(lastWrittenId);

            Assert.IsTrue(result);
        }
    }
}