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
    public class MonitorParaDaoImpl : MonitorParaDao
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

        public void InsertMonitorParaData(string filpath, MonitorParaEntity paraInfo)
        {
            string sql = "insert into " + "t_keyparameters" + " (ioname,upthreshv,upenableflg,upcolor,dwnthreshv,dwnenableflg,dwncolor,datatype,startaddr) values(@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)";
            using (SQLiteConnection connection = new SQLiteConnection(filpath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@value1", paraInfo.IoName);
                    command.Parameters.AddWithValue("@value2", paraInfo.UpThreshv);
                    command.Parameters.AddWithValue("@value3", paraInfo.UpEnableFlg);
                    command.Parameters.AddWithValue("@value4", paraInfo.UpColor);
                    command.Parameters.AddWithValue("@value5", paraInfo.DwnThreshv);
                    command.Parameters.AddWithValue("@value6", paraInfo.DwnEnableFlg);
                    command.Parameters.AddWithValue("@value7", paraInfo.DwnColor);
                    command.Parameters.AddWithValue("@value8", paraInfo.DataType);
                    command.Parameters.AddWithValue("@value9", paraInfo.StartAddr);
                    command.ExecuteNonQuery();

                }
            }
        }

        public MonitorParaEntity QueryById(string filePath, string tableName, string id)
        {
            MonitorParaEntity paraInfo = new MonitorParaEntity();

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
                            paraInfo = new MonitorParaEntity
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IoName = Convert.ToString(reader["ioname"]),
                                UpThreshv = Convert.ToString(reader["upthreshv"]),
                                UpEnableFlg = Convert.ToInt32(reader["upenableflg"]),
                                UpColor = Convert.ToInt32(reader["upcolor"]),
                                DwnThreshv = Convert.ToString(reader["dwnthreshv"]),
                                DwnEnableFlg = Convert.ToInt32(reader["dwnenableflg"]),
                                DwnColor = Convert.ToInt32(reader["dwncolor"]),
                                DataType = Convert.ToString(reader["datatype"]),
                                StartAddr = Convert.ToString(reader["startaddr"])

                            };
                        }
                    }
                }

                connection.Close();
            }


            return paraInfo;
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

        public void UpdateData(string filePath, string tableName, string id, MonitorParaEntity paraInfo)
        {
            string sql = "update  " + tableName + " set ioname=@ioName,upthreshv=@upThreshv,upenableflg=@upEnableFlg,upcolor=@upColor,dwnthreshv=@dwnThreshv,dwnenableflg=@dwnEnableFlg,dwncolor=@dwnColor,datatype=@dataType,startaddr=@startAddr where id=" + id;
            using (SQLiteConnection connection = new SQLiteConnection(filePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ioName", paraInfo.IoName);
                    command.Parameters.AddWithValue("@upThreshv", paraInfo.UpThreshv);
                    command.Parameters.AddWithValue("@upEnableFlg", paraInfo.UpEnableFlg);
                    command.Parameters.AddWithValue("@upColor", paraInfo.UpColor);
                    command.Parameters.AddWithValue("@dwnThreshv", paraInfo.DwnThreshv);
                    command.Parameters.AddWithValue("@dwnEnableFlg", paraInfo.DwnEnableFlg);
                    command.Parameters.AddWithValue("@dwnColor", paraInfo.DwnColor);
                    command.Parameters.AddWithValue("@dataType", paraInfo.DataType);
                    command.Parameters.AddWithValue("@startAddr", paraInfo.StartAddr);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
