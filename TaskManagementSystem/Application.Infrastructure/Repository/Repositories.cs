namespace Application.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Application.Infrastructure.Contract;
using Application.Infrastructure.Entities;
using Application.Infrastructure.Data;

using Microsoft.CodeAnalysis.CSharp;


public class Repositories : IRepositories
{
    private readonly TaskManagementSystemDbContext _context;

    public Repositories(TaskManagementSystemDbContext context)
    {
        _context = context;
    }


   public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> Get(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User>Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    // public async Task Update(User users)
    // {
    //     _context.Users.Update(users);
    //     await _context.SaveChangesAsync();
    // }

    // public async Task<User> Delete(int id)
    // {
    //     var user = await Get(id);
    //     if (user != null)
    //     {
    //         _context.Users.Remove(user);
    //         await _context.SaveChangesAsync();
    //     }
    //     return user;
    // }
}