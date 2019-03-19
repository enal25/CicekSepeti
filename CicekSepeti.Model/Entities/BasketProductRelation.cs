using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Model.Entities
{
    public class BasketProductRelation : IEntityBase
    {
        public ObjectId InternalId { get; set; }

        public string Id { get; set; }

        [Required]
        public string BasketId { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool IsActive { get; set; }
    }
}
