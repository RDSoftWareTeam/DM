using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface LayoutsDao
    {
        /// <summary>
        /// 返回Layouts数据
        /// </summary>
        /// <returns></returns>
        DataTable returnLayouts();
        /// <summary>
        /// 增加Layouts数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        void addLayouts(EntityLayouts entityLayouts);
        /// <summary>
        /// 编辑Layouts数据
        /// </summary>
        /// <param name="entityLayouts"></param>
        void editLayouts(EntityLayouts entityLayouts);
        /// <summary>
        /// 删除Layouts数据
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteLayouts(string delete_id);
    }
}
