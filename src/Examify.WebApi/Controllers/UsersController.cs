using Examify.Application.Interfaces;
using Examify.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Examify.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = userService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await userService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        try
        {
            await userService.CreateAsync(userDto);
            return Ok("Created");
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message + exception.StackTrace);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UserDto userDto)
    {
        try
        {
            await userService.UpdateAsync(userDto);
            return Ok("Updated");
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message + exception.StackTrace);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await userService.DeleteAsync(id);
            return Ok("Deleted!");
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message + exception.StackTrace);
        }
    }
}