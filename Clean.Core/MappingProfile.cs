using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User,UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserPostDTO, User>();
            CreateMap<Vacations,VacationDTO>();
            CreateMap<WorkingHours,WorkingHoursDTO>();
        }
    }
}
