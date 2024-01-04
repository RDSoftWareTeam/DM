using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.dao;

namespace DM.dao.impl
{
    class ScanareasDaoImpl: ScanareasDao
    {
        /// <summary>
        /// 返回Scanareas数据
        /// </summary>
        /// <returns></returns>
        public DataTable returnScanareas()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT t_scanareas.*,t_products.productname FROM t_scanareas JOIN t_products ON t_scanareas.idt_products = t_products.id", connection))

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
        /// 编辑Scanareas数据
        /// </summary>
        /// <param name="entityScanareas"></param>
        /// <param name="options1"></param>
        public void editScanareas(EntityScanareas entityScanareas, List<string> options1)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_scanareas SET areano = @areano, offsetx = @offsetx, offsety = @offsety, offsetz = @offsetz, scanlen = @scanlen, indexlen = @indexlen, scanres = @scanres, indexres = @indexres, idt_products= @idt_products WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityScanareas.idSg);
                    updateCommand.Parameters.AddWithValue("@areano", entityScanareas.areanoSg);
                    updateCommand.Parameters.AddWithValue("@offsetx", entityScanareas.offsetxSg);
                    updateCommand.Parameters.AddWithValue("@offsety", entityScanareas.offsetySg);
                    updateCommand.Parameters.AddWithValue("@offsetz", entityScanareas.offsetzSg);
                    updateCommand.Parameters.AddWithValue("@scanlen", entityScanareas.scanlenSg);
                    updateCommand.Parameters.AddWithValue("@indexlen", entityScanareas.indexlenSg);
                    updateCommand.Parameters.AddWithValue("@scanres", entityScanareas.scanresSg);
                    updateCommand.Parameters.AddWithValue("@indexres", entityScanareas.indexresSg);
                    int index1 = options1.IndexOf(entityScanareas.idt_productsSg) + 1;
                    updateCommand.Parameters.AddWithValue("@idt_products", index1);
                    connection.Open();
                    updateCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 增加Scanareas数据
        /// </summary>
        /// <param name="entityScanareas"></param>
        /// <param name="options1"></param>
        public void addScanareas(EntityScanareas entityScanareas, List<string> options1)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {

                string insertQuery = "INSERT INTO t_scanareas (areano, offsetx, offsety, offsetz, scanlen, indexlen, scanres, indexres,idt_products) VALUES (@areano, @offsetx, @offsety, @offsetz, @scanlen, @indexlen, @scanres, @indexres,@idt_products);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {

                    insertCommand.Parameters.AddWithValue("@areano", entityScanareas.areanoSg);
                    insertCommand.Parameters.AddWithValue("@offsetx", entityScanareas.offsetxSg);
                    insertCommand.Parameters.AddWithValue("@offsety", entityScanareas.offsetySg);
                    insertCommand.Parameters.AddWithValue("@offsetz", entityScanareas.offsetzSg);
                    insertCommand.Parameters.AddWithValue("@scanlen", entityScanareas.scanlenSg);
                    insertCommand.Parameters.AddWithValue("@indexlen", entityScanareas.indexlenSg);
                    insertCommand.Parameters.AddWithValue("@scanres", entityScanareas.scanresSg);
                    insertCommand.Parameters.AddWithValue("@indexres", entityScanareas.indexresSg);
                    int index1 = options1.IndexOf(entityScanareas.idt_productsSg) + 1;
                    insertCommand.Parameters.AddWithValue("@idt_products", index1);
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }
        /// <summary>
        /// 删除选定行数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <param name="delete_id">数据库选定id</param>
        public void deleteScanareas(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_scanareas WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
