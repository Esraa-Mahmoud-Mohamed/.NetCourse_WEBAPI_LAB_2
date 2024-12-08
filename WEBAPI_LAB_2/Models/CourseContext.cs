using Microsoft.EntityFrameworkCore;

namespace WEBAPI_LAB_2.Models
{
    public class CourseContext: DbContext
    {
        public virtual DbSet<Course> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6H9B8GJ\\SQLEXPRESS;Initial Catalog=CourseDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                    new Course() { ID=1, Crs_name=".Net", Crs_description=".Net", Duration=96},
                    new Course() { ID = 2, Crs_name = "HTML", Crs_description = "HTML", Duration = 70 },
                    new Course() { ID = 3, Crs_name = "CSS", Crs_description = "CSS", Duration = 63 },
                    new Course() { ID = 4, Crs_name = "JS", Crs_description = "JS", Duration = 40 }
                );
        }
    }
}
