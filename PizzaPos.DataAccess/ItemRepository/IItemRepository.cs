using System.Collections.Generic;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Sizes;

namespace PizzaPos.DataAccess.ItemRepository
{
    public interface IItemRepository
    {
        Item FindById(int id);
        ItemDetails FindPriceBySizeAndItem(Item item,SizesDto size);
        Item SaveNewItem(Item item);
        Item UpdateItem(Item item);
        ItemDetails SaveNewItemPrice(ItemDetails price);
        ItemDetails UpdateItemPrice(ItemDetails price);
        List<Item> FindAllItems();
        List<ItemDetails> FindPricesByItem(Item item);
        List<ItemDetails> FindAllByCategory(int cate);
        ItemDetails GetByItemDetailsId(int id);
    }
}