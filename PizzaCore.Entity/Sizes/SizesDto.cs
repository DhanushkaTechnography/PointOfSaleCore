using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Sizes
{
    public class SizesDto
    {
        [Key]
        public int SizesId { get; set; }
        
        public string SizeName { get; set; }
        public DateTime SizeCreatedDate { get; set; }
        public DateTime SizeUpdatedDate { get; set; }
        public int SizeStatus { get; set; }
    }
}