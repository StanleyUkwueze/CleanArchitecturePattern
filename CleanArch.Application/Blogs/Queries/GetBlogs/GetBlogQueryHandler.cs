using AutoMapper;
using CleanArch.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetAllBlogsAsync();

          //var blogsvm =  blogs.Select(x => new BlogVm
          //  {
          //      Author = x.Author,
          //      Name = x.Name,
          //      Id= x.Id,
          //      Description = x.Description
          //  }).ToList();
            var blogsvm =   mapper.Map<List<BlogVm>>(blogs);
            return blogsvm;
        }
    }
}
