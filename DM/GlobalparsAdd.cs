
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
    public partial class GlobalparsAdd : Form
    {
        public GlobalparsAdd()
        {
            InitializeComponent();
        }
        string id = null;
        public GlobalparsAdd(bool EOA)
        {
            InitializeComponent();
            Edit = EOA;
        }
        bool Edit = false;
        DataRow listForm = null;
        GlobalparsService globalparsService = new GlobalparsServiceImpl();
        EntityGlobalpars entityGlobalpars = new EntityGlobalpars();
        public GlobalparsAdd(bool EOA, DataRow list)
        {
            InitializeComponent();
            Edit = EOA;
            listForm = list;
            id = Convert.ToString(list["id"]);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            entityGlobalpars.parnameSg = textBoxParname.Text;
            entityGlobalpars.parvalueSg = textBoxParvalue.Text;
            entityGlobalpars.dispnameSg = textBoxDispname.Text;
            if (Edit)
            {
                entityGlobalpars.idSg = Convert.ToInt32(id);
                globalparsService.editGlobalpars(entityGlobalpars);
                MessageBox.Show("编辑成功");
            }
            else
            {
                globalparsService.addGlobalpars(entityGlobalpars);
                MessageBox.Show("增加成功");
            }

        }
        private void ProductlinesAdd_Load(object sender, EventArgs e)
        {
            Form1.globalparsRef = true;
            if (Edit)
            {
                textBoxParname.Text = Convert.ToString(listForm["parname"]);
                textBoxParvalue.Text = Convert.ToString(listForm["parvalue"]);
                textBoxDispname.Text = Convert.ToString(listForm["dispname"]);     
            }
        }

        private void GlobalparsAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.globalparsRef = false;
        }
    }
}
