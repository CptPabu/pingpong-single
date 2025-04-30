using Model;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;
using User_Management.ExceptionHandlers;
using User_Management.Middlewares;

using Logic;
using Logic.Transformers.Interfaces;
using Logic.Factories;
using Logic.Factories.Interfaces;
using Logic.DTOs.Interfaces;
using Logic.DTOs.Exceptions;
using Logic.DTOs.Requests;
using Logic.DTOs.Responses;
using Logic.Transformers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// repository
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddSingleton<IRepository<Game>, GameRepository>();
builder.Services.AddSingleton<IRepository<Score>, ScoreRepository>();
builder.Services.AddSingleton<IRepositoryUser, UserRepository>();
// logic
builder.Services.AddSingleton<GameplayLogic>();
builder.Services.AddSingleton<UserLogic>();
builder.Services.AddSingleton<ITransformer<UserCreateRequest, User>, UserTransformer>();
builder.Services.AddSingleton<ITransformer<User, UserResponse>, UserResponseTransformer>();
builder.Services.AddSingleton<IFactory<GameCreateRequest, Game>, GameplayFactory>();
builder.Services.AddSingleton<ITransformer<Score, ScoreResponse>, ScoreResponseTransformer>();
builder.Services.AddSingleton<ITransformer<Game, GameResponse>, GameResponseTransformer>();
// logic -  exceptions
builder.Services.AddSingleton<IExceptionHandler, NoGameFoundExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, NoUserFoundExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, PasswordMismatchExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, UsernameAlreadyTakenExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, WrongUsernameOrPasswordExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, DefaultExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
