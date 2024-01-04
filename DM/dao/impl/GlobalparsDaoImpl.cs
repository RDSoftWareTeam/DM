using DM.dao;
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
    class GlobalparsDaoImpl: GlobalparsDao
    {
        /// <summary>
        /// 返回Globalpars数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <returns>数据库表</returns>
        public DataTable returnGlobalpars()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM t_globalpars", connection))
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
        /// 增加Globalpars数据
        /// </summary>
        /// <param name="entityGlobalpars"></param>
        public void addGlobalpars(EntityGlobalpars entityGlobalpars)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {

                string insertQuery = "INSERT INTO t_globalpars (parname, parvalue, dispname) VALUES (@parname, @parvalue, @dispname);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {

                    insertCommand.Parameters.AddWithValue("@parname", entityGlobalpars.parnameSg);
                    insertCommand.Parameters.AddWithValue("@parvalue", entityGlobalpars.parvalueSg);
                    insertCommand.Parameters.AddWithValue("@dispname", entityGlobalpars.dispnameSg);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }
        /// <summary>
        /// 编辑Globalpars数据
        /// </summary>
        /// <param name="entityGlobalpars"></param>
        public void editGlobalpars(EntityGlobalpars entityGlobalpars)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_globalpars SET parname = @parname, parvalue = @parvalue, dispname = @dispname WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityGlobalpars.idSg);
                    updateCommand.Parameters.AddWithValue("@parname", entityGlobalpars.parnameSg);
                    updateCommand.Parameters.AddWithValue("@parvalue", entityGlobalpars.parvalueSg);
                    updateCommand.Parameters.AddWithValue("@dispname", entityGlobalpars.dispnameSg);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 删除选定行数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <param name="delete_id">数据库选定id</param>
        public void deleteGlobalpars(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_globalpars WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
