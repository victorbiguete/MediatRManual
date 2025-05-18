using MediatRManual.Domain;
using MediatRManual.Features.Users.Commands.Create;
using MediatRManual.Features.Users.Commands.Delete;
using MediatRManual.Features.Users.Commands.Update;
using MediatRManual.Features.Users.Queries.GetAllUser;
using MediatRManual.Features.Users.Queries.GetUserById;
using MediatRManual.Infrastructure.Data;
using MediatRManual.Interface;
using MediatRManual.Mediatr;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMediatr,Mediator>();
builder.Services.AddScoped<IRequestHandler<CreateUserCommand,bool>,CreateUserHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllUserQuery,List<User>>,GetAllUserHandler>();
builder.Services.AddScoped<IRequestHandler<GetUserByIdQuery,User>,GetUserByIdHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand,bool>,UpdateUserHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserByIdCommand,bool>,DeleteUserByIdHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
