using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MicroServiceAPITutorial.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands
{
    public record CreateCategoryCommand : IRequest<Guid>
    {
        public CategoryDTO? CategoryDTO { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        // Quería crear con IBaseRepository pero no me ha dejado
        private readonly IAppDBContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request.CategoryDTO);
            category.ID = Guid.NewGuid();
            category.Created = DateTime.Now;
            category.Modified = DateTime.Now;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.ID;
        }
    }
}
