using System.Reflection;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Infrastructure.Repositories;
using LibraryManagementSystem.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Application.Commands; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GetBookUseCase>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<GetUsersUseCase>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<BookModel>();


builder.Services.AddScoped<GetUsersQuery>();
builder.Services.AddScoped<CreateUserCommand>();
builder.Services.AddScoped<DeleteUserCommand>();
builder.Services.AddScoped<UpdateUserCommand>();
builder.Services.AddScoped<GetUsersByIdQuery>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagementSystem V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
