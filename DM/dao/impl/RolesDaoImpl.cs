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
    class RolesDaoImpl : RolesDao
    {

        /// <summary>
        /// t_roles添加数据
        /// </summary>
        /// <param name="role"></param>
        public void InsertDataToRoles(Roles role)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query1 = "INSERT INTO t_roles (rolename, notes) VALUES(@rolename, @notes);";
                using (SQLiteCommand command = new SQLiteCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@rolename", role.rolename);
                    command.Parameters.AddWithValue("@notes", role.notes);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// t_roles更新数据
        /// </summary>
        /// <param name="role"></param>
        public void UpdateDataToRoles(Roles role)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "UPDATE t_roles SET rolename = @role_rolename, notes = @role_notes WHERE id = @role_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role.id);
                    command.Parameters.AddWithValue("@role_rolename", role.rolename);
                    command.Parameters.AddWithValue("@role_notes", role.notes);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 删除关系表中idt_roles的数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        public void DeleteIdt_rolesFromR(int role_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM r_roleandmodule WHERE idt_roles = @role_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 新建关系表数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <param name="lst_selectedModuleID">List功能id</param>
        public void AddDataToR(int role_id, List<int> lst_selectedModuleID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO r_roleandmodule (idt_roles, idt_modules) VALUES(@role_id, @module_id); ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);
                    foreach (int module_id in lst_selectedModuleID)
                    {
                        command.Parameters.AddWithValue("@module_id", module_id);
                        command.ExecuteNonQuery();
                        command.Parameters.RemoveAt("@module_id");
                    }
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 查询rolename对应的role_id
        /// </summary>
        /// <param name="rolename">角色名</param>
        /// <returns></returns>
        public int SelectRoleID(string rolename)
        {
            int role_id = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query1 = "SELECT id FROM t_roles WHERE rolename = @rolename;";
                using (SQLiteCommand command = new SQLiteCommand(query1, connection))
                {
                    //填入占位参数
                    command.Parameters.AddWithValue("@rolename", rolename);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        //查询表中每一行
                        while (reader.Read())
                        {
                            // 获取查询结果
                            role_id = Convert.ToInt32(reader["id"]);
                        }
                    }
                }
            }
            return role_id;
        }

        /// <summary>
        /// 查询角色id的rolename
        /// </summary>
        /// <param name="role">实体类Roles</param>
        /// <returns>实体类Roles</returns>
        public string SelectRolename(int role_id)
        {
            string roleName = null;
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT rolename FROM t_roles WHERE id = @role_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // 检查是否有行
                        if (reader.Read())
                        {
                            // 获取查询结果中的 "rolename" 列的值
                            roleName = reader["rolename"].ToString();
                            return roleName;
                        }
                    }
                }
                connection.Close();
            }
            return roleName;
        }

        /// <summary>
        /// 查询表t_role所有角色名
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllRoleName()
        {
            List<string> lst_roleName = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT rolename FROM t_roles";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // 执行查询并获取结果
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // 遍历查询结果
                        while (reader.Read())
                        {
                            // 获取查询结果中的 "rolename" 列的值
                            string roleName = reader["rolename"].ToString();
                            lst_roleName.Add(roleName);
                        }
                    }
                }
                connection.Close();
            }
            return lst_roleName;
        }

        /// <summary>
        /// 删除角色id的数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        public void DeleteRolesRowData(int role_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM t_roles WHERE ID = @role_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

       /// <summary>
       /// 查询t_roles表所有数据
       /// </summary>
       /// <returns></returns>
        public DataTable SelectRolesAllData()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_roles";
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
        /// 查询角色id的那行数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        public DataTable SelectRowDataFromRoleID(int role_id)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_roles WHERE id = (SELECT @role_id FROM t_roles); ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role_id", role_id);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

    }
}
