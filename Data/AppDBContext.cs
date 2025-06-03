using CustomerPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Data
{
    public class AppDBContext : DbContext //inherits from the inbuilt DBContext class
    {
        //Constructor properties are also inherited from the base class
        public AppDBContext(DbContextOptions<AppDBContext>opt) : base(opt)
        {
            
        }
        //Creates the table which holds the values in your dataset
        public DbSet<Customer>customers { get; set; }
    }
}
