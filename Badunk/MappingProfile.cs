using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badunk
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInfo, UserDto>();
            CreateMap<UserForCreationDto, UserInfo>();
            CreateMap<TaskForCreationDto, Entities.Models.Task>();
            CreateMap<Entities.Models.Task, TaskDto>();

        }
    }

}
