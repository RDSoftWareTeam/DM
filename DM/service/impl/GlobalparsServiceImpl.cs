using DM.dao;
using DM.dao.impl;
using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service.impl
{
    class GlobalparsServiceImpl: GlobalparsService
    {
        GlobalparsDao globalparsDao = new GlobalparsDaoImpl();
        /// <summary>
        /// 删除Globalpars数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteGlobalpars( DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                globalparsDao.deleteGlobalpars( Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Globalpars数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable returnGlobalpars()
        {
            DataTable dataTable = globalparsDao.returnGlobalpars();
            return dataTable;
        }
        /// <summary>
        /// 编辑Globalpars数据
        /// </summary>
        /// <param name="rntityGlobalpars"></param>
        public void editGlobalpars(EntityGlobalpars entityGlobalpars)
        {
            globalparsDao.editGlobalpars(entityGlobalpars);
        }
        /// <summary>
        /// 增加Globalpars数据
        /// </summary>
        /// <param name="rntityGlobalpars"></param>
        public void addGlobalpars(EntityGlobalpars entityGlobalpars)
        {
            globalparsDao.addGlobalpars(entityGlobalpars);
        }
        /// <summary>
        /// 非空判断
        /// </summary>
        /// <param name="userInput"></param>
        public bool determineNotNull(string userInput)
        {

            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
