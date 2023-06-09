﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P013WebSite.Entities
{
	public class Category
	{
		public int Id { get; set; }
		[Display(Name = "Kategori Adı"), StringLength(50)]
		public string Name { get; set; }
		[Display(Name = "Kategori Açıklaması")]
		public string? Description { get; set; }
		[Display(Name = "Eklenme Tarihi")]
		public DateTime? CreateDate { get; set; } = DateTime.Now; // sonradan 1 classa bu şekilde property eklersek yeni bir migration eklememiz gerekir yoksa proje çalışırken hata alırız
        public virtual List<Product>? Products { get; set; } // kategorinin birden çok ürünü olabilir bire çok ilişki
    }
}
