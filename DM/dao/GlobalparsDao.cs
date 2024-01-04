using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface GlobalparsDao
    {
        /// <summary>
        /// 返回Globalpars数据
        /// </summary>
        /// <returns></returns>
        DataTable returnGlobalpars();
        /// <summary>
        /// 增加Globalpars数据
        /// </summary>
        /// <param name="entityGlobalpars"></param>
        void addGlobalpars(EntityGlobalpars entityGlobalpars);
        /// <summary>
        /// 编辑Globalpars数据
        /// </summary>
        /// <param name="entityGlobalpars"></param>
        void editGlobalpars(EntityGlobalpars entityGlobalpars);
        /// <summary>
        /// 删除Globalpars数据
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteGlobalpars(string delete_id);
    }
}
