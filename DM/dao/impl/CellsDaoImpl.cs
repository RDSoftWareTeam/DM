using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;
using DM.dao;

namespace DM.dao.impl
{
    class CellsDaoImpl : CellsDao
    {
        /// <summary>
        /// 返回cells数据
        /// </summary>
        /// <param name="connectionString">数据库路径</param>
        /// <returns>数据库表</returns>
        public DataTable returnCells()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT t_cells.*,t_layouts.layoutname,t_products.productname FROM t_cells JOIN t_layouts ON t_cells.idt_layouts = t_layouts.id JOIN t_products ON t_cells.idt_products = t_products.id", connection))

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
        /// 增加cells数据
        /// </summary>
        /// <param name="entityCells"></param>
        /// <param name="options1"></param>
        /// <param name="options2"></param>
        public void addCells(EntityCells entityCells, List<string> options1, List<string> options2)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {

                string insertQuery = "INSERT INTO t_cells (rowno, colno, safypointx, zeropointx, safypointy, zeropointy, safypointz, zeropointz, idt_layouts,idt_products) VALUES (@rowno, @colno, @safypointx, @zeropointx, @safypointy, @zeropointy, @safypointz, @zeropointz, @idt_layouts, @idt_products);";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {

                    insertCommand.Parameters.AddWithValue("@rowno", entityCells.rownoSg);
                    insertCommand.Parameters.AddWithValue("@colno", entityCells.colnoSg);
                    insertCommand.Parameters.AddWithValue("@safypointx", entityCells.safypointxSg);
                    insertCommand.Parameters.AddWithValue("@zeropointx", entityCells.zeropointxSg);
                    insertCommand.Parameters.AddWithValue("@safypointy", entityCells.safypointySg);
                    insertCommand.Parameters.AddWithValue("@zeropointy", entityCells.zeropointySg);
                    insertCommand.Parameters.AddWithValue("@safypointz", entityCells.safypointzSg);
                    insertCommand.Parameters.AddWithValue("@zeropointz", entityCells.zeropointzSg);
                    int index1 = options1.IndexOf(entityCells.idt_layoutsSg) + 1;
                    int index2 = options2.IndexOf(entityCells.idt_productsSg) + 1;
                    insertCommand.Parameters.AddWithValue("@idt_layouts", index1);
                    insertCommand.Parameters.AddWithValue("@idt_products", index2);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }
        /// <summary>
        /// 编辑cells数据
        /// </summary>
        /// <param name="entityCells"></param>
        /// <param name="options1"></param>
        /// <param name="options2"></param>
        public void editCells(EntityCells entityCells, List<string> options1, List<string> options2)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                string updateQuery = "UPDATE t_cells SET rowno = @rowno, colno = @colno, safypointx = @safypointx, zeropointx = @zeropointx, safypointy = @safypointy, zeropointy = @zeropointy, safypointz = @safypointz, zeropointz = @zeropointz, idt_layouts = @idt_layouts, idt_products = @idt_products WHERE ID = @id;";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {

                    updateCommand.Parameters.AddWithValue("@id", entityCells.idSg);
                    updateCommand.Parameters.AddWithValue("@rowno", entityCells.rownoSg);
                    updateCommand.Parameters.AddWithValue("@colno", entityCells.colnoSg);
                    updateCommand.Parameters.AddWithValue("@safypointx", entityCells.safypointxSg);
                    updateCommand.Parameters.AddWithValue("@zeropointx", entityCells.zeropointxSg);
                    updateCommand.Parameters.AddWithValue("@safypointy", entityCells.safypointySg);
                    updateCommand.Parameters.AddWithValue("@zeropointy", entityCells.zeropointySg);
                    updateCommand.Parameters.AddWithValue("@safypointz", entityCells.safypointzSg);
                    updateCommand.Parameters.AddWithValue("@zeropointz", entityCells.zeropointzSg);
                    int index1 = options1.IndexOf(entityCells.idt_layoutsSg) + 1;
                    int index2 = options2.IndexOf(entityCells.idt_productsSg) + 1;
                    updateCommand.Parameters.AddWithValue("@idt_layouts", index1);
                    updateCommand.Parameters.AddWithValue("@idt_products", index2);

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
        public void deleteCells(string delete_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM t_cells WHERE ID = " + delete_id + ";", connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}
