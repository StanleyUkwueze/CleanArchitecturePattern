using CleanArch.Domain.Entitiy;
using CleanArch.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpldateBlogCommand, int>
    {
        private readonly IBlogRepository blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpldateBlogCommand request, CancellationToken cancellationToken)
        {

            var blogToUpdate = new Blog
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };
          return await blogRepository.UpdateAsync(request.Id, blogToUpdate);
        }
    }
}
