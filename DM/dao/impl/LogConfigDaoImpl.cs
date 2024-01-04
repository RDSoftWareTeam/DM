using System;
using System.Data;
using System.Data.SQLite;
using DM.entity;

namespace DM.dao.impl
{
    public class LogConfigDaoImpl : LogConfigDao
    {
        public void DeleteById(string filePath, string deleteId, string tableName)
        {
            string sql = "delete from " + tableName + " where id=" + deleteId;
            using (SQLiteConnection connection = new SQLiteConnection(filePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void InsertLogConfigData(string filpath, LogConfigEntity logInfo)
        {
            string sql = "insert into " + "t_logconfigure" + " (logname,logkey,strtemplate) values(@value1,@value2,@value3)";
            using (SQLiteConnection connection = new SQLiteConnection(filpath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@value1", logInfo.LogName);
                    command.Parameters.AddWithValue("@value2", logInfo.LogKey);
                    command.Parameters.AddWithValue("@value3", logInfo.StrTemplate);
                    
                    command.ExecuteNonQuery();

                }
            }
        }

        public LogConfigEntity QueryById(string filePath, string tableName, string id)
        {
            LogConfigEntity logConfigEntity = null;

            string sql = "select * from " + tableName + " where id=" + id;
            using (SQLiteConnection connection = new SQLiteConnection(filePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            logConfigEntity = new LogConfigEntity
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                LogName = Convert.ToString(reader["logname"]),
                                LogKey = Convert.ToString(reader["logkey"]),
                                StrTemplate = Convert.ToInt32(reader["strtemplate"])
                            };
                        }
                    }
                }

                connection.Close();
            }


            return logConfigEntity;
        }

        public DataTable QueryByTable(string filepath, string tableName)
        {
            DataTable dataTable = new DataTable();
            //List<IOInformationEntity> list = new List<IOInformationEntity>();

            using (SQLiteConnection connection = new SQLiteConnection(filepath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + tableName, connection))
                {
                    //SQLiteDataAdapter类可以将数据填充到DataTable里
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                connection.Close();
            }
            return dataTable;
        }

        public void UpdateData(string filePath, string tableName, string id, LogConfigEntity logInfo)
        {
            string sql = "update  " + "t_logconfigure" + " set logname=@logName,logkey=@logKey,strtemplate=@strTemplate where id=" + id;
            using (SQLiteConnection connection = new SQLiteConnection(filePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@logName", logInfo.LogName);
                    command.Parameters.AddWithValue("@logKey", logInfo.LogKey);
                    command.Parameters.AddWithValue("@strTemplate", logInfo.StrTemplate);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
