using AutoMapper;
using CleanArch.Application.Blogs.Queries.GetBlogs;
using CleanArch.Domain.Entitiy;
using CleanArch.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog
            { Name = request.Name, Description=request.Description, Author=request.Author };

            var result = await blogRepository.CreateAsync(blogEntity);

            return mapper.Map<BlogVm>(result);


        }
    }
}
