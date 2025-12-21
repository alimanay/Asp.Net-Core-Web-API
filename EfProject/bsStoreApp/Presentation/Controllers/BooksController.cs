using Entites.Exceptions;
using Entites.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var entitys = _manager.BookService.GetAllBook(false);
            return Ok(entitys);
        }
        [HttpGet("GetABook")]
        public IActionResult GetABook(int id)
        {
            var ABook = _manager.BookService.GetOneBookById(id, false);
                return Ok(ABook);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
                if (book is null)
                    return BadRequest();
                _manager.BookService.CreateOneBook(book);
                return StatusCode(201, book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneBook(int id, Book book)
        {  if (book is null)
                    return BadRequest();//400
                _manager.BookService.UpdateOneBook(id, book, true);
                return NoContent();//204
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var entity = _manager.BookService.GetOneBookById(id, false);
            if (entity is null)
            {
                return NotFound();
            }
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }
        [HttpPatch]

        public IActionResult PartialyUpadatePatch([FromRoute(Name = "İd")] int id, [FromBody] JsonPatchDocument<Book> book)
        {  var enitiy = _manager.BookService.GetOneBookById(id, true);
                if (enitiy is null)
                {
                    return NotFound();
                }
                book.ApplyTo(enitiy);
                _manager.BookService.UpdateOneBook(id, enitiy, true);
                return NoContent();
        }
    }
}

