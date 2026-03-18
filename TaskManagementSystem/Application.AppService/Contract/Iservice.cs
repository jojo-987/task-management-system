namespace Application.AppService.Contract;

using Application.AppService.DTOs;

using Application.Infrastructure.Contract;
using Application.Infrastructure.Entities;
public interface Iservice
{

    Task<List<User>> GetAllUser();
 
    Task<User> Get(int id);
  Task<User>AddUser(User user);

// Task<User>Update(UserDto dto);
// Task<User>Delete(int id );
}
