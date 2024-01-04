using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.dao
{
    interface ModulesDao
    {
        /// <summary>
        /// 查询t_modules表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable SelectModulesAllData();

        /// <summary>
        /// 查询表中是否有该modulekey
        /// </summary>
        /// <param name="modulekey"></param>
        /// <returns></returns>
        bool SelectModulekey(string modulekey);

        /// <summary>
        /// t_modules添加数据
        /// </summary>
        /// <param name="module"></param>
        void InsertDataToModules(Modules module);

        /// <summary>
        /// t_modules更新数据
        /// </summary>
        /// <param name="module"></param>
        void UpdatetDataToModules(Modules module);

        /// <summary>
        /// 删除功能id的数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        void DeleteModulesRowData(int module_id);

        //// <summary>
        /// 删除关系表中module_id的数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        void DeleteIdt_modulesFromR(int module_id);

        /// <summary>
        /// 查询角色id对应的功能id
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns>List功能id</returns>
        List<int> SelectModuleID(int role_id);

        /// <summary>
        /// 查询功能id的那行数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        /// <returns></returns>
        DataTable SelectRowDataFromModuleID(int module_id);

        /// <summary>
        /// 查询功能id对应的功能key
        /// </summary>
        /// <param name="module_id"></param>
        /// <returns></returns>
        string SelectModuleIDsKey(int module_id);
    }
}
