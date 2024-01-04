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
    class ProductsServiceImpl: ProductsService
    {
        ProductsDao productsDao = new ProductsDaoImpl();
        /// <summary>
        /// 删除Products数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="list"></param>
        public void deleteProducts( DataRow list)
        {
            if (list != null)
            {
                object id = list["id"];
                productsDao.deleteProducts( Convert.ToString(id));
            }
        }
        /// <summary>
        /// 返回Products数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable returnProducts()
        {
            DataTable dataTable = productsDao.returnProducts();
            return dataTable;
        }
        /// <summary>
        /// 编辑Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        public void editProducts(EntityProducts entityProducts)
        {
            productsDao.editProducts(entityProducts);
        }
        /// <summary>
        /// 增加Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        public void addProducts(EntityProducts entityProducts)
        {
            productsDao.addProducts(entityProducts);
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
