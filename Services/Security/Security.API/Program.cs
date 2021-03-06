using System.Reflection;
using Security.Application.Handlers.CommandHandler;
using Security.Core.Repositories.Command.Base;
using Security.Core.Repositories.Query;
using Security.Core.Repositories.Query.Base;
using Security.Infrastructure.Repository.Command;
using Security.Infrastructure.Repository.Command.Base;
using Security.Infrastructure.Repository.Query;
using Security.Infrastructure.Repository.Query.Base;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Registration;
using Security.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Security.Core.Repositories.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Security.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
//using Microsoft.Extensions.DependencyInjection.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddMvc();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SecurityContext>( options => options.UseSqlServer(connectionString));

// Register dependencies
//builder.Services.AddMediatR(typeof(CreateCustomerHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(ModifyPermissionHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
//builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
//builder.Services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPermissionsQueryRepository, PermissionsQueryRepository>();
builder.Services.AddTransient<IPermissionsCommandRepository, PermissionsCommandRepository>();
/**/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "dist")),
    RequestPath = "/dist",
    EnableDirectoryBrowsing = true
});

app.MapControllers();
app.MapRazorPages();
app.UseStaticFiles();

app.Run();

