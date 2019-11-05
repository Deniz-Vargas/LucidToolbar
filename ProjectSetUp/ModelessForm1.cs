using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using static LucidToolbar.TestCommand;

namespace LucidToolbar
{
    public partial class ModelessForm1 : System.Windows.Forms.Form
    {
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;
        public ModelessForm1(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;
            lblNS_PBP.Text= TestCommand.NS_PBP;
            txtEW_PBP.Text = TestCommand.EW_PBP;
            txtElev_PBP.Text = TestCommand.Elev_PBP;
            txtAng_PBP.Text = TestCommand.Ang_PBP;

            txtNS_SP.Text = TestCommand.NS_SP;
            txtEW_SP.Text = TestCommand.EW_SP;
            txtElev_SP.Text = TestCommand.Elev_SP;
            txtAng_SP.Text = TestCommand.Ang_SP;
        }
        /// <summary>
        /// Form closed event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            // do not forget to call the base class
            base.OnFormClosed(e);
        }


        /// <summary>
        ///   Control enabler / disabler 
        /// </summary>
        ///
        private void EnableCommands(bool status)
        {

        }


        /// <summary>
        ///   A private helper method to make a request
        ///   and put the dialog to sleep at the same time.
        /// </summary>
        /// <remarks>
        ///   It is expected that the process which executes the request 
        ///   (the Idling helper in this particular case) will also
        ///   wake the dialog up after finishing the execution.
        /// </remarks>
        ///
        private void MakeRequest(RequestId request)
        {
            m_Handler.Request.Make(request);
            m_ExEvent.Raise();
            DozeOff();
        }


        /// <summary>
        ///   DozeOff -> disable all controls (but the Exit button)
        /// </summary>
        /// 
        private void DozeOff()
        {
            EnableCommands(false);
        }


        /// <summary>
        ///   WakeUp -> enable all controls
        /// </summary>
        /// 
        public void WakeUp()
        {
            EnableCommands(true);
        }
        private void ProjectInfoForm_Load(object sender, EventArgs e)
        {
            List<FakeWorksets> worksets = new List<FakeWorksets>{ new FakeWorksets("Workset1"),
                new FakeWorksets("Workset2"),
                new FakeWorksets("Workset3")
            };
            this.worksetComboBox.DataSource = worksets;
            this.worksetComboBox.DisplayMember = "Name";
            this.worksetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.worksetComboBox.Sorted = true;
            //this.worksetComboBox.DropDown += new EventHandler(worksetComboBox_DropDown);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Button4_Click(object sender, EventArgs e)
        {

        }


        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSelSourceFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)//Check whether some files are selected 
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    textBox1.Text = openFileDialog1.FileNames[i].ToString();
                //FilePath fp = new FilePath(textBox1.Text);
                //for (int i =0;i<openFileDialog1.FileName.Length;i++) //loop to iterate through the array of file names
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnSelTargetPath_Click(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void WorksetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void worksetComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustWidthComboBox_DropDown(sender, e);
        }

        private void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FilePath fp = new FilePath(textBox1.Text);
            TaskDialog.Show("About to open file: ", textBox1.Text);
        }

    }
}