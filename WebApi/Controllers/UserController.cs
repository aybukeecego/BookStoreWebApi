using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using AutoMapper;
using WebApi.Application.UserOperations.CreateUser;
using WebApi.Application.UserOperations.CreateToken;
using WebApi.TokenOperations.Models;
using WebApi.Application.UserOperations.RefreshToken;
using static WebApi.Application.UserOperations.CreateUser.CreateUserCommand;
using static WebApi.Application.UserOperations.CreateToken.CreateTokenCommand;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]

public class UserController:ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;

    public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        mapper=_mapper;
        context=_context;
        configuration=_configuration;
    }

    [HttpPost]

    public IActionResult CreateUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command= new CreateUserCommand(_context,_mapper);
        command.Model=newUser;

        command.Handle();

         return Ok();
    }
    [HttpPost("connect/token")]

    public ActionResult<Token> CreateToken ([FromBody] CreateTokenModel login)
    {
        CreateTokenCommand command= new CreateTokenCommand(_context,_mapper,_configuration);
        command.Model=login;
        var token = command.Handle();
        return token;

    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken ([FromQuery] string token)
    {
        RefreshTokenCommand command= new RefreshTokenCommand(_context,_configuration);
        command.RefreshToken=token;
        var resultToken = command.Handle();
        return resultToken;

    }

}