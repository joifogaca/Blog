using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Blog.Controllers
{
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        //[HttpGet("categorias")] Tem a opção de mapear 2x o HttpGet, Exemplo 2 idiomas
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context) {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if(category == null) 
                return NotFound();

            return Ok(category);
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Category model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                await context.Categories.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{model.Id}", model);
            }
            catch (DbUpdateException ex) //exeção o catch pega a mais especifica e as abaixos podem ser mais genericas
            {
                return StatusCode( 500, "05X09 - Não foi possivél incluir a categoria");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "05X10 - Falha interna no servidor");
            }
          

        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Category model,
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {

            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound();

            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category); //Metódo Update não é assincrono
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
           [FromRoute] int id,
           [FromServices] BlogDataContext context)
        {

            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound();

            context.Categories.Remove(category); //Metódo Remove não é assincrono
            await context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
