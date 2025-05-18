namespace MediatRManual.Features.Users.Commands.Update
{
    public record UpdateUserCommand(Guid id, string nome, string sobrenome, string cpf);
}
