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
    public partial class Form_roles : Form
    {
        /// <summary>
        /// 实体类roles
        /// </summary>
        Roles role = new Roles();

        /// <summary>
        /// SEV层roles
        /// </summary>
        RolesService roleSev = new RolesServiceImpl();

        /// <summary>
        /// 角色表名
        /// </summary>
        string tableName = "t_roles";

        public Form_roles()
        {
            InitializeComponent();
        }

        private void Form_roles_Load(object sender, EventArgs e)
        {
            gc_roles.DataSource = roleSev.ReturnRolesAllData();
            gc_roles_id.FieldName = "id";
            gc_roles_rolename.FieldName = "rolename";
            gc_roles_notes.FieldName = "notes";

            //调整button的相对位置
            btn_roles_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_roles_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_roles_Resize(object sender, EventArgs e)
        {
            btn_roles_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_roles_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 角色表导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_roles_import_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 角色表删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_roles_btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "提示", messBtn);
            if (dr == DialogResult.OK)
            {
                //获取当前有焦点的视图，转换成GridView类型
                GridView view = gc_roles.FocusedView as GridView;

                if (view != null)
                {
                    // 获取按钮所在行的数据
                    int rowHandle = view.FocusedRowHandle;
                    DataRow row = view.GetDataRow(rowHandle);

                    if (row != null)
                    {
                        // 获取选定id
                        role.id = Convert.ToInt32(row["id"]);

                        // 删除角色id的用户表和关系表
                        roleSev.DeleteRoleIDData(role.id);

                        // 刷新 GridControl
                        RefreshGCRoles();
                    }
                }
            }       
        }

        /// <summary>
        /// 角色表增加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_roles_btn_add_Click(object sender, EventArgs e)
        {
            Form_AddOrEdit_roles far = new Form_AddOrEdit_roles();
            far.Owner = this;
            far.Show();
        }

        /// <summary>
        /// 角色表编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_roles_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //获取当前有焦点的视图，转换成GridView类型
            GridView view = gc_roles.FocusedView as GridView;
            if (view != null)
            {
                // 获取按钮所在行的数据
                int rowHandle = view.FocusedRowHandle;
                DataRow row = view.GetDataRow(rowHandle);

                if (row != null)
                {
                    // 获取选定id
                    role.id = Convert.ToInt32(row["id"]);
                }
            }
            if (role.id > 0)
            {
                //将用户id传入新窗体
                Form_AddOrEdit_roles far = new Form_AddOrEdit_roles(role.id);
                //继承父窗体
                far.Owner = this;
                far.Show();
            }
        }

        /// <summary>
        /// 角色表授权按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_roles_btn_auth_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //获取当前有焦点的视图，转换成GridView类型
            GridView view = gc_roles.FocusedView as GridView;

            if (view != null)
            {
                // 获取按钮所在行的数据
                int rowHandle = view.FocusedRowHandle;
                DataRow row = view.GetDataRow(rowHandle);
                if (row != null)
                {
                    // 获取选定id
                    int role_id = Convert.ToInt32(row["id"]);

                    Form_roleAuth faram = new Form_roleAuth(role_id);
                    faram.Show();
                }             
            }
            else
            {
                MessageBox.Show("Error！");
                return;
            }
        }

        /// <summary>
        /// 控件序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_roles_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 刷新gc_roles
        /// </summary>
        public void RefreshGCRoles()
        {
            //返回t_roles表所有数据
            DataTable dataTable = roleSev.ReturnRolesAllData();
            gc_roles.DataSource = dataTable;
            gc_roles.RefreshDataSource();
        }
    }
}
