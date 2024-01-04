using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.dao;
using DM.dao.impl;
using DM.entity;

namespace DM.service.impl
{
    class AccessoriesServiceImpl : AccessoriesService
    {
        /// <summary>
        /// DAO层接口Accessories
        /// </summary>
        AccessoriesDao accDao = new AccessoriesDaoImpl();

        /// <summary>
        /// 返回t_accessories表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable ReturnRolesAllData()
        {
            return accDao.SelectAccAllData();
        }

        /// <summary>
        /// 删除易损/点检id的数据
        /// </summary>
        /// <param name="acc_id"></param>
        public void DeleteAccRowData(int acc_id)
        {
            accDao.DeleteAccRowData(acc_id);
        }

        /// <summary>
        /// 返回易损/点检id的那行数据
        /// </summary>
        /// <param name="acc_id">易损/点检id</param>
        /// <returns></returns>
        public DataTable ReturnRowDataFromAccID(int acc_id)
        {
            return accDao.SelectRowDataFromAccID(acc_id);
        }

        /// <summary>
        /// 数据存入表t_roles
        /// </summary>
        public void SaveDataToAcc(Accessories acc)
        {
            if (acc.id > 0)
                accDao.UpdateDataToAcc(acc);
            else
                accDao.InsertDataToAcc(acc);
        }

        /// <summary>
        /// 返回易损/点检id的起始时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public DateTime ReturnStartTime(int acc_id)
        {
            // 获取启用时间
            string starttime = accDao.SelectStartTime(acc_id);

            //转换成DateTime
            DateTime defaultTime = DateTime.MinValue;
            if (DateTime.TryParse(starttime, out defaultTime))
                return defaultTime;
            else
                return defaultTime;
        }

        /// <summary>
        /// 返回易损/点检id的更新时间
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public DateTime ReturnUpdateTime(int acc_id)
        {
            // 获取启用时间
            string updatetime = accDao.SelectUpdateTime(acc_id);

            //转换成DateTime
            DateTime defaultTime = DateTime.MinValue;
            if (DateTime.TryParse(updatetime, out defaultTime))
                return defaultTime;
            else
                return defaultTime;
        }

        /// <summary>
        /// 返回易损/点检id的周期单位
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public int ReturnCircleUnit(int acc_id)
        {
            return accDao.SelectCircleUnit(acc_id);
        }

    }
}
