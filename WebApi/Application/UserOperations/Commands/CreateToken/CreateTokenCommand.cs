
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using WebApi.Entities;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.CreateToken;

public class CreateTokenCommand
{
    public CreateTokenModel Model { get; set; }

    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public CreateTokenCommand(IBookStoreDbContext dbcontext, IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _dbcontext = dbcontext;
        _configuration = configuration;
    }
    public Token Handle()
    {
        var user=_dbcontext.Users.FirstOrDefault(x=>x.Email==Model.Email&& x.Password==Model.Password);
        if(user is not null)
        {
            TokenHandler handler=new TokenHandler(_configuration);
            Token token=handler.CreateAccsessToken(user);

            user.RefreshToken=token.RefreshToken;
            user.RefreshTokenExpireDate=DateTime.Now.AddMinutes(5);
            _dbcontext.SaveChanges();
            
            return token;

        }
        else
        throw new InvalidOperationException("Kullanıcı adı ve şifre hatalı");

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }

}