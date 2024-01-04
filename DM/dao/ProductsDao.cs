using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface ProductsDao
    {
        /// <summary>
        /// 返回Products数据
        /// </summary>
        /// <returns></returns>
        DataTable returnProducts();
        /// <summary>
        /// 编辑Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        void editProducts(EntityProducts entityProducts);
        /// <summary>
        /// 增加Products数据
        /// </summary>
        /// <param name="entityProducts"></param>
        void addProducts(EntityProducts entityProducts);
        /// <summary>
        /// 删除Products数据
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteProducts(string delete_id);
    }
}
