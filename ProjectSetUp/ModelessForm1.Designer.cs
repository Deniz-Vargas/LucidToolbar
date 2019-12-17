namespace LucidToolbar
{
    partial class ModelessForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private ProjectInfo m_projectInfo;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetWorkset = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSelSourceFile = new System.Windows.Forms.Button();
            this.txbFolderPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.worksetComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.ckbCheckAll = new System.Windows.Forms.CheckBox();
            this.btnSetWorkset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetWorkset
            // 
            this.btnGetWorkset.Location = new System.Drawing.Point(12, 558);
            this.btnGetWorkset.Name = "btnGetWorkset";
            this.btnGetWorkset.Size = new System.Drawing.Size(222, 23);
            this.btnGetWorkset.TabIndex = 10;
            this.btnGetWorkset.Text = "Get Current Workset";
            this.btnGetWorkset.UseVisualStyleBackColor = true;
            this.btnGetWorkset.Visible = false;
            this.btnGetWorkset.Click += new System.EventHandler(this.btnGetWorkset_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(8, 51);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(390, 242);
            this.checkedListBox1.TabIndex = 9;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_2);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 469);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(675, 22);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Workset:";
            this.label2.Click += new System.EventHandler(this.Label1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(474, 97);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(189, 32);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Link in checked file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSelSourceFile
            // 
            this.btnSelSourceFile.Location = new System.Drawing.Point(630, 21);
            this.btnSelSourceFile.Name = "btnSelSourceFile";
            this.btnSelSourceFile.Size = new System.Drawing.Size(33, 24);
            this.btnSelSourceFile.TabIndex = 6;
            this.btnSelSourceFile.Text = "...";
            this.btnSelSourceFile.UseVisualStyleBackColor = true;
            this.btnSelSourceFile.Click += new System.EventHandler(this.btnSelSourceFile_Click);
            // 
            // txbFolderPath
            // 
            this.txbFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFolderPath.Location = new System.Drawing.Point(83, 21);
            this.txbFolderPath.Name = "txbFolderPath";
            this.txbFolderPath.Size = new System.Drawing.Size(541, 24);
            this.txbFolderPath.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(590, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(492, 540);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Revit files (*.rvt)|*.rvt|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Location = new System.Drawing.Point(5, 8);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(706, 526);
            this.tab.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pre-Project Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txbFolderPath);
            this.groupBox5.Controls.Add(this.btnOpen);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.checkedListBox1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.worksetComboBox);
            this.groupBox5.Controls.Add(this.btnSelSourceFile);
            this.groupBox5.Location = new System.Drawing.Point(9, 150);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(669, 313);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Step 2: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "File source:";
            this.label4.Click += new System.EventHandler(this.Label1_Click);
            // 
            // worksetComboBox
            // 
            this.worksetComboBox.FormattingEnabled = true;
            this.worksetComboBox.Location = new System.Drawing.Point(474, 55);
            this.worksetComboBox.Name = "worksetComboBox";
            this.worksetComboBox.Size = new System.Drawing.Size(189, 24);
            this.worksetComboBox.TabIndex = 4;
            this.worksetComboBox.DropDown += new System.EventHandler(this.worksetComboBox_DropDown);
            this.worksetComboBox.SelectedIndexChanged += new System.EventHandler(this.worksetComboBox_SelectedIndexChanged_1);
            this.worksetComboBox.Click += new System.EventHandler(this.worksetComboBox_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(9, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(669, 138);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 1: ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(474, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(189, 25);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Edit Project Information";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(365, 17);
            this.label19.TabIndex = 1;
            this.label19.Text = "Enter in the project and team information into the window";
            this.label19.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ckbCheckAll
            // 
            this.ckbCheckAll.AutoSize = true;
            this.ckbCheckAll.Enabled = false;
            this.ckbCheckAll.Location = new System.Drawing.Point(240, 560);
            this.ckbCheckAll.Name = "ckbCheckAll";
            this.ckbCheckAll.Size = new System.Drawing.Size(88, 21);
            this.ckbCheckAll.TabIndex = 11;
            this.ckbCheckAll.Text = "Check All";
            this.ckbCheckAll.UseVisualStyleBackColor = true;
            this.ckbCheckAll.Visible = false;
            this.ckbCheckAll.CheckedChanged += new System.EventHandler(this.ckbCheckAll_CheckedChanged);
            // 
            // btnSetWorkset
            // 
            this.btnSetWorkset.Location = new System.Drawing.Point(12, 536);
            this.btnSetWorkset.Name = "btnSetWorkset";
            this.btnSetWorkset.Size = new System.Drawing.Size(222, 23);
            this.btnSetWorkset.TabIndex = 10;
            this.btnSetWorkset.Text = "Change Current Workset to";
            this.btnSetWorkset.UseVisualStyleBackColor = true;
            this.btnSetWorkset.Visible = false;
            this.btnSetWorkset.Click += new System.EventHandler(this.btnSetWorkset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Get Linked Models";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ModelessForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 585);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSetWorkset);
            this.Controls.Add(this.ckbCheckAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGetWorkset);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModelessForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Set Up ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProjectInfoForm_Load);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelSourceFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnGetWorkset;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox txbFolderPath;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSetWorkset;
        private System.Windows.Forms.ComboBox worksetComboBox;
        private System.Windows.Forms.CheckBox ckbCheckAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnUpdate;
    }
}