using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByRejected(int id);
        List<Reservation> GetListWithReservationByApproved(int id);

        List<Reservation> GetAllReservation();
        void ApproveReservation(int id);
        void RejectReservation(int id);
        void WaitingApproveReservation(int id);
    }
}
