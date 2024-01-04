
using DM.entity;
using DM.service;
using DM.service.impl;
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

namespace DM
{
    public partial class LayoutsAdd : Form
    {
        public LayoutsAdd()
        {
            InitializeComponent();
        }
        string id = null;
        public LayoutsAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        bool Edit = false;
        DataRow listForm = null;
        LayoutsService layoutsService = new LayoutsServiceImpl();
        EntityLayouts entityLayouts = new EntityLayouts();
        public LayoutsAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            entityLayouts.layoutnameSg = textBoxLayoutname.Text;
            entityLayouts.rowsSg = textBoxRows.Text;
            entityLayouts.colsSg = textBoxCols.Text;
            if (layoutsService.determineNotNull(entityLayouts.rowsSg)
                && layoutsService.determineNotNull(entityLayouts.colsSg))
            {
                if (layoutsService.isInt(entityLayouts.rowsSg)&& layoutsService.isInt(entityLayouts.colsSg))
                {
                    if (Edit)
                    {
                        entityLayouts.idSg = Convert.ToInt32(id);
                        layoutsService.editLayouts(entityLayouts);
                        MessageBox.Show("编辑成功");
                    }
                    else
                    {
                        layoutsService.addLayouts(entityLayouts);
                        MessageBox.Show("增加成功");
                    }
                }
                else
                {
                    MessageBox.Show("行数和列数有值类型错误");
                }
                
            }
            else
            {
                MessageBox.Show("行数和列数不能为空");
            }
        }
        
        

   
        private void LayoutsAdd_Load(object sender, EventArgs e)
        {
            Form1.layoutsRef = true;
            if (Edit)
            {
                textBoxLayoutname.Text = Convert.ToString(listForm["layoutname"]);
                textBoxRows.Text = Convert.ToString(listForm["rows"]);
                textBoxCols.Text = Convert.ToString(listForm["cols"]);

            }
        }

        private void LayoutsAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.layoutsRef = false;
        }
    }
}
