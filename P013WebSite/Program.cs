using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DatabaseContext>();// burada veritabaný iþlemleri için kullandýðýmýz contexti tanýyoruz veritabaný ooluþturmak için üst menden tools nugget package managerdan package manager console menüsünü açýyoruz bu ekranda add--migration ýnýtýalcreate yazýp enttera basýyoruz
// migrations klasörü ve initialcreatte classý oluþtuktan sonra update-database yazýp entera basýyoruz 
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
