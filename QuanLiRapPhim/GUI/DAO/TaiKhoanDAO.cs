using QuanLiRapPhim.DTO;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuanLiRapPhim.DAO
{
    public class TaiKhoanDAO
    {
        private TaiKhoanDAO() { }

        private static string PasswordEncryption(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            char[] arr = hasPass.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static int Login(string userName, string passWord)
        {
            string pass = PasswordEncryption(passWord);

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.getInstance().ExecuteQuery(query, new object[]
            { userName, pass });
            if (result == null)
                return -1;
            else if (result.Rows.Count > 0)
                return 1;
            else
                return 0;
        }
        public static bool UpdatePasswordForAccount(string userName, string passWord, string newPassWord)
        {

            string oldPass = PasswordEncryption(passWord);
            string newPass = PasswordEncryption(newPassWord);

            int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_UpdatePasswordForAccount @username , @pass , @newPass", new object[] { userName, oldPass, newPass });

            return result > 0;
        }

        public static TaiKhoan GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.getInstance().ExecuteQuery("Select * from TaiKhoan where userName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new TaiKhoan(row);
            }

            return null;
        }
        public static void DeleteAccountByIdStaff(string idStaff)
        {
            DataProvider.getInstance().ExecuteQuery("DELETE dbo.TaiKhoan WHERE idNV = '" + idStaff + "'");
        }

		public static DataTable GetAccountList()
		{
			return DataProvider.getInstance().ExecuteQuery("USP_GetAccountList");
		}

		public static bool InsertAccount(string username, int accountType, string staffID)
		{
			int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_InsertAccount @username , @loaiTK , @idnv ", new object[] { username, accountType, staffID });
			return result > 0;
		}

		public static bool UpdateAccount(string username, int accountType)
		{
			string command = string.Format("USP_UpdateAccount  @username , @loaiTK", new object[] { username, accountType});
			int result = DataProvider.getInstance().ExecuteNonQuery(command);
			return result > 0;
		}

		public static bool DeleteAccount(string username)
		{
			int result = DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.TaiKhoan WHERE UserName = N'" + username + "'");
			return result > 0;
		}

		public static DataTable SearchAccountByStaffName(string name)
		{
			return DataProvider.getInstance().ExecuteQuery("EXEC USP_SearchAccount @hoten ", new object[] { name });
		}

		public static bool ResetPassword(string username)
		{
			int result = DataProvider.getInstance().ExecuteNonQuery("USP_ResetPasswordtAccount @username", new object[] { username});
			return result > 0;
		}
    }
}
