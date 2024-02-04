using CleanArch.Application.Blogs.Commands.CreateBlog;
using CleanArch.Application.Blogs.Commands.DeleteBlog;
using CleanArch.Application.Blogs.Commands.UpdateBlog;
using CleanArch.Application.Blogs.Queries.GetBlogs;
using CleanArch.Application.Blogs.Queries.GetBlogsById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : APIBaseController
    {
        public BlogController() 
        { 

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());

            if (blogs.Count < 0) return NotFound();

            return Ok(blogs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id) 
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId=id});

            if (blog == null) return NotFound(blog);

            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createdBlog = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id=createdBlog.Id}, createdBlog);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await Mediator.Send(new DeleteBlogCommand() {Id = id });

            if (blog < 0) return NotFound(blog);

            return Ok(blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpldateBlogCommand command)
        {
            command.Id = id;

            var result = await Mediator.Send(command);
            if(result < 1) return BadRequest();
            return Ok("Blog Successfully updated");
        }
    }
}
