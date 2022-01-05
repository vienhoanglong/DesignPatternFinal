using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.AbstracFactory
{
    interface DatabaseFactory
    {
        DbConnection createConnection();
        DbCommand createCommand(String sql);
        DbCommand createCommand(String sql, DbConnection cn);
        DbDataAdapter createDataAdapter(DbCommand selectCmd);
        DbParameter createParam(String key, Object value);
        DbDataReader createDataReader(DbCommand cmd);
    }
}
