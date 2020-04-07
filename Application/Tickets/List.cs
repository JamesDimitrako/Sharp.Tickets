using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Apllication.Tickets
{
    public class List
    {
        public class Query : IRequest<List<Ticket>> { };

        public class Handler : IRequestHandler<Query, List<Ticket>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Ticket>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tickets = await _context.Tickets.ToListAsync();

                return tickets;
            }
        }
    }
}