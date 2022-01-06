using QuanLiRapPhim.Patterns.AbstracFactory;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.AbstractFactory
{
    class DatabaseSqlServer : DatabaseFactory
    {
        private static readonly object padlock = new object();
        private static SqlConnection con;


        //Signleton
        public DbConnection createConnection()
        {
            if (con == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    con = new SqlConnection(@"Data Source=.;Initial Catalog=QLRP;Integrated Security=True");
                }
            }
            return con;
        }

        public DbCommand createCommand(string sql)
        {
            return new SqlCommand(sql, con);
        }

        public DbParameter createParam(string key, object value)
        {
            return new SqlParameter(key, value);
        }

        public DbDataReader createDataReader(DbCommand cmd)
        {
            return cmd.ExecuteReader();
        }

        public DbCommand createCommand(string sql, DbConnection cn)
        {
            return new SqlCommand(sql, (SqlConnection)cn);
        }

        public DbDataAdapter createDataAdapter(DbCommand selectCmd)
        {
            return new SqlDataAdapter((SqlCommand)selectCmd);
        }
    }
}
