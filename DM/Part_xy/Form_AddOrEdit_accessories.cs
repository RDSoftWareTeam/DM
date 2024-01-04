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
    public partial class Form_AddOrEdit_accessories : Form
    {
        /// <summary>
        /// 实体类accessories
        /// </summary>
        Accessories acc = new Accessories();

        /// <summary>
        /// SEV层接口accessories
        /// </summary>
        AccessoriesService accSev = new AccessoriesServiceImpl();

        /// <summary>
        /// 用户表名
        /// </summary>
        private string tableName = "t_accessories";

        /// <summary>
        /// t_accessories的DataTable
        /// </summary>
        DataTable dataTable = new DataTable();

        private string acctype_1 = "易损";
        private string acctype_2 = "点检";
        private string circleunit_1 = "天";
        private string circleunit_2 = "分钟";

        public Form_AddOrEdit_accessories()
        {
            InitializeComponent();
            //为comboBox赋初始值
            comboBox_accessories_acctype.Items.Add(acctype_1);
            comboBox_accessories_acctype.Items.Add(acctype_2);
            comboBox_accessories_acctype.SelectedIndex = 0;
            comboBox_accessories_circleunit.Items.Add(circleunit_1);
            comboBox_accessories_circleunit.Items.Add(circleunit_2);
            comboBox_accessories_circleunit.SelectedIndex = 0;
        }

        public Form_AddOrEdit_accessories(int id)
        {
            InitializeComponent();

            //赋初始值
            acc.id = id;
            acc.circleunit = accSev.ReturnCircleUnit(acc.id);

            //获取对应id行的数据
            dataTable = accSev.ReturnRowDataFromAccID(acc.id);

            //判断DateTimePicker的显示格式
            if (acc.circleunit == 1)
            {
                dateTimePicker_accessories_starttime.CustomFormat = "yyyy-MM-dd";
                dateTimePicker_accessories_updatetime.CustomFormat = "yyyy-MM-dd";
            }
            else if (acc.circleunit == 2)
            {
                dateTimePicker_accessories_starttime.CustomFormat = "yyyy-MM-dd HH:mm";
                dateTimePicker_accessories_updatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            }

            //给控件赋值
            textBox_accessories_accname.DataBindings.Add("Text", dataTable, "accname");
            textBox_accessories_circletime.DataBindings.Add("Text", dataTable, "circletime");
            string starttime = accSev.ReturnStartTime(acc.id).ToString();
            dateTimePicker_accessories_starttime.Value = accSev.ReturnStartTime(acc.id);
            dateTimePicker_accessories_updatetime.Value = accSev.ReturnUpdateTime(acc.id);
            comboBox_accessories_acctype.Items.Add(acctype_1);
            comboBox_accessories_acctype.Items.Add(acctype_2);
            comboBox_accessories_circleunit.Items.Add(circleunit_1);
            comboBox_accessories_circleunit.Items.Add(circleunit_2);
            DataRow firstRow = dataTable.Rows[0];
            int acctypeValue = Convert.ToInt32(firstRow["acctype"]);
            if (acctypeValue.Equals(1))
            {
                comboBox_accessories_acctype.SelectedIndex = 0;
            }
            else if (acctypeValue.Equals(2))
            {
                comboBox_accessories_acctype.SelectedIndex = 1;
            }
            int circleunitValue = Convert.ToInt32(firstRow["circleunit"]);
            if (circleunitValue.Equals(1))
            {
                comboBox_accessories_circleunit.SelectedIndex = 0;
            }
            else if (circleunitValue.Equals(2))
            {
                comboBox_accessories_circleunit.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 调整控件相对位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_AddOrEdit_accessories_Resize(object sender, EventArgs e)
        {
            // 计算居中的位置
            int x = (this.ClientSize.Width - panel1.Width) / 2;

            // 设置Panel的位置
            panel1.Location = new System.Drawing.Point(x, 30);
        }

        /// <summary>
        /// 易损/点检表_新增/编辑 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_accessories_save_Click(object sender, EventArgs e)
        {
            acc.accname = textBox_accessories_accname.Text;

            string acc_acctypeString = comboBox_accessories_acctype.Text;
            string acc_circletime = textBox_accessories_circletime.Text;
            string acc_circleunitString = comboBox_accessories_circleunit.Text;

            if (string.IsNullOrEmpty(acc.accname))
            {
                MessageBox.Show("请输入配件名称");
                return;
            }

            int result;
            if (!int.TryParse(acc_circletime, out result))
            {
                MessageBox.Show("周期输入不是有效整数");
                return;
            }
            acc.circletime = Convert.ToInt32(acc_circletime);

            //将字符串转为int
            if (acc_acctypeString == acctype_1)
            {
                acc.acctype = 1;
            }
            else if (acc_acctypeString == acctype_2)
            {
                acc.acctype = 2;
            }

            if (acc_circleunitString == circleunit_1)
            {
                acc.circleunit = 1;
            }
            else if (acc_circleunitString == circleunit_2)
            {
                acc.circleunit = 2;
            }

            if (acc.circleunit == 1)
            {
                acc.starttime = dateTimePicker_accessories_starttime.Value.ToString("yyyy-MM-dd");
                acc.updatetime = dateTimePicker_accessories_updatetime.Value.ToString("yyyy-MM-dd");
            }
            else if (acc.circleunit == 2)
            {
                acc.starttime = dateTimePicker_accessories_starttime.Value.ToString("yyyy-MM-dd HH:mm");
                acc.updatetime = dateTimePicker_accessories_updatetime.Value.ToString("yyyy-MM-dd HH:mm");
            }
            //数据存入表t_roles
            accSev.SaveDataToAcc(acc);

            // 刷新 GridControl
            // 获取父窗体（Form_users）
            Form_accessories formAcc = this.Owner as Form_accessories;
            // 确保获取到父窗体后，调用刷新数据的方法
            if (formAcc != null)
            {
                formAcc.RefreshGCAccessories();
            }

            MessageBox.Show("保存成功");
        }

        private void comboBox_accessories_circleunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(accSev.ReturnCircleUnit(acc.id) == 1)
            //{
            //    dateTimePicker_accessories_starttime.CustomFormat = "yyyy-MM-dd HH:mm";
            //    dateTimePicker_accessories_updatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            //}
            //else
            //{
            //    dateTimePicker_accessories_starttime.CustomFormat = "yyyy - MM - dd";
            //    dateTimePicker_accessories_updatetime.CustomFormat = "yyyy - MM - dd";
            //}
        }
    }
}
