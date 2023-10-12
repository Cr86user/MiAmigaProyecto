using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Implementacion
{
    public class BaseImpl
    {
            string connectionString = @"Server=Lopezito\SQLEXPRESS;Database=bdMiAmiga;User Id=sa;Password=Univalle;";
            internal string query = "";
            public string GetGenerateIDTable(string table)
            {
                query = @"SELECT IDENT_CURRENT('" + table + "') + IDENT_INCR('" + table + "')";
                SqlCommand command = CreateBasicCommand(query);
                try
                {
                    command.Connection.Open();
                    return command.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            public SqlCommand CreateBasicCommand(string sql)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                return command;
            }
            public List<SqlCommand> Create2BasicCommand(string sql1, string sql2)
            {
                List<SqlCommand> commands = new List<SqlCommand>();
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command1 = new SqlCommand(sql1, connection);
                commands.Add(command1);

                SqlCommand command2 = new SqlCommand(sql2, connection);
                commands.Add((command2));

                return commands;
            }
        public List<SqlCommand> Create3BasicCommand(string sql1, string sql2, string sql3)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command1 = new SqlCommand(sql1, connection);
            commands.Add(command1);

            SqlCommand command2 = new SqlCommand(sql2, connection);
            commands.Add((command2));

            SqlCommand command3 = new SqlCommand(sql3, connection);
            commands.Add((command3));

            return commands;
        }

        public int ExecuteBasicCommand(SqlCommand command)
            {
                try
                {
                    command.Connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            public void ExecuteNBasicCommand(List<SqlCommand> commands)
            {

                SqlCommand command0 = commands[0];


                try
                {
                    commands[0].Connection.Open();


                    foreach (SqlCommand item in commands)
                    {
                        item.ExecuteNonQuery();
                    }




                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command0.Connection.Close();
                }
            }

            public DataTable ExecuteDataTableCommand(SqlCommand command)
            {
                DataTable table = new DataTable();
                try
                {
                    command.Connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    command.Connection.Close();
                }
                return table;
            }
        
    } 
}
