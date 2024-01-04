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
    class ProductlinesServiceImpl: ProductlinesService
    {
        ProductlinesDao productlinesDao = new ProductlinesDaoImpl();
        /// <summary>
        /// 删除Productlines数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteProductlines( DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                productlinesDao.deleteProductlines(Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Productlines数据
        /// </summary>
        /// <returns></returns>
        public DataTable returnProductlines()
        {
            DataTable dataTable = productlinesDao.returnDataProductlines();
            return dataTable;
        }
        /// <summary>
        /// 编辑Productlines数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void editProductlines(EntityProductlines entityProductlines, List<string> options1)
        {
            productlinesDao.editProductlines(entityProductlines, options1);
        }
        /// <summary>
        /// 增加Productlines数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        public void addProductlines(EntityProductlines entityProductlines, List<string> options1)
        {
            productlinesDao.addProductlines(entityProductlines, options1);
        }
        /// <summary>
        /// 返回布局名称
        /// </summary>
        /// <returns></returns>
        public List<string> returnColData3()
        {
            List<string> options = SQLite.returnColData(SQLite.query1);
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
