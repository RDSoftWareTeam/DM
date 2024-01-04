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
    class LayoutsDaoImpl: LayoutsDao
    {
        /// <summary>
        /// 返回Layouts数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <returns>数据库表</returns>
        public DataTable returnLayouts()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM t_layouts", connection))
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
        /// 增加Layouts数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void addLayouts(EntityLayouts entityLayouts)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {

                string insertQuery = "INSERT INTO t_layouts (layoutname, rows, cols) VALUES (@layoutname, @rows, @cols);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {

                    insertCommand.Parameters.AddWithValue("@layoutname", entityLayouts.layoutnameSg);
                    insertCommand.Parameters.AddWithValue("@rows", entityLayouts.rowsSg);
                    insertCommand.Parameters.AddWithValue("@cols", entityLayouts.colsSg);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }
        /// <summary>
        /// 编辑Layouts数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void editLayouts(EntityLayouts entityLayouts)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_layouts SET layoutname = @layoutname, rows = @rows, cols = @cols WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityLayouts.idSg);
                    updateCommand.Parameters.AddWithValue("@layoutname", entityLayouts.layoutnameSg);
                    updateCommand.Parameters.AddWithValue("@rows", entityLayouts.rowsSg);
                    updateCommand.Parameters.AddWithValue("@cols", entityLayouts.colsSg);

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
        public void deleteLayouts(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_layouts WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
