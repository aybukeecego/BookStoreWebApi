
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOperations.GetBookDetail;

public class GetBookDetailQuery
{
    public int bookId {get;set;}
    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;

    public GetBookDetailQuery(IBookStoreDbContext dbcontext, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }
    public GetBookDetailViewModel Handle()
    {
        var book = _dbcontext.Books.Include(x=>x.Genre).Where(book=> book.Id==bookId).SingleOrDefault();
        if(book==null)
        throw new InvalidOperationException("Bu id'ye ait ürün bulunamadı");
        
        GetBookDetailViewModel vm =_mapper.Map<GetBookDetailViewModel>(book);

        return vm;
    }

    public class GetBookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }

        public string Genre { get; set; }

    }

}