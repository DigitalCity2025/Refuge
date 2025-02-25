using Microsoft.EntityFrameworkCore;
using Refuge.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuge.DAL
{
    public class RefugeContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Cat> Cats { get; set; }
    }
}
