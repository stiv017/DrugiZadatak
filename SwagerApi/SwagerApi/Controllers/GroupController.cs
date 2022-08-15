using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwagerApi.DTO;
using SwagerApi.Models;

namespace SwagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        public readonly SwagerContext _context;
        public readonly IMapper _mapper;
        public GroupController(SwagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
       
        public async Task<IEnumerable<GroupsDTO>> Get()
        {
            var groups = _context.Groups.ToList();
            List<GroupsDTO> result = _mapper.Map<List<Groups>, List<GroupsDTO>>(groups);

            return result;
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            //var group=  await _context.Users.FindAsync(id);
            var group = _context.Groups.Find(id);
            var result = _mapper.Map<Groups, GroupsDTO>(group);
            return group == null ? NotFound() : Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<GroupsDTO> Create(GroupsDTO group)
        {

            var createGroup = _mapper.Map<GroupsDTO, Groups>(group);
            _context.Groups.Add(createGroup);
            _context.SaveChanges();
            return Ok(createGroup);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, GroupsDTO groups)
        {
            if (id != groups.IdGrupe) BadRequest();
            var updateGroup = _mapper.Map<GroupsDTO, Groups>(groups);
            // _context.Entry(updateUser).State = EntityState.Modified;
            _context.Groups.Update(updateGroup);
            _context.SaveChanges();
            return Ok(updateGroup);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            var group= _context.Groups.Find(id);
            var resultFind = _mapper.Map<Groups, GroupsDTO>(group);

            if (resultFind == null) return NotFound();
            _context.Groups.Remove(group);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
