using Amazon;
using Amazon.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Handler
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, UserWithOrdersResult>
    {
        private readonly DataContext _context;

        public GetUserOrdersQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<UserWithOrdersResult> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var userWithOrders = await (from u in _context.Users
                    where u.UserId == request.UserId
                    select new UserWithOrdersResult
                    {
                        UserName = u.UserName,
                        Orders = _context.Orders
                            .Where(o => o.UserId == u.UserId)
                            .ToList()
                    })
                .FirstOrDefaultAsync();

            return userWithOrders;
        }
    }

    }

    public class CheckUserExistenceQueryHandler : IRequestHandler<CheckUserExistenceQuery, bool>
    {
        private readonly DataContext _context;

        public CheckUserExistenceQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckUserExistenceQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.UserId == request.UserId);
        }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly DataContext _context;

        public GetUserByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.UserId);
        }
    }
