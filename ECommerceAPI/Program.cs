using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();

builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EFCategoryDal>();

builder.Services.AddSingleton<ISubCategoryService, SubCategoryManager>();
builder.Services.AddSingleton<ISubCategoryDal, EFSubCategoryDal>();

builder.Services.AddSingleton<IProductToSubCategoryService, ProductToSubCategoryManager>();
builder.Services.AddSingleton<IProductToSubCategoryDal, EFProductToSubCategoryDal>();

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EFUserDal>();

builder.Services.AddSingleton<IRegionService, RegionManager>();
builder.Services.AddSingleton<IRegionDal, EFRegionDal>();

builder.Services.AddSingleton<IOrderService, OrderManager>();
builder.Services.AddSingleton<IOrderDal, EFOrderDal>();

builder.Services.AddSingleton<IOrderToProductService, OrderToProductManager>();
builder.Services.AddSingleton<IOrderToProductDal, EFOrderToProductDal>();

builder.Services.AddSingleton<IBlogService, BlogManager>();
builder.Services.AddSingleton<IBlogDal, EFBlogDal>();

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
