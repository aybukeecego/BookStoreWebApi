using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations;
public class DataGenerator {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }

            

            context.Genres.AddRange(
                new Genre
                {
                    Name="Personal Growth"

                },
                new Genre
                {
                    Name="Science Fiction"

                },
                new Genre
                {
                    Name="Romance"

                } );

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

            context.SaveChanges();
        }
    }
}