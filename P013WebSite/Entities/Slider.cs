using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P013WebSite.Entities
{
	public class Slider
	{
		public int Id { get; set; }
		[Display(Name = "Resim"), StringLength(50)]
		public string? Image { get; set; }
	}
}
