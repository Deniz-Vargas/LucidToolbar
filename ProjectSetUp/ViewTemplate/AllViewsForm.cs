using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LucidToolbar.ProjectSetUp.ViewTemplate
{
    public partial class AllViewsForm : Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="data"></param>
         
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;
        public AllViewsForm(ViewsMgr data)
        {
            m_data = data;
            InitializeComponent();
        }
        public AllViewsForm(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed
            //m_ExEvent.Dispose();
            //m_ExEvent = null;
            //m_Handler = null;

            //// do not forget to call the base class
            //base.OnFormClosed(e);
        }

        private void EnableCommands(bool status)
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = status;
            }
            if (!status)
            {
                this.cancelButton.Enabled = true;
            }
        }

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

        private void AllViewsForm_Load(object sender, EventArgs e)
        {
            allViewsTreeView.Nodes.Add(m_data.AllViewsNames);
            allViewsTreeView.TopNode.Expand();

            foreach (string s in m_data.AllViewTemplatesNames)
            {
                viewTemplateListBox.Items.Add(s);
            }


            //foreach (string s in m_data.AllTitleBlocksNames)
            //{
            //    titleBlocksListBox.Items.Add(s);
            //}
        }

        private void oKButton_Click(object sender, EventArgs e)
        {
            m_data.SelectViews();
            if (1 == viewTemplateListBox.SelectedItems.Count)
            {
                string viewTemplate = viewTemplateListBox.SelectedItems[0].ToString();
                m_data.ChooseViewTemplate(viewTemplate);
                //m_data.ChooseTitleBlock(titleBlock);
            }
        }

        #region CheckTreeNode
        private void CheckNode(TreeNode node, bool check)
        {
            if (0 < node.Nodes.Count)
            {
                if (node.Checked)
                {
                    node.Expand();
                }
                else
                {
                    node.Collapse();
                }

                foreach (TreeNode t in node.Nodes)
                {
                    t.Checked = check;
                    CheckNode(t, check);
                }
            }
        }

        private void allViewsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckNode(e.Node, e.Node.Checked);
        }
        #endregion

        /// <summary>
        /// Select title block to generate sheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBlocksListBox_MouseClick(object sender, MouseEventArgs e)
        {
            int idx = viewTemplateListBox.SelectedIndex;
            if (0 < idx)
            {
                viewTemplateListBox.SetSelected(idx, true);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void titleBlocksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void titleBlocksLabel_Click(object sender, EventArgs e)
        {

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            m_data.SelectViews();
            if (1 == viewTemplateListBox.SelectedItems.Count)
            {
                string viewTemplate = viewTemplateListBox.SelectedItems[0].ToString();
                m_data.ChooseViewTemplate(viewTemplate);
            }
        }
    }
}
