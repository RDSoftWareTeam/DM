
using DM.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DM
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        public static bool cellsRef = false;
        public static bool globalparsRef = false;
        public static bool layoutsRef = false;
        public static bool productlinesRef = false;
        public static bool ProductsRef = false;
        public static bool ScanareasRef = false;

        private void buttonScanareas_Click(object sender, EventArgs e)
        {
            Scanareas scanareas = new Scanareas();
            scanareas.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productlines productlines = new Productlines();
            productlines.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Layouts layouts = new Layouts();
            layouts.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cells cells = new Cells();
            cells.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Globalpars globalpars = new Globalpars();
            globalpars.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            //SQLite.CreateTable(SQLite.connectionString);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Form_users fu = new Form_users();
            //fu.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2();
            //form2.ShowDialog();
        }

        private void btn_usersForm_Click(object sender, EventArgs e)
        {
            Form_users fu = new Form_users();
            fu.Show();
        }

        private void btn_rolesForm_Click(object sender, EventArgs e)
        {
            Form_roles fr = new Form_roles();
            fr.Show();
        }

        private void btn_modulesForm_Click(object sender, EventArgs e)
        {
            Form_modules fm = new Form_modules();
            fm.Show();
        }

        private void btn_accForm_Click(object sender, EventArgs e)
        {
            Form_accessories fa = new Form_accessories();
            fa.Show();
        }

        private void btn_initSql_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath + "\\m_sqlite.db";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                SQLite.CreateTable(SQLite.connectionString);
                SQLite.InsertData(SQLite.connectionString, 5);
                MessageBox.Show("重建成功");
            }
            else
            {
                MessageBox.Show("重建失败");
            }
        }

        private void btn_IO_Click(object sender, EventArgs e)
        {
            IOControls ioc = new IOControls();
            ioc.Show();
        }

        private void btn_monitorpara_Click(object sender, EventArgs e)
        {
            LogConfig logConfig = new LogConfig();
            logConfig.Show();
        }

        private void btn_logconfig_Click(object sender, EventArgs e)
        {
            MonitorPara monitorPara = new MonitorPara();
            monitorPara.Show();
        }
    }
}
