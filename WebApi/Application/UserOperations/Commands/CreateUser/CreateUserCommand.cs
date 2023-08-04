
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.CreateUser;

public class CreateUserCommand
{
    public CreateUserModel Model { get; set; }

    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;
    public CreateUserCommand(IBookStoreDbContext dbcontext,IMapper mapper)
    {
        _mapper=mapper;
        _dbcontext = dbcontext;
    }
    public void Handle()
    {
            var user=_dbcontext.Users.SingleOrDefault(x=>x.Email==Model.Email);
            if(user is not null)
            throw new InvalidOperationException("eklemek istediğiniz kullanıcı zaten mevcut");


            user=_mapper.Map<User>(Model);

            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();

    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

    }

}