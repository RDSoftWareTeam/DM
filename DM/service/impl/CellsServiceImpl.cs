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
    class CellsServiceImpl: CellsService
    {
        CellsDao CellsDao = new CellsDaoImpl();
        /// <summary>
        /// 删除Cells数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteCells( DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                CellsDao.deleteCells( Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Cells数据
        /// </summary>
        public DataTable returnCells()
        {
            DataTable dataTable = CellsDao.returnCells();
            return dataTable;
        }
        /// <summary>
        /// 编辑Cells数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void editCells(EntityCells entityCells, List<string> options1, List<string> options2)
        {
            CellsDao.editCells(entityCells, options1, options2);
        }
        /// <summary>
        /// 增加Cells数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void addCells(EntityCells entityCells, List<string> options1, List<string> options2)
        {
            CellsDao.addCells(entityCells, options1, options2);
        }
        /// <summary>
        /// 返回布局名称
        /// </summary>
        /// <returns></returns>
        public List<string> returnColData1()
        {
            List<string> options = SQLite.returnColData(SQLite.query1);
            return options;
        }
        /// <summary>
        /// 返回产品名称
        /// </summary>
        /// <returns></returns>
        public List<string> returnColData2()
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
        public List<string> returnColData5(string layoutname)
        {

            List<string> options = SQLite.returnRowData(SQLite.query3, layoutname);
            return options;
        }
    }
}
