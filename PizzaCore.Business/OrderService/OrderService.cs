using System;
using System.Collections.Generic;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Order;
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
using PizzaPos.DataAccess.OrderRepository;
using PizzaPos.DataAccess.PizzaOrderDetailsRepository;
using PizzaPos.DataAccess.PizzaPrices;
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


        public OrderService(IOrderRepository orderRepository, IDeliveryOptionRepository deliveryOptionRepository,
            ICustomerRepository customerRepository, IEmployeeRepository employeeRepository,
            IAuthRepository authRepository, IPizzaOrderDetailsRepository pizzaOrderDetailsRepository,
            IPizzaPricesRepository pizzaPricesRepository, ICrustPricesRepository crustPricesRepository,
            IToppingPricesRepository toppingPricesRepository)
        {
            _orderRepository = orderRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _customerRepository = customerRepository;
            _authRepository = authRepository;
            _pizzaOrderDetailsRepository = pizzaOrderDetailsRepository;
            _pizzaPricesRepository = pizzaPricesRepository;
            _crustPricesRepository = crustPricesRepository;
            _toppingPricesRepository = toppingPricesRepository;
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
                    $"{DateTime.Now:d/M/yyyy HH:mm:ss}", dto.Note);
                order = _orderRepository.SaveOrder(order);
            }
            else
            {
                order.UpdateData(_customerRepository.SearchById(dto.Customer),
                    _authRepository.CheckEmployeeId(dto.Employee)
                    , _deliveryOptionRepository.FindById(dto.DeliveryOption), dto.DateWanted, dto.TimeWanted,
                    dto.OrdSubTotal,
                    dto.OrdDiscount, dto.OrdTax, dto.OrdTotal, $"{DateTime.Now:d/M/yyyy HH:mm:ss}", dto.Note);
            }

            order = _orderRepository.UpdateOrder(order);
            _orderRepository.SaveOrderStatus(new OrderStatusDto(0, order, dto.Status,
                $"{DateTime.Now:d/M/yyyy HH:mm:aa}", 1));
            return order.OrderId;
        }

        public bool SaveOrderPizzaItems(List<OrderPizzaItems> pizzaItems, OrderDto order)
        {
            PizzaOrderDetailsDto details;
            foreach (var item in pizzaItems)
                SaveExtraToppings(item.ExtraToppings, _pizzaOrderDetailsRepository.SaveOrderDetails(
                    new PizzaOrderDetailsDto(0, order,
                        _pizzaPricesRepository.SearchById(item.Pizza),
                        _crustPricesRepository.SearchById(item.Crust), item.PizzaSubTotal, item.Note, item.Status)));
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

        public bool SaveOrderStatus(int order, string status)
        {
            var orderDto = _orderRepository.SearchOrder(order);
            var statusDto = _orderRepository.SearchOrderStatus(orderDto);
            if (statusDto != null)
            {
                statusDto.Active = 0;
                _orderRepository.UpdateOrderStatus(statusDto);
            }

            _orderRepository.SaveOrderStatus(new OrderStatusDto(0, orderDto, status,
                $"{DateTime.Now:d/M/yyyy HH:mm:aa}", 1));
            return true;
        }
    }
}