namespace Tests.TestSetup;
using WebApi.Entities;
using WebApi.DbOperations;

public static class Authors
{
    public static void AddAuthor(this BookStoreDbContext context)
    {
            context.Authors.AddRange(
            new Author{
                //Id=1,
                Name="Sinan",
                Surname="Canan",
                Birthday= new DateTime(1973,02,23)
                

            },
                new Author{
                //Id=2,
                Name="Ahmet Hamdi",
                Surname="Tanpınar",
                Birthday= new DateTime(1970,03,13)

            },
            new Author{
                //Id=3,
                Name="Muzaffer",
                Surname="İzgü",
                Birthday= new DateTime(1965,01,03)

            });
    }
}