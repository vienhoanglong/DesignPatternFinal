using QuanLiRapPhim.Patterns.AbstractFactory;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.DAO
{
    public class DataProvider
    {

        private DataProvider() { }
        private static DataProvider instance;
        public static DataProvider getInstance()
        {
            if (instance == null)
            {
                instance = new DataProvider();
            }
            return instance;
        }

        private static string connectionSTR = "Data Source=.;Initial Catalog=QLRP;Integrated Security=True";
        public bool TestConnectionSQL(string conn)
        {
            bool result = false;
            connectionSTR = conn;
            try
            {
                SqlConnection connection = (SqlConnection) new DatabaseMySql().createConnection();
                connection.Open();
                result = true;
                connection.Close();
                
            }
            catch
            {
                return false;
            }
            return result;
        }


        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                SqlConnection connection = (SqlConnection) new DatabaseMySql().createConnection();

                connection.Open();

                SqlCommand command = (SqlCommand) new DatabaseMySql().createCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter =(SqlDataAdapter) new DatabaseMySql().createDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            try
            {
                SqlConnection connection = (SqlConnection)new DatabaseMySql().createConnection();

                connection.Open();

                SqlCommand command = (SqlCommand)new DatabaseMySql().createCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            try
            {
                SqlConnection connection = (SqlConnection)new DatabaseMySql().createConnection();
                connection.Open();
                SqlCommand command = (SqlCommand)new DatabaseMySql().createCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        
    }
}
