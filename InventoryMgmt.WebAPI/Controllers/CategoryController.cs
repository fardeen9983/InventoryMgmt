using InvnetoryMgmt.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace InventoryMgmt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private  List<Category> _categories;

        public CategoryController()
        {
            var now = DateTime.Now; ;

            _categories = new List<Category>
            {
                new Category(id: 1, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 2, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 3, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 4, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 5, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 6, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
                new Category(id: 7, name: "Book", createdAt: now, description: "Ready to sell books from all genres"),
            };
        }
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Category>> GetAll()
        {
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Category? category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }
            return Ok(category);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] Category category)
        {

            try
            {
                category.Id = _categories.Count() + 1;
                _categories.Add(category);
                Console.WriteLine(_categories.Count());
                return Ok("Category Added Succesfully");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Update([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("No Category data was passed");
            }
            else
            {
                Category? occurence = _categories.FirstOrDefault(c => c.Id == category.Id);
                if (occurence == null)
                {
                    return NotFound($"Category with id {category.Id} not found");
                }
                else
                {
                    
                    _categories.Remove(occurence);
                    _categories.Add(category);
                    return Ok("Update successfull");
                }
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Category? category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }
            else
            {
                bool resukt = _categories.Remove(category);
                if (resukt)
                {
                    return Ok($"Category id {id}, removed successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong. Please try again");
                }
            }
        }


        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAll()
        {
            _categories.Clear();
            return Ok("All categories have been removed");
        }
    }
}
