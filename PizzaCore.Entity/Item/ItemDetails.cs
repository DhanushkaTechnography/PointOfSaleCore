using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Sizes;

namespace PizzaCore.Entity.Item
{
    public class ItemDetails
    {
        [Key]
        public int ItemPriceId{ get; set; }
        public Item Item { get; set; }
        public SizesDto SizeId { get; set; }
        public double Price { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int Status { get; set; }

        public ItemDetails()
        {
        }

        public ItemDetails(int itemPriceId, Item item, SizesDto sizeId, double price, string createDate, string updateDate, int status)
        {
            ItemPriceId = itemPriceId;
            Item = item;
            SizeId = sizeId;
            Price = price;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Status = status;
        }
    }
}