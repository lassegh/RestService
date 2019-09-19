using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> bookList = new List<Book>
        {
            new Book("I offentlighedens tjeneste",400,"9788793772137","Politiken"),
            new Book("Simones perlebog",100,"9788793825000","Simone"),
            new Book("Ternet Ninja",272,"9788763859646","Anders Matthesen"),
            new Book("De smaa synger",127,"9788714195519","Benita Haastrup"),
            new Book("Funny Face",25,"9978814155520","Funny Face")
        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(string id)
        {
            return bookList.Find(b => b.ISbn == id);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bookList.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book value)
        {
            Book book = Get(id);
            if (book != null)
            {
                Delete(book.ISbn);
                value.ISbn = id;
                bookList.Add(value);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Book book = Get(id);
            if (book != null)
            {
                bookList.Remove(book);
            }
        }
    }
}
