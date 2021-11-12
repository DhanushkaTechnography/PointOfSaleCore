using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.OrderDetails;
using PizzaCore.Entity.Payload.orderResponses;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaOrderDetails;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.ToppingPrices;
using PizzaPos.DataAccess.AuthRepository;
using PizzaPos.DataAccess.CrustPricesRepository;
using PizzaPos.DataAccess.CustomerRepository;
using PizzaPos.DataAccess.DeliveryMethodRepository;
using PizzaPos.DataAccess.EmployeeRepository;
using PizzaPos.DataAccess.ItemRepository;
using PizzaPos.DataAccess.OrderDetailsRepository;
using PizzaPos.DataAccess.OrderRepository;
using PizzaPos.DataAccess.PizzaOrderDetailsRepository;
using PizzaPos.DataAccess.PizzaPrices;
using PizzaPos.DataAccess.PizzaRepository;
using PizzaPos.DataAccess.SubCategoryRepository;
using PizzaPos.DataAccess.ToppingPricesRepository;

namespace PizzaCore.Business.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaOrderDetailsRepository _pizzaOrderDetailsRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IPizzaPricesRepository _pizzaPricesRepository;
        private readonly ICrustPricesRepository _crustPricesRepository;
        private readonly IToppingPricesRepository _toppingPricesRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaOrderDetailsRepository _orderDetailsRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderDetailsRepository _orderOtherItemDetailsRepository;


        public OrderService(IOrderRepository orderRepository, IDeliveryOptionRepository deliveryOptionRepository,
            ICustomerRepository customerRepository, IEmployeeRepository employeeRepository,
            IAuthRepository authRepository, IPizzaOrderDetailsRepository pizzaOrderDetailsRepository,
            IPizzaPricesRepository pizzaPricesRepository, ICrustPricesRepository crustPricesRepository,
            IToppingPricesRepository toppingPricesRepository, ISubCategoryRepository subCategoryRepository, IPizzaRepository pizzaRepository, IPizzaOrderDetailsRepository orderDetailsRepository, IItemRepository itemRepository, IOrderDetailsRepository orderOtherItemDetailsRepository)
        {
            _orderRepository = orderRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _customerRepository = customerRepository;
            _authRepository = authRepository;
            _pizzaOrderDetailsRepository = pizzaOrderDetailsRepository;
            _pizzaPricesRepository = pizzaPricesRepository;
            _crustPricesRepository = crustPricesRepository;
            _toppingPricesRepository = toppingPricesRepository;
            _subCategoryRepository = subCategoryRepository;
            _pizzaRepository = pizzaRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _itemRepository = itemRepository;
            _orderOtherItemDetailsRepository = orderOtherItemDetailsRepository;
        }

        public bool SaveDeliveryOption(DeliveryOptionDto dto)
        {
            DeliveryOptionDto optionDto = null;
            try
            {
                optionDto = _deliveryOptionRepository.FindById(dto.MethodId);
            }
            catch (InvalidOperationException e)
            {
                try
                {
                    optionDto = _deliveryOptionRepository.FindByName(dto.MethodName);
                }
                catch (InvalidOperationException r)
                {
                    
                }
            }

            if (optionDto == null)
            {
                return _deliveryOptionRepository.SaveOption(dto: dto);
            }

            optionDto.Charge = dto.Charge;
            optionDto.MethodName = dto.MethodName;
            return _deliveryOptionRepository.UpdateOption(optionDto);
        }

        public List<DeliveryOptionDto> GetDeliveryOptions()
        {
            return _deliveryOptionRepository.OptionList();
        }

        public int SaveOrder(OrderRequest dto)
        {
            var order = _orderRepository.SearchOrder(dto.OrderId);
            if (order == null)
            {
                order = new OrderDto(0, _customerRepository.SearchById(dto.Customer),
                    _authRepository.CheckEmployeeId(dto.Employee)
                    , _deliveryOptionRepository.FindById(dto.DeliveryOption), dto.DateWanted, dto.TimeWanted,
                    dto.OrdSubTotal,
                    dto.OrdDiscount, dto.OrdTax, dto.OrdTotal, $"{DateTime.Now:d/M/yyyy HH:mm:ss}",
                    $"{DateTime.Now:d/M/yyyy HH:mm:ss}", dto.Note,dto.PayBy);
                order = _orderRepository.SaveOrder(order);
            }
            else
            {
                order.UpdateData(_customerRepository.SearchById(dto.Customer),
                    _authRepository.CheckEmployeeId(dto.Employee)
                    , _deliveryOptionRepository.FindById(dto.DeliveryOption), dto.DateWanted, dto.TimeWanted,
                    dto.OrdSubTotal,
                    dto.OrdDiscount, dto.OrdTax, dto.OrdTotal, $"{DateTime.Now:d/M/yyyy HH:mm:ss}", dto.Note,dto.PayBy);
            }

            order = _orderRepository.UpdateOrder(order);
            _orderRepository.SaveOrderStatus(new OrderStatusDto(0, order, dto.Status,
                $"{DateTime.Now:d/M/yyyy HH:mm}", 1));
            SaveOrderPizzaItems(dto.PizzaItems, order);
            SaveOtherItems(dto.OtherItems,order);
            return order.OrderId;
        }

        private void SaveOtherItems(List<OrderItems> otherItems, OrderDto order)
        {
            OrderDetailsDto dto;
            foreach (var item in otherItems)
            {
                dto = new OrderDetailsDto
                {
                    Item = _itemRepository.GetByItemDetailsId(item.Item),
                    Order = order,
                    Price = item.Price,
                    Qty = item.Qty,
                    Status = item.Status,
                    SubTotal = item.SubTotal
                };
                _orderOtherItemDetailsRepository.SaveOrderDetail(dto);
            }
        }

        public bool SaveOrderPizzaItems(List<OrderPizzaItems> pizzaItems,OrderDto order)
        {
            foreach (var item in pizzaItems)
                SaveExtraToppings(item.ExtraToppings, _pizzaOrderDetailsRepository.SaveOrderDetails(
                    new PizzaOrderDetailsDto(0, order,
                        _pizzaPricesRepository.SearchById(item.Pizza),
                        _crustPricesRepository.SearchById(item.Crust), item.PizzaSubTotal, item.Note, item.Qty,item.Status)));
            return true;
        }

        public bool SaveExtraToppings(List<ExtraToppingRequest> toppings, PizzaOrderDetailsDto dto)
        {
            foreach (var topping in toppings)
                _pizzaOrderDetailsRepository.SaveExtraTopping(new ExtraToppings(0, dto,
                    _toppingPricesRepository.SearchById(topping.ToppingPriceId), topping.Side, topping.Portion,
                    topping.Cost));
            return true;
        }

        public List<OrdersResponse> GetOrdersByStatus(string status)
        {
            return _orderRepository.GetAllByStatus(status).Select(dto => new OrdersResponse(dto.Order.OrderId, dto.Order.Customer.CusId, dto.Order.Employee.EmployeeId, dto.Order.DeliveryOption.MethodId, dto.Order.Customer.CusName, dto.Order.Employee.FirstName, dto.Order.DeliveryOption.MethodName, dto.Order.DateWanted, dto.Order.TimeWanted, dto.Order.OrdSubTotal, dto.Order.OrdDiscount, dto.Order.OrdTax, dto.Order.OrdTotal, dto.Order.OrdCreatedDate, dto.Order.OrdUpdatedDate, dto.Order.Note, GetStatusList(dto.Order), GetPizzaItems(dto.Order),GetOtherItems(dto.Order))).ToList();
        }

        private List<OtherItemResponse> GetOtherItems(OrderDto order)
        {
            List<OtherItemResponse> list = new List<OtherItemResponse>();
            CategoryDto category;
            ItemDetails item;
            foreach (var details in _orderOtherItemDetailsRepository.FindAllByOrder(order))
            {
                item = _itemRepository.GetByItemDetailsId(details.Item.ItemPriceId);
                category = _itemRepository.FindById(item.Item.ItemId)
                    .Category;
                list.Add(new OtherItemResponse(details.DetailsId,details.Item.ItemPriceId,order.OrderId,category.CategoryId,item.Item.Name,category.CategoryName,category.Color,item.SizeId.SizeName,details.Qty,details.Price,details.SubTotal,details.Status));
            }
            return list;
        }

        public List<CustomerOrdersResponse> GetCustomerOrderList(int id)
        {
            return _orderRepository.CustomerOrders(id).Select(customerOrder => new CustomerOrdersResponse(customerOrder.OrderId, customerOrder.Employee.LastName, customerOrder.DeliveryOption.MethodName, customerOrder.DateWanted + " " + customerOrder.TimeWanted, customerOrder.OrdCreatedDate, customerOrder.OrdTotal)).ToList();
        }

        public bool UpdateOrderOtherItemStatus(int id)
        {
            var byId = _orderOtherItemDetailsRepository.FindById(id);
            if (byId.Status != 3)
            {
                byId.Status += 1;
            }
            _orderOtherItemDetailsRepository.UpdateOrderDetail(byId);
            updateMainOrder(byId.Order);
            return true;
        }

        public bool UpdateOrderPizzaItemStatus(int id)
        {
            var byId = _pizzaOrderDetailsRepository.FindById(id);
            if (byId.Status != 3)
            {
                byId.Status += 1;
            }
            _pizzaOrderDetailsRepository.UpdateOrderDetails(byId);
            updateMainOrder(byId.Order);
            return true;
        }

        private void updateMainOrder(OrderDto order)
        {
            string status = "FINISHED";
            foreach (var dto in _orderOtherItemDetailsRepository.FindAllByOrder(order))
            {
                if (dto.Status is 1 or 2 or 0)
                {
                    status = "IN PROGRESS";
                }
            }

            if (status == "FINISHED")
            {
                foreach (var dto in _pizzaOrderDetailsRepository.GetPizzaForOrder(order.OrderId))
                {
                    if (dto.Status is 1 or 2 or 0)
                    {
                        status = "IN PROGRESS";
                    }
                }
            }
            SaveOrderStatus(order.OrderId, status);
        }

        private List<PizzaItemResponse> GetPizzaItems(OrderDto order)
        {
            List<PizzaItemResponse> list = new List<PizzaItemResponse>();
            PizzaItemResponse response;
            PizzaDto pizzaDto;
            CategoryDto categoryDto;
            foreach (var dto in _pizzaOrderDetailsRepository.GetPizzaForOrder(order.OrderId))
            {
                pizzaDto = _pizzaRepository.SearchById(_pizzaPricesRepository.SearchById(dto.Pizza.PizzaSizeId).PizzaId.PizzaId);
                response = new PizzaItemResponse
                {
                    PizzaDetailsId = dto.PizzaOrderDetailsId,
                    Order = dto.Order.OrderId,
                    PizzaSizeId = dto.Pizza.PizzaSizeId,
                    CrustPriceId = dto.Crust.CrustPriceId,
                    PizzaName = pizzaDto.PizzaName,
                    PizzaSizeName = _pizzaPricesRepository.SearchById(dto.Pizza.PizzaSizeId).SizeId.SizeName,
                    PizzaCrustName = _crustPricesRepository.SearchById(dto.Crust.CrustPriceId).Crust.CrustName,
                    SubTotal = dto.PizzaSubTotal,
                    Note = dto.Note,
                    Color = _subCategoryRepository.GetById(pizzaDto.SubCategory.SubCategoryId).Category.Color,
                    Status = dto.Status,
                    ToppingResponses = GetToppingList(dto.PizzaOrderDetailsId),
                    Qty = dto.Qty
                };
                list.Add(response);
            }
            return list;
        }

        private List<ExtraToppingResponse> GetToppingList(int dtoPizzaOrderDetailsId)
        {
            return _pizzaOrderDetailsRepository.GetToppingsForPizzaItem(dtoPizzaOrderDetailsId).Select(extraToppings => new ExtraToppingResponse(extraToppings.ExtraToppingId, dtoPizzaOrderDetailsId, extraToppings.Topping.ToppingPriceId,_toppingPricesRepository.SearchById(extraToppings.Topping.ToppingPriceId).Topping.ToppingName, extraToppings.Side, extraToppings.Portion, extraToppings.Cost)).ToList();
        }

        private List<string> GetStatusList(OrderDto dtoOrder)
        {
            return _orderRepository.GetStatusByOrder(dtoOrder.OrderId).Select(dto => dto.StatusName + " - " + dto.Date).ToList();
        }

        public bool SaveOrderStatus(int order, string status)
        {
            var orderDto = _orderRepository.SearchOrder(order);
            var statusDto = _orderRepository.SearchOrderStatus(orderDto);
            if (statusDto != null)
            {
                if (status == statusDto.StatusName)
                {
                    return true;
                }
                statusDto.Active = 0;
                _orderRepository.UpdateOrderStatus(statusDto);
            }
            _orderRepository.SaveOrderStatus(new OrderStatusDto(0, orderDto, status,
                $"{DateTime.Now:d/M/yyyy HH:mm}", 1));
            return true;
        }
    }
}