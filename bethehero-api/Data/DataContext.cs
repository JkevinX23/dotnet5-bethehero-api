using Microsoft.EntityFrameworkCore;
using bethehero_api.Models;

namespace bethehero_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
            {

            }
        public DbSet<Incident> Incident { get; set; } 
        public DbSet<Ong> Ong { get; set; } 

    }
}