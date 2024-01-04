using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.service
{
    interface ModulesService
    {
        /// <summary>
        /// 返回t_modules表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable ReturnModulesAllData();

        /// <summary>
        /// 返回角色id对应的功能id的List
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        List<int> ReturnLstModuleID(int role_id);

        /// <summary>
        /// 删除功能id的功能表和关系表
        /// </summary>
        /// <param name="role_id"></param>
        void DeleteModuleIDData(int module_id);

        /// <summary>
        /// 返回功能id的那行数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        /// <returns></returns>
        DataTable ReturnRowDataFromModuleID(int module_id);

        /// <summary>
        /// 数据存入表t_modules
        /// </summary>
        void SaveDataToModules(Modules module);

        /// <summary>
        /// 判断modulekey是否重复
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        bool JudgeModulekey(Modules module);
    }
}
