using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void ApproveReservation(int id)
        {
            _reservationDal.ApproveReservation(id);
        }

        public List<Reservation> GetAllReservation()
        {
           return _reservationDal.GetAllReservation();
        }

        public List<Reservation> GetListWithReservationByApproved(int id)
        {
            return _reservationDal.GetListWithReservationByApproved(id);
        }

        public List<Reservation> GetListWithReservationByRejected(int id)
        {
            return _reservationDal.GetListWithReservationByRejected(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);

        }

        public void RejectReservation(int id)
        {
            _reservationDal.RejectReservation(id);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetByID(int id)
        {
           return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TInsert(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }

        public void WaitingApproveReservation(int id)
        {
           _reservationDal.WaitingApproveReservation(id);
        }
    }
}
