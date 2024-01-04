using DM.dao;
using System.Data;
using DM.dao.impl;
using System.Windows.Forms;
using DM.entity;

namespace DM.service.impl
{
    public class IOControlServiceImpl : IOControlService
    {

        IOControlDao ioControlDao = new IOControlDaoImpl();

        /// <summary>
        /// 根据D删除数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="deleteId">删除ID</param>
        /// <param name="tableName">数据表名</param>
        public void DeleteDataById(string filePath, string deleteId, string tableName)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "删除成功！", messBtn);
            if (dr == DialogResult.OK)
            {
                ioControlDao.DeleteById(filePath, deleteId, tableName);
                MessageBox.Show("删除成功！");
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="filpath">数据库路径</param>
        /// <param name="ioInfo">存储前端的实体类</param>
        public void InsertIOData(string filpath, IOInformationEntity ioInfo)
        {
            ioControlDao.InsertIOData(filpath, ioInfo);
        }

        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">查询的ID</param>
        /// <returns></returns>
        public IOInformationEntity QueryByID(string filePath, string tableName, string id)
        {
            IOInformationEntity ioInfo = new IOInformationEntity();
            ioInfo = ioControlDao.QueryById(filePath, tableName, id);
            return ioInfo;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="filepath">数据库路径</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataTable ShowData(string filepath, string tableName)
        {

            DataTable dataTable = new DataTable();
            dataTable = ioControlDao.QueryByTable(filepath, tableName);
            return dataTable;

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="filePath">数据库路径</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="id">根据修改的id</param>
        /// <param name="ioInfo">存储前端文本的实体类</param>
        public void UpdateData(string filePath, string tableName, string id, IOInformationEntity ioInfo)
        {
            ioControlDao.UpdateData(filePath, tableName, id, ioInfo);
        }
    }
}
