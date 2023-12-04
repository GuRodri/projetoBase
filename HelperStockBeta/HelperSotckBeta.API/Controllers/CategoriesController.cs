namespace HelperSotckBeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService

        public CategoriesController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ExceptionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if(categories == null)
            {
                return NotFound("Categoria not found");
            }

            return Ok(categories);
        }

        [HttpGet(("id:int"), Name="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if(category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if(categoryDto == null)
            {
                return BadResquest("Invalid Body Data")
            }

            await _categoryService.Add(categoryDto);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }); categoryDto;
        }
        [HttpPut]

        public async Task<ActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if(id != categoryDto.Id)
            {
                return BadResquest("Id not verificated");
            }

            if (categoryDto == null)
            {
                return BadRequest("DTO inspc fail");
            }

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if(category == null)
            {
                return NotFound("The category delete not found");
            }

            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}
