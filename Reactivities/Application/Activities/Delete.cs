﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public static class Delete
    {
        public record Command(Guid Id) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                _context.Remove(activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
