using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.service
{
    interface RolesService
    {
        /// <summary>
        /// 获取t_roles表所有角色名
        /// </summary>
        /// <returns></returns>
        List<string> GetAllRoleName();

        /// <summary>
        /// 获取角色名对应的角色id
        /// </summary>
        /// <param name="rolename">角色名</param>
        /// <returns></returns>
        int GetRoleID(string rolename);

        /// <summary>
        /// 删除角色id的角色表和关系表
        /// </summary>
        /// <param name="role_id"></param>
        void DeleteRoleIDData(int role_id);

        /// <summary>
        /// 返回t_roles表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable ReturnRolesAllData();

        /// <summary>
        /// 返回角色id的那行数据
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        DataTable ReturnRowDataFromRoleID(int role_id);

        /// <summary>
        /// 数据存入表t_roles
        /// </summary>
        void SaveDataToRoles(Roles role);

        /// <summary>
        /// 保存授权的角色
        /// </summary>
        /// <param name="e_roles">角色实体类</param>
        /// <param name="lst_selectedModuleID">授权的功能ID</param>
        void SaveDataToR(int role_id, List<int> lst_selectedModuleID);

        /// <summary>
        /// 获取角色id的角色名
        /// </summary>
        /// <returns></returns>
        string GetRolesRoleName(int role_id);
    }
}
