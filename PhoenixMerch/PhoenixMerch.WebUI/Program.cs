using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Business.AutoMapper;
using PhoenixMerch.Business.Concrete;
using PhoenixMerch.DataAccess.Abstract;
using PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore;
using PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore.Context;
using PhoenixMerch.Entities.Concrete;
using PhoenixMerch.WebUI.BasketTransaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PhoenixMerchContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<PhoenixMerchContext>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IOrderDal, OrderDal>();
builder.Services.AddScoped<IOrderProcessService, OrderProcessManager>();
builder.Services.AddScoped<IProductOrderDal, ProductOrderDal>();
builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddTransient<IBasketTransaction, BasketTransaction>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
