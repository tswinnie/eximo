using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eximo.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private MockUserData _mockUserData;

        public UserServiceTest()
        {
            _mockUserData = new MockUserData();
        }
        [TestMethod]
        public void AddUserToDB()
        {
            //call mock data to get test user
            var testUser = _mockUserData._GetTestUser;
        }
    }
}
