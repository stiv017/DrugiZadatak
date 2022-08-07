using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwagerApi.Models;

namespace SwagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        public readonly SwagerContext _context;
        public GroupController(SwagerContext context)=>_context=context;

        [HttpGet]
        public async Task<IEnumerable<Users>> Get() => await _context.Users.ToListAsync();
        [HttpGet("id")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
          var group=  await _context.Users.FindAsync(id);
            return group == null ? NotFound() : Ok(group);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Users user)
        {
             await _context.Users.AddAsync(user);
             await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new{id=user.Id},user);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id,Users user)
        {
            if (id != user.Id) BadRequest();

             _context.Entry(user).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
           var user = await _context.Users.FindAsync(id);
            if(user==null) return NotFound();
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
