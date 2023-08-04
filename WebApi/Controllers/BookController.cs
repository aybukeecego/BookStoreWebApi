using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.BookOperations.CreateBook;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;
using WebApi.Application.BookOperations.GetBookDetail;
using static WebApi.Application.BookOperations.GetBookDetail.GetBookDetailQuery;
using WebApi.Application.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation;
using static WebApi.Application.BookOperations.UpdateBook.UpdateBookCommand;
using WebApi.Application.BookOperations.UpdateBook;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;
[Authorize]
[ApiController]
[Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

    public BookController(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]

        public IActionResult GetBook()
        {
            GetBooksQuery query=new GetBooksQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
          GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
          GetBookDetailViewModel result;

        query.bookId=id;
        GetBookDetailQueryValidation validator= new GetBookDetailQueryValidation();
        validator.ValidateAndThrow(query);
         result= query.Handle();


        return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command= new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model=newBook;
                CreateBookCommandValidation validator=new CreateBookCommandValidation();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }
        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            UpdateBookCommand command= new UpdateBookCommand(_context);

            command.bookId=id;
            command.Model=updateBook;
            UpdateBookCommandValidation validator= new UpdateBookCommandValidation();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command= new DeleteBookCommand(_context);


            command.bookId=id;
            DeleteBookCommandValidation validator= new DeleteBookCommandValidation();
            validator.ValidateAndThrow(command);
            command.Handle();


            return Ok();
        }



    }
    
