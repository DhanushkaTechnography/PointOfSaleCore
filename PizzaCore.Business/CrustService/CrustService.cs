using PizzaPos.DataAccess.CrustRepository;

namespace PizzaCore.Business.CrustService
{
    public class CrustService: ICrustService
    {
        private readonly ICrustRepository _crustRepository;

        public CrustService(ICrustRepository crustRepository)
        {
            _crustRepository = crustRepository;
        }
        
    }
}