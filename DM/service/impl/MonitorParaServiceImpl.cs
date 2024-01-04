using DM.dao;
using DM.dao.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM.entity;
using DM.service;

namespace DM.service.impl
{
    public class MonitorParaServiceImpl : MonitorParaService
    {

        private MonitorParaDao monitorParaDao = new MonitorParaDaoImpl();

        public void DeleteDataById(string filePath, string deleteId, string tableName)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "删除成功！", messBtn);
            if (dr == DialogResult.OK)
            {
                monitorParaDao.DeleteById(filePath, deleteId, tableName);
                MessageBox.Show("删除成功！");
            }
        }

        public void InsertMonitorParaData(string filpath, MonitorParaEntity paraInfo)
        {
            monitorParaDao.InsertMonitorParaData(filpath, paraInfo);
        }

        public MonitorParaEntity QueryByID(string filePath, string tableName, string id)
        {
            MonitorParaEntity paraInfo = new MonitorParaEntity();
            paraInfo = monitorParaDao.QueryById(filePath, tableName, id);
            return paraInfo;
        }

        public DataTable ShowData(string filepath, string tableName)
        {
            DataTable dataTable = new DataTable();
            dataTable = monitorParaDao.QueryByTable(filepath, tableName);
            return dataTable;
        }

        public void UpdateData(string filePath, string tableName, string id, MonitorParaEntity paraInfo)
        {
            monitorParaDao.UpdateData(filePath, tableName, id, paraInfo);
        }
    }
}
