using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOperation.Commands.CreateBook;

public class CreateBookCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTest(CommonTestFixture testFixture)
    {
        _context=testFixture.Context;
        _mapper=testFixture.Mapper;

    }
    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        //arrange (Hazırlık)
        var book = new Book(){Title= "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",GenreId=1,PageCount=200, PublishDate= new System.DateTime(2003,11,21)};
        _context.Books.Add(book);
        _context.SaveChanges();

        CreateBookCommand command= new CreateBookCommand(_context,_mapper);

        command.Model= new CreateBookModel(){Title=book.Title};

        //Act and assert(Çalıştırma ve doğrulama)

        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("eklemek istediğiniz kitap zaten mevcut");

    }






}