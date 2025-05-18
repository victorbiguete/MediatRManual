using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediatRManual.Features.Users.Commands.Delete
{
    public class DeleteUserByIdHandler :IRequestHandler<DeleteUserByIdCommand,bool>
    {
        private readonly AppDBContext _context;

        public DeleteUserByIdHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserByIdCommand request)
        {
            var user = await _context.Users.Where(u => u.Id == request.id).FirstOrDefaultAsync();

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
