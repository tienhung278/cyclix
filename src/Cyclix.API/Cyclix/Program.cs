using Cyclix.Entities;
using Cyclix.Repository;
using Cyclix.Services;
using Cyclix.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<RepositoryContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlite(connectionString);
    });
    builder.Services.AddScoped<IBikeRepository, BikeRepository>();
    builder.Services.AddScoped<IBikeServices, BikeServices>();
    builder.Services.AddScoped<IItemRepository, ItemRepository>();
    builder.Services.AddScoped<IItemServices, ItemServices>();
    builder.Services.AddCors(opt =>
    {
        opt.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
            builder.AllowAnyOrigin();
        });
    });
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
