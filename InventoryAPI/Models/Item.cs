using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemLocation { get; set; }
    }
}
