
using DM.service;
using DM.service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM
{
    public partial class Layouts : Form
    {
        public Layouts()
        {
            InitializeComponent();
        }
        
        string tablename = "t_layouts";
        LayoutsService layoutsService = new LayoutsServiceImpl();
        private void Layouts_Load(object sender, EventArgs e)
        {
            timer1.Start();
            gridControl1.DataSource = layoutsService.returnLayouts();
            gridId.FieldName = "id";
            gridLayoutname.FieldName = "layoutname";
            gridRows.FieldName = "rows";
            gridCols.FieldName = "cols";

        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                layoutsService.deleteLayouts( list);
            }
            gridControl1.DataSource = layoutsService.returnLayouts();
            gridView1.RefreshData();
            MessageBox.Show("删除成功！");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            LayoutsAdd layoutsAdd = new LayoutsAdd(false);
            layoutsAdd.ShowDialog();
        }

        private void repositoryItemButtonEdit_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    LayoutsAdd layoutsEdit = new LayoutsAdd(true,list);
                    layoutsEdit.ShowDialog();
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.layoutsRef)
            {
                gridControl1.DataSource = layoutsService.returnLayouts();
            }
        }

        private void Layouts_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
