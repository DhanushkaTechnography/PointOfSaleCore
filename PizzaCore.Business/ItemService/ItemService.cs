using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Sizes;
using PizzaPos.DataAccess.CategoryRepository;
using PizzaPos.DataAccess.ItemRepository;
using PizzaPos.DataAccess.SizesRepository;

namespace PizzaCore.Business.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISizesRepository _sizesRepository;

        public ItemService(IItemRepository itemRepository, ICategoryRepository categoryRepository,
            ISizesRepository sizesRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _sizesRepository = sizesRepository;
        }

        public bool SaveNewItem(ItemRequest request)
        {
            Item item = null;
            try
            {
                item = _itemRepository.FindById(request.Id);
            }
            catch (Exception e)
            {
                item = new Item(request.Id, _categoryRepository.FindCategoryById(request.Category).Result, request.Name,
                    request.Status);
                item = _itemRepository.SaveNewItem(item);
                saveItemPrices(item, request.Prices);
                return true;
            }
            item.Category = _categoryRepository.FindCategoryById(request.Category).Result;
            item.Name = request.Name;
            item.Status = request.Status;
            return _itemRepository.SaveNewItem(item) != null;
        }

        public List<ItemRequest> GetItemList()
        {
            List<ItemRequest> list = new List<ItemRequest>();
            List<PricesRequest> prices;
            foreach (var item in _itemRepository.FindAllItems())
            {
                prices = _itemRepository.FindPricesByItem(item).Select(details => new PricesRequest(item.ItemId, details.SizeId.SizesId, details.Price, details.Status)).ToList();
                list.Add(new ItemRequest(item.ItemId,item.Category.CategoryId,item.Name,item.Category.CategoryName,item.Status,prices));
            }
            return list;
        }

        public List<ItemDetails> GetByCategory(int cate)
        {
            return _itemRepository.FindAllByCategory(cate);
        }

        private void saveItemPrices(Item item, List<PricesRequest> prices)
        {
            ItemDetails priceDetails;
            SizesDto dto;
            foreach (var price in prices)
            {
                dto = _sizesRepository.GetById(price.SizeId);
                try
                {
                    priceDetails = _itemRepository.FindPriceBySizeAndItem(item, dto);
                }
                catch (Exception e)
                {
                    priceDetails = new ItemDetails(0, item, dto, price.Price, $"{DateTime.Now:d/M/yyyy HH:mm}",
                        $"{DateTime.Now:d/M/yyyy HH:mm}", price.Status);
                    _itemRepository.SaveNewItemPrice(priceDetails);
                    continue;
                }
                priceDetails.Status = price.Status;
                priceDetails.Price = price.Price;
                priceDetails.UpdateDate = $"{DateTime.Now:d/M/yyyy HH:mm}";
                _itemRepository.UpdateItemPrice(priceDetails);
            }
        }
    }
}