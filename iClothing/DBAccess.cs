using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClothing
{
    class DBAccess
    {
        private static SqlCeConnection objConnection;
        private static SqlCeDataAdapter objDataAdapter;
        public static string ConnectionString = "Data Source="+ ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        private static void OpenConnection()
        {
            try
            {
                if (objConnection == null)
                {
                    objConnection = new SqlCeConnection(ConnectionString);
                    objConnection.Open();
                }
                else
                {
                    if (objConnection.State != ConnectionState.Open)
                    {
                        objConnection = new SqlCeConnection(ConnectionString);
                        objConnection.Open();
                    }
                }
            }
            catch (Exception ex) { }
        }

        private static void CloseConnection()
        {
            try
            {
                if (!(objConnection == null))
                {
                    if (objConnection.State == ConnectionState.Open)
                    {
                        objConnection.Close();
                        objConnection.Dispose();
                    }
                }
            }
            catch (Exception ex) { }
        }

        public static DataTable FillDataTable(string Query, DataTable Table)
        {

            OpenConnection();
            try
            {
                objDataAdapter = new SqlCeDataAdapter(Query, objConnection);
                objDataAdapter.Fill(Table);
                objDataAdapter.Dispose();
                CloseConnection();

                return Table;
            }
            catch
            {
                return null;
            }
        }
            public static SqlCeDataReader ExecuteReader(string cmd)
            {
                try
                {
                SqlCeDataReader objReader;
                    objConnection = new SqlCeConnection(ConnectionString);
                    OpenConnection();
                    SqlCeCommand cmdRedr = new SqlCeCommand(cmd, objConnection);
                    objReader = cmdRedr.ExecuteReader(CommandBehavior.CloseConnection);
                    cmdRedr.Dispose();
                    return objReader;
                }
                catch
                {
                    return null;
                }
            }
            public static bool ExecuteQuery(string query)
            {
                try
                {
                    using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(query, connection))
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        public static bool IsServerConnected()
        {
            using (var l_oConnection = new SqlCeConnection(ConnectionString))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlCeException ex)
                {
                    return false;
                }
            }
        }

    }
}

