using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eximo.Models
{
    public class Repo : DbContext
    {
        /// <summary>
        /// Creates our repo.
        /// </summary>
        /// <param name="dbPath">the platform specific path to the database</param>
        public Repo(string dbPath) : base()
        {
            _dbPath = dbPath;
            // Create database if not there. This will also ensure the data seeding will happen.
            Database.EnsureCreated();
        }

        string _dbPath;

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("**** OnConfiguring");
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Debug.WriteLine("**** OnModelCreating");

            // Make ID property the primary key.
            modelBuilder.Entity<Item>()
                .HasKey(p => p.Id);

            // Require text to be set.
            modelBuilder.Entity<Item>()
                .Property(p => p.Text)
                .IsRequired();

            // Add a converter to store category enum as string instead of int.
            modelBuilder.Entity<Item>()
                .Property(p => p.Category)
                .HasConversion(new EnumToStringConverter<ItemCategory>());

#if DEBUG
            // Add some initial data.
            modelBuilder.Entity<Item>()
                .HasData(
                    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description = "This is a private item description.", Category = ItemCategory.Private },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description = "This is a shopping item description.", Category = ItemCategory.Shopping },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description = "This is a work item description.", Category = ItemCategory.Work }
                );
#endif
        }

        #region IDataStore<Item> start
        public async Task<Item> GetItemAsync(string id)
        {
            Debug.WriteLine("**** GetItemAsync");
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            Debug.WriteLine("**** GetItemsAsync");
            // Ignore forceRefresh for now.
            var allItems = await Items.ToListAsync().ConfigureAwait(false);
            return allItems;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            Debug.WriteLine("**** AddItemAsync");
            await Items.AddAsync(item).ConfigureAwait(false);
            await SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            Debug.WriteLine("**** UpdateItemAsync");
            Items.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
            // No error handling. Homework :-)
            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Debug.WriteLine("**** DeleteItemAsync");
            var itemToRemove = Items.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
                await SaveChangesAsync().ConfigureAwait(false);
            }

            return true;
        }
        #endregion
    }
}
