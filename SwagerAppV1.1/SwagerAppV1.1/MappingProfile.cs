using AutoMapper;
using SwagerAppV1._1.DTO;
using SwagerAppV1._1.Model;

namespace SwagerAppV1._1
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<UserDTO, Users>().ReverseMap();

            CreateMap<Groups, GroupDTO>().ReverseMap();
            CreateMap<GroupDTO, Groups>().ReverseMap();
        }
    }
}
