using QuanLiRapPhim.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace QuanLiRapPhim.Patterns.Strategy
{
    public class ObjectCRUD
    {
        protected LoadMethod loadMethod;
        protected AddMethod addMethod;
        protected UpdateMethod updateMethod;
        protected DeleteMethod deleteMethod;

        public ObjectCRUD(string ob)
        {
            switch (ob)
            {
                case "KhachHang":
                    setAddMethod(new AddKH());
                    setLoadMethod(new LoadKH());
                    setUpdateMethod(new UpdateKH());
                    setDeleteMethod(new DeleteKH());
                    break;
                case "NhanVien":
                    setAddMethod(new AddNV());
                    setLoadMethod(new LoadNV());
                    setUpdateMethod(new UpdateNV());
                    setDeleteMethod(new DeleteNV());
                    break;
                case "TaiKhoan":
                    setAddMethod(new AddTK());
                    setLoadMethod(new LoadTK());
                    setUpdateMethod(new UpdateTK());
                    setDeleteMethod(new DeleteTK());
                    break;
                case "Phim":
                    setAddMethod(new AddMV());
                    setLoadMethod(new LoadMV());
                    setUpdateMethod(new UpdateMV());
                    setDeleteMethod(new DeleteMV());
                    break;
                case "TheLoai":
                    setAddMethod(new AddTL());
                    setLoadMethod(new LoadTL());
                    setUpdateMethod(new UpdateTL());
                    setDeleteMethod(new DeleteTL());
                    break;

            }


        }
        public void setLoadMethod(LoadMethod load)
        {
            loadMethod = load;
        }
        public void setAddMethod(AddMethod add)
        {
            addMethod = add;
        }
        public void setUpdateMethod(UpdateMethod update)
        {
            updateMethod = update;
        }
        public void setDeleteMethod(DeleteMethod delete)
        {
            deleteMethod = delete;
        }

        public void add(ArrayList data)
        {
            addMethod.add(data);
        }
        public void update(ArrayList data)
        {
            updateMethod.update(data);
        }
        public DataTable load()
        {
            return loadMethod.load();
        }
        public void delete(string id)
        {
            deleteMethod.delete(id);
        }
    }
}
