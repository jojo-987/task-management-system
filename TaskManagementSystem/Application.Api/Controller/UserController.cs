using Microsoft.AspNetCore.Mvc;
using Application.AppService.Contract;
using Application.Infrastructure.Entities;

namespace Application.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly Iservice _service;

    public UserController(Iservice service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await _service.GetAllUser();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _service.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> AddUSers (User user)
    {
      return Ok (await _service.AddUser(user));
    }
}
