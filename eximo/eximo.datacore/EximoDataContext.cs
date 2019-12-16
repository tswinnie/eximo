using eximo.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace eximo.datacore
{
    public class EximoDataContext : DbContext
    {
        private string _dbPath;

        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizationType> AuthorizationTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DataBroker> DataBrokers { get; set; }
        public DbSet<EmailMarketing> EmailMarketings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<ServicePlan> ServicePlan { get; set; }
        public EximoDataContext(string dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("Configuring eximo database...");
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Debug.WriteLine("Creating DB Model...");
            modelBuilder.Entity<User>().HasKey(p => p.UserId);
            modelBuilder.Entity<AuthorizationType>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Contact>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<DataBroker>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EmailMarketing>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Notification>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<PaymentInfo>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Phone>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<ServicePlan>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);

            //add data if in Debug
#if DEBUG
            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        UserId = 1,
                        FirstName = "James",
                        LastName = "Brown",
                        UserName = "jbrown",
                        Email = "jbrown@mail.com",
                        Password = "abc123",
                        ContactInformation = new Contact
                        {
                            ContactId = 1,
                            ContactAddress = new Address
                            {
                                AddressId = 1,
                                City = "Americus",
                                State = "GA",
                                PostalZip = "31709",
                                StreetOne = "abc 123 south lee st",
                                StreetTwo = "",
                                UserId = 1
                            },
                            PhoneNumber = new Phone
                            {
                                PhoneId = 1,
                                AreaCode = 229,
                                PhoneNumber = 5555555,
                                UserId = 1
                            },
                            UserId = 1
                        },
                        Payment = new PaymentInfo
                        {
                            PaymentId = 1,
                            CardName = "Customer Card",
                            CardNumber = 1234456789102340,
                            CardType = "Visa",
                            SecurityNumber = 234,
                            UserId = 1
                        },
                        Plan = new ServicePlan
                        {
                            ServicePlanId = 1,
                            ServiceName = "basic",
                            UserId = 1
                        },
                        Authorizations = new List<AuthorizationType>()
                        {
                           new AuthorizationType
                           {
                               AuthorizationId = 1,
                               AuthorizationName = "Email",
                               AuthorizationActive = true,
                               UserId = 1

                           },
                           new AuthorizationType
                           {
                               AuthorizationId = 2,
                               AuthorizationName = "Mail",
                               AuthorizationActive = true,
                               UserId = 1

                           }

                        },
                        DataBrokers = new List<DataBroker>()
                        {
                            new DataBroker
                            {
                                DataBrokerId = 1,
                                Name = "Databroker One",
                                Website = "www.databrokerone.com",
                                VerificationType = "Email",
                                OptOutLink = "www.optoutlink.com",
                                Bio = "This is an example bio for data broker.",
                                CaptureCustomerInfo = new List<string>()
                                {
                                    "Email",
                                    "Mail",
                                    "Phone",
                                    "Address"
                                },
                                CustomerAccountStatus = Status.Active,
                                UserId = 1

                            },
                            new DataBroker
                            {
                                DataBrokerId = 2,
                                Name = "Databroker Two",
                                Website = "www.databrokertwo.com",
                                VerificationType = "Email",
                                OptOutLink = "www.optoutlink.com",
                                Bio = "This is an example bio for data broker.",
                                CaptureCustomerInfo = new List<string>()
                                {
                                    "Email",
                                    "Mail",
                                    "Phone",
                                    "Address"
                                },
                                CustomerAccountStatus = Status.Active,
                                UserId = 1

                            }
                        },
                        EmailMarketings = new List<EmailMarketing>()
                        {
                            new EmailMarketing
                            {
                                EmailMarketingId = 1,
                                MarketerName = "Email Marketer One",
                                Website = "www.emailmarketerone.com",
                                EmailMarketingStatus = Status.Active,
                                UserId = 1
                            },
                            new EmailMarketing
                            {
                                EmailMarketingId = 2,
                                MarketerName = "Email Marketer Two",
                                Website = "www.emailmarketertwo.com",
                                EmailMarketingStatus = Status.Active,
                                UserId = 1
                            },
                        },
                        Notifications = new List<Notification>()
                        {
                            new Notification
                            {
                                NotificationId = 1,
                                Title = "Notification One",
                                Description = "This is an example notification",
                                NotificationDate = new DateTime(),
                                NotificationCompleted = false
                            },
                            new Notification
                            {
                                NotificationId = 2,
                                Title = "Notification Two",
                                Description = "This is an example notification",
                                NotificationDate = new DateTime(),
                                NotificationCompleted = false
                            },
                        }


                    }
                );


#endif

        }

        //CRUD  Operations 
        public async Task<object[]> GetUserAsync(int userId)
        {
            var userObj = new object[2];

            Debug.WriteLine("Getting user...");
            try
            {
                var user = await Users.FirstOrDefaultAsync(u => u.UserId == userId).ConfigureAwait(false);
                userObj[0] = user;
                userObj[1] = true;
                return userObj;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Exception occured while trying to get user {e.Message}");
                userObj[0] = e.Message;
                userObj[1] = false;
                return userObj;
            }

        }

        public async Task<object[]> AddUserAsync(User user)
        {
            var userObj = new object[2];

            Debug.WriteLine("Adding new user...");
            try
            {
                await Users.AddAsync(user).ConfigureAwait(false);
                await SaveChangesAsync().ConfigureAwait(false);
                userObj[0] = user;
                userObj[1] = true;
                return userObj;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Exception occured while trying to add user {e.Message}");
                userObj[0] = e.Message;
                userObj[1] = false;
                return userObj;
            }
           
        }

        public async Task<object[]> UpdateUserAsync(User user)
        {
            var userObj = new object[2];

            try
            {
                Users.Update(user);
                await SaveChangesAsync().ConfigureAwait(false);
                userObj[0] = user;
                userObj[1] = true;
                return userObj;

            }
            catch(Exception e)
            {
                Debug.WriteLine($"Exception occured while trying to update user {e.Message}");
                userObj[0] = e.Message;
                userObj[1] = false;
                return userObj;

            }
        }


        public async Task<object[]> DeleteUserAsync(int userId)
        {
            var userObj = new object[2];

            try
            {
                User userToDelete = await Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if(userToDelete != null)
                {
                    Users.Remove(userToDelete);
                    await SaveChangesAsync().ConfigureAwait(false);
                    userObj[0] = userToDelete;
                    userObj[1] = true;
                }
                return userObj;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception occured while trying to delete user {e.Message}");
                userObj[0] = e.Message;
                userObj[1] = false;
                return userObj;
            }
        }



    }
}
