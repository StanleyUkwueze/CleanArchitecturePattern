using CleanArch.Domain.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions options):base(options) 
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
