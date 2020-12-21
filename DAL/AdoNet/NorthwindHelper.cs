using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AdoNet
{
    public class NorthwindHelper
    {
        private readonly string connectionString;
        public NorthwindHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public SqlDataReader GetEntity(string cmdText, List<SqlParameter> sqlParameters = null, CommandType type = CommandType.Text)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand())
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                command.Connection = con;
                command.CommandText = cmdText;
                if (sqlParameters != null)
                    command.Parameters.AddRange(sqlParameters.ToArray());
                command.CommandType = type;
                con.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
        public int ExecCommand(string cmdText, List<SqlParameter> parameters = null, CommandType type = CommandType.Text)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    command.CommandType = type;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    result= command.ExecuteNonQuery();
                    connection.Close();
                    return result;
                }
            }
        }
    }

}
