using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;
namespace DM.dao.impl
{
    class AccessoriesDaoImpl : AccessoriesDao
    {
        /// <summary>
        /// t_acc添加数据
        /// </summary>
        /// <param name="acc"></param>
        public void InsertDataToAcc(Accessories acc)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO t_accessories (accname, starttime, acctype, updatetime, circletime, circleunit) VALUES(@acc_accname, @acc_starttime, @acc_acctype, @acc_updatetime, @acc_circletime, @acc_circleunit);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_accname", acc.accname);
                    command.Parameters.AddWithValue("@acc_starttime", acc.starttime);
                    command.Parameters.AddWithValue("@acc_acctype", acc.acctype);
                    command.Parameters.AddWithValue("@acc_updatetime", acc.updatetime);
                    command.Parameters.AddWithValue("@acc_circletime", acc.circletime);
                    command.Parameters.AddWithValue("@acc_circleunit", acc.circleunit);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// t_acc更新数据
        /// </summary>
        /// <param name="acc"></param>
        public void UpdateDataToAcc(Accessories acc)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "UPDATE t_accessories SET accname = @acc_accname, starttime = @acc_starttime, acctype = @acc_acctype, updatetime = @acc_updatetime, circletime = @acc_circletime, circleunit = @acc_circleunit WHERE id = @acc_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc.id);
                    command.Parameters.AddWithValue("@acc_accname", acc.accname);
                    command.Parameters.AddWithValue("@acc_starttime", acc.starttime);
                    command.Parameters.AddWithValue("@acc_acctype", acc.acctype);
                    command.Parameters.AddWithValue("@acc_updatetime", acc.updatetime);
                    command.Parameters.AddWithValue("@acc_circletime", acc.circletime);
                    command.Parameters.AddWithValue("@acc_circleunit", acc.circleunit);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 查询t_accessories表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAccAllData()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_accessories";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                connection.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// 删除易损/点检id的数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        public void DeleteAccRowData(int acc_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM t_accessories WHERE ID = @acc_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 查询易损/点检id的那行数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        /// <returns></returns>
        public DataTable SelectRowDataFromAccID(int acc_id)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_accessories WHERE id = (SELECT @acc_id FROM t_accessories); ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 查询该易损/点检id的起始时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public string SelectStartTime(int acc_id)
        {
            string starttime = null;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT starttime FROM t_accessories WHERE id = @acc_id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            starttime = reader["starttime"].ToString();
                            return starttime;
                        }
                    }
                }
                connection.Close();
            }
            return starttime;
        }

        /// <summary>
        /// 查询该易损/点检id的更新时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public string SelectUpdateTime(int acc_id)
        {
            string updatetime = null;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT updatetime FROM t_accessories WHERE id = @acc_id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            updatetime = reader["updatetime"].ToString();
                            return updatetime;
                        }
                    }
                }
                connection.Close();
            }
            return updatetime;
        }

        /// <summary>
        /// 查询该易损/点检id的周期
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public int SelectCircleTime(int acc_id)
        {
            int circletime = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT circletime FROM t_accessories WHERE id = @acc_id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            circletime = Convert.ToInt32(reader["circletime"]);
                            return circletime;
                        }
                    }
                }
                connection.Close();
            }
            return circletime;
        }

        /// <summary>
        /// 查询该易损/点检id的周期单位
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public int SelectCircleUnit(int acc_id)
        {
            int circleunit = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT circleunit FROM t_accessories WHERE id = @acc_id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@acc_id", acc_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            circleunit = Convert.ToInt32(reader["circleunit"]);
                            return circleunit;
                        }
                    }
                }
                connection.Close();
            }
            return circleunit;
        }
    }
}
