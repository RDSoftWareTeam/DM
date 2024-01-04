using DM.dao;
using DM.entity;
using DM.service;
using DM.service.impl;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DM
{
    public partial class MonitorPara : Form
    {

        //表单高度
        private float FormHeight;
        //表单宽度
        private float FormWidth;

        private AdaptFont adaptFont = new AdaptFont();

        public string connectionString = SQLite.connectionString;//"Data Source=" + "D:\\test.db;Version=3;";

        public object queryById = null;

        private MonitorParaService monitorParaService = new MonitorParaServiceImpl();

        private string enableFlag_1 = "不启用";
        private string enableFlag_2 = "启用";



        public MonitorPara()
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
            MonitorParaInsertOrEditData monitorParaInsertOrEditData;

            int handle = gridView1.FocusedRowHandle;
            DataRow list = gridView1.GetDataRow(handle);
            if (gridView1 != null)
            {

                if (list != null)
                {
                    queryById = list["id"];
                    monitorParaInsertOrEditData = new MonitorParaInsertOrEditData(queryById);
                    monitorParaInsertOrEditData.Owner = this;
                    MonitorParaEntity paraInfo = new MonitorParaEntity();
                    paraInfo = monitorParaService.QueryByID(connectionString, "t_keyparameters", Convert.ToString(queryById));
                    monitorParaInsertOrEditData.Text = "监控参数信息编辑";
                    monitorParaInsertOrEditData.txt_ioname.Text = paraInfo.IoName;
                    monitorParaInsertOrEditData.txt_upthreshv.Text = paraInfo.UpThreshv;
                    monitorParaInsertOrEditData.c_box_upenableflg.Checked = Convert.ToBoolean(paraInfo.UpEnableFlg);
                    monitorParaInsertOrEditData.color_upcolor.Color = IntToColorRGB(Convert.ToInt32(paraInfo.UpColor));
                    monitorParaInsertOrEditData.txt_dwnthreshv.Text = paraInfo.DwnThreshv;
                    monitorParaInsertOrEditData.c_box_dwnenableflg.Checked = Convert.ToBoolean(paraInfo.DwnEnableFlg);
                    monitorParaInsertOrEditData.color_downcolor.Color = IntToColorRGB(Convert.ToInt32(paraInfo.DwnColor));// txt_dwncolor.Text = paraInfo.DwnColor;
                    monitorParaInsertOrEditData.txt_datatype.Text = paraInfo.DataType;
                    monitorParaInsertOrEditData.txt_startaddr.Text = paraInfo.StartAddr;
                    monitorParaInsertOrEditData.sbtn_insert.Text = "修改";
                    monitorParaInsertOrEditData.label1.Text = "监控参数修改信息功能";
                    monitorParaInsertOrEditData.insertOrQueryFlag = false;
                    monitorParaInsertOrEditData.ShowDialog();
                }

            }


            
        }
        private void MonitorPara_Load(object sender, EventArgs e)
        {
            RefreshForm();
            id.FieldName = "id";
            ioname.FieldName = "ioname";
            upthreshv.FieldName = "upthreshv";
            upenableflg.FieldName = "upenableflgstring";
            upcolor.FieldName = "upcolorcolor";
            dwnthreshv.FieldName = "dwnthreshv";
            dwnenableflg.FieldName = "dwnenableflgstring";
            dwncolor.FieldName = "dwncolorcolor";
            datatype.FieldName = "datatype";
            startaddr.FieldName = "startaddr";

            //自适应大小
            FormWidth = this.Width;
            FormHeight = this.Height;
            adaptFont.setTag(this);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    object id = list["id"];
                    monitorParaService.DeleteDataById(connectionString, Convert.ToString(id), "t_keyparameters");
                }
            }
            RefreshForm();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_insert_Click(object sender, EventArgs e)
        {
            MonitorParaInsertOrEditData monitorParaInsertOrEditData = new MonitorParaInsertOrEditData();
            monitorParaInsertOrEditData.Owner = this;
            monitorParaInsertOrEditData.insertOrQueryFlag = true;
            monitorParaInsertOrEditData.ShowDialog();
        }

        

        private void MonitorPara_Resize(object sender, EventArgs e)
        {
            adaptFont.Resize(this.Width, this.Height, FormWidth, FormHeight, this);
        }


        
        /// <summary>
        /// 刷新主窗体中数据
        /// </summary>
        public void RefreshForm()
        {

            DataTable dataTable = monitorParaService.ShowData(connectionString, "t_keyparameters");


            dataTable.Columns.Add("upenableflgstring", typeof(string));
            dataTable.Columns.Add("dwnenableflgstring", typeof(string));
            dataTable.Columns.Add("upcolorcolor", typeof(Color));
            dataTable.Columns.Add("dwncolorcolor", typeof(Color));
            foreach (DataRow row in dataTable.Rows)
            {
                int ioTypeValue = Convert.ToInt32(row["upenableflg"]);
                int controlValue = Convert.ToInt32(row["dwnenableflg"]);
                Color upColorValue = IntToColorRGB(Convert.ToInt32(row["upcolor"]));
                Color dwnColorValue = IntToColorRGB(Convert.ToInt32(row["dwncolor"]));

                Color upColorColor = new Color();
                Color dwnColorColor = new Color();
                string upEnableFlgString = null;
                string dwnEnableFlgString = null;
                if (ioTypeValue.Equals(0))
                {
                    upEnableFlgString = enableFlag_1;
                }
                else //if (ioTypeValue.Equals(2))
                {
                    upEnableFlgString = enableFlag_2;
                }
                if (controlValue.Equals(0))
                {
                    dwnEnableFlgString = enableFlag_1;
                }
                else
                {
                    dwnEnableFlgString = enableFlag_2;
                }
                upColorColor = upColorValue;
                dwnColorColor = dwnColorValue;

                row["dwncolorcolor"] = dwnColorColor;
                row["upcolorcolor"] = upColorColor;
                row["upenableflgstring"] = upEnableFlgString;
                row["dwnenableflgstring"] = dwnEnableFlgString;
            }
            gcontrol_t_keyparameters.DataSource = dataTable;

            //gcontrol_t_keyparameters.DataSource = monitorParaService.ShowData(connectionString, "t_keyparameters");
        }


        /// <summary>
        /// 整型还原为颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color IntToColorRGB(int color)
        {
            int r = 0xFF & color;
            int g = 0xFF00 & color;
            g >>= 8;
            int b = 0xFF0000 & color;
            b >>= 16;
            return Color.FromArgb(r, g, b);
        }
    }
}
