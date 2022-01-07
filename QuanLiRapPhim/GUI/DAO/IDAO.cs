using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.DAO
{
    interface IDAO<T>
    {
        List<T> getall();
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);
    }
}
