using EmployeeSecurityByUsingADO.Data;
using EmployeeSecurityByUsingADO.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRegisterService, RegisterService>();

builder.Services.AddScoped<DataBaseHelper>();

builder.Services.AddControllersWithViews();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=GetUsers}/{id?}");

app.Run();
