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

namespace Application.Categories.Commands
{
    public record CreateCategorieCommand : IRequest<Guid>
    {
        public CategoryDTO categoryDTO { get; set; }
    }
    public class CreateCategorieCommandHandler : IRequestHandler<CreateCategorieCommand, Guid>
    {
        private readonly IAppDBContext _context;
        private readonly IMapper _mapper;
        public CreateCategorieCommandHandler(IAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategorieCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request.categoryDTO);
            category.ID = Guid.NewGuid();
            category.Created = DateTime.Now;
            category.Modified = DateTime.Now;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.ID;
        }
    }
}
