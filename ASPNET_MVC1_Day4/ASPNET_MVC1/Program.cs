using ASPNET_MVC.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var services = builder.Services;
services.AddBusinessServices();

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

//Exercise 6
app.MapControllerRoute(
    name: "default",
    pattern: "{area=NashTech}/{controller=Rookies}/{action=GetListPeople}/{id?}");

app.Run();
