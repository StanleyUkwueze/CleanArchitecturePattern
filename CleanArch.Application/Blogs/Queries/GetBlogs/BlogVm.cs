using AutoMapper;
using CleanArch.Application.Blogs.Common.Mappings;
using CleanArch.Domain.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm: IMapperFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
