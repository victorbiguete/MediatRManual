using MediatRManual.Domain;
using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediatRManual.Features.Users.Queries.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly AppDBContext _context;

        public GetAllUserHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
