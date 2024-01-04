using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.dao
{
    interface RolesDao
    {
        /// <summary>
        /// t_roles添加数据
        /// </summary>
        /// <param name="role"></param>
        void InsertDataToRoles(Roles role);

        /// <summary>
        /// t_roles更新数据
        /// </summary>
        /// <param name="role"></param>
        void UpdateDataToRoles(Roles role);

        /// <summary>
        /// 删除关系表中idt_roles的数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        void DeleteIdt_rolesFromR(int role_id);

        /// <summary>
        /// 新建关系表数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <param name="lst_selectedModuleID">List功能id</param>
        void AddDataToR(int role_id, List<int> lst_selectedModuleID);

        /// <summary>
        /// 查询rolename对应的role_id
        /// </summary>
        /// <param name="rolename">角色名</param>
        /// <returns></returns>
        int SelectRoleID(string rolename);

        /// <summary>
        /// 查询角色id的rolename
        /// </summary>
        /// <param name="role">实体类Roles</param>
        /// <returns>实体类Roles</returns>
        string SelectRolename(int role_id);

        /// <summary>
        /// 查询表t_role所有角色名
        /// </summary>
        /// <returns></returns>
        List<string> SelectAllRoleName();

        /// <summary>
        /// 删除角色id的数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        void DeleteRolesRowData(int role_id);

        /// <summary>
        /// 查询t_roles表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable SelectRolesAllData();

        /// <summary>
        /// 查询角色id的那行数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        DataTable SelectRowDataFromRoleID(int role_id);
    }
}
