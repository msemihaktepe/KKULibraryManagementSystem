using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Library.Business.Abstract;
using Library.Business.Concrete;
using Library.Business.Validation;
using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.EntityFramework;
using Library.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Reflection;
using Position = Library.Entity.Concrete.Position;
using Type = Library.Entity.Concrete.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IBookDal, EfBookDal>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IValidator<Book>, BookValidations>();

builder.Services.AddScoped<ITypeDal, EfTypeDal>();
builder.Services.AddScoped<ITypeService, TypeManager>();
builder.Services.AddScoped<IValidator<Type>, TypeValidations>();

builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IValidator<Author>, AuthorValidations>();


builder.Services.AddScoped<IBorrowedBookService, BorrowedBookManager>();
builder.Services.AddScoped<IBorrowedBookDal, EfBorrowedBookDal>();


builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IValidator<User>, UserValidations>();


builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IValidator<Message>, MessageValidations>();


builder.Services.AddScoped<IPositionService, PositionManager>();
builder.Services.AddScoped<IPositionDal, EfPositionDal>();
builder.Services.AddScoped<IValidator<Position>, PositionValidations>();

builder.Services.AddScoped<IRuleService, RuleManager>();
builder.Services.AddScoped<IRuleDal, EfRuleDal>();
builder.Services.AddScoped<IValidator<Rule>, RuleValidations>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();



builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 4;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Loginout/Login/";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loginout}/{action=Login}/{id?}");

app.Run();
