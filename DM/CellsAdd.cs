
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
    public partial class CellsAdd : Form
    {
        public CellsAdd()
        {
            InitializeComponent();
        }
        string id = null;
        public CellsAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        bool Edit = false; 
        DataRow listForm = null;
        CellsService CellsService = new CellsServiceImpl();
        EntityCells entityCells = new EntityCells();
        public CellsAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }
        List<string> options1 = new List<string>();
        List<string> options2 = new List<string>();
        List<string> options3 = new List<string>();
        private void buttonSave_Click(object sender, EventArgs e)
        {          
            entityCells.rownoSg = textBoxRowno.Text;
            entityCells.colnoSg = textBoxColno.Text;
            entityCells.safypointxSg = textBoxSafypointx.Text;
            entityCells.safypointySg = textBoxSafypointy.Text;
            entityCells.safypointzSg = textBoxSafypointz.Text;
            entityCells.zeropointxSg = textBoxZeropointx.Text;
            entityCells.zeropointySg = textBoxZeropointy.Text;
            entityCells.zeropointzSg = textBoxZeropointz.Text;
            entityCells.idt_layoutsSg = comboBoxIdt_layouts.Text;
            entityCells.idt_productsSg = comboBoxIdt_products.Text;
            if (CellsService.determineNotNull(entityCells.rownoSg)
                && CellsService.determineNotNull(entityCells.colnoSg)
                && CellsService.determineNotNull(entityCells.safypointxSg)
                && CellsService.determineNotNull(entityCells.safypointySg)
                && CellsService.determineNotNull(entityCells.zeropointxSg) 
                && CellsService.determineNotNull(entityCells.zeropointySg)
                && CellsService.determineNotNull(entityCells.idt_layoutsSg)
                && CellsService.determineNotNull(entityCells.idt_productsSg))
            {
                if (CellsService.isInt(entityCells.rownoSg)&& CellsService.isInt(entityCells.colnoSg))
                {
                    if (CellsService.isFloat(entityCells.safypointxSg)
                        && CellsService.isFloat(entityCells.safypointySg)
                        && CellsService.isFloat(entityCells.safypointzSg)
                        && CellsService.isFloat(entityCells.zeropointxSg)
                        && CellsService.isFloat(entityCells.zeropointySg)
                        && CellsService.isFloat(entityCells.zeropointzSg))
                    {
                        if (Edit)
                        {
                            entityCells.idSg = Convert.ToInt32(id);
                            CellsService.editCells(entityCells, options1, options2);
                            MessageBox.Show("编辑成功");
                        }
                        else
                        {
                            CellsService.addCells(entityCells, options1, options2);
                            MessageBox.Show("增加成功");
                        }
                    }
                    else
                    {
                        MessageBox.Show("行号或列号值类型错误");
                    }
                   
                }
                else
                {
                    MessageBox.Show("安全点x、零点x、安全点、零点y、安全点z、零点z有值类型错误");
                }
                
            }
            else
            {
                MessageBox.Show("行号、列号、安全点x、零点x、安全点y、零点y、所属布局、放置产品都不能为空");
            }
            
        }
        
        
            
    

        private void ProductlinesAdd_Load(object sender, EventArgs e)
        {
            Form1.cellsRef = true;

            options1 = CellsService.returnColData1();
            comboBoxIdt_layouts.Items.AddRange(options1.ToArray());

            options2 = CellsService.returnColData2();
            comboBoxIdt_products.Items.AddRange(options2.ToArray());

            

            if (Edit)
            {
                options3 = CellsService.returnColData5(Convert.ToString(listForm["layoutname"]));
                textBoxRowno.Text = Convert.ToString(listForm["rowno"]);
                textBoxColno.Text = Convert.ToString(listForm["colno"]);
                textBoxSafypointx.Text = Convert.ToString(listForm["safypointx"]);
                textBoxZeropointx.Text = Convert.ToString(listForm["zeropointx"]);
                textBoxSafypointy.Text = Convert.ToString(listForm["safypointy"]);
                textBoxZeropointy.Text = Convert.ToString(listForm["zeropointy"]);
                textBoxSafypointz.Text = Convert.ToString(listForm["safypointz"]);
                textBoxZeropointz.Text = Convert.ToString(listForm["zeropointz"]);
                comboBoxIdt_layouts.Text = Convert.ToString(listForm["layoutname"]);
                comboBoxIdt_products.Text = Convert.ToString(listForm["productname"]);
            }
        }

        private void CellsAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.cellsRef = false;
        }
    }
}
