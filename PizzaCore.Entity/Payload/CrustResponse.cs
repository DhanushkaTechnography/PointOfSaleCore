namespace PizzaCore.Entity.Payload
{
    public class CrustResponse
    {
        public int CrustId { get; set; }
        public int Sizes { get; set; }
        public string CrustName { get; set; }
        public string CrustCreatedDate { get; set; }
        public string CrustUpdatedDate { get; set; }
        public int CrustStatus { get; set; }
        public int Deleted { get; set; }

        public CrustResponse(int crustId, int sizes, string crustName, string crustCreatedDate, string crustUpdatedDate, int crustStatus, int deleted)
        {
            CrustId = crustId;
            Sizes = sizes;
            CrustName = crustName;
            CrustCreatedDate = crustCreatedDate;
            CrustUpdatedDate = crustUpdatedDate;
            CrustStatus = crustStatus;
            Deleted = deleted;
        }
    }
}