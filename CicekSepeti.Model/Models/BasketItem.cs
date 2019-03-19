using CicekSepeti.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Model.Models
{
    public class BasketItem
    {
        [Required]
        public Product Product { get; set; }

        [Required]
        public string BasketId { get; set; }

    }
}
