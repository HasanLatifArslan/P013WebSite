using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace P013WebSite.Entities
{
	public class Product
	{
		public int Id { get; set; }
		[Display(Name = "Ürün Adı"), StringLength(50)]
		public string Name { get; set; }
		[Display(Name = "Ürün Açıklaması")]

		public string? Description { get; set; }
		[Display(Name = "Ürün Fiyatı")]
		public decimal? Price { get; set; }
		[Display(Name = "Stok")]
		public int Stock { get; set; }
		[Display(Name = "Resim"), StringLength(50)]
		public string? Image { get; set; }
		[Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // oluşacak viewlarda createdate alanının otomatik oluşturulmasını engeller
		public DateTime CreateDate { get; set; } = DateTime.Now;
		[Display(Name = "Kategori")]
		public int CategoryId { get; set; }
		[Display(Name = "Kategori")]
		public Category? Category { get; set; }
		[Display(Name = "Durum")]
		public bool IsActive { get; set; }
		[Display(Name = "Anasayfa")]
		public bool IsHome { get; set; }
		
	}
}
