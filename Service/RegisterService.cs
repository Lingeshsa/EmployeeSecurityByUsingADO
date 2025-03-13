using EmployeeSecurityByUsingADO.Data;
using EmployeeSecurityByUsingADO.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeSecurityByUsingADO.Service
{
    public class RegisterService : IRegisterService
    {

        private readonly DataBaseHelper _dbHelper;

        public RegisterService(DataBaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool DeleteUser(int id)
        {
            try
            {
                
                SqlParameter[] parameters = { new SqlParameter("@UserId", id) };

                int result = _dbHelper.InsertUpdateDelete("sp_DeleteUser", parameters, CommandType.StoredProcedure);
                return result > 0;  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
                return false;
            }
        }

        public List<RegisterModel> GetAllUsers()
        {
            List<RegisterModel> users = new List<RegisterModel>();

            try
            {
                DataTable dataTable = _dbHelper.GetData("sp_GetAllUsers", null, CommandType.StoredProcedure);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        RegisterModel user = new RegisterModel
                        {
                            UserId = Convert.ToInt32(row["Id"]),
                            firstName = row["FirstName"].ToString(),
                            lastName = row["LastName"].ToString(),
                            DOB = row.Field<DateTime>("DOB"),
                            Gender = row["Gender"].ToString(),
                            phoneNumber = row["PhoneNumber"].ToString(),
                            emailAddress = row["EmailAddress"].ToString(),
                            address = row["Address"].ToString(),
                            state = row["State"].ToString(),
                            city = row["City"].ToString(),
                            userName = row["UserName"].ToString()
                        };

                        users.Add(user);
                    }
                }

                Console.WriteLine("Users count: " + users.Count);

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<RegisterModel>();
            }
        }

        public RegisterModel GetUserById(int id)
        {
            RegisterModel user = null;

            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", id) };

                DataTable dataTable = _dbHelper.GetData("sp_GetUserById", parameters, CommandType.StoredProcedure);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    user = new RegisterModel
                    {
                        UserId = Convert.ToInt32(row["Id"]),
                        firstName = row["FirstName"]?.ToString() ?? "",
                        lastName = row["LastName"]?.ToString() ?? "",
                        DOB = row.Field<DateTime>("DOB"),
                        Gender = row["Gender"]?.ToString() ?? "",
                        phoneNumber = row["PhoneNumber"]?.ToString() ?? "",
                        emailAddress = row["EmailAddress"]?.ToString() ?? "",
                        address = row["Address"]?.ToString() ?? "",
                        state = row["State"]?.ToString() ?? "",
                        city = row["City"]?.ToString() ?? "",
                        userName = row["UserName"]?.ToString() ?? ""
                    };

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return user;
        }

        public bool RegisterUser(RegisterModel user)
        {
            try
            {
                SqlParameter[] parameters =
                {

            new SqlParameter("@firstName", user.firstName),
            new SqlParameter("@lastName", user.lastName),
            new SqlParameter("@DOB", user.DOB),
            new SqlParameter("@Gender", user.Gender),
            new SqlParameter("@phoneNumber", user.phoneNumber),
            new SqlParameter("@emailAddress", user.emailAddress),
            new SqlParameter("@address", user.address),
            new SqlParameter("@state", user.state),
            new SqlParameter("@city", user.city),
            new SqlParameter("@userName", user.userName),
            new SqlParameter("@password", user.password)
            };

                int result = _dbHelper.InsertUpdateDelete("dbo.sp_InsertUser", parameters, CommandType.StoredProcedure);
                return result > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }


        public bool UpdateUser(RegisterModel user)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Id", user.UserId),
            new SqlParameter("@FirstName", user.firstName),
            new SqlParameter("@LastName", user.lastName),
            new SqlParameter("@DOB", user.DOB),
            new SqlParameter("@Gender", user.Gender),
            new SqlParameter("@PhoneNumber", user.phoneNumber),
            new SqlParameter("@EmailAddress", user.emailAddress),
            new SqlParameter("@Address", user.address),
            new SqlParameter("@State", user.state),
            new SqlParameter("@City", user.city),
            new SqlParameter("@UserName", user.userName)
        };

                int rowsAffected = _dbHelper.InsertUpdateDelete("sp_UpdateUser", parameters, CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }



    }
}
