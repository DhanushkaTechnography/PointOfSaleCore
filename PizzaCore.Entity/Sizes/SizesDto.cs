using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Sizes
{
    public class SizesDto
    {
        [Key]
        public int SizesId { get; set; }
        public string SizeName { get; set; }
        public string SizeCreatedDate { get; set; }
        public string SizeUpdatedDate { get; set; }
        public int SizeStatus { get; set; }
        public int Deleted { get; set; }
    }
}