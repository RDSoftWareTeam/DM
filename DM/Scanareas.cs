using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM.service;
using DM.service.impl;

namespace DM
{
    public partial class Scanareas : Form
    {
        public Scanareas()
        {
            InitializeComponent();
        }
        string tablename = "t_scanareas";
        ScanareasService scanareasService = new ScanareasServiceImpl();
        private void Scanareas_Load(object sender, EventArgs e)
        {
            timer1.Start();
            gridControl1.DataSource = scanareasService.returnScanareas();
            gridId.FieldName = "id";
            gridAreano.FieldName = "areano";
            gridOffsetx.FieldName = "offsetx";
            gridOffsety.FieldName = "offsety";
            gridOffsetz.FieldName = "offsetz";
            gridScanlen.FieldName = "scanlen";
            gridIndexlen.FieldName = "indexlen";
            gridScanres.FieldName = "scanres";
            gridIndexres.FieldName = "indexres";
            gridIdt_products.FieldName = "productname";

        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                scanareasService.deleteScanareas( list);
            }
            gridControl1.DataSource = scanareasService.returnScanareas();
            //gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
            MessageBox.Show("删除成功！");
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            ScanareasAdd scanareasAdd = new ScanareasAdd(false);
            scanareasAdd.ShowDialog();
        }

        private void repositoryItemButtonEdit_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    ScanareasAdd ScanareasEdit = new ScanareasAdd(true, list);
                    ScanareasEdit.ShowDialog();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.ScanareasRef)
            {
                gridControl1.DataSource = scanareasService.returnScanareas();
            }
        }
  

        private void Scanareas_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
