using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MicroServiceAPITutorial.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Put
{
    public record UpdateCategoryCommand(Guid Id, CategoryDTO categoryDTO) : IRequest<Category>
    {
    }

    public class UpdateCategorieCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly IAppDBContext _context;
        private readonly IMapper _mapper;
        public UpdateCategorieCommandHandler(IAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(category => category.ID == request.Id).FirstOrDefaultAsync();
            // Aquí manejar excepción
            if (result == null) return null;

            result.Description = request.categoryDTO.Description;
            result.Habilited = request.categoryDTO.Habilited;

            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
