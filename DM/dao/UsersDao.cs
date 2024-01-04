using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.dao
{
    interface UsersDao
    {
        /// <summary>
        /// 查询user的idt_role
        /// </summary>
        /// <param name="user">实体类Users</param>
        /// <returns>实体类Roles</returns>
        int SELECTIdt_role(int user_id);

        /// <summary>
        /// t_users添加数据
        /// </summary>
        void InsertDataToUsers(Users user);

        /// <summary>
        /// t_users更新数据
        /// </summary>
        void UpdateDataToUsers(Users user);

        /// <summary>
        /// 删除用户id的数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        void DeleteUsersRowData(int user_id);

        /// <summary>
        /// 查询t_users和t_roles的rolename
        /// </summary>
        /// <returns></returns>
        DataTable SelectUsersDataAndRolename();

        /// <summary>
        /// 查询用户id的那行数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        DataTable SelectRowDataFromUserID(int user_id);
    }
}
