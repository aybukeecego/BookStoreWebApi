
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.CreateBook;

public class CreateBookCommand
{
    public CreateBookModel Model { get; set; }

    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;
    public CreateBookCommand(IBookStoreDbContext dbcontext,IMapper mapper)
    {
        _mapper=mapper;
        _dbcontext = dbcontext;
    }
    public void Handle()
    {
            var book=_dbcontext.Books.SingleOrDefault(x=> x.Title==Model.Title);
            if(book is not null)
            throw new InvalidOperationException("eklemek istediğiniz kitap zaten mevcut");

            book=_mapper.Map<Book>(Model);

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }

        public DateTime PublishDate { get; set; }

    }

}