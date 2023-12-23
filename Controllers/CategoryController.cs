using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class CategoryController : ControllerBase
    {
        [HttpGet("categories")]
        //[HttpGet("categorias")] Tem a opção de mapear 2x o HttpGet, Exemplo 2 idiomas
        public IActionResult Get([FromServices] BlogDataContext context) {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }
    }
}
