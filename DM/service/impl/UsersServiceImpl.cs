using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.dao;
using DM.dao.impl;
using DM.entity;

namespace DM.service.impl
{
    class UsersServiceImpl : UsersService
    {
        /// <summary>
        /// DAO层user接口
        /// </summary>
        UsersDao userDao = new UsersDaoImpl();

        /// <summary>
        /// DAO层user接口
        /// </summary>
        RolesDao roleDao = new RolesDaoImpl();

        /// <summary>
        /// 返回用户id的那行数据
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public DataTable ReturnRowDataFromUserID(int user_id)
        {
            return userDao.SelectRowDataFromUserID(user_id);
        }

        /// <summary>
        /// 获取用户id的角色名
        /// </summary>
        /// <returns></returns>
        public string GetUsersRoleName(int user_id)
        {
            int role_id = userDao.SELECTIdt_role(user_id);
            if(role_id > 0)
            {
                string rolename = roleDao.SelectRolename(role_id);
                return rolename;
            }
            else
                return null;
        }


        /// <summary>
        /// 数据存入表t_users
        /// </summary>
        public void SaveDataToUsers(Users user)
        {
            if (user.id > 0)
                userDao.UpdateDataToUsers(user);
            else
                userDao.InsertDataToUsers(user);
        }

        /// <summary>
        /// 删除用户id的数据
        /// </summary>
        /// <param name="user_id">用户id</param>
        public void DeleteUsersRowData(int user_id)
        {
            userDao.DeleteUsersRowData(user_id);
        }

        /// <summary>
        /// 返回gc_users数据
        /// </summary>
        /// <returns></returns>
        public DataTable ReturnGCUsersData()
        {
            return userDao.SelectUsersDataAndRolename();
        }

    }
}
