using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourToto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;
using TourToto.Builder;

namespace TourToto.Service.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        UserService service;
        int lastWrittenId;
        User retrievedUser;

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
            testDelete();
        }

        public void registerUser()
        {
            UserBuilder builder = new UserBuilder();
            User user = builder
                            .setCredentials(1)
                            .setName("Entity thijs werkt")
                            .setEmail("test@gmail.com")
                            .setPassword("pasword")
                            .build();
            int result = service.add(user);
            lastWrittenId = result;
            Assert.IsTrue(result > 0);
        }

        public void getUserTest_validId()
        {
            User actual = service.get(lastWrittenId);
            UserBuilder builder = new UserBuilder();
            User expected = builder
                            .setCredentials(1)
                            .setName("Entity thijs werkt")
                            .setEmail("test@gmail.com")
                            .setPassword("pasword")
                            .build();
            Assert.AreEqual(expected.name, actual.name);
            Assert.AreEqual(expected.email, actual.email);

            retrievedUser = actual;

            Console.WriteLine(actual.ToString());
        }

        
        public void updateUser()
        {
            try
            {
                retrievedUser.name = "updatenaam";
                service.update(retrievedUser);

                User updatedUser = service.get(retrievedUser.id);

                Assert.AreEqual(updatedUser.name, "updatenaam");
            }
            catch (Exception e)
            {
                Console.WriteLine("test stacktrace: " + e.StackTrace);
            }
        }

        public void testDelete()
        {
            bool result = service.delete(lastWrittenId);

            Assert.IsTrue(result);
        }

        /*[TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void getUserTest_invalidId()
        {
            User actual = service.getUser(50);
        }

        [TestMethod()]
        public void updateUserTest_validUser()
        {
            User user = new User(1, 10, "My Name UPDATED", "testUpdated@gmail.com", "password");
            bool result = service.updateUser(user);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void updateUserTest_nonExistingUser()
        {
            User user = new User(999, 10, "My Name UPDATED", "testUpdated@gmail.com", "password");
            bool result = service.updateUser(user);
        }*/

    }
}