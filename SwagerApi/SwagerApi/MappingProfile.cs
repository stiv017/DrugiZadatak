using AutoMapper;
using SwagerApi.DTO;
using SwagerApi.Models;

namespace SwagerApi
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<UsersDTO, Users>().ReverseMap();

            CreateMap<Groups, GroupsDTO>().ReverseMap();
            CreateMap<GroupsDTO, Groups>().ReverseMap();
        }
    }
}
