using eximo.core.Models;
using eximo.data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.Test
{
    public class MockUserData
    {
        public User _GetTestUser { get; }

        //private UserService _userService;

        public MockUserData()
        {

            //create mock data object

            _GetTestUser = CreateTestUser();
                
        }

        public static User CreateTestUser()
        {


            var testAddress = new Address
            {
                AddressId = 2,
                City = "Americus",
                State = "GA",
                PostalZip = "31709",
                StreetOne = "123 South lee st",
                StreetTwo = "example street two",
                UserId = 2

            };

            var testPhone = new Phone
            {
                PhoneId = 2,
                AreaCode = 229,
                PhoneNumber = 5555555,
                UserId = 2,
            };

            var testContact = new Contact
            {
                ContactId = 2,
                UserId = 2,
                ContactAddress = testAddress,
                PhoneNumber = testPhone

            };

            var testPaymentInfo = new PaymentInfo
            {
                PaymentId = 2,
                CardName = "Matt Ryan",
                CardNumber = "123445677890",
                CardType = "Master Card",
                SecurityNumber = 299,
                UserId = 2
            };

            var testServicePlan = new ServicePlan
            {
                ServicePlanId = 2,
                ServiceName = "Basic",
                UserId = 2
            };

            var testAuthorization = new List<AuthorizationType>()  
            {
               new AuthorizationType  {  AuthorizationId = 2, AuthorizationName = "Email", AuthorizationActive = true, UserId = 2 }
            };
            
            var testDatabroker = new List<DataBroker>()
            {
                new DataBroker 
                {
                    DataBrokerId = 2,
                    Name = "Databroker One",
                    Website = "http://databrokerone.com",
                    Bio = "Some bio information",
                    VerificationType = "Email",
                    OptOutLink = "http://optoutlink.com",
                    CaptureCustomerInfo = new List<string>()
                        {
                            "Email",
                            "Phone"
                        },
                    UserId = 2,
                }
            };

            var testEmailMarketing = new List<EmailMarketing>() 
            {
                new EmailMarketing
                {
                    EmailMarketingId = 2,
                    EmailMarketingStatus = Status.Active,
                    MarketerName = "Email Marketing Name Example",
                    Website = "http://emailmarketersite.com",
                    UserId = 2
                }
            };

            var testNotification = new List<Notification>()
            {
                new Notification
                {
                    NotificationId = 2,
                    Title = "Notification Title",
                    NotificationDate = new DateTime(),
                    NotificationCompleted = false,
                    UserId = 2
                }
            };

            var testPament = new PaymentInfo
            {
                PaymentId = 2,
                CardName = "James Brown",
                CardNumber = "123445677890",
                CardType = "Visa",
                SecurityNumber = 299,
                UserId = 2
            };

            var testUser = new User
            {
                UserId = 2,
                FirstName = "Matt",
                LastName = "Ryan",
                UserName = "mryan",
                Email = "matt.ryan@mail.com",
                Password = "abc123",
                ContactInformation = testContact,
                Payment = testPament,
                Plan = testServicePlan,
                Authorizations = testAuthorization,
                Databrokers = testDatabroker,
                EmailMarketings = testEmailMarketing,
                Notifications = testNotification

            };


            return testUser;
        
             
        }


    }
}
