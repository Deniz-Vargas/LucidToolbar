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

namespace LucidToolbar
{
    public partial class ModelessForm1 : System.Windows.Forms.Form
    {
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;
        public ModelessForm1(Autodesk.Revit.UI.ExternalEvent exEvent)
        {
            InitializeComponent();
            //m_Handler = handler;
            m_ExEvent = exEvent;
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
        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //NOTE open file dialog then filter out only .rvt file
            ofd.Title = "Select Revit Project Files";
            ofd.Filter = "RVT files|*.rvt";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)

            {
                string mpath = "";
                string mpathOnlyFilename = "";
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "Select Folder Where Revit Projects to be Saved in Local";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    mpath = folderBrowserDialog1.SelectedPath;
                    foreach (String projectPath in ofd.FileNames)
                    {
                        FileInfo filePath = new FileInfo(projectPath);
                        ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath.FullName);
                        OpenOptions opt = new OpenOptions();
                        opt.DetachFromCentralOption = DetachFromCentralOption.DetachAndDiscardWorksets;
                        mpathOnlyFilename = filePath.Name;
                        //Document openedDoc = Autodesk.Revit.ApplicationServices.Application.OpenDocumentFile(mp, opt);
                        SaveAsOptions options = new SaveAsOptions();
                        options.OverwriteExistingFile = true;
                        ModelPath modelPathout = ModelPathUtils.ConvertUserVisiblePathToModelPath(mpath + "\\" + mpathOnlyFilename);
                        //openedDoc.SaveAs(modelPathout, options);
                        //openedDoc.Close(false);
                    }
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}