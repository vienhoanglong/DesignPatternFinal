using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Strategy
{
    public interface AddMethod
    {
        void add(ArrayList data);
    }
    public interface LoadMethod
    {
        DataTable load();
    }
    public interface UpdateMethod
    {
        void update(ArrayList data);
    }
    public interface DeleteMethod
    {
        void delete(string id);
    }
}
