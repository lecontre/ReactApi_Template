using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public static class Details
    {
        public record Query(Guid Id) : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities.FindAsync(request.Id);
                return result == null ? null : new Response(result);
            }
        }

        public record Response(Activity Activity);
    }
}
