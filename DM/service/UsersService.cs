using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.service
{
    interface UsersService
    {
        /// <summary>
        /// 返回用户id的那行数据
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        DataTable ReturnRowDataFromUserID(int user_id);

        /// <summary>
        /// 获取用户id的角色名
        /// </summary>
        /// <returns></returns>
        string GetUsersRoleName(int user_id);

        /// <summary>
        /// 数据存入表t_users
        /// </summary>
        void SaveDataToUsers(Users user);

        /// <summary>
        /// 删除用户id的数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        void DeleteUsersRowData(int user_id);

        /// <summary>
        /// 返回gc_users数据
        /// </summary>
        /// <returns></returns>
        DataTable ReturnGCUsersData();
    }
}
