using ArkTechUnitTesting.MockRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechUnitTesting.UserTests
{
    [TestClass]
    public class UserCRUDUnitTests
    {
        private IUserService _userService;

        [TestInitialize]
        public void TestInitialize()
        {
            _userService = new UserService(new MockUserRepo());
        }

        private User CreateTestUser()
        {
            User user = new User("Noah", "Goossen", "admin@arktech.nl", "0612341234", "Eindhoven", 2, "Admin");
            _userService.CreateUser(user);
            return user;
        }
        [TestMethod]
        public async void TestCreateUser_ReturnsTrue()
        {
            User user = new User("Noah", "Goossen", "admin@arktech.nl", "0612341234", "Eindhoven", 2, "Admin");
            Result result = await _userService.CreateUser(user);
            Assert.IsTrue(result.Success);
        }
        [TestMethod]
        public async void TestCreateUser_ReturnsFalse()
        {
            Result result = await _userService.CreateUser(null);
            Assert.IsFalse(result.Success);
        }
        [TestMethod]
        public async void TestUpdateUser_ReturnsFalse()
        {
            var user = CreateTestUser();
            Result result = await _userService.UpdateUser(user, String.Empty, "Goossen", "admin@arktech.nl", "0612341234", "Eindhoven", 2);
            Assert.IsFalse(result.Success);
        }
    }
}
