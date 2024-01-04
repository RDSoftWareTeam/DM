using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.dao
{
    interface AccessoriesDao
    {
        /// <summary>
        /// t_acc添加数据
        /// </summary>
        /// <param name="acc"></param>
        void InsertDataToAcc(Accessories acc);

        /// <summary>
        /// t_acc更新数据
        /// </summary>
        /// <param name="acc"></param>
        void UpdateDataToAcc(Accessories acc);

        /// <summary>
        /// 查询t_accessories表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable SelectAccAllData();

        /// <summary>
        /// 删除易损/点检id的数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        void DeleteAccRowData(int acc_id);

        /// <summary>
        /// 查询易损/点检id的那行数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        /// <returns></returns>
        DataTable SelectRowDataFromAccID(int acc_id);

        /// <summary>
        /// 查询该易损/点检id的起始时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        string SelectStartTime(int acc_id);

        /// <summary>
        /// 查询该易损/点检id的更新时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        string SelectUpdateTime(int acc_id);

        /// <summary>
        /// 查询该易损/点检id的周期
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        int SelectCircleTime(int acc_id);

        /// <summary>
        /// 查询该易损/点检id的周期单位
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        int SelectCircleUnit(int acc_id);
    }
}
