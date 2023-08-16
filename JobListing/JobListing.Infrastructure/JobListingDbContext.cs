using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Infrastructure
{
    public class JobListingDbContext : DbContext
    {
        public JobListingDbContext(DbContextOptions<JobListingDbContext> options)
            : base(options)
        { }
    }
}
