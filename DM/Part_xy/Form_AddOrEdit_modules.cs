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
    public partial class Form_AddOrEdit_modules : Form
    {
        /// <summary>
        /// 实体类users
        /// </summary>
        Modules module = new Modules();

        /// <summary>
        /// SEV层接口modules
        /// </summary>
        ModulesService moduleSev = new ModulesServiceImpl();

        /// <summary>
        /// 用户表名
        /// </summary>
        private string tablenName = "t_modules";

        /// <summary>
        /// t_modules的DataTable
        /// </summary>
        DataTable dataTable = new DataTable();

        public Form_AddOrEdit_modules()
        {
            InitializeComponent();
        }

        public Form_AddOrEdit_modules(int id)
        {
            InitializeComponent();

            //赋初始值
            module.id = id;

            //获取对应id行的数据
            dataTable = moduleSev.ReturnRowDataFromModuleID(module.id);

            //给控件赋值
            textBox_modules_modulename.DataBindings.Add("Text", dataTable, "modulename");
            textBox_modules_modulekey.DataBindings.Add("Text", dataTable, "modulekey");
        }

        private void Form_AddOrEdit_modules_Load(object sender, EventArgs e)
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
        private void Form_AddOrEdit_modules_Resize(object sender, EventArgs e)
        {
            // 计算居中的位置
            int x = (this.ClientSize.Width - panel1.Width) / 2;

            // 设置Panel的位置
            panel1.Location = new System.Drawing.Point(x, 30);
        }

        /// <summary>
        /// 功能表_新增/编辑 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_modules_save_Click(object sender, EventArgs e)
        {
            //获取控件数据
            module.modulename= textBox_modules_modulename.Text;
            module.modulekey = textBox_modules_modulekey.Text;

            //判断用户是否输入正确
            if (string.IsNullOrEmpty(module.modulename))
            {
                MessageBox.Show("请输入功能名");
                return;
            }
            if (string.IsNullOrEmpty(module.modulekey))
            {
                MessageBox.Show("请输入功能key");
                return;
            }
            if (moduleSev.JudgeModulekey(module))
            {
                MessageBox.Show("功能key重复");
                return;
            }

            //通过实体类 存入表t_modules
            moduleSev.SaveDataToModules(module);

            // 刷新 GridControl
            // 获取父窗体（Form_users）
            Form_modules formModules = this.Owner as Form_modules;
            // 确保获取到父窗体后，调用刷新数据的方法
            if (formModules != null)
            {
                formModules.RefreshGCModules();
            }

            MessageBox.Show("保存成功");
        }
    }
}
