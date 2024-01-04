using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Windows.Forms;

namespace DM
{
    public partial class IOInsertData : Form
    {
        /// <summary>
        /// 用来接获取到编辑当前行的ID
        /// </summary>
        public string curr_id;

        /// <summary>
        /// 表单高度
        /// </summary>
        private float FormHeight;

        /// <summary>
        /// 表单宽度
        /// </summary>
        private float FormWidth;

        private AdaptFont adaptFont = new AdaptFont();
        /// <summary>
        /// 添加修改标记位
        /// </summary>
        public bool insertOrQueryFlag = false;

        /// <summary>
        /// 实例化IO业务层
        /// </summary>
        private IOControlService ioControlService = new IOControlServiceImpl();

        /// <summary>
        /// 数据库路径
        /// </summary>
        public string filePath = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";

        IOControls form1 = new IOControls();
        public IOInsertData()
        {
            InitializeComponent();      
        }
        
        public IOInsertData(object id)
        {
            InitializeComponent();
            curr_id = id.ToString();
        }

        private void IOInsertData_Load(object sender, EventArgs e)
        {
            if (insertOrQueryFlag)
            {
                cmbox_iotype.Text = "input";
                cmbox_control.Text = "PLC";
                txt_truetext.Text = "关闭";
                txt_falsetext.Text = "打开";
            }

            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
        }
        /// <summary>
        /// 重新设计尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IOInsertData_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
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
        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_insert_Click(object sender, EventArgs e)
        {
            // 获取父窗体（Form_users）
            IOControls formUsers = this.Owner as IOControls;
            if (insertOrQueryFlag)//insertOrQueryFlag为true是添加
            {
                IOInformationEntity ioInfo = new IOInformationEntity();
                //将前端文本框内容存储到实体类中
                ioInfo.IoName = txt_ioname.Text;
                ioInfo.TrueText = txt_truetext.Text;
                ioInfo.FalseText = txt_falsetext.Text;
                if (cmbox_iotype.Text == "input")
                {
                    ioInfo.IoType = 1;
                }
                else
                {
                    ioInfo.IoType = 2;
                }
                if (cmbox_control.Text == "PLC")
                {
                    ioInfo.Control = 1;
                }
                else
                {
                    ioInfo.Control = 2;
                }
                ioInfo.Addr1 = txt_addr1.Text;
                ioInfo.Addr2 = txt_addr2.Text;
                
                if (ioInfo.IoName == "")
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if (ioInfo.Addr1 == "")
                {
                    MessageBox.Show("控制地址1不能为空！");
                }
                else if(txt_truetext.Text == txt_falsetext.Text)
                {
                    MessageBox.Show("开文字与关文字不能相等！");
                }
                else
                {
                    ioControlService.InsertIOData(filePath, ioInfo);
                    MessageBox.Show("添加数据成功！");
                    this.Close();
                }
                // 确保获取到父窗体后，调用刷新数据的方法
                if (formUsers != null)
                {
                    formUsers.RefreshForm();
                }
            }
            else//修改
            {
                IOInformationEntity ioInfo = new IOInformationEntity();
                //将前端文本框内容存储到实体类中
                ioInfo.IoName = txt_ioname.Text;
                ioInfo.TrueText = txt_truetext.Text;
                ioInfo.FalseText = txt_falsetext.Text;

                if (cmbox_iotype.Text == "input")
                {
                    ioInfo.IoType = 1;
                }
                else
                {
                    ioInfo.IoType = 2;
                }
                if (cmbox_control.Text == "PLC")
                {
                    ioInfo.Control = 1;
                }
                else
                {
                    ioInfo.Control = 2;
                }
                ioInfo.Addr1 = txt_addr1.Text;
                ioInfo.Addr2 = txt_addr2.Text;


                if (ioInfo.IoName == "")
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if (ioInfo.Addr1 == "")
                {
                    MessageBox.Show("控制地址1不能为空！");
                }
                else if (txt_truetext.Text == txt_falsetext.Text)
                {
                    MessageBox.Show("开文字与关文字不能相等！");
                }
                else
                {
                    ioControlService.UpdateData(filePath, "t_ios", curr_id, ioInfo);
                    MessageBox.Show("修改数据成功！");
                    this.Close();
                }
                // 确保获取到父窗体后，调用刷新数据的方法
                if (formUsers != null)
                {
                    formUsers.RefreshForm();
                }
            }
        }

    }
}
