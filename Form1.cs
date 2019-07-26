using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;

//using Autodesk.Revit.UI;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;

namespace LucidToolbar
{
    public partial class Form1 : Form
    {
        public UIApplication uiapp;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "PipeSystemType.pipeSysTypeId";
            textBox2.Text = "1500";
            textBox3.Text = "Unknown";
        }



        public Form1(UIApplication uiapp)
        {
            this.uiapp = uiapp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            ExternalApplication.Press.Keys("PI");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
