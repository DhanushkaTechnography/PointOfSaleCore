using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Crust;


namespace PizzaCore.Entity.Pizza
{
    public class PizzaDto
    {
        [Key]
        public int PizzaId { get; set; }
        //Have to add foreign key to sub cost id but i don't Know what is the table this attribute at Primary Key =>
        public int SubCatId { get; set; }
        public CrustDto CrustId { get; set; }
        public string PizzaName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}