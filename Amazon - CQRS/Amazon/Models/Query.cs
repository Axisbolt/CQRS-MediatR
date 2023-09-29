using MediatR;

namespace Amazon.Models
{
    public class GetUserQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }

    public class CheckUserExistenceQuery : IRequest<bool>
    {
        public int UserId { get; set; }
    }


    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }

    public class GetUserOrdersQuery : IRequest<UserWithOrdersResult>
    {
        public int UserId { get; set; }
    }

}
