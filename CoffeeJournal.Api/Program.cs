using CoffeeJournal.Api.Endpoints;
using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Application.UseCases.BrewSessions;
using CoffeeJournal.Infrastructure.Persistence;
using CoffeeJournal.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CoffeeJournalDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("CoffeeJournal")));

builder.Services.AddScoped<
    IBrewSessionRepository,
    BrewSessionRepository>();

builder.Services.AddScoped<CreateBrewSessionHandler>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapBrewSessionEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();