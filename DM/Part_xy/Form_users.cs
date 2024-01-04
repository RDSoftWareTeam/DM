using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DM.service;
using DM.service.impl;
using DM.entity;

namespace DM
{
    public partial class Form_users : Form
    {
        /// <summary>
        /// 实体类users
        /// </summary>
        Users user = new Users();

        /// <summary>
        /// SEV层接口users
        /// </summary>
        UsersService userSev = new UsersServiceImpl();

        /// <summary>
        /// 用户表名
        /// </summary>
        string tableName = "t_users";

        public Form_users()
        {
            InitializeComponent();
        }

        private void Form_users_Load(object sender, EventArgs e)
        {
            DataTable dataTable = userSev.ReturnGCUsersData();

            gc_users.DataSource = dataTable;
            gc_users_id.FieldName = "id";
            gc_users_username.FieldName = "username";
            gc_users_userpwd.FieldName = "userpwd";
            gc_users_realname.FieldName = "realname";
            gc_users_idt_role.FieldName = "rolename";
            gc_users_photo.FieldName = "photo";

            //调整button的相对位置
            btn_users_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_users_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_users_Resize(object sender, EventArgs e)
        {
            btn_users_import.Location = new System.Drawing.Point(this.ClientSize.Width - 100, 10);
            btn_users_add.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 10);
        }

        /// <summary>
        /// 用户表增加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_users_add_Click(object sender, EventArgs e)
        {
            Form_AddOrEdit_users fau = new Form_AddOrEdit_users();
            fau.Owner = this;
            fau.Show();
        }

        /// <summary>
        /// 控件序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_users_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if(e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 用户表编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_users_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //获取当前有焦点的视图，转换成GridView类型
            GridView view = gc_users.FocusedView as GridView;
            if (view != null)
            {
                // 获取按钮所在行的数据
                int rowHandle = view.FocusedRowHandle;
                DataRow row = view.GetDataRow(rowHandle);

                if (row != null)
                {
                    // 获取选定id
                    int result = 0;
                    user.id = int.TryParse(row["id"].ToString(), out result) ? result : 0;
                }
            }
            if(user.id > 0)
            {
                //将用户id传入新窗体
                Form_AddOrEdit_users fau = new Form_AddOrEdit_users(user.id);
                //继承父窗体
                fau.Owner = this;
                fau.Show();
            }
        }

        /// <summary>
        /// 用户表删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_users_btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "提示", messBtn);
            if (dr == DialogResult.OK)
            {               
                //获取当前有焦点的视图，转换成GridView类型
                GridView view = gc_users.FocusedView as GridView;
                if (view != null)
                {
                    // 获取按钮所在行的数据
                    int rowHandle = view.FocusedRowHandle;
                    DataRow row = view.GetDataRow(rowHandle);

                    if (row != null)
                    {
                        // 获取选定id
                        int user_id = Convert.ToInt32(row["id"]);

                        //删除数据库内容
                        userSev.DeleteUsersRowData(user_id);

                        // 刷新 GridControl
                        RefreshGCUsers();
                    }
                }
            } 
        }

        /// <summary>
        /// 刷新gc_users
        /// </summary>
        public void RefreshGCUsers()
        {
            DataTable dataTable = userSev.ReturnGCUsersData();
            gc_users.DataSource = dataTable;
            gc_users.RefreshDataSource();
        }
    }
}
