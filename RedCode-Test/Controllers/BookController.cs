using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedCode_Test.Data;
using RedCode_Test.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedCode_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Book>>>GetAll()
        {
            return Ok(await _dbContext.Books.ToListAsync());
        }

        [HttpGet]
        [Route("{string}")]
        public async Task<ActionResult<Book>> GetOne(string title)
        {
            var hero = _dbContext.Books.Find(title);

            if (hero == null)
            {
                return BadRequest("Book not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostHero(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Books.ToListAsync());
        }

        [HttpPatch]
        [Route("{id}")]
        //[Route("Patch/{id:int}")]
        public async Task<ActionResult<Book>>
        PatchHero(JsonPatchDocument hero, int id)
        {
            var heroToUpdate = await
                _dbContext.Books.FindAsync(id);

            if (heroToUpdate == null)
            {
                return BadRequest("Book not found");
            }

            hero.ApplyTo(heroToUpdate);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Books.ToListAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        //[Route("Delete/{id:int}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return BadRequest("Book not found");
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Books.ToListAsync());
        }
    }
}

