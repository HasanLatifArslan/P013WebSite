using Microsoft.EntityFrameworkCore;
using P013WebSite.Entities;

namespace P013WebSite.Data
{
	public class DatabaseContext : DbContext //  DatabaseContext sınıfına entityframewokcore paketinden gelen dbcontext sınıfından kalıtım alıyoruz böylece tüm veritabanı işemlerini yapabileceğiz
	{
		//Projede entitiy framework kullanacak bunun için nuget package managerdan sql server paketi yüklenir. 
		//code first ile classlarımızı kullanarak veritabanı oluşturma veya değiştirme işlemleri için de tools paketini yüklüyoruz
		public DbSet<Category> Categories { get; set; } // EntityFrameworkCore da entity class larımızı kullanarak veritabanı ile nesneler db set 
		public DbSet<Product> Products { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Slider> Slider { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu metot veritabanı ayarlarını yapılandırabileceğimiz metot
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=P013WebSite; trusted_connection=true"); // UseSqlServer ile bu projede veritabanı olarak sql server kullanacağımızı belirttik tırnak içerisindeki alana connection string yani veritabanı bilgilerini yazıyoruz
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
			
		{
			modelBuilder.Entity<User>().HasData( // bu metot veritabanı oluştuktan sonra veritabanında kayıt eklemmizi sağlıyor
				new User() // admin paneline giriş yapabilmek için en az bir tane kullanıcı olması lazım ki bu bilgilerle giriş yapabilelim
				{
					Id = 1,
					Email= "admin@p013WebSite.com",
					IsActive= true,
					IsAdmin= true,
					Name= "Admin",
					Password="123"
				}
				);
			// fluent API

			modelBuilder.Entity<Category>().HasData( // kategoriler tablsouna da aşağıdaki kayıtları ekledik 
				new Category
				{
					Id = 1,
					Name = "Elektronik"
				},
				new Category
				{
					Id = 2,
					Name = "Bilgisayar"
				},
				new Category
				{
					Id = 3,
					Name = "Telefon"
				}


				);
			base.OnModelCreating(modelBuilder);
		}
		// Not : buradaki yapılandırmayı da yaptıktan sonra program.cs ye gidip orada databasecontext sınıfını programa tanımlamamız gerekiyor
	}
}
