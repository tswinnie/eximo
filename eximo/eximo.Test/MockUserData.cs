using eximo.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.Test
{
    public class MockUserData
    {
        public User _GetTestUser { get; }

        public MockUserData()
        {

            //create mock data object

            _GetTestUser = CreateTestUser();
                
        }

        public static User CreateTestUser()
        {

            var testPament = new PaymentInfo
            {
                PaymentId = 1,
                CardName = "James Brown",
                CardNumber = "123445677890",
                CardType = "Visa",
                SecurityNumber = 299,
                UserId = 1
            };

            var testUser = new User
            {
                UserId = 2,
                FirstName = "Matt",
                LastName = "Ryan",
                Payment = testPament,

            };


            return testUser;
        
             
        }


    }
}
