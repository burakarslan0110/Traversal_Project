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
	public class Feature1Manager : IFeature1Service
	{
		IFeature1Dal _feature1Dal;

		public Feature1Manager(IFeature1Dal feature1Dal)
		{
			_feature1Dal = feature1Dal;
		}

		public void TDelete(Feature1 t)
		{
			_feature1Dal.Delete(t);	
		}

		public Feature1 TGetByID(int id)
		{
			return _feature1Dal.GetByID(id);
		}

		public List<Feature1> TGetList()
		{
			return _feature1Dal.GetList();	
		}

		public void TInsert(Feature1 t)
		{
			_feature1Dal.Insert(t);
		}

		public void TUpdate(Feature1 t)
		{
			_feature1Dal.Update(t);	
		}
	}
}
