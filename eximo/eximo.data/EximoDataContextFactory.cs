using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.data
{
    public class EximoDataContextFactory : IDesignTimeDbContextFactory<EximoDataContext>
    {
        public EximoDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EximoDataContext>();

            return new EximoDataContext(string.Empty);
        }
    }
}
