namespace Application.Infrastructure.Contract;
using Application.Infrastructure.Entities;
public interface IRepositories
{
    
Task<List<User>>GetAll();
 Task <User>Get(int id);
Task<User>Add(User user);

// Task<User>Update(User user);
// Task<User>Delete(int id );


}
