using DM.dao;
using DM.dao.impl;
using System.Data;
using System.Windows.Forms;
using DM.entity;

namespace DM.service.impl
{
    public class LogConfigServiceImpl : LogConfigService
    {
        private LogConfigDao logConfigDao = new LogConfigDaoImpl();

        public void DeleteDataById(string filePath, string deleteId, string tableName)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "删除成功！", messBtn);
            if (dr == DialogResult.OK)
            {
                logConfigDao.DeleteById(filePath, deleteId, tableName);
                MessageBox.Show("删除成功！");
            }
        }

        public void InsertLogConfigData(string filpath, LogConfigEntity logInfo)
        {
            logConfigDao.InsertLogConfigData(filpath, logInfo);
        }

        public LogConfigEntity QueryByID(string filePath, string tableName, string id)
        {
            LogConfigEntity logInfo = new LogConfigEntity();
            logInfo = logConfigDao.QueryById(filePath, tableName, id);
            return logInfo;
        }

        public DataTable ShowData(string filepath, string tableName)
        {
            DataTable dataTable = new DataTable();
            dataTable = logConfigDao.QueryByTable(filepath, tableName);
            return dataTable;
        }

        public void UpdateData(string filePath, string tableName, string id, LogConfigEntity logInfo)
        {
            logConfigDao.UpdateData(filePath, tableName, id, logInfo);
        }
    }
}
