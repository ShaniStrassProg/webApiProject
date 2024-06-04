using LoginProject.MiddleWare;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using PresidentsApp.Middlewares;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<IRatingService, RatingService>();

builder.Services.AddDbContext<PhotoGalleryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("school")));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Host.UseNLog();
builder.Services.AddControllers();



var app = builder.Build();

app.UseErrorHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.UseRatingMiddleware();


app.Run();
