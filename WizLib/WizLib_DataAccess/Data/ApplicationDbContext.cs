using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WizLib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> GetCategories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetails> BookDetail { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Fluent_BookDetails> Fluent_BookDetails { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //we configure fluent API

            //Catergoy table name and column name
            modelbuilder.Entity<Category>().ToTable("tbl_category");
            modelbuilder.Entity<Category>().Property(c=>c.Name).HasColumnName("CategoryName");
            //Composite key
            modelbuilder.Entity<BookAuthor>().HasKey(ba =>new { ba.Author_Id ,ba.Book_Id});
         
            //BookDetail
            modelbuilder.Entity<Fluent_BookDetails>().HasKey(b => b.BookDetail_Id);
            modelbuilder.Entity<Fluent_BookDetails>().Property(b => b.NumberOfChapters).IsRequired();


            //Book
            modelbuilder.Entity<Fluent_Book>().HasKey(b => b.Book_Id);
            modelbuilder.Entity<Fluent_Book>().Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelbuilder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            modelbuilder.Entity<Fluent_Book>().Property(b => b.Price).IsRequired();


            //one to one relation between book and book detail
            modelbuilder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_BookDetails)
                .WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_Id");
            
            //one to many relation between book and publisher
            modelbuilder.Entity<Fluent_Book>()
               .HasOne(b => b.Fluent_Publisher)
               .WithMany(b => b.Fluent_Book).HasForeignKey(b=>b.Publisher_Id);

            //Author
            modelbuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelbuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelbuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelbuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);

            //Publisher
            modelbuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelbuilder.Entity<Fluent_Publisher>().Property(b => b.Name).IsRequired();
            modelbuilder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();

            
        }
    }
}
