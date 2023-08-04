using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.CreateBook;

public class CreateAuthorCommand
{
    public CreateAuthorModel Model { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommand(IMapper mapper, IBookStoreDbContext context)
    {
        mapper=_mapper;
        context=_context;

    }
    public void Handle()
    {
        var author= _context.Authors.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname);
        if (author is not null)
        throw new InvalidOperationException ("Yazar zaten mevcut");

        author=_mapper.Map<Author>(Model);

        _context.Authors.Add(author);
        _context.SaveChanges();

    }


    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }

}