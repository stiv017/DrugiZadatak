using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwagerAppV1._1.DTO;
using SwagerAppV1._1.Model;

namespace SwagerAppV1._1.Controllers
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

        public async Task<IEnumerable<GroupDTO>> Get()
        {
            

            var groups = _context.Groups.Select(groups => new GroupDTO()
            {
                IdGrupe = groups.IdGrupe,
                Name = groups.Name,
                Users = groups.User.Select(u => new UserDTO() { Id = u.Id, Name = u.Name, Email = u.Email, Password = u.Password, idGrupe = u.IdGrupe }).ToList()
            }).ToList();
            
            return groups;
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            
            var group = _context.Groups.Where(n => n.IdGrupe == id).Select(groups => new GroupDTO()
            {
                IdGrupe = groups.IdGrupe,
                Name = groups.Name,
                Users = groups.User.Select(u => new UserDTO() {Id=u.Id,Name=u.Name,Email=u.Email,Password=u.Password,idGrupe=u.IdGrupe}).ToList()
            }).FirstOrDefault();
            
            return group == null ? NotFound() : Ok(group);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<GroupDTO> Create(GroupDTO group)
        {

            var createGroup = _mapper.Map<GroupDTO, Groups>(group);

            _context.Groups.Add(createGroup);
            _context.SaveChanges();
            return Ok(createGroup);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, GroupDTO groups)
        {
            if (id != groups.IdGrupe) BadRequest();
            var updateGroup = _mapper.Map<GroupDTO, Groups>(groups);
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
            var group = _context.Groups.Find(id);
            var resultFind = _mapper.Map<Groups, GroupDTO>(group);

            if (resultFind == null) return NotFound();
            _context.Groups.Remove(group);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
