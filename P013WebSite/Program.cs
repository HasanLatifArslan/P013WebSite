using Microsoft.Build.Framework;
using P013WebSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // admin panelde oturum i�lemi i�in 
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DatabaseContext>();// burada veritaban� i�lemleri i�in kulland���m�z contexti tan�yoruz veritaban� oolu�turmak i�in �st menden tools nugget package managerdan package manager console men�s�n� a��yoruz bu ekranda add--migration �n�t�alcreate yaz�p enttera bas�yoruz
// migrations klas�r� ve initialcreatte class� olu�tuktan sonra update-database yaz�p entera 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
	x.LoginPath = "/Admin/Login"; // login sisteminin varsay�lan login giri� adresini kendi adresimizle de�i�tiriyoruz
	x.Cookie.Name = "AdminLogin"; // oturum i�in olu�acak cookie nin ismini belirledik 
}); // admin panelde authorize attrib�te � ile g�venlik sa�layabilmek i�in 
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
		   name: "admin",
		   pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
		 );
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
