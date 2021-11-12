using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Sizes;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ItemRepository
{
    public class ItemRepository:IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Item FindById(int id)
        {
            return _dbContext.Items.Include(item => item.Category).First(item => item.ItemId == id);
        }

        public ItemDetails FindPriceBySizeAndItem(Item item, SizesDto size)
        {
            return _dbContext.ItemPrices
                .Include(details => details.Item).Include(details => details.SizeId)
                .First(details => details.Item == item && details.SizeId == size);
        }

        public Item SaveNewItem(Item item)
        {
            var entry = _dbContext.Items.Add(item).Entity;
            _dbContext.SaveChanges();
            return entry;
        }

        public Item UpdateItem(Item item)
        {
            var entry = _dbContext.Items.Update(item).Entity;
            _dbContext.SaveChanges();
            return entry;
        }

        public ItemDetails SaveNewItemPrice(ItemDetails price)
        {
            var entity = _dbContext.ItemPrices.Add(price).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public ItemDetails UpdateItemPrice(ItemDetails price)
        {
            var entity = _dbContext.ItemPrices.Update(price).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public List<Item> FindAllItems()
        {
            return _dbContext.Items.Include(item => item.Category).ToList();
        }

        public List<ItemDetails> FindPricesByItem(Item item)
        {
            return _dbContext.ItemPrices.Include(details => details.Item)
                .Include(details => details.SizeId).Where(details => details.Item.ItemId == item.ItemId).ToList();
        }

        public List<ItemDetails> FindAllByCategory(int cate)
        {
            return _dbContext.ItemPrices.Include(details => details.Item).Include(details => details.SizeId)
                .Where(details => details.Item.Category.CategoryId == cate).ToList();
        }

        public ItemDetails GetByItemDetailsId(int id)
        {
            return _dbContext.ItemPrices.Include(details => details.Item).Include(details => details.SizeId)
                .First(details => details.ItemPriceId == id);
        }
    }
}