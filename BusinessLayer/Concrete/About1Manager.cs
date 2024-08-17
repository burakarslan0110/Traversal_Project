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
	public class About1Manager : IAbout1Service
	{
		IAbout1Dal _about1Dal;

		public About1Manager(IAbout1Dal aboutDal)
		{
			_about1Dal = aboutDal;
		}

		public void TDelete(About1 t)
		{
			_about1Dal.Delete(t);
		}

		public List<About1> TGetList()
		{
			return _about1Dal.GetList();
		}

		public About1 TGetByID(int id)
		{
			return _about1Dal.GetByID(id);
		}

		public void TInsert(About1 t)
		{
			_about1Dal.Insert(t);
		}

		public void TUpdate(About1 t)
		{
			_about1Dal.Update(t);
		}
	}
}
