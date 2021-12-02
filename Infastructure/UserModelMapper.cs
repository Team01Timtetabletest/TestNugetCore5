using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure
{
    public class User : Profile
    {
        public User()
        {
            var mapper = CreateMap<User, UserModel>();
            /*mapper.ForMember(d => d.userId, opt => opt.MapFrom(s => s.Id));*/
        }
    }
}
