using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configura��o para conectar ao MySql server


var connectionString = builder.Configuration.GetConnectionString(name: "FilmeConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Auto map

//builder.Services.AddDbContext<FilmeContext>
//    (
//        options =>
//        options.UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"),
//        new MySqlServerVersion(new Version(8,0,29,0)))
//    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
