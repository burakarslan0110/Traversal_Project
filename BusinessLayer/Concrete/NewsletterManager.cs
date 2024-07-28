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
	public class NewsletterManager : INewsletterService
	{
		INewsletterDal _newsletterManager;

		public NewsletterManager(INewsletterDal newsletterManager)
		{
			_newsletterManager = newsletterManager;
		}

		public void TDelete(Newsletter t)
		{
			_newsletterManager.Delete(t);
		}

		public Newsletter TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Newsletter> TGetList()
		{
			return _newsletterManager.GetList();	
		}

		public void TInsert(Newsletter t)
		{
			_newsletterManager.Insert(t);	
		}

		public void TUpdate(Newsletter t)
		{
			_newsletterManager.Update(t);
		}
	}
}
