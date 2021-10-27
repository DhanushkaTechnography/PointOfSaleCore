using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.DeliveryOptions
{
    public class DeliveryOptionDto
    {
        [Key]
        public int MethodId { get; set; }
        public string MethodName { get; set; }
        public double Charge { get; set; }

        public DeliveryOptionDto()
        {
        }

        public DeliveryOptionDto(int methodId, string methodName, double charge)
        {
            MethodId = methodId;
            MethodName = methodName;
            Charge = charge;
        }
    }
}