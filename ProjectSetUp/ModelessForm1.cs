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
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Creation;
using Autodesk.Revit.ApplicationServices;

namespace LucidToolbar
{
    public partial class ModelessForm1 : System.Windows.Forms.Form
    {
        #region Fields
        /// <summary>
        /// Wrapper for ProjectInfo
        /// </summary>
        ProjectInfoWrapper m_projectInfoWrapper = null;
        #endregion
        public static string targetWorkset { get; set; }
        public static WorksetId activeId { get; set; }
        List<KeyValuePair<string, string>> data { get; set; }
        public static int progressb { get; set; }
        public static int revitlinks { get; set; }
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        public ModelessForm1()
        {
            InitializeComponent();
        }
        public ModelessForm1(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;
            //lblNS_PBP.Text= TestCommand.NS_PBP;
            //txtEW_PBP.Text = TestCommand.EW_PBP;
            //txtElev_PBP.Text = TestCommand.Elev_PBP;
            //txtAng_PBP.Text = TestCommand.Ang_PBP;

            //txtNS_SP.Text = TestCommand.NS_SP;
            //txtEW_SP.Text = TestCommand.EW_SP;
            //txtElev_SP.Text = TestCommand.Elev_SP;
            //txtAng_SP.Text = TestCommand.Ang_SP;
        }
        
        public ModelessForm1(ProjectInfoWrapper projectInfoWrapper) :this()
        {
            
            m_projectInfoWrapper = projectInfoWrapper;
            
            //Initialize propertyGrid with CustomDescriptor
            //propertyGrid1.SelectedObject = new WrapperCustomDescriptor(m_projectInfoWrapper);


        }



        public void UpdateUI (MyProgress progress)
        {
            Invoke(new Action(() =>
            {
                //update UI based on progress;
                MessageBox.Show(progress.Data);
            }));
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

        //private void DoRequest(RequestId request)
        //{
        //    d_Handler.Request.Make(request);
        //    d_ExEvent.Raise();
        //    DozeOff();
        //}


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
        public void ProjectInfoForm_Load(object sender, EventArgs e)
        {
            // Create a List to store our KeyValuePairs
            data = new List<KeyValuePair<string, string>>();
            TestCommand.filePath = "";

            // Add data to the List
            data.Add(new KeyValuePair<string, string>("ws1", "X_Architectural"));
            data.Add(new KeyValuePair<string, string>("ws2", "Access and Penetrations"));
            data.Add(new KeyValuePair<string, string>("ws3", "Electrical"));
            data.Add(new KeyValuePair<string, string>("ws4", "Fire"));
            data.Add(new KeyValuePair<string, string>("ws5", "Hydraulics"));
            data.Add(new KeyValuePair<string, string>("ws6", "Mechanical"));
            data.Add(new KeyValuePair<string, string>("ws7", "_Levels and Grids"));
            data.Add(new KeyValuePair<string, string>("ws8", "X_Structural"));
            //data.Add(new KeyValuePair<string, string>("ws9", RequestHandler.GetWorkset.ToString()));
            // Clear the combobox
            //worksetComboBox1.DataSource = null;
            //worksetComboBox1.Items.Clear();

            worksetComboBox.DataSource = null;
            worksetComboBox.Items.Clear();
            // Bind the combobox
            //worksetComboBox1.DataSource = new BindingSource(data, null);
            //worksetComboBox1.DisplayMember = "Value";
           

            worksetComboBox.DataSource = new BindingSource(data, null);
            worksetComboBox.DisplayMember = "Value";
            worksetComboBox.ValueMember = "Key";

            worksetComboBox.SelectedItem = null;
            //worksetComboBox.SelectedText = "---Select---";

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
            checkedListBox1.Items.Clear();
            if (openFileDialog1.ShowDialog()==DialogResult.OK)//Check whether some files are selected 
            { 
                txbFolderPath.Text = Path.GetDirectoryName(openFileDialog1.FileNames[0]).ToString();
                //checkedListBox1.Items.Add("Check All");
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {

                    //checkedListBox1.Items.Add(openFileDialog1.FileNames[i]);
                    checkedListBox1.Items.Add(Path.GetFileName(openFileDialog1.FileNames[i]));
                }
                    
                //ckbAll.Enabled = true; //After the list box is filled. enables the check box
                    //textBox1.Text = openFileDialog1.FileNames[i].ToString();
                //FilePath fp = new FilePath(textBox1.Text);
                //for (int i =0;i<openFileDialog1.FileName.Length;i++) //loop to iterate through the array of file names
            }
            
            ckbCheckAll.Enabled = true;
            ckbCheckAll.Checked = false;
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
            // Get the selected item in the combobox
            KeyValuePair<string, string> selectedPair = (KeyValuePair<string, string>)worksetComboBox.SelectedItem;

            // Show selected information on screen
            //lblSelectedKey.Text = selectedPair.Key;
            //lblSelectedValue.Text = selectedPair.Value;
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

        public void btnOpen_Click(object sender, EventArgs e)
        {
            MakeRequest(RequestId.Linkfile);
            
            progressBar1.Value = progressBar1.Minimum;//restore the progress bar between copy 
            progressBar1.Maximum = checkedListBox1.CheckedItems.Count; //
            foreach (var item in checkedListBox1.CheckedItems) //need to grab each item from the list
            {
                TestCommand.filePath = Path.Combine(txbFolderPath.Text, Path.GetFileName(item.ToString()));
                //TaskDialog.Show("Target Directory",TestCommand.filePath.ToString());
                MakeRequest(RequestId.Linkfile);
                progressBar1.PerformStep();
            }
        }

        private void btnGetWorkset_Click(object sender, EventArgs e)
        {
            //MakeRequest(RequestId.GetActiveWorkset);
            MakeRequest(RequestId.GetActiveWorkset);
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbAll.Checked)
            //{
            //    for (int i =0;i<checkedListBox1.Items.Count; i++)
            //    {
            //        checkedListBox1.SetItemChecked(i, true);//check the box at index i

            //    }
            //}
            //else
            //    for (int i = 0; i < checkedListBox1.Items.Count; i++)
            //    {
            //        checkedListBox1.SetItemChecked(i, false);//check the box at index i

            //    }



            //if (checkedListBox1.GetItemChecked(0))
            //{
            //    for (int i = 1; i < checkedListBox1.Items.Count; i++)
            //    {
            //        checkedListBox1.SetItemChecked(i, true);//check the box at index i

            //    }
            //}
            //else
            //    for (int i = 1; i < checkedListBox1.Items.Count; i++)
            //    {
            //        checkedListBox1.SetItemChecked(i, false);//check the box at index i

            //    }
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MakeRequest(RequestId.ProjectInfo);
            //DoRequest();
        }

        private void btnSetWorkset_Click(object sender, EventArgs e)
        {
            MakeRequest(RequestId.SetCurWorkset);
        }

        private void worksetComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //targetWorkset.Set(worksetComboBox1.Text);
            
            targetWorkset = worksetComboBox.Text;
            MakeRequest(RequestId.SetCurWorkset);
        }

        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCheckAll.Checked == true)
            {
                for(int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void worksetComboBox_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MakeRequest(RequestId.TreeDiagram);
        }

        private void propertyGrid1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            MakeRequest(RequestId.ProjectInfo);
        }
    }
}