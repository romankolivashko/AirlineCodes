using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirportCodes.Models;
using System.Linq;

namespace AirportCodes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly AirportCodesContext _db;

    public UsersController(AirportCodesContext db)
    {
      _db = db;
    }

    // GET api/account
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get(string userName, string email, string postedRating)
    {
      var query = _db.ApplicationUsers.AsQueryable();
      if (postedRating != null)
      {
        query = query.Where(entry => entry.PostedRating.Contains(postedRating));
      }
      if (userName != null)
      {
        query = query.Where(entry => entry.UserName.Contains(userName));
      }
      if (email != null)
      {
        query = query.Where(entry => entry.Email.Contains(email));
      }
      return await query.ToListAsync();
    }

    // POST api/ApplicationUsers
    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> Post(ApplicationUser applicationUser)
    {
      _db.ApplicationUsers.Add(applicationUser);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUser), new { id = applicationUser.Id }, applicationUser );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser>> GetUser(int id)
    {
      var applicationUser = await _db.ApplicationUsers.FindAsync(id);

      if (applicationUser == null)
      {
        return NotFound();
      }

      return applicationUser;
    }

    // PATCH: api/Messages/5
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id, ApplicationUser applicationUser)
    {
      if (id != applicationUser.Id)
      {
        return BadRequest();
      }

      _db.Entry(applicationUser).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
      var user = await _db.ApplicationUsers.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _db.ApplicationUsers.Remove(user);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool UserExists(string id)
    {
      return _db.ApplicationUsers.Any(e => e.Id == id);
    }
  }
}