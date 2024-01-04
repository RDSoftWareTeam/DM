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
using System.Data.SQLite;
using DM.entity;
using DM.service;
using DM.service.impl;
namespace DM
{
    public partial class Form_modules : Form
    {
        /// <summary>
        /// 实体类modules
        /// </summary>
        Modules module = new Modules();

        /// <summary>
        /// SEV层接口modules
        /// </summary>
        ModulesService moduleSev = new ModulesServiceImpl();

        /// <summary>
        /// 功能表名
        /// </summary>
        string tableName = "t_modules";

        public Form_modules()
        {
            InitializeComponent();
        }

        private void Form_modules_Load(object sender, EventArgs e)
        {
            gc_modules.DataSource = moduleSev.ReturnModulesAllData();
            gc_modules_id.FieldName = "id";
            gc_modules_modulename.FieldName = "modulename";
            gc_modules_modulekey.FieldName = "modulekey";

            //调整button的相对位置
            btn_modules_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_modules_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_modules_Resize(object sender, EventArgs e)
        {
            btn_modules_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_modules_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 功能表删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_modules_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "提示", messBtn);
            if (dr == DialogResult.OK)
            {
                //获取当前有焦点的视图，转换成GridView类型
                GridView view = gc_modules.FocusedView as GridView;

                if (view != null)
                {
                    // 获取按钮所在行的数据
                    int rowHandle = view.FocusedRowHandle;
                    DataRow row = view.GetDataRow(rowHandle);

                    if (row != null)
                    {
                        // 获取选定id
                        module.id = Convert.ToInt32(row["id"]);

                        // 删除功能id的用户表和关系表
                        moduleSev.DeleteModuleIDData(module.id);

                        // 刷新 GridControl
                        RefreshGCModules();
                    }
                }
            }
        }

        /// <summary>
        /// 功能表添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_modules_add_Click(object sender, EventArgs e)
        {
            Form_AddOrEdit_modules fam = new Form_AddOrEdit_modules();
            fam.Owner = this;
            fam.Show();
        }

        /// <summary>
        /// 功能表编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_modules_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //获取当前有焦点的视图，转换成GridView类型
            GridView view = gc_modules.FocusedView as GridView;
            if (view != null)
            {
                // 获取按钮所在行的数据
                int rowHandle = view.FocusedRowHandle;
                DataRow row = view.GetDataRow(rowHandle);

                if (row != null)
                {
                    // 获取选定id
                    module.id = Convert.ToInt32(row["id"]);
                }
            }
            if (module.id > 0)
            {
                Form_AddOrEdit_modules fam = new Form_AddOrEdit_modules(module.id);
                fam.Owner = this;
                fam.Show();
            }
        }

        /// <summary>
        /// 控件序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_modules_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if(e.Info.IsRowIndicator && e.RowHandle >=0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 刷新gc_modules
        /// </summary>
        public void RefreshGCModules()
        {
            DataTable dataTable = moduleSev.ReturnModulesAllData();
            gc_modules.DataSource = dataTable;
            gc_modules.RefreshDataSource();
        }
    }
}
