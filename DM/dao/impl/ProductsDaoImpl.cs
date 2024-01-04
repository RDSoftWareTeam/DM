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
    class ProductsDaoImpl: ProductsDao
    {
        /// <summary>
        /// 返回Products数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <returns>数据库表</returns>
        public DataTable returnProducts()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM t_products", connection))
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
        /// 编辑Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        public void editProducts(EntityProducts entityProducts)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_products SET productname = @productname, scanorder = @scanorder, notes = @notes WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityProducts.idSg);
                    updateCommand.Parameters.AddWithValue("@productname", entityProducts.productnameSg);
                    updateCommand.Parameters.AddWithValue("@scanorder", entityProducts.scanorderSg);
                    updateCommand.Parameters.AddWithValue("@notes", entityProducts.notesSg);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 增加Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        public void addProducts(EntityProducts entityProducts)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string insertQuery = "INSERT INTO t_products (productname, scanorder, notes) VALUES (@productname, @scanorder, @notes);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@productname", entityProducts.productnameSg);
                    insertCommand.Parameters.AddWithValue("@scanorder", entityProducts.scanorderSg);
                    insertCommand.Parameters.AddWithValue("@notes", entityProducts.notesSg);

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
        public void deleteProducts(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_products WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
