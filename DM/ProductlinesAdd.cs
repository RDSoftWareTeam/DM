
using DM.entity;
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
    public partial class ProductlinesAdd : Form
    {
        public ProductlinesAdd()
        {
            InitializeComponent();
        }
        bool Edit = false;
        string id = null;
        DataRow listForm = null;
        ProductlinesService productlinesService = new ProductlinesServiceImpl();
        EntityProductlines entityProductlines = new EntityProductlines();
        public ProductlinesAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        public ProductlinesAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }
        List<string> options1 = new List<string>();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            entityProductlines.linenameSg = textBoxLinename.Text;
            entityProductlines.linekeySg = textBoxLinekey.Text;
            entityProductlines.scanspeedSg = textBoxScanspeed.Text;
            entityProductlines.indexspeedSg = textBoxIndexspeed.Text;
            entityProductlines.auxspeedSg = textBoxAuxspeed.Text;
            entityProductlines.scanspeed_emptySg = textBoxScanspeed_empty.Text;
            entityProductlines.indexspeed_emptySg = textBoxIndexspeed_empty.Text;
            entityProductlines.auxspeed_emptySg = textBoxAuxspeed_empty.Text;
            entityProductlines.idt_layoutsSg = comboBoxIdt_layouts.Text;
            if (productlinesService.determineNotNull(entityProductlines.linekeySg))
            {
                if (productlinesService.isFloat(entityProductlines.scanspeedSg)
                    && productlinesService.isFloat(entityProductlines.indexspeedSg)
                    && productlinesService.isFloat(entityProductlines.auxspeedSg)
                    && productlinesService.isFloat(entityProductlines.scanspeed_emptySg)
                    && productlinesService.isFloat(entityProductlines.indexspeed_emptySg)
                    && productlinesService.isFloat(entityProductlines.auxspeed_emptySg))
                {
                    if (Edit)
                    {
                        entityProductlines.idSg = Convert.ToInt32(id);
                        productlinesService.editProductlines(entityProductlines, options1);
                        MessageBox.Show("编辑成功");
                    }
                    else
                    {
                        productlinesService.addProductlines(entityProductlines, options1);
                        MessageBox.Show("增加成功");
                    }
                }
                else
                {
                    MessageBox.Show("扫查速度、步进速度、升降速度、x空行速度、y空行速度、z空行速度有值类型错误");

                }
                
            }
            else
            {
                MessageBox.Show("Key不能为空");
            }
           
            
        }

       
        private void ProductlinesAdd_Load(object sender, EventArgs e)
        {
            Form1.productlinesRef = true;
            options1 = productlinesService.returnColData3();
            comboBoxIdt_layouts.Items.AddRange(options1.ToArray());
            if (Edit)
            {
                textBoxLinename.Text = Convert.ToString(listForm["linename"]);
                textBoxLinekey.Text = Convert.ToString(listForm["linekey"]);
                textBoxScanspeed.Text = Convert.ToString(listForm["scanspeed"]);
                textBoxIndexspeed.Text = Convert.ToString(listForm["indexspeed"]);
                textBoxAuxspeed.Text = Convert.ToString(listForm["auxspeed"]);
                textBoxScanspeed_empty.Text = Convert.ToString(listForm["scanspeed_empty"]);
                textBoxIndexspeed_empty.Text = Convert.ToString(listForm["indexspeed_empty"]);
                textBoxAuxspeed_empty.Text = Convert.ToString(listForm["auxspeed_empty"]);
                comboBoxIdt_layouts.Text = Convert.ToString(listForm["layoutname"]);
            }
        }

        private void ProductlinesAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.productlinesRef = false;
        }
    }
}
