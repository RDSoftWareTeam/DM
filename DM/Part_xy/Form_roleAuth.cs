using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM.entity;
using DM.service;
using DM.service.impl;

namespace DM
{
    public partial class Form_roleAuth : Form
    {
        /// <summary>
        /// 实体类roles
        /// </summary>
        Roles role = new Roles();

        /// <summary>
        /// SEV层接口roles
        /// </summary>
        RolesService roleSev = new RolesServiceImpl();

        /// <summary>
        /// SEV层接口modules
        /// </summary>
        ModulesService moduleSev = new ModulesServiceImpl();

        /// <summary>
        /// 存放角色id对应的功能id
        /// </summary>
        private List<int> lst_module_id = new List<int>();

        /// <summary>
        /// t_modules的DataTable
        /// </summary>
        DataTable dataTable = new DataTable();

        public Form_roleAuth()
        {
            InitializeComponent();
        }
        public Form_roleAuth(int id)
        {
            InitializeComponent();

            //赋初始值
            role.id = id;

            //获取功能表的所有数据
            dataTable = moduleSev.ReturnModulesAllData();

            //添加选择列，给选择列赋值
            dataTable.Columns.Add("select", typeof(bool));
            foreach (DataRow row in dataTable.Rows)
            {
                row["select"] = false; //默认不打勾
            }

            //给控件赋值
            gc_roleAuth.DataSource = dataTable;
            gc_roleAuth_moduleID.FieldName = "id";
            gc_roleAuth_modulename.FieldName = "modulename";
            gc_roleAuth_modulekey.FieldName = "modulekey";
            gc_roleAuth_select.FieldName = "select";

            textBox_auth_rolename.Text = roleSev.GetRolesRoleName(role.id);
        }

        private void Form_roleAuth_Load(object sender, EventArgs e)
        {
            //获取角色id对应的功能id，存入list
            lst_module_id = moduleSev.ReturnLstModuleID(role.id);

            //将选择的功能id打勾
            if (lst_module_id.Count > 0)
                foreach (int moduleID in lst_module_id)
                {
                    DataRow[] rowsToSelect = dataTable.Select($"id = {moduleID}");
                    foreach (DataRow row in rowsToSelect)
                    {
                        row["select"] = true;
                    }
                }
            
            //调整button的相对位置
            btn_roleAuth_save.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
        }

        /// <summary>
        /// 控件序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_roleAuth_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 选择列点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_roleAuth_btn_select_Click(object sender, EventArgs e)
        {
            // 获取当前行
            int rowIndex = t_roleAuth.FocusedRowHandle;

            // 获取当前行的 select 列的值
            bool currentValue = (bool)t_roleAuth.GetRowCellValue(rowIndex, "select");

            // 更改 select 列的值
            t_roleAuth.SetRowCellValue(rowIndex, "select", !currentValue);

            // 刷新当前行
            t_roleAuth.RefreshRow(rowIndex);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_roleAuth_Resize(object sender, EventArgs e)
        {
            //调整button的相对位置
            btn_roleAuth_save.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
        }

        /// <summary>
        /// 授权表保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_roleAuth_save_Click(object sender, EventArgs e)
        {
            //储存当前界面已选择的功能id
            List<int> lst_selectedModuleIds = new List<int>();

            //获取已选择的功能id
            foreach (DataRow row in dataTable.Rows)
            {
                // 检查 "select" 列是否为 true
                if (Convert.ToBoolean(row["select"]))
                {
                    // 如果为 true，获取相应的 ID 列的值，并添加到集合中
                    int idValue = Convert.ToInt32(row["id"]);
                    lst_selectedModuleIds.Add(idValue);
                }
            }

            //保存授权的角色
            roleSev.SaveDataToR(role.id, lst_selectedModuleIds);
            MessageBox.Show("保存成功");
        }
    }
}
