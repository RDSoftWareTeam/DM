
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
    public partial class ProductsAdd : Form
    {
        public ProductsAdd()
        {
            InitializeComponent();
        }
        string id = null;
        public ProductsAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        bool Edit = false;
        DataRow listForm = null;
        ProductsService productsService = new ProductsServiceImpl();
        EntityProducts entityProducts = new EntityProducts();
        public ProductsAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            entityProducts.productnameSg = textBoxProductname.Text;
            entityProducts.scanorderSg = textBoxScanorder.Text;
            entityProducts.notesSg = textBoxNotes.Text;
            if (productsService.determineNotNull(entityProducts.productnameSg))
            { 
                if (Edit)
                {
                    entityProducts.idSg = Convert.ToInt32(id);
                    productsService.editProducts(entityProducts);
                    MessageBox.Show("编辑成功");
                }
                else
                {
                    productsService.addProducts(entityProducts);
                    MessageBox.Show("增加成功");
                }
            }
            else
            {
                MessageBox.Show("产品名称不能为空");
            }

        }



        private void ProductlinesAdd_Load(object sender, EventArgs e)
        {
            Form1.ProductsRef = true;
            if (Edit)
            {
                textBoxProductname.Text = Convert.ToString(listForm["productname"]);
                textBoxScanorder.Text = Convert.ToString(listForm["scanorder"]);
                textBoxNotes.Text = Convert.ToString(listForm["notes"]);

            }
        }

        private void ProductsAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.ProductsRef = false;
        }
    }
}
