using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    //Single Responsibility Principle - There is only one class that defines what a specific item is
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        [Required]
        public string ItemType { get; set; }
    }
}
