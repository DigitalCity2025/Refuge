using Microsoft.EntityFrameworkCore;
using Refuge.Application.Entities;

namespace Refuge.DAL
{
    public class RefugeContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Cat> Cats { get; set; }
    }
}
