namespace MediatRManual.Features.Users.Commands.Create
{
    public record CreateUserCommand(string nome, string sobrenome, string cpf);
}
