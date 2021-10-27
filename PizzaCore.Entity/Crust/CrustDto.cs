using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Crust
{
    public class CrustDto
    {
        [Key]
        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public string CrustCreatedDate { get; set; }
        public string CrustUpdatedDate { get; set; }
        public int CrustStatus { get; set; }
        public int Deleted { get; set; }

        public CrustDto(string crustName, string crustCreatedDate, string crustUpdatedDate, int crustStatus,int deleted)
        {
            CrustName = crustName;
            CrustCreatedDate = crustCreatedDate;
            CrustUpdatedDate = crustUpdatedDate;
            CrustStatus = crustStatus;
            Deleted = deleted;
        }
    }
}