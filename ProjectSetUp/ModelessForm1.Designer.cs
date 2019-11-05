namespace LucidToolbar
{
    partial class ModelessForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSelSourceFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.worksetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNS_PBP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.txtAng_SP = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtAng_PBP = new System.Windows.Forms.TextBox();
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
            this.txtEW_PBP = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNS_SP = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnSelSourceFile);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(33, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Select Revit template:";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(812, 12);
            this.progressBar1.TabIndex = 9;
            // 
            // btnSelSourceFile
            // 
            this.btnSelSourceFile.Location = new System.Drawing.Point(834, 21);
            this.btnSelSourceFile.Name = "btnSelSourceFile";
            this.btnSelSourceFile.Size = new System.Drawing.Size(148, 23);
            this.btnSelSourceFile.TabIndex = 6;
            this.btnSelSourceFile.Text = "Select File";
            this.btnSelSourceFile.UseVisualStyleBackColor = true;
            this.btnSelSourceFile.Click += new System.EventHandler(this.btnSelSourceFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(811, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.worksetComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(33, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1001, 173);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 3: ";
            this.groupBox2.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // worksetComboBox
            // 
            this.worksetComboBox.FormattingEnabled = true;
            this.worksetComboBox.Location = new System.Drawing.Point(121, 39);
            this.worksetComboBox.Name = "worksetComboBox";
            this.worksetComboBox.Size = new System.Drawing.Size(256, 24);
            this.worksetComboBox.TabIndex = 4;
            this.worksetComboBox.DropDown += new System.EventHandler(this.worksetComboBox_DropDown);
            this.worksetComboBox.SelectedIndexChanged += new System.EventHandler(this.WorksetComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Workset ";
            this.label2.Click += new System.EventHandler(this.Label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Revit files (*.rvt)|*.rvt|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNS_PBP);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.txtAng_SP);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.txtAng_PBP);
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
            this.groupBox3.Controls.Add(this.txtEW_PBP);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNS_SP);
            this.groupBox3.Location = new System.Drawing.Point(33, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1001, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 2: ";
            this.groupBox3.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // lblNS_PBP
            // 
            this.lblNS_PBP.AutoSize = true;
            this.lblNS_PBP.Location = new System.Drawing.Point(118, 43);
            this.lblNS_PBP.Name = "lblNS_PBP";
            this.lblNS_PBP.Size = new System.Drawing.Size(54, 17);
            this.lblNS_PBP.TabIndex = 3;
            this.lblNS_PBP.Text = "label12";
            this.lblNS_PBP.Click += new System.EventHandler(this.label12_Click);
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
            this.textBox12.Location = new System.Drawing.Point(717, 128);
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
            this.textBox11.Location = new System.Drawing.Point(579, 128);
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
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(717, 98);
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
            this.textBox9.Location = new System.Drawing.Point(579, 98);
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
            this.label13.Location = new System.Drawing.Point(726, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Survey Point";
            this.label13.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(573, 18);
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
            this.textBox8.Location = new System.Drawing.Point(717, 68);
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
            this.textBox13.Location = new System.Drawing.Point(579, 38);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(118, 24);
            this.textBox13.TabIndex = 2;
            this.textBox13.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(579, 68);
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
            this.textBox6.Location = new System.Drawing.Point(717, 38);
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
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(834, 46);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(148, 23);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "OpenDetached";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ModelessForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 584);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModelessForm1";
            this.Text = "Project Set Up ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProjectInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelSourceFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtElev_PBP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEW_PBP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAng_SP;
        private System.Windows.Forms.TextBox txtAng_PBP;
        private System.Windows.Forms.TextBox txtElev_SP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEW_SP;
        private System.Windows.Forms.TextBox txtNS_SP;
        private System.Windows.Forms.Label lblNS_PBP;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox worksetComboBox;
        private System.Windows.Forms.Button btnOpen;
    }
}