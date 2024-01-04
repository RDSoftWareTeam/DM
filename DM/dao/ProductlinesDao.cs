using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface ProductlinesDao
    {
        /// <summary>
        /// 返回Productlines数据
        /// </summary>
        /// <returns></returns>
        DataTable returnDataProductlines();
        /// <summary>
        /// 编辑Productlines数据
        /// </summary>
        /// <param name="entityProductlines"></param>
        /// <param name="options1"></param>
        void editProductlines(EntityProductlines entityProductlines, List<string> options1);
        /// <summary>
        /// 增加Productlines数据
        /// </summary>
        /// <param name="entityProductlines"></param>
        /// <param name="options1"></param>
        void addProductlines(EntityProductlines entityProductlines, List<string> options1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteProductlines(string delete_id);
    }
}
