using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Model.Entities
{
    public class Product : IEntityBase
    {
        public ObjectId InternalId { get; set; }

        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int Color { get; set; }

        public int Size { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool IsActive { get; set; }

    }
}
