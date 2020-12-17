using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace DAL
{
    public class LibraryDbContext: DbContext 
    {
        public LibraryDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NH8SSB6\MSSQLSERVER01;dataBase=LibraryDb;Trusted_Connection=True;");
        }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Location> Locations { get; set; }
        
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Owner> Owners { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
