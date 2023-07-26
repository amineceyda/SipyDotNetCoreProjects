using Microsoft.EntityFrameworkCore;
using QuoteApi.DbOperations;
using QuoteApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext as a service with in-memory database
builder.Services.AddDbContext<QuoteDbContext>(options => options.UseInMemoryDatabase(databaseName: "QuoteDB"));

var app = builder.Build();

// Seed the initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerators.initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Register custom middlewares here
app.UseMiddleware<GlobalLogging>();
app.UseMiddleware<GlobalException>();

app.MapControllers();

app.Run();