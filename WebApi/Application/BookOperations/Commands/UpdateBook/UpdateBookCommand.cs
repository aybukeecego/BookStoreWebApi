using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.UpdateBook;

public class UpdateBookCommand
{
    public int bookId { get; set; }
    public UpdateBookModel Model { get; set; }
    private readonly IBookStoreDbContext _dbcontext;

    public UpdateBookCommand(IBookStoreDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public void Handle()
    {
        var book= _dbcontext.Books.SingleOrDefault(x=>x.Id==bookId);
        if(book is null)
        throw new InvalidOperationException("Güncellenecek ürün bulunamamıştır");
        book.GenreId=Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.PageCount=Model.PageCount != default? Model.PageCount : book.PageCount;
        book.Title= Model.Title != default ? Model.Title : book.Title;

        _dbcontext.SaveChanges();

    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId {get;set;}

    }

}