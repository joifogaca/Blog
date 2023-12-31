using Blog.Data;
using Blog.Models;
using Blog.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        //[HttpGet("categorias")] Tem a opção de mapear 2x o HttpGet, Exemplo 2 idiomas
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context) {
            try
            {
                var categories = await context.Categories.ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<List<Category>>( "05X07 - Falha interna no servidor"));
            }

        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado!"));

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Category>( "05X078 - Falha interna no servidor"));
            }
            
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext context)
        {
            //Essa válidação já é feita automaticamente pelo .net com o modelo do FromBody, quando usado anotation [ApiController] 
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug.ToLower()
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", category);
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
            [FromBody] EditorCategoryViewModel model,
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            try
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
            catch (DbUpdateException ex) //exeção o catch pega a mais especifica e as abaixos podem ser mais genericas
            {
                return StatusCode(500, "05X11 - Não foi possivél alterar a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05X12 - Falha interna no servidor");
            }


        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
           [FromRoute] int id,
           [FromServices] BlogDataContext context)
        {
            try
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
            catch (DbUpdateException ex) //exeção o catch pega a mais especifica e as abaixos podem ser mais genericas
            {
                return StatusCode(500, "05X13 - Não foi possivél excluir a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05X14 - Falha interna no servidor");
            }


        }
    }
}
