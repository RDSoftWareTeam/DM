using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM.service;
using DM.service.impl;
using DM.entity;

namespace DM
{
    public partial class Form_AddOrEdit_users : Form
    {
        /// <summary>
        /// 实体类users
        /// </summary>
        Users user = new Users();

        /// <summary>
        /// 实体类roles
        /// </summary>
        Roles role = new Roles();

        /// <summary>
        /// SEV层接口users
        /// </summary>
        UsersService userSev = new UsersServiceImpl();

        /// <summary>
        /// SEV层接口roles
        /// </summary>
        RolesService roleSev = new RolesServiceImpl();

        /// <summary>
        /// 用户表名
        /// </summary>
        private string tablename = "t_users";

        /// <summary>
        /// t_users的DataTable
        /// </summary>
        DataTable dataTable = new DataTable();

        public Form_AddOrEdit_users()
        {
            InitializeComponent();       
        }

        public Form_AddOrEdit_users(int id)
        {
            InitializeComponent();

            //赋初始值
            user.id = id;
            user.idt_role = -1;

            //获取对应id行的数据
            dataTable = userSev.ReturnRowDataFromUserID(user.id);

            //获取对应id的角色名
            role.rolename = userSev.GetUsersRoleName(user.id);
            
            //给控件赋值
            textBox_users_username.DataBindings.Add("Text", dataTable, "username");
            textBox_users_userpwd.DataBindings.Add("Text", dataTable, "userpwd");
            textBox_users_realname.DataBindings.Add("Text", dataTable, "realname");
            string filePath = dataTable.Rows[0]["photo"].ToString();
            if (File.Exists(filePath))
            {
                // 加载图像并显示在 PictureBox 上
                pictureBox_users_photo.Image = Image.FromFile(filePath);
            }
            else
            {
                pictureBox_users_photo.Image = null;
            }
        }

        private void Form_AddOrEdit_users_Load(object sender, EventArgs e)
        {
            //获取表t_role所有角色名
            List<string> lst_roleName = roleSev.GetAllRoleName();
            //给comboBox赋值
            if (lst_roleName.Count > 0)
            {
                foreach (string rolename in lst_roleName)
                {
                    comboBox_users_idt_role.Items.Add(rolename);
                }
            }
            //设置comboBox默认值
            if (string.IsNullOrEmpty(role.rolename))
            {
                if(comboBox_users_idt_role.Items.Count > 0)
                    comboBox_users_idt_role.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < comboBox_users_idt_role.Items.Count; i++)
                {
                    if (comboBox_users_idt_role.Items[i].ToString() == role.rolename)
                    {
                        comboBox_users_idt_role.SelectedIndex = i;
                        break;
                    }
                }
            }

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
        private void Form_AddOrEdit_users_Resize(object sender, EventArgs e)
        {
            // 计算居中的位置
            int x = (this.ClientSize.Width - panel1.Width) / 2;

            // 设置Panel的位置
            panel1.Location = new System.Drawing.Point(x, 30);
        }

        /// <summary>
        /// 用户表_新增/编辑 选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "图片文件|*.png;*.jpg;*.jpeg;*.gif;*.bmp|所有文件|*.*";
            openFileDialog1.Title = "选择图片";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 设置PictureBox的Image属性为选择的图片路径
                pictureBox_users_photo.ImageLocation = openFileDialog1.FileName;
                user.photo = openFileDialog1.FileName;
            }
            
        }

        /// <summary>
        /// 用户表_新增/编辑 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_users_save_Click(object sender, EventArgs e)
        {
            //获取控件数据
            user.username = textBox_users_username.Text;
            user.userpwd = textBox_users_userpwd.Text;
            user.realname = textBox_users_realname.Text;
            string role_rolename = comboBox_users_idt_role.Text;

            //判断用户是否输入正确
            if (string.IsNullOrEmpty(user.username))
            {
                MessageBox.Show("请输入用户名");
                return;
            }

            if (string.IsNullOrEmpty(user.userpwd))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            if (string.IsNullOrEmpty(user.realname))
            {
                MessageBox.Show("请输入真实姓名");
                return;
            }

            if (string.IsNullOrEmpty(role_rolename))
            {
                MessageBox.Show("请先在角色表添加角色");
                return;
            }

            //获取rolename对应的role_id
            user.idt_role = roleSev.GetRoleID(role_rolename);
            if (user.idt_role < 1)
            {
                MessageBox.Show("不存在该角色");
                return;
            }
            else
                //数据存入表t_users
                userSev.SaveDataToUsers(user);

            // 刷新 GridControl
            // 获取父窗体（Form_users）
            Form_users formUsers = this.Owner as Form_users;
            // 确保获取到父窗体后，调用刷新数据的方法
            if (formUsers != null)
            {
                formUsers.RefreshGCUsers();
            }

            MessageBox.Show("保存成功！");
        }
    }
}
