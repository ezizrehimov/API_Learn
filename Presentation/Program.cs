using Business.MappingProfiles.Products;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Common.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitofWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.MIddlewares;

var builder = WebApplication.CreateBuilder(args);

#region Builder Config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(new ProductMappingProfile());
});
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly(nameof(DataAccess))));
builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>();
#endregion

var app = builder.Build();


#region App Config
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<CustomExceptionMiddleware>();
#endregion


app.Run();
