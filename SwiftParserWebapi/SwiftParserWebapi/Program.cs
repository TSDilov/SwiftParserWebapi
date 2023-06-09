using SwiftparserData.Interfaces;
using SwiftParserWebapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataServices();
builder.Services.AddBusinessServices();
builder.Services.AddWebServices();

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

MigrateDb(builder);

app.Run();

static void MigrateDb(WebApplicationBuilder builder)
{
    var serviceProvider = builder.Services.BuildServiceProvider();

    var dbContext = serviceProvider.GetService<IDbContext>();

    dbContext.CreateIfNotExist();
}