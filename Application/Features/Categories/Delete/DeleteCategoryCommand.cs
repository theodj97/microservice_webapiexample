using Application.Common.Interfaces;
using Application.Features.Categories.Get;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Delete
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<Guid>
    {
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Guid>
    {
        // Quería crear con IBaseRepository pero no me ha dejado
        private readonly IAppDBContext _context;
        public DeleteCategoryCommandHandler(IAppDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Categories
            //.FindAsync(new object[] { request.Id }, cancellationToken);

            var result = await _context.Categories.Where(category => category.ID == request.Id).FirstOrDefaultAsync();
            // Aquí manejar excepción
            if (result == null) throw new Exception();

            _context.Categories.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);
            return result.ID;
        }
    }
}
