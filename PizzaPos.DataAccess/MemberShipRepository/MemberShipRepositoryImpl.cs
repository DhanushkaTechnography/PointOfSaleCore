using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Membership;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.MemberShipRepository
{
    public class MemberShipRepositoryImpl:IMemberShipRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MemberShipRepositoryImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewMembership(MemberShipDto dto)
        {
            _dbContext.MemberShip.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateMembership(MemberShipDto dto)
        {
            _dbContext.MemberShip.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public MemberShipDto FindMembershipById(int id)
        {
            return _dbContext.MemberShip.First(dto => dto.Status != 0 && dto.MembershipId == id);
        }

        public List<MemberShipDto> FindAllMemberShips()
        {
            return _dbContext.MemberShip.Where(dto => dto.Status != 0).ToList();
        }
    }
}