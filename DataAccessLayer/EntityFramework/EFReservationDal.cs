using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByApproved(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByRejected(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylanmadı" && x.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetAllReservation()
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).ToList();
            }
        }

        public void ApproveReservation(int id)
        {
            using (var context = new Context())
            {
                var values = context.Reservations.Find(id);
                values.Status = "Onaylandı";
                context.SaveChanges();
            }
        }

        public void RejectReservation(int id)
        {
            using (var context = new Context())
            {
                var values = context.Reservations.Find(id);
                values.Status = "Onaylanmadı";
                context.SaveChanges();
            }
        }

        public void WaitingApproveReservation(int id)
        {
            using (var context = new Context())
            {
                var values = context.Reservations.Find(id);
                values.Status = "Onay Bekliyor";
                context.SaveChanges();
            }
        }
    }
}
