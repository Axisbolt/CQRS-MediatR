using MediatR;

namespace Amazon.Models
{
    public class CreateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class CreateOrder : IRequest<int>
    {
        public int UserId { get; set; }
        public int CourierId { get; set; }
    }
}
