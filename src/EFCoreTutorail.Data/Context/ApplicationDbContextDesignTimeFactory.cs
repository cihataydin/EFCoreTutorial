using System;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreTutorail.Data.Context
{
    public class ApplicationDbContextDesignTimeFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContextDesignTimeFactory()
        {

        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var context = new ApplicationDbContext();
            return context;
        }
    }
}
