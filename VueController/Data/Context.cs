using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using VueController.Models;

namespace VueController.Data
{
    public class Context: DbContext
    {
        public DbSet<StudentModel> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=Students;Uid=dylan;Pwd=password;");

            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>(p =>
            {
                p.HasKey(o => o.Id);
                p.Property(o => o.Name);
                p.Property(o => o.Surname);
                p.Property(o => o.Fav);
            });
        }
    }
}