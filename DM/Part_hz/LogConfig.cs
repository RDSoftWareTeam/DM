using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Data;
using System.Windows.Forms;

namespace DM
{
    public partial class LogConfig : Form
    {

        public object queryById = null;

        //表单高度
        private float FormHeight;
        //表单宽度
        private float FormWidth;

        /// <summary>
        /// 数据库路径
        /// </summary>
        public string connectionString = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";

        private LogConfigService logConfigService = new LogConfigServiceImpl();

        private AdaptFont adaptFont = new AdaptFont();
        public LogConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LogInsertOrEditData logInsertOrEditData ;
            //IOInformationEntity ioInfo = new IOInformationEntity();
            //object id = null;
            int handle = gridView1.FocusedRowHandle;
            DataRow list = gridView1.GetDataRow(handle);
            if (gridView1 != null)
            {

                if (list != null)
                {
                    queryById = list["id"];
                    logInsertOrEditData = new LogInsertOrEditData(queryById);
                    logInsertOrEditData.Owner = this;
                    LogConfigEntity logInfo = new LogConfigEntity();
                    logInfo = logConfigService.QueryByID(connectionString, "t_logconfigure", Convert.ToString(queryById));
                    logInsertOrEditData.Text = "日志配置信息编辑";
                    logInsertOrEditData.txt_loname.Text = logInfo.LogName;
                    logInsertOrEditData.txt_logkey.Text = logInfo.LogKey;
                    logInsertOrEditData.txt_strtemplate.Text = Convert.ToString(logInfo.StrTemplate);
                    logInsertOrEditData.sbtn_insert.Text = "修改";
                    logInsertOrEditData.label1.Text = "日志配置修改信息功能";
                    logInsertOrEditData.insertOrQueryFlag = false;
                    logInsertOrEditData.ShowDialog();
                }

            }


        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deletelog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    object id = list["id"];
                    logConfigService.DeleteDataById(connectionString, Convert.ToString(id), "t_logconfigure");
                }
            }
            RefreshForm();

            //string connectionString = "Data Source=" + "D:\\test.db;Version=3;";
            //DeleteLogData(connectionString, "t_logconfigure");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_insert_Click(object sender, EventArgs e)
        {
            LogInsertOrEditData logInsertOrEditData = new LogInsertOrEditData();
            logInsertOrEditData.Owner = this;
            logInsertOrEditData.insertOrQueryFlag = true;
            logInsertOrEditData.ShowDialog();
        }

        private void LogConfig_Load(object sender, EventArgs e)
        {
            gcontrol_t_logconfigure.DataSource = logConfigService.ShowData(connectionString, "t_logconfigure");
            id.FieldName = "id";
            logname.FieldName = "logname";
            logkey.FieldName = "logkey";
            strtemplate.FieldName = "strtemplate";



            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
        }


        /// <summary>
        /// 刷新主窗体中数据
        /// </summary>
        public void RefreshForm()
        {
            gcontrol_t_logconfigure.DataSource = logConfigService.ShowData(connectionString, "t_logconfigure");
        }

        private void LogConfig_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
        }
    }
}
