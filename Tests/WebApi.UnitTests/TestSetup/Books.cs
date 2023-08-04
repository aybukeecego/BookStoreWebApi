namespace Tests.TestSetup;
using WebApi.Entities;
using WebApi.DbOperations;

public static class Books
{
    public static void AddBooks(this BookStoreDbContext context)
    {
            context.Books.AddRange(
            new Book{
                //Id=1,
                Title="Lean Startup",
                PageCount=200,
                GenreId=1,
                PublishDate=new DateTime(2001,12,03)

            },
                new Book{
                //Id=2,
                Title="Herland",
                PageCount=250,
                GenreId=2, 
                PublishDate=new DateTime(2001,09,06)

            },
                new Book{
                //Id=3,
                Title="Dune",
                PageCount=200,
                GenreId=2, 
                PublishDate=new DateTime(2001,11,21)

            } );
    }
}