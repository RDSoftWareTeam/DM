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
    class ModulesServiceImpl : ModulesService
    {
        /// <summary>
        /// DAO层接口modules
        /// </summary>
        ModulesDao moduleDao = new ModulesDaoImpl();

        /// <summary>
        /// DAO层接口roles
        /// </summary>
        RolesDao roleDao = new RolesDaoImpl();

        /// <summary>
        /// 返回t_modules表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable ReturnModulesAllData()
        {
            return moduleDao.SelectModulesAllData();
        }

        /// <summary>
        /// 返回角色id对应的功能id的List
        /// </summary>
        /// <param name="role_id">角色id</param>
        /// <returns></returns>
        public List<int> ReturnLstModuleID(int role_id)
        {
            return moduleDao.SelectModuleID(role_id);
        }

        /// <summary>
        /// 删除功能id的功能表和关系表
        /// </summary>
        /// <param name="role_id"></param>
        public void DeleteModuleIDData(int module_id)
        {
            //先删功能表内容
            moduleDao.DeleteModulesRowData(module_id);
            //再删关系表
            moduleDao.DeleteIdt_modulesFromR(module_id);
        }

        /// <summary>
        /// 返回功能id的那行数据
        /// </summary>
        /// <param name="module_id">功能id</param>
        /// <returns></returns>
        public DataTable ReturnRowDataFromModuleID(int module_id)
        {
            return moduleDao.SelectRowDataFromModuleID(module_id);
        }

        /// <summary>
        /// 数据存入表t_modules
        /// </summary>
        public void SaveDataToModules(Modules module)
        {
            if (module.id > 0)
                moduleDao.UpdatetDataToModules(module);
            else
                moduleDao.InsertDataToModules(module);
        }

        /// <summary>
        /// 判断modulekey是否重复
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public bool JudgeModulekey(Modules module)
        {
            //判断modulekey是否为初始值
            if (module.modulekey == moduleDao.SelectModuleIDsKey(module.id))
                return false;
            else
                return moduleDao.SelectModulekey(module.modulekey);
        }

    }
}
