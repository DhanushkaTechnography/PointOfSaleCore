using System.Collections.Generic;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Business.ItemService
{
    public interface IItemService
    {
        bool SaveNewItem(ItemRequest request);
        List<ItemRequest> GetItemList();
        List<ItemDetails> GetByCategory(int cate);
    }
}