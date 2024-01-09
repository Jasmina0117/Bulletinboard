using Bulletinboard.Models;
using Bulletinboard.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BulletinboardContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

//ª`¤J services
builder.Services.Scan(scan =>
          scan.FromAssemblyOf<IAnnouncementService>()
          .AddClasses(s => s.Where(c => c.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)))
          .AsImplementedInterfaces()
          .WithScopedLifetime()
       );

//ª`¤J Repository
builder.Services.Scan(scan =>
   scan.FromAssemblyOf<BulletinboardContext>()
   .AddClasses(s => s.AssignableTo<IAnnouncementRepo>())
   .AsImplementedInterfaces()
   .WithScopedLifetime()
);

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

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();