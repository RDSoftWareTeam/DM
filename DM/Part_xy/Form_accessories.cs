using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DM.entity;
using DM.service;
using DM.service.impl;

namespace DM
{
    public partial class Form_accessories : Form
    {
        /// <summary>
        /// 实体类modules
        /// </summary>
        Accessories acc = new Accessories();

        /// <summary>
        /// SEV层接口accessories
        /// </summary>
        AccessoriesService accSev = new AccessoriesServiceImpl();

        /// <summary>
        /// 功能表名
        /// </summary>
        string tableName = "t_accessories";

        private string acctype_1 = "易损";
        private string acctype_2 = "点检";
        private string circleunit_1 = "天";
        private string circleunit_2 = "分钟";

        public Form_accessories()
        {
            InitializeComponent();
        }

        private void Form_accessories_Load(object sender, EventArgs e)
        {
            //加载数据
            DataTable dataTable = accSev.ReturnRolesAllData();
            dataTable.Columns.Add("acctypeString", typeof(string));
            foreach (DataRow row in dataTable.Rows)
            {
                int acctypeValue = Convert.ToInt32(row["acctype"]);
                string acctypeString = null;

                if (acctypeValue.Equals(1))
                {
                    acctypeString = acctype_1;
                }
                else if (acctypeValue.Equals(2))
                {
                    acctypeString = acctype_2;
                }
                row["acctypeString"] = acctypeString;
            }

            dataTable.Columns.Add("circleunitString", typeof(string));
            foreach (DataRow row in dataTable.Rows)
            {
                int circleunitValue = Convert.ToInt32(row["circleunit"]);
                string circleunitString = null;

                if (circleunitValue.Equals(1))
                {
                    circleunitString = circleunit_1;
                }
                else if (circleunitValue.Equals(2))
                {
                    circleunitString = circleunit_2;
                }
                row["circleunitString"] = circleunitString;
            }

            gc_accessories.DataSource = dataTable;
            gc_accessories_id.FieldName = "id";
            gc_accessories_accname.FieldName = "accname";
            gc_accessories_starttime.FieldName = "starttime";
            gc_accessories_acctype.FieldName = "acctypeString";
            gc_accessories_updatetime.FieldName = "updatetime";
            gc_accessories_circletime.FieldName = "circletime";
            gc_accessories_circleunit.FieldName = "circleunitString";

            //调整button的相对位置
            btn_accessories_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_accessories_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_accessories_Resize(object sender, EventArgs e)
        {
            //调整button的相对位置
            btn_accessories_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_accessories_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 易损/点检删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_accessories_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "提示", messBtn);
            if (dr == DialogResult.OK)
            {
                //获取当前有焦点的视图，转换成GridView类型
                GridView view = gc_accessories.FocusedView as GridView;

                if (view != null)
                {
                    // 获取按钮所在行的数据
                    int rowHandle = view.FocusedRowHandle;
                    DataRow row = view.GetDataRow(rowHandle);

                    if (row != null)
                    {
                        // 获取选定id
                        acc.id = Convert.ToInt32(row["id"]);

                        //删除易损/点检表的内容
                        accSev.DeleteAccRowData(acc.id);

                        // 刷新 GridControl
                        RefreshGCAccessories();
                    }
                }
            }
        }

        /// <summary>
        /// 易损/点检添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_accessories_add_Click(object sender, EventArgs e)
        {
            Form_AddOrEdit_accessories faa = new Form_AddOrEdit_accessories();
            faa.Owner = this;
            faa.Show();
        }

        /// <summary>
        /// 易损/点检编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_accessories_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //获取当前有焦点的视图，转换成GridView类型
            GridView view = gc_accessories.FocusedView as GridView;
            if (view != null)
            {
                // 获取按钮所在行的数据
                int rowHandle = view.FocusedRowHandle;
                DataRow row = view.GetDataRow(rowHandle);

                if (row != null)
                {
                    // 获取选定id
                    acc.id = Convert.ToInt32(row["id"]);
                }
            }
            if (acc.id > 0)
            {
                Form_AddOrEdit_accessories faa = new Form_AddOrEdit_accessories(acc.id);
                faa.Owner = this;
                faa.Show();
            }
        }

        /// <summary>
        /// 控件序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_accessories_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 刷新gc_accessories
        /// </summary>
        public void RefreshGCAccessories()
        {
            DataTable dataTable = accSev.ReturnRolesAllData();
            dataTable.Columns.Add("acctypeString", typeof(string));
            dataTable.Columns.Add("circleunitString", typeof(string));
            string acctypeString = null;
            string circleunitString = null;
            foreach (DataRow row in dataTable.Rows)
            {
                int acctypeValue = Convert.ToInt32(row["acctype"]);
                if (acctypeValue.Equals(1))
                {
                    acctypeString = acctype_1;
                }
                else if (acctypeValue.Equals(2))
                {
                    acctypeString = acctype_2;
                }
                row["acctypeString"] = acctypeString;

                int circleunitValue = Convert.ToInt32(row["circleunit"]);

                if (circleunitValue.Equals(1))
                {
                    circleunitString = circleunit_1;
                }
                else if (circleunitValue.Equals(2))
                {
                    circleunitString = circleunit_2;
                }
                row["circleunitString"] = circleunitString;
            }
            gc_accessories.DataSource = dataTable;
            gc_accessories_acctype.FieldName = "acctypeString";
            gc_accessories_circleunit.FieldName = "circleunitString";
            gc_accessories.RefreshDataSource();          
        }
    }
}
