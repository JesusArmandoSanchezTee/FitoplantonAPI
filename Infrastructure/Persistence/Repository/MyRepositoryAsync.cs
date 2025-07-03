using Application.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext _dbcontext;

    public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbcontext = dbContext;
    }
}