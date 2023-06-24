using Microsoft.EntityFrameworkCore;

namespace devicesItDepartment.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base(){
            
        }

        public TaskContext(DbContextOptions options) : base(options) { 
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceCategory> DeviceCategories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-75M4UJ7;Initial Catalog=networkTask;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
