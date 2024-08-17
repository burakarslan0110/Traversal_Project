using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUOW
{
    public interface IGenericUOWService<T>
    {
        List<T> TGetAll();
        void TInsert(T t);
        void TUpdate(T t);
        void TMultiUpdate(List<T> t);

        T TGetByID(int id);
    }
}
