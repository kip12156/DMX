using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEx
{
    internal class DataBaseConnection
    {
        static SqlConnection sqlConn = new SqlConnection("Data Source=ENDURANCE\\SQLEXPRESS;Initial Catalog=User_010;Integrated Security=True;");
    
        public static List<string> statusesList = new List<string>()
        {
            "В ожидании",
            "В работы",
            "Выполнено",
            "Не выполнено",
        };

        public static void OpenConnection()
        {
            sqlConn.Open();
        }

        public static void CloseConnection()
        {
            sqlConn.Close();
        }

        public static List<int> GetInvoicesId()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Invoice", sqlConn);
            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            var returnResult = new List<int>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    returnResult.Add(dataReader.GetInt32(0));
                }
            }
            CloseConnection();
            return returnResult;
        }
        public static List<int> GetInvoicesIdByExecutorId(int executorId)
        {
            SqlCommand cmd = new SqlCommand($"SELECT Id FROM Invoice WHERE ExecutorId = {executorId}", sqlConn);

            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            var returnResult = new List<int>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    returnResult.Add(dataReader.GetInt32(0));
                }
            }

            CloseConnection();
            return returnResult;
        }
        public static List<int> GetExecutorsId()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM [User] WHERE RoleId = 2", sqlConn);
            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            var returnResult = new List<int>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    returnResult.Add(dataReader.GetInt32(0));
                }
            }
            CloseConnection();
            return returnResult;
        }
        public static List<int> GetDefectsId()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Defect", sqlConn);
            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            var returnResult = new List<int>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    returnResult.Add(dataReader.GetInt32(0));
                }
            }
            CloseConnection();
            return returnResult;
        }
        public static List<int> GetDevicesId()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Device", sqlConn);
            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            var returnResult = new List<int>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    returnResult.Add(dataReader.GetInt32(0));
                }
            }
            CloseConnection();
            return returnResult;
        }
    
        public static bool AuthorizeUser(string login, string password)
        {
            SqlCommand cmd = new SqlCommand($"SELECT Id, RoleId FROM [User] WHERE Login = '{login}' AND Password = '{password}'", sqlConn);
            OpenConnection();
            var dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    MainWindow.UserId = dataReader.GetInt32(0);
                    if (dataReader.GetInt32(1) == 1)
                    {
                        MainWindow.UserRole = "User";
                        CloseConnection();
                        return true;
                    }
                    else if (dataReader.GetInt32(1) == 2)
                    {
                        MainWindow.UserRole = "Executor";
                        CloseConnection();
                        return true;
                    }
                    else if (dataReader.GetInt32(1) == 3)
                    {
                        MainWindow.UserRole = "Manager";
                        CloseConnection();
                        return true;
                    }
                    else
                    {
                        CloseConnection();
                        return false;
                    }
                }
            }
            else
            {
                CloseConnection();
                return false;
            }
            CloseConnection();
            return false;
        }

        public static bool AddInvoice(string clientName, string clientEmail, int deviceId, string serialNumber, int defectId, string defectDescription, string finishDate)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO Invoice (ClientName, ClientEmail, DeviceId, SerialNumber, DefectId, DefectDescription, CreationDate, FinishDate, Status)" +
                $"VALUES (@ClientName, @ClientEmail, @DeviceId, @SerialNumber, @DefectId, @DefectDescription, @CreationDate, @FinishDate, 'В ожидании')" , sqlConn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@ClientName", clientName);
            cmd.Parameters.AddWithValue("@ClientEmail", clientEmail);
            cmd.Parameters.AddWithValue("@DeviceId", deviceId);
            cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
            cmd.Parameters.AddWithValue("@DefectId", defectId);
            cmd.Parameters.AddWithValue("@DefectDescription", defectDescription);
            cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@FinishDate", finishDate);
            var creationresult = cmd.ExecuteNonQuery();
            CloseConnection();
            if (creationresult < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool EditInvoice(int invoiceId, int executorId, string defectDescription)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE Invoice SET ExecutorId = {executorId}, DefectDescription = '{defectDescription}' Where Id = {invoiceId}", sqlConn);
            OpenConnection();
            var updateResult = cmd.ExecuteNonQuery();
            CloseConnection();
            if (updateResult < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataTable GetAllInvoices()
        {
            SqlCommand cmd = new SqlCommand($"Select * FROM Invoice", sqlConn);
            OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public static bool AcceptInvoiceinWork(int invoiceId)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE Invoice SET Status = 'В работе'  Where Id = {invoiceId}", sqlConn);
            OpenConnection();
            var updateResult = cmd.ExecuteNonQuery();
            CloseConnection();
            if (updateResult < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CompleteInvoice(int invoiceId, string executorComment)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE Invoice SET Status = 'Выполнено', ExecutorComment = '{executorComment}' Where Id = {invoiceId}", sqlConn);
            OpenConnection();
            var updateResult = cmd.ExecuteNonQuery();
            CloseConnection();
            if (updateResult < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetCompletedInvoiceCount()
        {
            SqlCommand cmd = new SqlCommand("SELECT Count(Id) FROM Invoice WHERE Status = 'Выполнено'", sqlConn);
            OpenConnection();
            var result = cmd.ExecuteScalar();
            CloseConnection();
            if (result == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return (int)result;
            }    
        }
    }
}
