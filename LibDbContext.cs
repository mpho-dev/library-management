using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryManagementConsole.Model;

namespace LibraryManagementConsole
{
    internal class LibDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configBuilder.GetConnectionString("SQLServerConnection") ?? null;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //Set up relationships
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Author)
                .WithMany(a => a.Books);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Categories);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Author);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN).IsUnique();
        }

    }
}
