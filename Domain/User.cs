﻿namespace MediatRManual.Domain
{
    public class User
    {
        public Guid Id { get; init; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
    }
}
