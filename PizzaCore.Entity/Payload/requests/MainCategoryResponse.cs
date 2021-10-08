using System;
using PizzaCore.Entity.Category;

namespace PizzaCore.Entity.Payload.requests
{
    public class MainCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvailableOn { get; set; }
        public int SubCateCount { get; set; }
        public int ItemCount { get; set; }
        public string Color { get; set; }
        public int Status { get; set; }

        public MainCategoryResponse()
        {
        }

        public MainCategoryResponse(CategoryDto dto, int subCateCount)
        {
            this.Id = dto.CategoryId;
            this.Name = dto.CategoryName;
            this.Status = dto.Status;
            this.AvailableOn = getAvailable(dto);
            this.ItemCount = 0;
            this.Color = dto.Color;
            this.SubCateCount = subCateCount;
        }

        private string getAvailable(CategoryDto dto)
        {
            string Available = "";
            if (dto.IsPizza == 1)
            {
                Available = "Pizza ";
            }

            if (dto.IsTopping == 1)
            {
                Available = Available + "Topping ";
            }

            if (dto.IsOther == 1)
            {
                Available = Available + "Items ";
            }
            return Available;
        }
    }
}