
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
    public partial class Productlines : Form
    {
        public Productlines()
        {
            InitializeComponent();
        }
        string tablename = "t_productlines";
        ProductlinesService productlinesService = new ProductlinesServiceImpl();
        private void Productlines_Load(object sender, EventArgs e)
        {
            timer1.Start();
            gridControl1.DataSource = productlinesService.returnProductlines();
            gridId.FieldName = "id";
            gridLinename.FieldName = "linename";
            gridLinekey.FieldName = "linekey";
            gridScanspeed.FieldName = "scanspeed";
            gridIndexspeed.FieldName = "indexspeed";
            gridAuxspeed.FieldName = "auxspeed";
            gridScanspeed_empty.FieldName = "scanspeed_empty";
            gridIndexspeed_empty.FieldName = "indexspeed_empty";
            gridAuxspeed_empty.FieldName = "auxspeed_empty";
            gridIdt_layouts.FieldName = "layoutname";
        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                productlinesService.deleteProductlines( list);
            }
            gridControl1.DataSource = productlinesService.returnProductlines();
            //gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
            MessageBox.Show("删除成功！");
        }
     
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductlinesAdd productlinesAdd = new ProductlinesAdd(false);
            productlinesAdd.ShowDialog();
        }

        private void repositoryItemButtonEdit_Click(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow list = gridView1.GetDataRow(handle);
                if (list != null)
                {
                    ProductlinesAdd productlinesAdd = new ProductlinesAdd(true, list);
                    productlinesAdd.ShowDialog();
                }

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.productlinesRef)
            {
                gridControl1.DataSource = productlinesService.returnProductlines();
            }
        }
        

        private void Productlines_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
