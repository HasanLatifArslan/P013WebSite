using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DatabaseContext>();// burada veritaban� i�lemleri i�in kulland���m�z contexti tan�yoruz veritaban� oolu�turmak i�in �st menden tools nugget package managerdan package manager console men�s�n� a��yoruz bu ekranda add--migration �n�t�alcreate yaz�p enttera bas�yoruz
// migrations klas�r� ve initialcreatte class� olu�tuktan sonra update-database yaz�p entera bas�yoruz 
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
