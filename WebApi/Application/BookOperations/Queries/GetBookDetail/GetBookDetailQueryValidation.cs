
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using FluentValidation;

namespace WebApi.Application.BookOperations.GetBookDetail;

public class GetBookDetailQueryValidation : AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidation()
    {
        RuleFor(query=>query.bookId).NotEmpty().GreaterThan(0);

    }
    
}