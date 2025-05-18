using MediatRManual.Domain;
using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;

namespace MediatRManual.Features.Users.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly AppDBContext _context;

        public CreateUserHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request)
        {
            var user = new User
            {
                CPF = request.cpf,
                Id = Guid.NewGuid(),
                Nome = request.nome,
                Sobrenome = request.sobrenome
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
