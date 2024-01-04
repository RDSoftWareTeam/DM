using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.dao
{
    interface LogConfigDao
    {

        /// <summary>
        /// 查询所有数据显示到页面中
        /// </summary>
        /// <param name="filepath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        DataTable QueryByTable(string filepath, string tableName);

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="deleteId">删除ID</param>
        /// <param name="tableName">数据表名</param>
        void DeleteById(string filePath, string deleteId, string tableName);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="filpath">数据库路径</param>
        /// <param name="ioInfo">接受前端信息实体类</param>
        void InsertLogConfigData(string filpath, LogConfigEntity logInfo);

        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">编辑时获取到的ID</param>
        /// <returns></returns>
        LogConfigEntity QueryById(string filePath, string tableName, string id);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">根据修改的id</param>
        /// <param name="ioInfo">存储前端文本的实体类</param>
        void UpdateData(string filePath, string tableName, string id, LogConfigEntity logInfo);
    }
}
