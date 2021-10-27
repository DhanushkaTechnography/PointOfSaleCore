using System;
using System.Collections.Generic;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Sizes;
using PizzaPos.DataAccess.CrustPricesRepository;
using PizzaPos.DataAccess.CrustRepository;
using PizzaPos.DataAccess.SizesRepository;

namespace PizzaCore.Business.CrustService
{
    public class CrustService : ICrustService
    {
        private readonly ICrustRepository _crustRepository;
        private readonly ICrustPricesRepository _crustPricesRepository;
        private readonly ISizesRepository _sizesRepository;

        public CrustService(ICrustRepository crustRepository, ICrustPricesRepository crustPricesRepository,
            ISizesRepository sizesRepository)
        {
            _crustRepository = crustRepository;
            _crustPricesRepository = crustPricesRepository;
            _sizesRepository = sizesRepository;
        }

        public int SaveCrust(CrustDto dto)
        {
            var byId = _crustRepository.GetById(dto.CrustId);
            if (byId == null)
            {
                byId = new CrustDto(dto.CrustName, $"{DateTime.Now:d/M/yyyy HH:mm:ss}",
                    $"{DateTime.Now:d/M/yyyy HH:mm:ss}", dto.CrustStatus, dto.Deleted);
                return _crustRepository.SaveCrust(byId).CrustId;
            }

            byId.CrustName = dto.CrustName;
            byId.CrustStatus = dto.CrustStatus;
            byId.CrustUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            byId.Deleted = dto.Deleted;
            return _crustRepository.UpdateCrust(byId).CrustId;
        }

        public bool SaveCrustPrices(List<PricesRequest> list)
        {
            Console.WriteLine(list.Count);
            CrustDto crustDto = null;
            SizesDto sizesDto = null;
            CrustPricesDto crustPricesDto = null;
            foreach (var request in list)
            {
                crustDto = _crustRepository.GetById(request.ItemId);
                sizesDto = _sizesRepository.GetById(request.SizeId);
                try
                {
                    crustPricesDto = _crustPricesRepository.GetByCrustAndSize(crustDto, sizesDto);
                }
                catch (Exception e)
                {
                    crustPricesDto = new CrustPricesDto(crustDto, sizesDto, request.Price,
                        $"{DateTime.Now:d/M/yyyy HH:mm:ss}", $"{DateTime.Now:d/M/yyyy HH:mm:ss}", request.Status);
                    _crustPricesRepository.SavePrice(crustPricesDto);
                    continue;
                }

                crustPricesDto.CrustPriceStatus = request.Status;
                crustPricesDto.CrustPriceUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                crustPricesDto.CrustPrice = request.Price;
                _crustPricesRepository.UpdatePrice(crustPricesDto);
            }

            return true;
        }

        public List<CrustResponse> GetAllCrusts()
        {
            List<CrustResponse> list = new List<CrustResponse>();
            foreach (var crust in _crustRepository.GetAllCrusts())
            {
                list.Add(new CrustResponse(crust.CrustId, _crustPricesRepository.CountByCrust(crust),
                    crust.CrustName, crust.CrustCreatedDate, crust.CrustUpdatedDate, crust.CrustStatus, crust.Deleted));
            }

            return list;
        }

        public List<CrustPricesDto> GetPricesForCrust(int id)
        {
            return _crustPricesRepository.GetCrustPricesByCrust(_crustRepository.GetById(id));
        }

        public List<ItemPriceResponse> GetCrustPricesForSize(int size)
        {
            List<ItemPriceResponse> list = new List<ItemPriceResponse>();
            foreach (var price in _crustPricesRepository.GetCrustPricesBySize(_sizesRepository.GetById(size)))
                list.Add(new ItemPriceResponse(price.CrustPriceId,price.Crust.CrustId,price.CrustSize.SizesId,price.Crust.CrustName,price.CrustSize.SizeName,price.CrustPrice));
            return list;

        }
    }
}