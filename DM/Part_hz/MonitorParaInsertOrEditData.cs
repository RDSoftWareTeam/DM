using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DM
{
    public partial class MonitorParaInsertOrEditData : Form
    {
        /// <summary>
        /// 判断增加还是编辑的标志位
        /// </summary>
        public bool insertOrQueryFlag = false;

        /// <summary>
        /// 存储点击编辑时的获取的ID
        /// </summary>
        public string curr_id;

        /// <summary>
        /// 正则表达式约束int
        /// </summary>
        public string patternInt = @"^[0-9]*$";

        public string filePath = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";
        private MonitorParaService monitorParaService = new MonitorParaServiceImpl();

        //表单高度
        private float FormHeight;
        //表单宽度
        private float FormWidth;

        private AdaptFont adaptFont = new AdaptFont();

        public MonitorParaInsertOrEditData()
        {
            InitializeComponent();
        }

        public MonitorParaInsertOrEditData(object id)
        {
            InitializeComponent();
            curr_id = id.ToString();
        }


        private void MonitorParaInsertOrEditData_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
        }

        private void MonitorParaInsertOrEditData_Load(object sender, EventArgs e)
        {

            if (insertOrQueryFlag)
            {
                c_box_upenableflg.Checked = true;
                c_box_dwnenableflg.Checked = true;
            }


            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
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
            MonitorPara formUsers = this.Owner as MonitorPara;
            LogConfig logConfig = new LogConfig();
            if (insertOrQueryFlag)//insertOrQueryFlag为true是添加
            {

                MonitorParaEntity paraInfo = new MonitorParaEntity();
                float result;
                paraInfo.IoName = txt_ioname.Text;
                paraInfo.DataType = txt_datatype.Text;
                paraInfo.StartAddr = txt_startaddr.Text;
                paraInfo.UpColor = ParseRGB(color_upcolor.Color);
                paraInfo.DwnColor = ParseRGB(color_downcolor.Color);
                if (paraInfo.IoName == "")
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if (!float.TryParse(txt_upthreshv.Text, out result) && !(txt_upthreshv.Text == ""))
                {
                    MessageBox.Show("请在上阈值中输入整型数字或小数！");
                }
                else if (!float.TryParse(txt_dwnthreshv.Text, out result) && !(txt_dwnthreshv.Text == ""))
                {
                    MessageBox.Show("请在下阈值输入整型数字或小数！");
                }
                else
                {
                    if (txt_upthreshv.Text == "")
                    {
                        paraInfo.UpThreshv = null;
                    }
                    else
                    {
                        paraInfo.UpThreshv = txt_upthreshv.Text;
                    }


                    if (c_box_upenableflg.Checked)
                    {
                        paraInfo.UpEnableFlg = Convert.ToInt32(c_box_upenableflg.Checked);
                    }
                    else
                    {
                        paraInfo.UpEnableFlg = Convert.ToInt32(c_box_upenableflg.Checked);
                    }

                    
                    if (txt_dwnthreshv.Text == "")
                    {
                        paraInfo.DwnThreshv = null;
                    }
                    else
                    {
                        paraInfo.DwnThreshv = txt_dwnthreshv.Text;
                    }

                    if (c_box_dwnenableflg.Checked)
                    {
                        paraInfo.DwnEnableFlg = Convert.ToInt32(c_box_dwnenableflg.Checked);
                    }
                    else
                    {
                        paraInfo.DwnEnableFlg = Convert.ToInt32(c_box_dwnenableflg.Checked);
                    }                      
                    monitorParaService.InsertMonitorParaData(filePath, paraInfo);
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
                MonitorParaEntity paraInfo = new MonitorParaEntity();
                float result;
                paraInfo.IoName = txt_ioname.Text;
                paraInfo.DataType = txt_datatype.Text;
                paraInfo.StartAddr = txt_startaddr.Text;
                paraInfo.UpColor = ParseRGB(color_upcolor.Color);
                paraInfo.DwnColor = ParseRGB(color_downcolor.Color);
                if (paraInfo.IoName == "")
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if (!float.TryParse(txt_upthreshv.Text, out result) && !(txt_upthreshv.Text == ""))
                {
                    MessageBox.Show("请在上阈值中输入整型数字或小数！");
                }
                else if (!float.TryParse(txt_dwnthreshv.Text, out result) && !(txt_dwnthreshv.Text == ""))
                {
                    MessageBox.Show("请在下阈值输入整型数字或小数！");
                }
                else
                {
                    if (txt_upthreshv.Text == "")
                    {
                        paraInfo.UpThreshv = null;
                    }
                    else
                    {
                        paraInfo.UpThreshv = txt_upthreshv.Text;
                    }


                    if (c_box_upenableflg.Checked)
                    {
                        paraInfo.UpEnableFlg = Convert.ToInt32(c_box_upenableflg.Checked);
                    }
                    else
                    {
                        paraInfo.UpEnableFlg = Convert.ToInt32(c_box_upenableflg.Checked);
                    }
                        //paraInfo.UpColor = txt_upcolor.Text;

                    if (txt_dwnthreshv.Text == "")
                    {
                        paraInfo.DwnThreshv = null;
                    }
                    else
                    {
                        paraInfo.DwnThreshv = txt_dwnthreshv.Text;
                    }

                    if (c_box_dwnenableflg.Checked)
                    {
                        paraInfo.DwnEnableFlg = Convert.ToInt32(c_box_dwnenableflg.Checked);
                    }
                    else
                    {
                        paraInfo.DwnEnableFlg = Convert.ToInt32(c_box_dwnenableflg.Checked);
                    }

                    monitorParaService.UpdateData(filePath, "t_keyparameters", curr_id, paraInfo);
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


        public int ParseRGB(Color color)
        {
            return (int)(((uint)color.B << 16) | (ushort)(((ushort)color.G << 8) | color.R));
        }

        

    }
}
