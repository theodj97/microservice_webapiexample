using Application.Common.Interfaces;
using Application.Features.Categories.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MicroServiceAPITutorial.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Get
{
    public record GetCategoriesCommand : IRequest<List<Category>>
    {
    }
    public class GetCategoriesCommandHandler : IRequestHandler<GetCategoriesCommand, List<Category>>
    {
        // Quería crear con IBaseRepository pero no me ha dejado
        private readonly IAppDBContext _context;
        public GetCategoriesCommandHandler(IAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            return categories;
        }
    }
}
