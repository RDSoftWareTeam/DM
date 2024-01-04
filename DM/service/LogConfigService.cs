using DM.entity;
using System.Data;

namespace DM.service
{
    interface LogConfigService
    {

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="filepath">数据库路径</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        DataTable ShowData(string filepath, string tableName);

        /// <summary>
        /// 根据D删除数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="deleteId">删除ID</param>
        /// <param name="tableName">数据表名</param>
        void DeleteDataById(string filePath, string deleteId, string tableName);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="filpath">数据库路径</param>
        /// <param name="logInfo">存储前端的实体类</param>
        void InsertLogConfigData(string filpath, LogConfigEntity logInfo);

        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">查询的ID</param>
        /// <returns></returns>
        LogConfigEntity QueryByID(string filePath, string tableName, string id);

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
