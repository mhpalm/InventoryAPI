using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string? ItemName { get; set; }
        public int? ItemPrice { get; set; }
        public string? ItemLocation { get; set; }
    }
}
