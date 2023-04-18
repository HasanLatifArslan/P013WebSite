using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P013WebSite.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Display(Name = "Soyad"), StringLength(50)]
		public string? Surname { get; set; }
		[StringLength(50)]
		public string? Email { get; set; }
		[Display(Name = "Telefon"), StringLength(50)]
		public string? Phone { get; set; }
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		[Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
		public DateTime CreateDate { get; set; } = DateTime.Now;
		[Display(Name = "Durum")]
		public bool IsActive { get; set; }
		[Display(Name = "Admin")]
		public bool IsAdmin { get; set; }

	}
}
