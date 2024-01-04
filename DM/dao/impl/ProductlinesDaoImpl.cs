
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
    class ProductlinesDaoImpl : ProductlinesDao
    {
        /// <summary>
        /// 返回Productlines数据
        /// </summary>
        /// <returns></returns>
        public DataTable returnDataProductlines()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT t_productlines.*,t_layouts.layoutname FROM t_productlines JOIN t_layouts ON t_productlines.idt_layouts = t_layouts.id ", connection))

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
        /// 编辑Productlines数据
        /// </summary>
        /// <param name="entityProductlines"></param>
        /// <param name="options1"></param>
        public void editProductlines(EntityProductlines entityProductlines, List<string> options1)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_productlines SET linename = @linename, linekey = @linekey,scanspeed = @scanspeed, indexspeed = @indexspeed, auxspeed = @auxspeed, scanspeed_empty = @scanspeed_empty, indexspeed_empty = @indexspeed_empty, auxspeed_empty = @auxspeed_empty, idt_layouts = @idt_layouts WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityProductlines.idSg);
                    updateCommand.Parameters.AddWithValue("@linename", entityProductlines.linenameSg);
                    updateCommand.Parameters.AddWithValue("@linekey", entityProductlines.linekeySg);
                    updateCommand.Parameters.AddWithValue("@scanspeed", entityProductlines.scanspeedSg);
                    updateCommand.Parameters.AddWithValue("@indexspeed", entityProductlines.indexspeedSg);
                    updateCommand.Parameters.AddWithValue("@auxspeed", entityProductlines.auxspeedSg);
                    updateCommand.Parameters.AddWithValue("@scanspeed_empty", entityProductlines.scanspeed_emptySg);
                    updateCommand.Parameters.AddWithValue("@indexspeed_empty", entityProductlines.indexspeedSg);
                    updateCommand.Parameters.AddWithValue("@auxspeed_empty", entityProductlines.auxspeed_emptySg);
                    int index1 = options1.IndexOf(entityProductlines.idt_layoutsSg) + 1;
                    updateCommand.Parameters.AddWithValue("@idt_layouts", index1);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 增加Productlines数据
        /// </summary>
        /// <param name="entityProductlines"></param>
        /// <param name="options1"></param>
        public void addProductlines(EntityProductlines entityProductlines, List<string> options1)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {

                string insertQuery = "INSERT INTO t_productlines (linename, linekey, scanspeed, indexspeed, auxspeed, scanspeed_empty, indexspeed_empty, auxspeed_empty, idt_layouts) VALUES (@linename, @linekey, @scanspeed, @indexspeed, @auxspeed, @scanspeed_empty, @indexspeed_empty, @auxspeed_empty, @idt_layouts);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {

                    insertCommand.Parameters.AddWithValue("@linename", entityProductlines.linenameSg);
                    insertCommand.Parameters.AddWithValue("@linekey", entityProductlines.linekeySg);
                    insertCommand.Parameters.AddWithValue("@scanspeed", entityProductlines.scanspeedSg);
                    insertCommand.Parameters.AddWithValue("@indexspeed", entityProductlines.indexspeedSg);
                    insertCommand.Parameters.AddWithValue("@auxspeed", entityProductlines.auxspeedSg);
                    insertCommand.Parameters.AddWithValue("@scanspeed_empty", entityProductlines.scanspeed_emptySg);
                    insertCommand.Parameters.AddWithValue("@indexspeed_empty", entityProductlines.indexspeedSg);
                    insertCommand.Parameters.AddWithValue("@auxspeed_empty", entityProductlines.auxspeed_emptySg);
                    int index1 = options1.IndexOf(entityProductlines.idt_layoutsSg) + 1;
                    insertCommand.Parameters.AddWithValue("@idt_layouts", index1);

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
        public void deleteProductlines(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_productlines WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
