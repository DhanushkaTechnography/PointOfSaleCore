using System;
using System.Collections.Generic;
using PizzaCore.Entity.Ingredients;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.PizzaIngredientsRepository;
using PizzaPos.DataAccess.PizzaPrices;
using PizzaPos.DataAccess.PizzaRepository;
using PizzaPos.DataAccess.SizesRepository;
using PizzaPos.DataAccess.SubCategoryRepository;
using PizzaPos.DataAccess.ToppingsRepository;

namespace PizzaCore.Business.PizzaService
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPizzaPricesRepository _pizzaPricesRepository;
        private readonly ISizesRepository _sizesRepository;
        private readonly IPizzaIngredientsRepository _ingredientsRepository;
        private readonly IToppingsRepository _toppingsRepository;

        public PizzaService(IPizzaRepository pizzaRepository, ISubCategoryRepository subCategoryRepository,
            IPizzaPricesRepository pizzaPricesRepository, ISizesRepository sizesRepository,
            IPizzaIngredientsRepository ingredientsRepository, IToppingsRepository toppingsRepository)
        {
            _pizzaRepository = pizzaRepository;
            _subCategoryRepository = subCategoryRepository;
            _pizzaPricesRepository = pizzaPricesRepository;
            _sizesRepository = sizesRepository;
            _ingredientsRepository = ingredientsRepository;
            _toppingsRepository = toppingsRepository;
        }

        public int SavePizza(PizzaRequest request)
        {
            PizzaDto byId;
            try
            {
                byId = _pizzaRepository.SearchById(request.SubCate);
            }
            catch (Exception e)
            {
                byId = new PizzaDto(request.Id, _subCategoryRepository.GetById(request.SubCate), request.Name,
                    request.Color, $"{DateTime.Now:d/M/yyyy HH:mm:ss}", $"{DateTime.Now:d/M/yyyy HH:mm:ss}",
                    request.Status, request.Deleted);
                return _pizzaRepository.SavePizza(byId);
            }

            byId.PizzaName = request.Name;
            byId.Deleted = request.Deleted;
            byId.PizzaColor = request.Color;
            byId.PizzaStatus = request.Status;
            byId.SubCategory = _subCategoryRepository.GetById(request.SubCate);
            byId.PizzaUpdateDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            return _pizzaRepository.UpdatePizza(new PizzaDto(request.Id,
                _subCategoryRepository.GetById(request.SubCate), request.Name, request.Color,
                $"{DateTime.Now:d/M/yyyy HH:mm:ss}", $"{DateTime.Now:d/M/yyyy HH:mm:ss}", request.Status,
                request.Deleted));
        }

        public bool SavePizzaPrices(List<PricesRequest> list)
        {
            PizzaSizesDto dto;
            PizzaDto pizzaDto = null;
            SizesDto sizesDto = null;
            foreach (var request in list)
            {
                sizesDto = _sizesRepository.GetById(request.SizeId);
                pizzaDto = _pizzaRepository.SearchById(request.ItemId);
                try
                {
                    dto = _pizzaPricesRepository.GetPricesBySizeAndPizza(sizesDto, pizzaDto);
                }
                catch (Exception e)
                {
                    _pizzaPricesRepository.CreatePizzaPrices(new PizzaSizesDto(0,
                        _pizzaRepository.SearchById(request.ItemId), sizesDto, request.Price,
                        $"{DateTime.Now:d/M/yyyy HH:mm:ss}", $"{DateTime.Now:d/M/yyyy HH:mm:ss}", request.Status));
                    continue;
                }

                dto.Price = request.Price;
                dto.Status = request.Status;
                dto.UpdateDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                _pizzaPricesRepository.UpdatePizzaPrices(dto);
            }

            return true;
        }

        public bool SavePizzaIngredients(List<IngredientRequest> list)
        {
            PizzaDto pizza;
            ToppingsDto topping;
            IngredientsDto ingredient;
            foreach (var request in list)
            {
                pizza = _pizzaRepository.SearchById(request.PizzaId);
                topping = _toppingsRepository.GetToppingById(request.ToppingId);
                try
                {
                    ingredient = _ingredientsRepository.GetByPizzaAndTopping(pizza, topping);
                }
                catch (Exception e)
                {
                    ingredient = new IngredientsDto(0, pizza, topping, request.Status);
                    _ingredientsRepository.SavePizzaIngredient(ingredient);
                    continue;
                }

                ingredient.Status = request.Status;
                _ingredientsRepository.UpdatePizzaIngredient(ingredient);
            }

            return true;
        }

        public List<PizzaResponse> GetPizzaList()
        {
            List<PizzaResponse> list = new List<PizzaResponse>();
            foreach (var dto in _pizzaRepository.GetPizzaList())
            {
                list.Add(new PizzaResponse(dto.PizzaId, dto.SubCategory.SubCategoryId, dto.PizzaName,
                    dto.SubCategory.SubCatName, dto.PizzaUpdateDate, getIngredients(dto), getSizes(dto),
                    dto.PizzaStatus));
            }

            return list;
        }

        public List<PizzaDto> GetPizzaByCategory(int id)
        {
            return _pizzaRepository.GetBySubcategory(_subCategoryRepository.GetById(id));
        }

        public List<ItemPriceResponse> GetPizzaPrices(int pizzaId)
        {
            List<ItemPriceResponse> list = new List<ItemPriceResponse>();
            foreach (var price in _pizzaPricesRepository.PizzaPrices(_pizzaRepository.SearchById(pizzaId)))
                list.Add(new ItemPriceResponse(price.PizzaSizeId, price.PizzaId.PizzaId, price.SizeId.SizesId,
                    price.PizzaId.PizzaName, price.SizeId.SizeName, price.Price));
            return list;
        }

        public List<IngredientsDto> GetIngredientsForByPizza(int id)
        {
            return _ingredientsRepository.GetIngredientsForPizza(_pizzaRepository.SearchById(id));
        }

        private int getSizes(PizzaDto dto)
        {
            return _pizzaPricesRepository.CountByPizza(dto);
        }

        private int getIngredients(PizzaDto dto)
        {
            return _ingredientsRepository.CountIngredient(dto);
        }
    }
}