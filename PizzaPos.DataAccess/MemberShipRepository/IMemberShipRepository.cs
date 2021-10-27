
using System.Collections.Generic;
using PizzaCore.Entity.Membership;

namespace PizzaPos.DataAccess.MemberShipRepository
{
    public interface IMemberShipRepository
    {
        public bool CreateNewMembership(MemberShipDto dto);
        public bool UpdateMembership(MemberShipDto dto);
        public MemberShipDto FindMembershipById(int id);
        public List<MemberShipDto> FindAllMemberShips();
    }
}