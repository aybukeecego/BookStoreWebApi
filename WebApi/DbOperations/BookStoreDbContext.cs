using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.DbOperations;

    public class BookStoreDbContext: DbContext,IBookStoreDbContext
{
    public BookStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books {get;set;}
    public DbSet<Genre> Genres {get;set;}

    public DbSet<Author> Authors {get;set;}

    public DbSet<User> Users {get;set;}

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
