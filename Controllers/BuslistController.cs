using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using MongoExample.Services;

namespace MongoExample.Controllers;

[Controller]
[Route("api/[controller]")]
public class BuslistController : Controller

{
    private readonly BusService _busServices;
    public BuslistController(BusService busServices)
    {
        _busServices = busServices;
    }

    [HttpGet]
    public async Task<List<Buslist>> Get()
    {
        return await _busServices.GetAsync();
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Buslist buslist)
    {
        await _busServices.CreateAsync(buslist);
        return CreatedAtAction(nameof(Get), new { id = buslist.Id }, buslist);
    }




    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Buslist updatebus)
    {
        await _busServices.UpdateAsync(id, updatebus);
        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _busServices.DeleteAsync(id);
        return NoContent();
    }
}