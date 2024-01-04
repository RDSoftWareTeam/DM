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
    public partial class Form_AddOrEdit_roles : Form
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
        /// 角色表名
        /// </summary>
        private string tablename = "t_roles";

        /// <summary>
        /// t_roles的DataTable
        /// </summary>
        DataTable dataTable = new DataTable();

        public Form_AddOrEdit_roles()
        {
            InitializeComponent();
        }

        public Form_AddOrEdit_roles(int id)
        {
            InitializeComponent();

            //赋初始值
            role.id = id;

            //获取对应id行的数据
            dataTable = roleSev.ReturnRowDataFromRoleID(role.id);

            //给控件赋值
            textBox_roles_rolename.DataBindings.Add("Text", dataTable, "rolename");
            textBox_roles_notes.DataBindings.Add("Text", dataTable, "notes");
        }

        private void Form_AddOrEdit_roles_Load(object sender, EventArgs e)
        {
            // 计算居中的位置
            int x = (this.ClientSize.Width - panel1.Width) / 2;

            // 设置Panel的位置
            panel1.Location = new System.Drawing.Point(x, 30);
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_AddOrEdit_roles_Resize(object sender, EventArgs e)
        {
            // 计算居中的位置
            int x = (this.ClientSize.Width - panel1.Width) / 2;

            // 设置Panel的位置
            panel1.Location = new System.Drawing.Point(x, 30);
        }

        /// <summary>
        /// 角色表_新增/编辑 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_roles_save_Click(object sender, EventArgs e)
        {
            //获取控件数据
            role.rolename = textBox_roles_rolename.Text;
            role.notes = textBox_roles_notes.Text;

            //判断用户是否输入正确
            if (string.IsNullOrEmpty(role.rolename))
            {
                MessageBox.Show("请输入角色名");
                return;
            }

            //数据存入表t_roles
            roleSev.SaveDataToRoles(role);

            // 刷新 GridControl
            // 获取父窗体（Form_users）
            Form_roles formRoles = this.Owner as Form_roles;
            // 确保获取到父窗体后，调用刷新数据的方法
            if (formRoles != null)
            {
                formRoles.RefreshGCRoles();
            }

            Form_users fu = Application.OpenForms.OfType<Form_users>().FirstOrDefault();
            // 如果 Form3 已经打开，则调用其刷新方法
            if (fu != null)
            {
                fu.RefreshGCUsers();
            }

            MessageBox.Show("保存成功");
        }
    }
}
