using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using MongoExample.Services;

namespace MongoExample.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserlistController : Controller

{
    private readonly UserService _userServices;
    public UserlistController(UserService userServices)
    {
        _userServices =userServices;
    }

    [HttpGet]
    public async Task<List<Userlist>> Get()
    {
        return await _userServices.GetAsync();
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Userlist userlist)
    {
        await _userServices.CreateAsync(userlist);
        return CreatedAtAction(nameof(Get), new { id = userlist.Id }, userlist);
    }




    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Userlist updatebus)
    {
        await _userServices.UpdateAsync(id, updatebus);
        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userServices.DeleteAsync(id);
        return NoContent();
    }
}