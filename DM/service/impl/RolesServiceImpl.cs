using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;
using DM.dao;
using DM.dao.impl;
using System.Data;

namespace DM.service.impl
{
    class RolesServiceImpl : RolesService
    {
        /// <summary>
        /// DAO层接口roles
        /// </summary>
        RolesDao roleDao = new RolesDaoImpl();

        /// <summary>
        /// 获取t_roles表所有角色名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllRoleName()
        {
            return roleDao.SelectAllRoleName();
        }

        /// <summary>
        /// 获取角色名对应的角色id
        /// </summary>
        /// <param name="rolename">角色名</param>
        /// <returns></returns>
        public int GetRoleID(string rolename)
        {
            return roleDao.SelectRoleID(rolename);
        }

        /// <summary>
        /// 删除角色id的角色表和关系表
        /// </summary>
        /// <param name="role_id"></param>
        public void DeleteRoleIDData(int role_id)
        {
            //先删角色表内容
            roleDao.DeleteRolesRowData(role_id);
            //再删关系表
            roleDao.DeleteIdt_rolesFromR(role_id);
        }

        /// <summary>
        /// 返回t_roles表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable ReturnRolesAllData()
        {
            return roleDao.SelectRolesAllData();
        }

        /// <summary>
        /// 返回角色id的那行数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        public DataTable ReturnRowDataFromRoleID(int role_id)
        {
            return roleDao.SelectRowDataFromRoleID(role_id);
        }

        /// <summary>
        /// 数据存入表t_roles
        /// </summary>
        public void SaveDataToRoles(Roles role)
        {
            if (role.id > 0)
                roleDao.UpdateDataToRoles(role);
            else
                roleDao.InsertDataToRoles(role);
        }

        /// <summary>
        /// 保存授权的角色
        /// </summary>
        /// <param name="e_roles">角色实体类</param>
        /// <param name="lst_selectedModuleID">授权的功能ID</param>
        public void SaveDataToR(int role_id, List<int> lst_selectedModuleID)
        {
            //删除关系表的角色id
            roleDao.DeleteIdt_rolesFromR(role_id);
            //添加授权的功能id
            roleDao.AddDataToR(role_id, lst_selectedModuleID);
        }

        /// <summary>
        /// 获取角色id的角色名
        /// </summary>
        /// <returns></returns>
        public string GetRolesRoleName(int role_id)
        {
            if (role_id > 0)
            {
                string rolename = roleDao.SelectRolename(role_id);
                return rolename;
            }
            else
                return null;
        }

    }
}
