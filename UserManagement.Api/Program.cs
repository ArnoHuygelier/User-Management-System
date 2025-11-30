using Scalar.AspNetCore;
using UserManagement.Api.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

await builder.InstallDatabaseAsync();

builder.InstallServices();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapScalarApiReference();
}

//Command this line out if you don't want to seed the database on application startup
//await app.SeedDatabaseAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

await app.RunAsync();