using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface ScanareasDao
    {
        /// <summary>
        /// 返回Scanareas数据
        /// </summary>
        /// <returns></returns>
        DataTable returnScanareas();
        /// <summary>
        ///编辑Scanareas数据 
        /// </summary>
        /// <param name="entityScanareas"></param>
        /// <param name="options1"></param>
        void editScanareas(EntityScanareas entityScanareas, List<string> options1);
        /// <summary>
        /// 增加Scanareas数据
        /// </summary>
        /// <param name="entityScanareas"></param>
        /// <param name="options1"></param>
        void addScanareas(EntityScanareas entityScanareas, List<string> options1);
        /// <summary>
        /// 删除Scanareas数据
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteScanareas(string delete_id);
    }
}
