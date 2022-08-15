using Blog.Entities;
using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
           : base(@"Server=(localdb)\MSSQLLocalDB;Database=McoraRental;integrated security=true;") { }
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Resim> Resims { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Aracistek> Aracisteks { get; set; }
        public DbSet<SSS> SSSes { get; set; }
        public DbSet<GaleriBlog> GaleriBlogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
