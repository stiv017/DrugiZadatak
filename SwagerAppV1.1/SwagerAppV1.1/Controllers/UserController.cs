using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwagerAppV1._1.DTO;
using SwagerAppV1._1.Model;

namespace SwagerAppV1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly SwagerContext _context;
        public readonly IMapper _mapper;
        public UserController(SwagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        //public async Task<IEnumerable<Users>> Get() => await _context.Users.ToListAsync();
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var users = _context.Users.ToList();
            List<UserDTO> result = _mapper.Map<List<Users>, List<UserDTO>>(users);

            return result;
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            //var group=  await _context.Users.FindAsync(id);
            var group = _context.Users.Find(id);
            var result = _mapper.Map<Users, UserDTO>(group);
            return group == null ? NotFound() : Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<UserDTO> Create(UserDTO user)
        {

            var createUser = _mapper.Map<UserDTO, Users>(user);
            _context.Users.Add(createUser);
            _context.SaveChanges();
            return Ok(createUser);
        }
        /*public async Task<IActionResult> Create(Users user)
        {
             await _context.Users.AddAsync(user);
             await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new{id=user.Id},user);
        }*/
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, UserDTO users)
        {
            if (id != users.Id) BadRequest();
            var updateUser = _mapper.Map<UserDTO, Users>(users);
            // _context.Entry(updateUser).State = EntityState.Modified;
            _context.Users.Update(updateUser);
            _context.SaveChanges();
            return Ok(updateUser);
        }
        /* public async Task<IActionResult> Update(int id,Users user)
         {
             if (id != user.Id) BadRequest();

              _context.Entry(user).State=EntityState.Modified;
             await _context.SaveChangesAsync();
             return NoContent();
         }*/
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            var resultFind = _mapper.Map<Users, UserDTO>(user);

            if (resultFind == null) return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
        /* public async Task<IActionResult> Delete(int id)
         {
            var user = await _context.Users.FindAsync(id);
             if(user==null) return NotFound();
             _context.Users.Remove(user);

             await _context.SaveChangesAsync();

             return NoContent();
         }*/
    }
}
