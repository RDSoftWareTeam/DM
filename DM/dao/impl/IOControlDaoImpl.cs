using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao.impl
{
    public class IOControlDaoImpl : IOControlDao
    {
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="filePath">数据库文件</param>
        /// <param name="deleteId">删除id</param>
        /// <param name="tableName">数据库表名</param>
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

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="filpath">数据库路径</param>
        /// <param name="ioInfo">用于获取前端所存的数据的实体类</param>
        public void InsertIOData(string filpath, IOInformationEntity ioInfo)
        {
            string sql = "insert into " + "t_ios" + " (ioname,truetext,falsetext,iotype,control,addr1,addr2) values(@value1,@value2,@value3,@value4,@value5,@value6,@value7)";
            using (SQLiteConnection connection = new SQLiteConnection(filpath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value1", ioInfo.IoName);
                    command.Parameters.AddWithValue("@value2", ioInfo.TrueText);
                    command.Parameters.AddWithValue("@value3", ioInfo.FalseText);
                    command.Parameters.AddWithValue("@value4", ioInfo.IoType);
                    command.Parameters.AddWithValue("@value5", ioInfo.Control);
                    command.Parameters.AddWithValue("@value6", ioInfo.Addr1);
                    command.Parameters.AddWithValue("@value7", ioInfo.Addr2);
                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">编辑时获取到的ID</param>
        /// <returns></returns>
        public IOInformationEntity QueryById(string filePath, string tableName, string id)
        {
            IOInformationEntity ioInfo = null;
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
                            ioInfo = new IOInformationEntity
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IoName = Convert.ToString(reader["ioname"]),
                                TrueText = Convert.ToString(reader["truetext"]),
                                FalseText = Convert.ToString(reader["falsetext"]),
                                IoType = Convert.ToInt32(reader["iotype"]),
                                Control = Convert.ToInt32(reader["control"]),
                                Addr1 = Convert.ToString(reader["addr1"]),
                                Addr2 = Convert.ToString(reader["addr2"]),
                            };
                        }
                    }
                }

                connection.Close();
            }
            return ioInfo;
        }

        /// <summary>
        /// 查询到数据在主页面中显示
        /// </summary>
        /// <param name="filepath">数据库路径</param>
        /// <param name="tableName">数据表表名</param>
        /// <returns></returns>
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

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">根据修改的id</param>
        /// <param name="ioInfo">存储前端文本的实体类</param>
        public void UpdateData(string filePath, string tableName, string id, IOInformationEntity ioInfo)
        {
            string sql = "update  " + "t_ios" + " set ioname=@ioName,truetext=@trueText,falsetext=@falseText,iotype=@ioType,control=@Control,addr1=@Addr1,addr2=@Addr2 where id=" + id;
            using (SQLiteConnection connection = new SQLiteConnection(filePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ioName", ioInfo.IoName);
                    command.Parameters.AddWithValue("@trueText", ioInfo.TrueText);
                    command.Parameters.AddWithValue("@falseText", ioInfo.FalseText);
                    command.Parameters.AddWithValue("@ioType", ioInfo.IoType);
                    command.Parameters.AddWithValue("@Control", ioInfo.Control);
                    command.Parameters.AddWithValue("@Addr1", ioInfo.Addr1);
                    command.Parameters.AddWithValue("@Addr2", ioInfo.Addr2);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
