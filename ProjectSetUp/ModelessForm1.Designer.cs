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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ckbCheckAll = new System.Windows.Forms.CheckBox();
            this.btnSetWorkset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSelSourceFile = new System.Windows.Forms.Button();
            this.worksetComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txbFolderPath = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetWorkset
            // 
            this.btnGetWorkset.Location = new System.Drawing.Point(12, 311);
            this.btnGetWorkset.Name = "btnGetWorkset";
            this.btnGetWorkset.Size = new System.Drawing.Size(222, 23);
            this.btnGetWorkset.TabIndex = 10;
            this.btnGetWorkset.Text = "Get Current Workset";
            this.btnGetWorkset.UseVisualStyleBackColor = true;
            this.btnGetWorkset.Visible = false;
            this.btnGetWorkset.Click += new System.EventHandler(this.btnGetWorkset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(603, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(476, 293);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
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
            // ckbCheckAll
            // 
            this.ckbCheckAll.AutoSize = true;
            this.ckbCheckAll.Enabled = false;
            this.ckbCheckAll.Location = new System.Drawing.Point(240, 313);
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
            this.btnSetWorkset.Location = new System.Drawing.Point(12, 289);
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
            this.button1.Location = new System.Drawing.Point(240, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Get Linked Models";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(688, 89);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 1: Edit Project Information";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(464, 35);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(199, 29);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Edit Project Information";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(28, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(380, 18);
            this.label19.TabIndex = 1;
            this.label19.Text = "Enter in the project and team information into the window";
            // 
            // btnSelSourceFile
            // 
            this.btnSelSourceFile.Location = new System.Drawing.Point(628, 21);
            this.btnSelSourceFile.Name = "btnSelSourceFile";
            this.btnSelSourceFile.Size = new System.Drawing.Size(33, 24);
            this.btnSelSourceFile.TabIndex = 6;
            this.btnSelSourceFile.Text = "...";
            this.btnSelSourceFile.UseVisualStyleBackColor = true;
            this.btnSelSourceFile.Click += new System.EventHandler(this.btnSelSourceFile_Click);
            // 
            // worksetComboBox
            // 
            this.worksetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worksetComboBox.FormattingEnabled = true;
            this.worksetComboBox.Location = new System.Drawing.Point(477, 61);
            this.worksetComboBox.Name = "worksetComboBox";
            this.worksetComboBox.Size = new System.Drawing.Size(187, 26);
            this.worksetComboBox.TabIndex = 4;
            this.worksetComboBox.Click += new System.EventHandler(this.worksetComboBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "File source:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 61);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(390, 99);
            this.checkedListBox1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(402, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Workset:";
            // 
            // btnOpen
            // 
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOpen.Enabled = false;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(464, 119);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(199, 32);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Link in checked file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txbFolderPath
            // 
            this.txbFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFolderPath.Location = new System.Drawing.Point(94, 21);
            this.txbFolderPath.Name = "txbFolderPath";
            this.txbFolderPath.Size = new System.Drawing.Size(528, 24);
            this.txbFolderPath.TabIndex = 2;
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
            this.groupBox5.Location = new System.Drawing.Point(12, 117);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(688, 166);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Step 2: Link in Architectural Model";
            // 
            // ModelessForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 355);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGetWorkset;
        private System.Windows.Forms.Button btnSetWorkset;
        private System.Windows.Forms.CheckBox ckbCheckAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSelSourceFile;
        private System.Windows.Forms.ComboBox worksetComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txbFolderPath;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}