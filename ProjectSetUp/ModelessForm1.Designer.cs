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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.txtAng_SP = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtAng_PBP = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtElev_SP = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtElev_PBP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtEW_SP = new System.Windows.Forms.TextBox();
            this.lblNS_PBP = new System.Windows.Forms.TextBox();
            this.txtEW_PBP = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNS_SP = new System.Windows.Forms.TextBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.worksetComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckbCheckAll = new System.Windows.Forms.CheckBox();
            this.btnSetWorkset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.checkedListBox1.Size = new System.Drawing.Size(390, 123);
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
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(474, 85);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(189, 28);
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
            this.btnCancel.Location = new System.Drawing.Point(610, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(458, 540);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(146, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.txtAng_SP);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.txtAng_PBP);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.txtElev_SP);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.txtElev_PBP);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.txtEW_SP);
            this.groupBox3.Controls.Add(this.lblNS_PBP);
            this.groupBox3.Controls.Add(this.txtEW_PBP);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNS_SP);
            this.groupBox3.Location = new System.Drawing.Point(15, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(648, 374);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 2: ";
            this.groupBox3.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Angle to North";
            this.label9.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Elevation";
            this.label3.Click += new System.EventHandler(this.Label1_Click);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(259, 287);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(118, 24);
            this.textBox12.TabIndex = 2;
            this.textBox12.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtAng_SP
            // 
            this.txtAng_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAng_SP.Location = new System.Drawing.Point(259, 128);
            this.txtAng_SP.Name = "txtAng_SP";
            this.txtAng_SP.Size = new System.Drawing.Size(118, 24);
            this.txtAng_SP.TabIndex = 2;
            this.txtAng_SP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(121, 287);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(118, 24);
            this.textBox11.TabIndex = 2;
            this.textBox11.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtAng_PBP
            // 
            this.txtAng_PBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAng_PBP.Location = new System.Drawing.Point(121, 128);
            this.txtAng_PBP.Name = "txtAng_PBP";
            this.txtAng_PBP.Size = new System.Drawing.Size(118, 24);
            this.txtAng_PBP.TabIndex = 2;
            this.txtAng_PBP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(247, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Transfer Linked Model Basepoint";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(259, 257);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(118, 24);
            this.textBox10.TabIndex = 2;
            this.textBox10.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtElev_SP
            // 
            this.txtElev_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElev_SP.Location = new System.Drawing.Point(259, 98);
            this.txtElev_SP.Name = "txtElev_SP";
            this.txtElev_SP.Size = new System.Drawing.Size(118, 24);
            this.txtElev_SP.TabIndex = 2;
            this.txtElev_SP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(121, 257);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(118, 24);
            this.textBox9.TabIndex = 2;
            this.textBox9.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtElev_PBP
            // 
            this.txtElev_PBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElev_PBP.Location = new System.Drawing.Point(121, 98);
            this.txtElev_PBP.Name = "txtElev_PBP";
            this.txtElev_PBP.Size = new System.Drawing.Size(118, 24);
            this.txtElev_PBP.TabIndex = 2;
            this.txtElev_PBP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(268, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Survey Point";
            this.label13.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(115, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Project Base Point";
            this.label12.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Survey Point";
            this.label11.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Project Base Point";
            this.label10.Click += new System.EventHandler(this.Label1_Click);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(259, 227);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(118, 24);
            this.textBox8.TabIndex = 2;
            this.textBox8.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "N/S";
            this.label6.Click += new System.EventHandler(this.Label1_Click);
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(121, 197);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(118, 24);
            this.textBox13.TabIndex = 2;
            this.textBox13.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(121, 227);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(118, 24);
            this.textBox7.TabIndex = 2;
            this.textBox7.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtEW_SP
            // 
            this.txtEW_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEW_SP.Location = new System.Drawing.Point(259, 68);
            this.txtEW_SP.Name = "txtEW_SP";
            this.txtEW_SP.Size = new System.Drawing.Size(118, 24);
            this.txtEW_SP.TabIndex = 2;
            this.txtEW_SP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // lblNS_PBP
            // 
            this.lblNS_PBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNS_PBP.Location = new System.Drawing.Point(121, 38);
            this.lblNS_PBP.Name = "lblNS_PBP";
            this.lblNS_PBP.Size = new System.Drawing.Size(118, 24);
            this.lblNS_PBP.TabIndex = 2;
            this.lblNS_PBP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtEW_PBP
            // 
            this.txtEW_PBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEW_PBP.Location = new System.Drawing.Point(121, 68);
            this.txtEW_PBP.Name = "txtEW_PBP";
            this.txtEW_PBP.Size = new System.Drawing.Size(118, 24);
            this.txtEW_PBP.TabIndex = 2;
            this.txtEW_PBP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(259, 197);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(118, 24);
            this.textBox6.TabIndex = 2;
            this.textBox6.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "E/W";
            this.label8.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txtNS_SP
            // 
            this.txtNS_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS_SP.Location = new System.Drawing.Point(259, 38);
            this.txtNS_SP.Name = "txtNS_SP";
            this.txtNS_SP.Size = new System.Drawing.Size(118, 24);
            this.txtNS_SP.TabIndex = 2;
            this.txtNS_SP.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Location = new System.Drawing.Point(5, 8);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(706, 526);
            this.tab.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
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
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(9, 259);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(669, 204);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Step 3: ";
            this.groupBox6.Visible = false;
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
            this.groupBox5.Location = new System.Drawing.Point(9, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(669, 189);
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
            this.groupBox4.Size = new System.Drawing.Size(669, 52);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coordinate";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.Text = "Project Set Up ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProjectInfoForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox txtAng_SP;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtAng_PBP;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtElev_SP;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox txtElev_PBP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtEW_SP;
        private System.Windows.Forms.TextBox lblNS_PBP;
        private System.Windows.Forms.TextBox txtEW_PBP;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNS_SP;
        private System.Windows.Forms.TextBox txbFolderPath;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSetWorkset;
        private System.Windows.Forms.ComboBox worksetComboBox;
        private System.Windows.Forms.CheckBox ckbCheckAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button2;
    }
}