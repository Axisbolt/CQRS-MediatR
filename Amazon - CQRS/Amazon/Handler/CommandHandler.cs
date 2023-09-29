using Amazon.Models;
using MediatR;

namespace Amazon.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DataContext _context;

        public CreateUserCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = request.UserId,
                UserName = request.UserName,
                Email = request.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }
    }


}
