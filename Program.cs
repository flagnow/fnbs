using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;
using fnbs.Core.Services;
using fnbs.Infra.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(
    "User Id=postgres;Password=fydqum-puBzy3-cydpyt;Server=db.giyrsyklsjpsrevgdptc.supabase.co;Port=5432;Database=postgres"));


builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IScopesService, ScopeService>();
builder.Services.AddScoped<IScopeRepo, ScopeRepo>();
builder.Services.AddScoped<IAbListRepo, AbListRepo>();
builder.Services.AddScoped<IAbListService, AbService>();

builder.Services.AddControllers();
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
