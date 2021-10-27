using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingApiKey.Attributes;
using Microsoft.AspNetCore.Mvc.Versioning;
using AirportCodes.Models;

namespace AirportCodes.Controllers
{
  //[ApiKey]
  [ApiController]
  [ApiVersion("1.0")]
  //[Route("api/[controller]")]
  [Route("api/airports")]
  public class AirportsV1Controller : ControllerBase
  {
    private readonly AirportCodesContext _db;

    
    public AirportsV1Controller(AirportCodesContext db)
    {
      _db = db;
    }

    // GET: api/Airports
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Airport>>> Get(string code, string city, string name, string biggestAirline)
    {
      var query = _db.Airports.AsQueryable();

      if (code != null)
      {
        query = query.Where(entry => entry.Code.Contains(code));
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }

      if (biggestAirline !=null)
      {
        query = query.Where(entry => entry.BiggestAirline.Contains(biggestAirline));
      }

      return await query.ToListAsync();
    }

    // GET: api/Airports/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Airport>> GetAirport(int id)
    {
        var airport = await _db.Airports.FindAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        return airport;
    }

    // PUT: api/Airports/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Airport airport)
    {
      if (id != airport.AirportId)
      {
        return BadRequest();
      }

      _db.Entry(airport).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AirportExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Airports
    [HttpPost]
    public async Task<ActionResult<Airport>> Post(Airport airport)
    {
      _db.Airports.Add(airport);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAirport), new { id = airport.AirportId }, airport);
    }

    // DELETE: api/Airports/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int id)
    {
      var airport = await _db.Airports.FindAsync(id);
      if (airport == null)
      {
        return NotFound();
      }

      _db.Airports.Remove(airport);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool AirportExists(int id)
    {
      return _db.Airports.Any(e => e.AirportId == id);
    }
  }
}