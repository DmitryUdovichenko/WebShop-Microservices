using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController( ICategoryRepository categoryRepository, ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                return Ok(category);
            }
            _logger.LogError($"Category not found: id {id}");
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category category)
        {
            await _categoryRepository.Create(category);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            return Ok(await _categoryRepository.Update(category));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _categoryRepository.Delete(id));
        }
    }
}
