using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using AutoMapper;
using FluentValidation;
using WebApi.Application.GenreOperations.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;
using WebApi.Application.GenreOperations.GetGenreDetailQueryValidation;
using WebApi.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using WebApi.Application.GenreOperations.Commands.CreateGenreCommandValidation;
using WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand;
using WebApi.Application.GenreOperations.DeleteGenre;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]s")]

 public class GenreController:ControllerBase
{
    private readonly IBookStoreDbContext _context;
    
    private readonly IMapper _mapper;

    public GenreController(IBookStoreDbContext context, IMapper mapper)
    {
        context=_context;
        mapper=_mapper;

    }

    [HttpGet]

    public IActionResult GetGenres()
    {
        GetGenresQuery query= new GetGenresQuery (_context,_mapper);

        var obj=query.Handle();

        return Ok(obj);
    }

    [HttpGet("{id}")]

    public IActionResult GetGenreDetail(int id)
    {
        GetGenreDetailQuery query= new GetGenreDetailQuery(_context,_mapper);
        query.genreId=id;
        GetGenreDetailQueryValidation validator= new GetGenreDetailQueryValidation();
        validator.ValidateAndThrow(query);

        var obj= query.Handle();
        return Ok(obj);

    }
    [HttpPost]

    public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command= new CreateGenreCommand(_context);
        command.Model=newGenre;
        CreateGenreCommandValidation validator= new CreateGenreCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]

    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId=id;
        command.Model=updateGenre;
        UpdateGenreCommandValidation validator= new UpdateGenreCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
        

    }

    [HttpDelete ("{id}")]

    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command=new DeleteGenreCommand(_context);
        command.GenreId=id;
        DeleteGenreCommandValidation validator = new DeleteGenreCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();

    }

    
}
