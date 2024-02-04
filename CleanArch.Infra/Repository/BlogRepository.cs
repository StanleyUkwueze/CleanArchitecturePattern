using CleanArch.Domain.Entitiy;
using CleanArch.Domain.Repository;
using CleanArch.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext context;

        public BlogRepository(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
          await context.Blogs.AddAsync(blog);
          await context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await context.Blogs.Where(m => m.Id == id)
                 .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await context.Blogs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await context.Blogs.Where(model => model.Id == id)
                                 .ExecuteUpdateAsync(setters => setters
                                   .SetProperty(m=>m.Name, blog.Name)
                                   .SetProperty(m=> m.Description, blog.Description)
                                   .SetProperty(m=>m.Author, blog.Author)
                                   );
        }
    }
}
