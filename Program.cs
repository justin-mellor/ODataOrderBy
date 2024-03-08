using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataOrderBy.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
builder.Services.AddControllers()
    .AddOData();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
