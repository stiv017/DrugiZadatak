using SwagerApi.Models;

namespace SwagerApi.DTO
{
    public class GroupsDTO
    {
        public int IdGrupe { get; set; }
        public string Name { get; set; }
       public List<UsersDTO> Users { get; set; }
    }
}
