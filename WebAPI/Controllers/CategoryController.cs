using Application.Categories.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MicroServiceAPITutorial.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase
    {
        private readonly IAppDBContext _context;
        private readonly IMapper _mapper;
        public CategoryController(IAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _context.Categories.Where(category => category.Habilited).ToListAsync();
        //    return Ok(result);
        //}

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> Get(Guid Id)
        //{
        //    var result = await _context.Categories.Where(category => category.ID == Id).FirstOrDefaultAsync();
        //    if (result == null) return NotFound();
        //    return Ok(result);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(CategoryDTO categoryDTO)
        //{
        //    var category = _mapper.Map<Category>(categoryDTO);
        //    category.ID = Guid.NewGuid();
        //    category.Created = DateTime.Now;
        //    category.Modified = DateTime.Now;
        //    _context.Categories.Add(category);
        //    await _context.SaveChangesAsync();
        //    return Ok(category);
        //}

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateCategorieCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(CategoryDTO categoryDTO, Guid Id)
        {
            var result = await _context.Categories.Where(category => category.ID == Id).FirstOrDefaultAsync();
            if (result == null) return NotFound();
            result.Description = categoryDTO.Description;
            result.Habilited = categoryDTO.Habilited;
            result.Modified = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _context.Categories.Where(category => category.ID == Id).FirstOrDefaultAsync();
            if (result == null) return NotFound();
            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}
