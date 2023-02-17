using Application.Features.Categories.Commands;
using Application.Features.Categories.Delete;
using Application.Features.Categories.Get;
using Application.Features.Categories.Put;
using Domain.Entities;
using MicroServiceAPITutorial.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await Mediator.Send(new GetCategoriesCommand());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> Get(Guid Id)
        {
            return await Mediator.Send(new GetCategoryCommand(Id));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Category>> Modify(Guid Id, CategoryDTO CategoryDTO)
        {
            return await Mediator.Send(new UpdateCategoryCommand(Id, CategoryDTO));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Guid>> Delete(Guid Id)
        {
            return await Mediator.Send(new DeleteCategoryCommand(Id));
        }

        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete(Guid Id)
        //{
        //    var result = await _context.Categories.Where(category => category.ID == Id).FirstOrDefaultAsync();
        //    if (result == null) return NotFound();
        //    _context.Categories.Remove(result);
        //    await _context.SaveChangesAsync();
        //    return Ok(result);
        //}
    }
}
