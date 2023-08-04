using WebApi.DbOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Mapping;

namespace Tests.TestSetup;

public class CommonTestFixture
{
    public BookStoreDbContext Context { get; set; }
    public IMapper Mapper { get; set; }

    public CommonTestFixture()
    {
        var options= new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreDbTest").Options;
        Context= new BookStoreDbContext(options);
        Context.Database.EnsureCreated();
        Context.AddGenres();
        Context.AddBooks();
        Context.AddAuthor();
        Context.SaveChanges();

        Mapper= new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>();}).CreateMapper();
    }

}