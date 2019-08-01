using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hart.Models
{
    public class HartContext : DbContext
    {
        public HartContext (DbContextOptions<HartContext> options)
            : base(options)
        {
        }

        public DbSet<ContactForm> ContactForm { get; set; }
    }
}
