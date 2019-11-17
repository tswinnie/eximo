using eximo.core.Models;
using eximo.data;
using eximo.data.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace eximo.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private MockUserData _mockUserData;
        private SqliteConnection connection;
        private TestDbInstance context;

        public UserServiceTest()
        {
            _mockUserData = new MockUserData();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<TestDbInstance>()
                   .UseSqlite(connection)
                   .Options;

            // Create the schema in the database
            context = new TestDbInstance(options);         
            context.Database.EnsureCreated();
            
        }
        [TestMethod]
        public async Task AddUserToDBAsync()
        {     
            // Run the test against one instance of the context               
            var userObj = new object[2];
            userObj = await context.AddUserAsync(_mockUserData._GetTestUser);
            connection.Close();

            Assert.AreEqual(true, userObj[1]);
        }

        [TestMethod]
        public async Task GetUserAsync()
        {
            var userObj = new object[2];
            int userId = 2;
            string testUserFirstName = "Matt";

            await context.AddUserAsync(_mockUserData._GetTestUser);

            userObj = await context.GetUserAsync(userId);
            User userFound = (User)userObj[0];
            connection.Close();

            Assert.AreEqual(testUserFirstName, userFound.FirstName);


        }
        [TestMethod]
        public async Task UpdateUserAsync()
        {

            var userObj = new object[2];
            var testUserFirstName = "Matty";
            await context.AddUserAsync(_mockUserData._GetTestUser);
            var updatedUser = _mockUserData._GetTestUser;
            updatedUser.FirstName = "Matty";
            userObj = await context.UpdateUserAsync(updatedUser);
            User updatedUserName = (User)userObj[0];

            connection.Close();

            Assert.AreEqual(testUserFirstName, updatedUserName.FirstName);


        }

        [TestMethod]
        public async Task DeleteUserAsync()
        {
            var userObj = new object[2];
            await context.AddUserAsync(_mockUserData._GetTestUser);
            int userId = 2;
            userObj = await context.DeleteUserAsync(userId);
            connection.Close();
            Assert.AreEqual(true, userObj[1]);
        }
    }
}
