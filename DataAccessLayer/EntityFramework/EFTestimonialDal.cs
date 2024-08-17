using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        Context context = new Context();
        public void ChangeToFalseByTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void ChangeToTrueByTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            values.Status = true;
            context.SaveChanges();
        }
    }
}
