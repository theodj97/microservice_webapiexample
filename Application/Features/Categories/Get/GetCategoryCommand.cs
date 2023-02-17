using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Get
{
    public record GetCategoryCommand(Guid Id) : IRequest<Category>
    {
    }
    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, Category>
    {
        // Quería crear con IBaseRepository pero no me ha dejado
        private readonly IAppDBContext _context;
        public GetCategoryCommandHandler(IAppDBContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(category => category.ID == request.Id).FirstOrDefaultAsync();
            return category;
        }
    }
}
