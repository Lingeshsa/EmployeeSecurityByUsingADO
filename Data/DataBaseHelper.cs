
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace EmployeeSecurityByUsingADO.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

        public DataBaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int InsertUpdateDelete(string query, SqlParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in InsertUpdateDelete: " + ex.Message);
                return -1; 
            }
        }


        public DataTable GetData(string query, SqlParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetData: " + ex.Message);
                return null;
            }
        }

    }

}

