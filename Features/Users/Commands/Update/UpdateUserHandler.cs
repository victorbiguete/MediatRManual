using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediatRManual.Features.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly AppDBContext _context;

        public UpdateUserHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request)
        {
            var user = await _context.Users.Where(u => u.Id == request.id).FirstOrDefaultAsync();

            if (user == null)
                return false;

            user.Nome = !string.IsNullOrEmpty(request.nome) ? request.nome : user.Nome;

            user.Sobrenome = !string.IsNullOrEmpty(request.sobrenome) ? request.sobrenome : user.Sobrenome;

            user.CPF = !string.IsNullOrEmpty(request.cpf) ? request.cpf : user.CPF;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
