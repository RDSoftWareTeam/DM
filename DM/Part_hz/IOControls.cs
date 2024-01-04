using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Data;
using System.Windows.Forms;

namespace DM
{
    public partial class IOControls : Form
    {
        //表单高度
        private float FormHeight;
        //表单宽度
        private float FormWidth;

        private string ioType_1 = "input";
        private string ioType_2 = "output";

        private string control_1 = "PLC";
        private string control_2 = "运控";



        private AdaptFont adaptFont = new AdaptFont();
        /// <summary>
        /// 接受编辑时查询的ID
        /// </summary>
        public object queryById = null;
        /// <summary>
        /// 实例化IO业务逻辑层接口
        /// </summary>
        private IOControlService ioControlService = new IOControlServiceImpl();

        private SQLite sqlLite = new SQLite();

        public string connectionString = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";
        public IOControls()
        {
            InitializeComponent();

        }

       

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            IOInsertData ioInsertData;
            int handle = gridView1.FocusedRowHandle;
            DataRow list = gridView1.GetDataRow(handle);
            if (gridView1 != null)
            {
                
                if (list != null)
                {
                    queryById = list["id"];
                    ioInsertData = new IOInsertData(queryById);
                    ioInsertData.Owner = this;
                    IOInformationEntity ioInfo = new IOInformationEntity();
                    ioInfo = ioControlService.QueryByID(connectionString, "t_ios", Convert.ToString(queryById));
                    ioInsertData.Text = "IO信息编辑";
                    ioInsertData.txt_ioname.Text = ioInfo.IoName;
                    ioInsertData.txt_truetext.Text = ioInfo.TrueText;
                    ioInsertData.txt_falsetext.Text = ioInfo.FalseText;
                    if(ioInfo.IoType == 1)
                    {
                        ioInsertData.cmbox_iotype.Text = "input";
                    }
                    else
                    {
                        ioInsertData.cmbox_iotype.Text = "output";
                    }
                    if(ioInfo.Control == 1)
                    {
                        ioInsertData.cmbox_control.Text = "PLC";
                    }
                    else
                    {
                        ioInsertData.cmbox_control.Text = "运控";
                    }
                    //ioInsertData.cmbox_iotype.Text = Convert.ToString(ioInfo.IoType);
                    //ioInsertData.cmbox_control.Text = Convert.ToString(ioInfo.Control);
                    ioInsertData.txt_addr1.Text = ioInfo.Addr1;
                    ioInsertData.txt_addr2.Text = ioInfo.Addr2;
                    ioInsertData.sbtn_insert.Text = "修改";
                    ioInsertData.label1.Text = "I/O修改信息功能";
                    ioInsertData.insertOrQueryFlag = false;
                    ioInsertData.ShowDialog();
                }

            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    object id = list["id"];
                    ioControlService.DeleteDataById(connectionString, Convert.ToString(id), "t_ios");
                }
            }
            RefreshForm();
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_insert_Click(object sender, EventArgs e)
        {
            IOInsertData ioInsertData = new IOInsertData();
            ioInsertData.Owner = this;
            ioInsertData.insertOrQueryFlag = true;
            ioInsertData.ShowDialog();
        }
        
        
        

        /// <summary>
        /// 刷新主窗体中数据
        /// </summary>
        public void RefreshForm()
        {
            //string connectionString = "Data Source=" + "D:\\test.db;Version=3;";
            //gcontrol_t_ios.DataSource = ioControlService.ShowData(connectionString, "t_ios");
            DataTable dataTable = ioControlService.ShowData(connectionString, "t_ios");
            dataTable.Columns.Add("iotypestring", typeof(string));
            dataTable.Columns.Add("controlstring", typeof(string));
            foreach (DataRow row in dataTable.Rows)
            {
                int ioTypeValue = Convert.ToInt32(row["iotype"]);
                int controlValue = Convert.ToInt32(row["control"]);
                string ioTypeString = null;
                string controlString = null;
                if (ioTypeValue.Equals(2))
                {
                    ioTypeString = ioType_2;
                }
                else //if (ioTypeValue.Equals(2))
                {
                    ioTypeString = ioType_1;
                }
                if (controlValue.Equals(2))
                {
                    controlString = control_2;
                }
                else
                {
                    controlString = control_1;
                }
                row["iotypestring"] = ioTypeString;
                row["controlstring"] = controlString;
            }
            gcontrol_t_ios.DataSource = dataTable;//ioControlService.ShowData(connectionString, "t_ios");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MonitorPara m = new MonitorPara();
            m.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            LogConfig l = new LogConfig();
            l.ShowDialog();
        }

        private void IOControls_Load(object sender, EventArgs e)
        {
            RefreshForm();
            id.FieldName = "id";
            ioname.FieldName = "ioname";
            truetext.FieldName = "truetext";
            falsetext.FieldName = "falsetext";
            iotype.FieldName = "iotypestring";
            control.FieldName = "controlstring";
            addr1.FieldName = "addr1";
            addr2.FieldName = "addr2";

            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
        }

        private void IOControls_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
        }
    }
}
