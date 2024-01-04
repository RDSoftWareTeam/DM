using DM.dao;
using DM.dao.impl;
using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DM.service.impl
{
    class LayoutsServiceImpl: LayoutsService
    {
        LayoutsDao layoutsDao = new LayoutsDaoImpl();
        /// <summary>
        /// 删除Layouts数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteLayouts(DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                layoutsDao.deleteLayouts(Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Layouts数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable returnLayouts()
        {
            DataTable dataTable = layoutsDao.returnLayouts();
            return dataTable;
        }
        /// <summary>
        /// 增加Layouts数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void addLayouts(EntityLayouts entityLayouts)
        {
            layoutsDao.addLayouts(entityLayouts);
        }
        /// <summary>
        /// 编辑Layouts数据
        /// </summary>
        /// <param name="entityGlobalpars"></param>
        public void editLayouts(EntityLayouts entityLayouts)
        {
            layoutsDao.editLayouts(entityLayouts);
        }
        /// <summary>
        /// 类型判断是否为int
        /// </summary>
        /// <param name="userInput"></param>
        public bool isInt(string userInput)
        {
            string pattern = @"^\d+$";
            bool isInteger = Regex.IsMatch(userInput, pattern);
            return isInteger;

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
