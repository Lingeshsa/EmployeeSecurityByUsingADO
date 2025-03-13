using EmployeeSecurityByUsingADO.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeSecurityByUsingADO.Service
{
    public class AuthService : IAuthService
    {

        private readonly DataBaseHelper? _dbHelper;
        public bool ValidateAdmin(string userName, string password)
        {
            return userName == "admin" && password == "password";

        }

        public int InsertAdmin(string userName, string password)
        {
            string query = "INSERT INTO Admins (Username, Password) VALUES (@Username, @Password)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Password", password) 
            };

            return _dbHelper.InsertUpdateDelete(query, parameters, CommandType.Text);
        }

        public int UpdateAdmin(int adminId, string newUserName, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }
    }
}
