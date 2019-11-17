using eximo.core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace eximo.Test
{
    public class TestDbInstance : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizationType> AuthorizationTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DataBroker> DataBrokers { get; set; }
        public DbSet<EmailMarketing> EmailMarketings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<ServicePlan> ServicePlan { get; set; }


        public TestDbInstance(DbContextOptions<TestDbInstance> options): base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Debug.WriteLine("Creating DB Model...");
            modelBuilder.Entity<User>().HasKey(p => p.UserId);
            modelBuilder.Entity<AuthorizationType>().HasOne(p => p.User).WithMany(u => u.Authorizations).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Contact>().HasOne(p => p.User).WithOne(u => u.ContactInformation);
            modelBuilder.Entity<DataBroker>().HasOne(p => p.User).WithMany(u => u.Databrokers).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EmailMarketing>().HasOne(p => p.User).WithMany(u => u.EmailMarketings).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Notification>().HasOne(p => p.User).WithMany(u => u.Notifications).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<PaymentInfo>().HasOne(p => p.User).WithOne(u => u.Payment);
            modelBuilder.Entity<ServicePlan>().HasOne(p => p.User).WithOne(u => u.Plan);
            modelBuilder.Entity<DataBroker>().Property(p => p.CaptureCustomerInfo)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));     

        }

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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
                if (userToDelete != null)
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
