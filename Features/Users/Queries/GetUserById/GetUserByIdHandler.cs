using MediatRManual.Domain;
using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediatRManual.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly AppDBContext _context;

        public GetUserByIdHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request)
        {
            var user = await _context.Users.Where(u => u.Id == request.id).FirstOrDefaultAsync();

            return user;
        }
    }
}
