using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using AutoMapper;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorQuery;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using FluentValidation;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using static WebApi.Application.BookOperations.CreateBook.CreateAuthorCommand;
using static WebApi.Application.AuthorOperations.Commands.UpdateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]

public class AuthorController:ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IBookStoreDbContext _context;

    public AuthorController(IMapper mapper, IBookStoreDbContext context)
    {
        _mapper=mapper;
        _context=context;

    }

    [HttpGet]

    public IActionResult GetAuthor()
    {
        GetAuthorQuery query= new GetAuthorQuery(_mapper,_context);

        var obj=query.Handle();
        return Ok(obj);

        

    }

    [HttpGet("{id}")]

    public IActionResult GetAuthorDetail(int id)
    {
        GetAuthorDetailQuery query =new GetAuthorDetailQuery(_mapper,_context);
        query.authorId=id;
        GetAuthorDetailValidation validator= new GetAuthorDetailValidation();
        validator.ValidateAndThrow(query);
         var obj=query.Handle();

         return Ok(obj);

    }

    [HttpPost]

    public IActionResult CreateAuthor([FromBody] CreateAuthorModel newAuthor )
    {
        CreateAuthorCommand command=new CreateAuthorCommand(_mapper,_context);
        command.Model=newAuthor;
        CreateAuthorCommandValidation validator=new CreateAuthorCommandValidation();
        validator.ValidateAndThrow(command);
         command.Handle();

         return Ok();


    }

    [HttpPut ("{id}")]

    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
    {
        UpdateAuthorCommand command=new UpdateAuthorCommand(_context,_mapper);
        command.authorId=id;
        command.Model=updateAuthor;

        UpdateAuthorCommandValidation validator= new UpdateAuthorCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpDelete]

    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand command=new DeleteAuthorCommand(_mapper,_context);
        DeleteAuthorCommandValidation validator= new DeleteAuthorCommandValidation();
        validator.ValidateAndThrow(command);
        command.authorId=id;
        command.Handle();
        return Ok();

    }
}
