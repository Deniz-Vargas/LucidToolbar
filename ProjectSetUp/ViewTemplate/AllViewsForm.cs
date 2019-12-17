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
        public AllViewsForm(ViewsMgr data)
        {
            m_data = data;
            InitializeComponent();
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
