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




    // [HttpPut("{id}")]
    //  public async Task<IActionResult> AddToBuslist(string id, [FromBody] string movieId){
    //     await _busServices.AddToBuslistAsync(id, movieId);
    //     return NoContent();
    //  }



    [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(string id){
        await _busServices.DeleteAsync(id);
        return NoContent();
     }
}