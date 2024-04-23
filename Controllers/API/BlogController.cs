using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3.Database;
using Project3.Models;
using Project3.Models.DTO;

namespace Project3.Controllers.API
{
    [Route("API/[controller]")]
    [ApiController]
    public class BlogController(ApplicationDbContext _db,IMapper _mp):ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BlogDTO>))]
        public IActionResult GetBlog()
        {
            var Blogs=_db.Blogs.Include(m=>m.category).ToList();

            return Ok(_mp.Map<List<BlogDTO>>(Blogs));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BlogDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBlog(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var Blogs =_db.Blogs.Include(p=>p.category).FirstOrDefault(m=>m.Id== id);
            if(Blogs == null)
            {
                return NotFound();
            }
            return Ok(_mp.Map<BlogDTO>(Blogs));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBlog(int id)
        {
            if (id <= 0)
                return BadRequest();
            var blog=_db.Blogs.Include(m=>m.category).FirstOrDefault(m=>m.Id == id);
            if(blog == null)
                return NotFound();
            _db.Blogs.Remove(blog);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostBlog(BlogDTO blogDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var blog=_mp.Map<Blog>(blogDTO);
            blog.AuthorName = "momen";
            blog.available=true;
            _db.Blogs.Add(blog);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBlog(BlogDTO blogDTO)
        {
            if(!ModelState.IsValid&&blogDTO.Id<=0)
                return BadRequest();
            var blog = _db.Blogs.Include(m => m.category).FirstOrDefault(m => m.Id == blogDTO.Id);
            if(blog == null) return NotFound();
            _mp.Map<BlogDTO,Blog>(blogDTO,blog);
            _db.SaveChanges();
            return Ok();
        }

    }
}
