using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Windows.Forms;

namespace DM
{
    public partial class LogInsertOrEditData : Form
    {
        /// <summary>
        /// 存储点击编辑时的获取的ID
        /// </summary>
        public string curr_id;

        //表单高度
        private float FormHeight;
        //表单宽度
        private float FormWidth;

        public bool insertOrQueryFlag = false;

        private LogConfigService logConfigService = new LogConfigServiceImpl();

        public string filePath = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";

        private AdaptFont adaptFont = new AdaptFont();
        public LogInsertOrEditData()
        {
            InitializeComponent();
        }

        public LogInsertOrEditData(object id)
        {
            InitializeComponent();
            curr_id = id.ToString();
        }

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_insert_Click(object sender, EventArgs e)
        {
            // 获取父窗体（Form_users）
            LogConfig formUsers = this.Owner as LogConfig;
            LogConfig logConfig = new LogConfig();
            if (insertOrQueryFlag)//insertOrQueryFlag为true是添加
            {
                LogConfigEntity logInfo = new LogConfigEntity();

                logInfo.LogName = txt_loname.Text;
                logInfo.LogKey = txt_logkey.Text;


                if (logInfo.LogKey == "")
                {
                    MessageBox.Show("key名不能为空！");
                }
                else if (txt_strtemplate.Text == "")
                {
                    MessageBox.Show("日志模板不能为空！");
                }
                else
                {
                    logInfo.StrTemplate = Convert.ToInt32(txt_strtemplate.Text);
                    logConfigService.InsertLogConfigData(filePath, logInfo);
                    MessageBox.Show("添加数据成功！");
                    this.Close();
                }
                // 确保获取到父窗体后，调用刷新数据的方法
                if (formUsers != null)
                {
                    formUsers.RefreshForm();
                }

            }
            else
            {
                LogConfigEntity logInfo = new LogConfigEntity();

                logInfo.LogName = txt_loname.Text;
                logInfo.LogKey = txt_logkey.Text;


                if (logInfo.LogKey == "")
                {
                    MessageBox.Show("key名不能为空！");
                }
                else if (txt_strtemplate.Text == "")
                {
                    MessageBox.Show("日志模板不能为空！");
                }
                else
                {
                    logInfo.StrTemplate = Convert.ToInt32(txt_strtemplate.Text);
                    logConfigService.UpdateData(filePath, "t_logconfigure", curr_id, logInfo);
                    MessageBox.Show("添加数据成功！");
                    this.Close();
                }
                // 确保获取到父窗体后，调用刷新数据的方法
                if (formUsers != null)
                {
                    formUsers.RefreshForm();
                }
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogInsertOrEditData_Load(object sender, EventArgs e)
        {
            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
        }

        private void LogInsertOrEditData_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
        }
    }
}
