using BookInventory.Domain;
using System.Data.Entity;

namespace BooksInventory.Data.EF
{
    public class BookInventoryDbContext(string connectionString) : DbContext(connectionString)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Author).HasMaxLength(256).IsRequired().IsUnicode(false);
            modelBuilder.Entity<Book>().Property(b => b.ISBN).HasMaxLength(13).IsRequired().IsUnicode(false);
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(256).IsRequired().IsUnicode(false);

            modelBuilder.Entity<Book>().HasRequired(b => b.Category).WithMany().HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookCategory>().Property(b => b.Name).HasMaxLength(256).IsRequired().IsUnicode(false);
            modelBuilder.Entity<BookCategory>().Property(b => b.Description).HasMaxLength(1000).IsUnicode(false);
        }
    }
}
