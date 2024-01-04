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
    class ModulesDaoImpl : ModulesDao
    {
        /// <summary>
        /// 查询t_modules表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectModulesAllData()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_modules";
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
        /// 查询表中是否有该modulekey
        /// </summary>
        /// <param name="modulekey"></param>
        /// <returns></returns>
        public bool SelectModulekey(string modulekey)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT modulekey FROM t_modules WHERE modulekey = @module_modulekey;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_modulekey", modulekey);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return true;
                        }
                    }
                }
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// t_modules添加数据
        /// </summary>
        /// <param name="module"></param>
        public void InsertDataToModules(Modules module)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO t_modules (modulename, modulekey) VALUES(@module_modulename, @module_modulekey);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_modulename", module.modulename);
                    command.Parameters.AddWithValue("@module_modulekey", module.modulekey);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// t_modules更新数据
        /// </summary>
        /// <param name="module"></param>
        public void UpdatetDataToModules(Modules module)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "UPDATE t_modules SET modulename = @module_modulename, modulekey = @module_modulekey WHERE id = @module_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_id", module.id);
                    command.Parameters.AddWithValue("@module_modulename", module.modulename);
                    command.Parameters.AddWithValue("@module_modulekey", module.modulekey);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 删除功能id的数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        public void DeleteModulesRowData(int module_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM t_modules WHERE ID = @module_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_id", module_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 删除关系表中module_id的数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        public void DeleteIdt_modulesFromR(int module_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM r_roleandmodule WHERE idt_modules = @module_id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_id", module_id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 查询角色id对应的功能id
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns>List功能id</returns>
        public List<int> SelectModuleID(int role_id)
        {
            List<int> lst_module_id = new List<int>();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();

                //存入角色id对应的功能id
                string query = "SELECT idt_modules FROM r_roleandmodule WHERE idt_roles = @role_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int module_id = Convert.ToInt32(reader["idt_modules"]);
                            lst_module_id.Add(module_id);
                        }
                    }
                }
                connection.Close();
            }
            return lst_module_id;
        }

        /// <summary>
        /// 查询功能id的那行数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        /// <returns></returns>
        public DataTable SelectRowDataFromModuleID(int module_id)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_modules WHERE id = (SELECT @module_id FROM t_modules); ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_id", module_id);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 查询功能id对应的功能key
        /// </summary>
        /// <param name="module_id"></param>
        /// <returns></returns>
        public string SelectModuleIDsKey(int module_id)
        {
            string modulekey = null;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT modulekey FROM t_modules WHERE id = @module_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@module_id", module_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            modulekey = reader["modulekey"].ToString();
                            return modulekey;
                        }
                    }
                }
                connection.Close();
            }
            return modulekey;
        }
    }
}
