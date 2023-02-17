using Application.Common.Interfaces;
using Application.Mapper;
using AutoMapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Migrations.MigrationFactory;
using Microsoft.EntityFrameworkCore;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddTransient<IAppDBContext, AppDBContext>();

// Conection to the server
var connectionString = builder.Configuration.GetConnectionString(EnvironmentConnection());
// Creating context
builder.Services.AddDbContext<AppDBContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

// Mapper
var mapperConfing = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mapperConfing.CreateMapper();
// Singleton porque va a ser el mismo mapper para toda la aplicación
builder.Services.AddSingleton(mapper);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateCategorieCommandHandler).Assembly);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// En Gestamp no se utilizan las migraciones, pero para estos ejemplos es útil
var scoope = app.Services.CreateScope();
MigrationFactory migration = new MigrationFactory(scoope.ServiceProvider);
await migration.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


string EnvironmentConnection()
{
    if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
    {
        return "ContainerConnection";
    }
    else
    {
        return "DefaultConnection";
    }
}
