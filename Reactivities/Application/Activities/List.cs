using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public static class List
    {
        public record Query : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _context.Activities.ToListAsync();

                return results == null ? null : new Response(results);
            }
        }

        public record Response(List<Activity> Activities);
    }
}
