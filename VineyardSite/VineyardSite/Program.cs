using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VineyardSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer("Server=localhost,1433;Database=VineyardSite;User Id=sa;Password=Zakuro19920120;Encrypt=false;");
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Server=localhost,1433;Database=VineyardSite;User Id=sa;Password=Zakuro19920120;Encrypt=false;");
});

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