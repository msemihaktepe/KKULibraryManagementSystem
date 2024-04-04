using Library.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Concrete
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=AKTEPE\\SQLEXPRESS;database=KKULibraryDB;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Entity.Concrete.Type> Types { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rule> Rules { get; set; }
    }
}
