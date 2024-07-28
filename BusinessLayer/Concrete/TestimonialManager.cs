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
	public class TestimonialManager : ITestimonialService
	{
		ITestimonialDal _testimonialDal;

		public TestimonialManager(ITestimonialDal testimonialDal)
		{
			_testimonialDal = testimonialDal;
		}

		public void TDelete(Testimonial t)
		{
			_testimonialDal.Delete(t);
		}

		public Testimonial TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Testimonial> TGetList()
		{
			return _testimonialDal.GetList();
		}

		public void TInsert(Testimonial t)
		{
			_testimonialDal.Insert(t);
		}

		public void TUpdate(Testimonial t)
		{
			_testimonialDal.Update(t);
		}
	}
}
