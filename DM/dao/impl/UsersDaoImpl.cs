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
    class UsersDaoImpl : UsersDao
    {

        /// <summary>
        /// 查询user的idt_role
        /// </summary>
        /// <param name="user">实体类Users</param>
        /// <returns>实体类Roles</returns>
        public int SELECTIdt_role(int user_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                //获取对应id那行的一行数据
                string query = "SELECT idt_role FROM t_users WHERE id = @id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", user_id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // 检查是否有行
                        if (reader.Read())
                        {
                            int idt_role = Convert.ToInt32(reader["idt_role"]);
                            return idt_role;
                        }
                    }
                }
                connection.Close();
            }
            return 0;
        }

        /// <summary>
        /// t_users添加数据
        /// </summary>
        public void InsertDataToUsers(Users user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO t_users (username, userpwd, realname, photo, idt_role) VALUES(@user_username, @user_userpwd, @user_realname, @user_photo, @user_idt_role);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_username", user.username);
                    command.Parameters.AddWithValue("@user_userpwd", user.userpwd);
                    command.Parameters.AddWithValue("@user_realname", user.realname);
                    command.Parameters.AddWithValue("@user_photo", user.photo);
                    command.Parameters.AddWithValue("@user_idt_role", user.idt_role);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// t_users更新数据
        /// </summary>
        public void UpdateDataToUsers(Users user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "UPDATE t_users SET username = @user_username, userpwd = @user_userpwd, realname = @user_realname, photo = @user_photo, idt_role = @user_idt_role WHERE id = @user_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", user.id);
                    command.Parameters.AddWithValue("@user_username", user.username);
                    command.Parameters.AddWithValue("@user_userpwd", user.userpwd);
                    command.Parameters.AddWithValue("@user_realname", user.realname);
                    command.Parameters.AddWithValue("@user_photo", user.photo);
                    command.Parameters.AddWithValue("@user_idt_role", user.idt_role);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 删除用户id的数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        public void DeleteUsersRowData(int user_id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM t_users WHERE ID = @user_id;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 查询t_users和t_roles的rolename
        /// </summary>
        /// <returns></returns>
        public DataTable SelectUsersDataAndRolename()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string queryString = "SELECT t_users.id, t_users.username,t_users.userpwd,t_users.realname,t_users.photo, t_roles.rolename FROM t_users JOIN t_roles ON t_users.idt_role = t_roles.id; ";
                using (SQLiteCommand command = new SQLiteCommand(queryString, connection))
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
        /// 查询用户id的那行数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        public DataTable SelectRowDataFromUserID(int user_id)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(SQLite.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM t_users WHERE id = (SELECT @user_id FROM t_users); ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", user_id);
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
