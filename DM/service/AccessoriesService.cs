using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.entity;

namespace DM.service
{
    interface AccessoriesService
    {
        /// <summary>
        /// 返回t_accessories表所有数据
        /// </summary>
        /// <returns></returns>
        DataTable ReturnRolesAllData();

        /// <summary>
        /// 删除易损/点检id的数据
        /// </summary>
        /// <param name="acc_id"></param>
        void DeleteAccRowData(int acc_id);

        /// <summary>
        /// 返回易损/点检id的那行数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        /// <returns></returns>
        DataTable ReturnRowDataFromAccID(int acc_id);

        /// <summary>
        /// 数据存入表t_accessories
        /// </summary>
        void SaveDataToAcc(Accessories acc);

        /// <summary>
        /// 返回易损/点检id的起始时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        DateTime ReturnStartTime(int acc_id);

        /// <summary>
        /// 返回易损/点检id的更新时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        DateTime ReturnUpdateTime(int acc_id);
        /// <summary>
        /// 返回易损/点检id的周期单位
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        int ReturnCircleUnit(int acc_id);
    }
}
