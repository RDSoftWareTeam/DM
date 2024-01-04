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
    class ScanareasServiceImpl: ScanareasService
    {
        ScanareasDao scanareasDao = new ScanareasDaoImpl();
        /// <summary>
        /// 删除Scanareas数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteScanareas(DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                scanareasDao.deleteScanareas( Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Scanareas数据
        /// </summary>
        /// <returns></returns>
        public DataTable returnScanareas()
        {
            DataTable dataTable = scanareasDao.returnScanareas();
            return dataTable;
        }
        /// <summary>
        /// 编辑Scanareas数据
        /// </summary>
        /// <param name="entityProductlines"></param>
        /// <param name="options1"></param>
        public void editScanareas(EntityScanareas entityScanareas, List<string> options1)
        {
            scanareasDao.editScanareas(entityScanareas, options1);
        }
        /// <summary>
        /// 增加Scanareas数据
        /// </summary>
        /// <param name="entityScanareas"></param>
        /// <param name="options1"></param>
        public void addScanareas(EntityScanareas entityScanareas, List<string> options1)
        {
            scanareasDao.addScanareas(entityScanareas, options1);
        }
        /// <summary>
        /// 返回产品名称
        /// </summary>
        /// <returns></returns>
        public List<string> returnColData4()
        {
            List<string> options = SQLite.returnColData(SQLite.query2);
            return options;
        }
        /// <summary>
        /// 类型判断是否为float
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool isFloat(string input)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$");
            return regex.IsMatch(input);
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
