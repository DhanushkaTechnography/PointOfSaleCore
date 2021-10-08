using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Category;

namespace PizzaCore.Entity.Payload
{
    public class SubCategoryResponse
    {
        public int SubCategoryId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCatName { get; set; }
        public string SubCatCreatedDate { get; set; }
        public string SubCatUpdatedDate { get; set; }
        public int SubCatStatus { get; set; }
        public int Deleted { get; set; }

        public SubCategoryResponse(int subCategoryId, int typeId, string typeName, int categoryId, string categoryName, string subCatName, string subCatCreatedDate, string subCatUpdatedDate, int subCatStatus, int deleted)
        {
            SubCategoryId = subCategoryId;
            TypeId = typeId;
            TypeName = typeName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            SubCatName = subCatName;
            SubCatCreatedDate = subCatCreatedDate;
            SubCatUpdatedDate = subCatUpdatedDate;
            SubCatStatus = subCatStatus;
            Deleted = deleted;
        }
    }

}