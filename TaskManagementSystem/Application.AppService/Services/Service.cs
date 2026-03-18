using Application.AppService.Contract;
using Application.Infrastructure.Contract;
using Application.Infrastructure.Entities;


namespace Application.AppService.Services;

public class Service:Iservice
{
    private readonly IRepositories _service;

    public Service(IRepositories service)
    {
        _service=service;
    }
   public async Task<List<User>> GetAllUser()
    {
      return await _service.GetAll();
    }

    public async Task<User> Get(int id)
    {
        return await _service.Get(id);
    }
    public async Task<User>AddUser(User user)
    {
        return await _service.Add(user);
    }
}
