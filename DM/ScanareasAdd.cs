

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
    public partial class ScanareasAdd : Form
    {
        public ScanareasAdd()
        {
            InitializeComponent();
        }
        string id = null;
        public ScanareasAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        bool Edit = false;
        DataRow listForm = null;
        ScanareasService scanareasService = new ScanareasServiceImpl();
        EntityScanareas entityScanareas = new EntityScanareas();
        public ScanareasAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }
        List<string> options1 = new List<string>();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            entityScanareas.areanoSg =  textBoxAreano.Text;
            entityScanareas.offsetxSg =    textBoxOffsetx.Text;
            entityScanareas.offsetySg =  textBoxOffsety.Text;
            entityScanareas.offsetzSg = textBoxOffsetz.Text;
            entityScanareas.scanlenSg =         textBoxScanlen.Text;
            entityScanareas.indexlenSg =   textBoxIndexlen.Text;
            entityScanareas.scanresSg = textBoxScanres.Text;
            entityScanareas.indexresSg = textBoxIndexres.Text;
            entityScanareas.idt_productsSg = comboBoxIdt_products.Text;
            if (scanareasService.determineNotNull(entityScanareas.areanoSg))
            {
                if (scanareasService.isFloat(entityScanareas.offsetxSg)
                    && scanareasService.isFloat(entityScanareas.offsetySg)
                    && scanareasService.isFloat(entityScanareas.offsetzSg)
                    && scanareasService.isFloat(entityScanareas.scanlenSg)
                    && scanareasService.isFloat(entityScanareas.indexlenSg)
                    && scanareasService.isFloat(entityScanareas.scanresSg)
                    && scanareasService.isFloat(entityScanareas.indexresSg))
                {
                    if (Edit)
                    {
                        entityScanareas.idSg = Convert.ToInt32(id);
                        scanareasService.editScanareas(entityScanareas, options1);
                        MessageBox.Show("编辑成功");
                    }
                    else
                    {
                        scanareasService.addScanareas(entityScanareas, options1);
                        MessageBox.Show("增加成功");
                    }
                }
                else
                {
                    MessageBox.Show("偏移x、偏移y、偏移z、扫查距离、步进距离、扫查精度、步进精度有值类型错误");
                }
                
            }
            else
            {
                MessageBox.Show("区域编号不能为空");
            }
            
             
        }
     
      
        private void ScanareasAdd_Load(object sender, EventArgs e)
        {
            Form1.ScanareasRef = true;
            options1 = scanareasService.returnColData4();
            comboBoxIdt_products.Items.AddRange(options1.ToArray());
            if (Edit)
            {
                textBoxAreano.Text = Convert.ToString(listForm["areano"]);
                textBoxOffsetx.Text = Convert.ToString(listForm["offsetx"]);
                textBoxOffsety.Text = Convert.ToString(listForm["offsety"]);
                textBoxOffsetz.Text = Convert.ToString(listForm["offsetz"]);
                textBoxScanlen.Text = Convert.ToString(listForm["scanlen"]);
                textBoxIndexlen.Text = Convert.ToString(listForm["indexlen"]);
                textBoxScanres.Text = Convert.ToString(listForm["scanres"]);
                textBoxIndexres.Text = Convert.ToString(listForm["indexres"]);
                comboBoxIdt_products.Text = Convert.ToString(listForm["productname"]);
            }
        }

        private void ScanareasAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.ScanareasRef = false;
        }
    }
}
