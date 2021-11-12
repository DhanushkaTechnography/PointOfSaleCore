using System;
using System.Collections.Generic;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.ToppingPrices;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.CategoryRepository;
using PizzaPos.DataAccess.SizesRepository;
using PizzaPos.DataAccess.SubCategoryRepository;
using PizzaPos.DataAccess.ToppingPricesRepository;
using PizzaPos.DataAccess.ToppingsRepository;

namespace PizzaCore.Business.ToppingService
{
    public class ToppingService : IToppingService
    {
        private readonly IToppingsRepository _toppingsRepository;
        private readonly ISizesRepository _sizeRepository;
        private readonly IToppingPricesRepository _toppingPricesRepository;
        private readonly ISubCategoryRepository _categoryRepository;

        public ToppingService(IToppingsRepository toppingsRepository, ISizesRepository sizeRepository,
            IToppingPricesRepository toppingPricesRepository, ISubCategoryRepository categoryRepository)
        {
            _toppingsRepository = toppingsRepository;
            _sizeRepository = sizeRepository;
            _toppingPricesRepository = toppingPricesRepository;
            _categoryRepository = categoryRepository;
        }

        public int SaveTopping(ToppingRequest request)
        {
            var category = _categoryRepository.GetById(request.Category);
            var byId = _toppingsRepository.GetToppingById(request.ToppingsId);
            if (byId == null)
            {
                byId = new ToppingsDto(request.ToppingsId, request.ToppingName, category,
                    $"{DateTime.Now:d/M/yyyy HH:mm:ss}", $"{DateTime.Now:d/M/yyyy HH:mm:ss}", request.ToppingStatus,request.Deleted);
                byId = _toppingsRepository.SaveTopping(byId);
                return byId.ToppingsId;
            }

            byId.Category = category;
            byId.ToppingName = request.ToppingName;
            byId.ToppingStatus = request.ToppingStatus;
            byId.ToppingUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            byId.Deleted = request.Deleted;
            byId = _toppingsRepository.UpdateTopping(byId);
            return byId.ToppingsId;
        }

        public bool SaveToppingPrices(List<PricesRequest> list)
        {
            ToppingsDto toppingsDto;
            SizesDto sizesDto;
            ToppingPricesDto pricesDto;
            foreach (var price in list)
            {
                toppingsDto = _toppingsRepository.GetToppingById(price.ItemId);
                sizesDto = _sizeRepository.GetById(price.SizeId);
                try
                {
                    pricesDto = _toppingPricesRepository.GetByToppingAndSize(toppingsDto, sizesDto);
                }
                catch (Exception e)
                {
                    pricesDto = new ToppingPricesDto(0, toppingsDto, sizesDto, price.Price,
                        $"{DateTime.Now:d/M/yyyy HH:mm:ss}",
                        $"{DateTime.Now:d/M/yyyy HH:mm:ss}", price.Status);
                    _toppingPricesRepository.SaveToppingPrices(pricesDto);
                    continue;
                }
                pricesDto.ToppingPrice = price.Price;
                pricesDto.ToppingPriceStatus = price.Status;
                Console.WriteLine(price.Status);
                pricesDto.ToppingPriceUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                _toppingPricesRepository.UpdateToppingPrices(pricesDto);
            }

            return true;
        }

        public List<ToppingResponse> GetAllToppings()
        {
            List<ToppingResponse> list = new List<ToppingResponse>();
            foreach (var topping in _toppingsRepository.GetAllToppings())
            {
                list.Add(new ToppingResponse(topping.ToppingsId,topping.Category.SubCategoryId,
                    topping.ToppingStatus,topping.ToppingName,topping.Category.SubCatName));
            }
            return list;
        }

        public List<ToppingPricesDto> GetPricesByTopping(int id)
        {
            var byId = _toppingsRepository.GetToppingById(id);
            return _toppingPricesRepository.getAllPricesByTopping(byId);
        }

        public List<ItemPriceResponse> GetPricesBySize(int id)
        {
            List<ItemPriceResponse> list = new List<ItemPriceResponse>();
            foreach (var prices in _toppingPricesRepository.GetToppingPriceBySize(_sizeRepository.GetById(id)))
                list.Add(new ItemPriceResponse(prices.ToppingPriceId,prices.Topping.ToppingsId,_toppingsRepository.GetToppingTypeById(prices.Topping.ToppingsId),prices.ToppingSize.SizesId,prices.Topping.ToppingName,prices.ToppingSize.SizeName,prices.ToppingPrice));
            return list;
        }
    }
}