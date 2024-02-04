using AutoMapper;
using CleanArch.Application.Blogs.Queries.GetBlogs;
using CleanArch.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Queries.GetBlogsById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
           var blog = await blogRepository.GetByIdAsync(request.BlogId);
           var blogVm = mapper.Map<BlogVm>(blog);

            return blogVm;
        }
    }
}
