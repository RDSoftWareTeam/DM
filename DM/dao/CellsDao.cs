using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface CellsDao
    {
        /// <summary>
        /// Cells返回数据
        /// </summary>
        /// <returns></returns>
        DataTable returnCells();
        /// <summary>
        /// Cells增加数据
        /// </summary>
        /// <param name="entityCells"></param>
        /// <param name="options1"></param>
        /// <param name="options2"></param>
        void addCells(EntityCells entityCells, List<string> options1, List<string> options2);
        /// <summary>
        /// Cells编辑数据
        /// </summary>
        /// <param name="entityCells"></param>
        /// <param name="options1"></param>
        /// <param name="options2"></param>
        void editCells(EntityCells entityCells, List<string> options1, List<string> options2);
        /// <summary>
        /// Cells删除数据
        /// </summary>
        /// <param name="delete_id"></param>
        void deleteCells(string delete_id);
    }
}
