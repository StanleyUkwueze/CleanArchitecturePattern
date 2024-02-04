using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Common.Mappings
{
    public interface IMapperFrom<T> 
    {
        void Mapper(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
