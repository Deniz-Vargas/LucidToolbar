//
// (C) Copyright 2003-2017 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE. AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.


namespace LucidToolbar.ProjectSetUp.ViewTemplate
{
    partial class AllViewsForm
    {
        private ViewsMgr m_data;
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
            this.allViewsGroupBox = new System.Windows.Forms.GroupBox();
            this.allViewsTreeView = new System.Windows.Forms.TreeView();
            this.GenerateSheetGroupBox = new System.Windows.Forms.GroupBox();
            this.titleBlocksListBox = new System.Windows.Forms.ListBox();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.sheetNameTextBox = new System.Windows.Forms.TextBox();
            this.titleBlocksLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.oKButton = new System.Windows.Forms.Button();
            this.allViewsGroupBox.SuspendLayout();
            this.GenerateSheetGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // allViewsGroupBox
            // 
            this.allViewsGroupBox.Controls.Add(this.allViewsTreeView);
            this.allViewsGroupBox.Location = new System.Drawing.Point(13, 26);
            this.allViewsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.allViewsGroupBox.Name = "allViewsGroupBox";
            this.allViewsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.allViewsGroupBox.Size = new System.Drawing.Size(283, 298);
            this.allViewsGroupBox.TabIndex = 2;
            this.allViewsGroupBox.TabStop = false;
            this.allViewsGroupBox.Text = "All Views";
            // 
            // allViewsTreeView
            // 
            this.allViewsTreeView.CheckBoxes = true;
            this.allViewsTreeView.Location = new System.Drawing.Point(8, 23);
            this.allViewsTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.allViewsTreeView.Name = "allViewsTreeView";
            this.allViewsTreeView.Size = new System.Drawing.Size(265, 266);
            this.allViewsTreeView.TabIndex = 0;
            // 
            // GenerateSheetGroupBox
            // 
            this.GenerateSheetGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.GenerateSheetGroupBox.Controls.Add(this.titleBlocksListBox);
            this.GenerateSheetGroupBox.Controls.Add(this.sheetNameLabel);
            this.GenerateSheetGroupBox.Controls.Add(this.sheetNameTextBox);
            this.GenerateSheetGroupBox.Controls.Add(this.titleBlocksLabel);
            this.GenerateSheetGroupBox.Controls.Add(this.cancelButton);
            this.GenerateSheetGroupBox.Controls.Add(this.oKButton);
            this.GenerateSheetGroupBox.Location = new System.Drawing.Point(304, 35);
            this.GenerateSheetGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateSheetGroupBox.Name = "GenerateSheetGroupBox";
            this.GenerateSheetGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GenerateSheetGroupBox.Size = new System.Drawing.Size(425, 289);
            this.GenerateSheetGroupBox.TabIndex = 3;
            this.GenerateSheetGroupBox.TabStop = false;
            this.GenerateSheetGroupBox.Text = "Apply Templates";
            // 
            // titleBlocksListBox
            // 
            this.titleBlocksListBox.FormattingEnabled = true;
            this.titleBlocksListBox.ItemHeight = 16;
            this.titleBlocksListBox.Location = new System.Drawing.Point(12, 38);
            this.titleBlocksListBox.Margin = new System.Windows.Forms.Padding(4);
            this.titleBlocksListBox.Name = "titleBlocksListBox";
            this.titleBlocksListBox.Size = new System.Drawing.Size(387, 148);
            this.titleBlocksListBox.Sorted = true;
            this.titleBlocksListBox.TabIndex = 6;
            this.titleBlocksListBox.SelectedIndexChanged += new System.EventHandler(this.titleBlocksListBox_SelectedIndexChanged);
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.Location = new System.Drawing.Point(8, 209);
            this.sheetNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(108, 17);
            this.sheetNameLabel.TabIndex = 5;
            this.sheetNameLabel.Text = "Template Name";
            // 
            // sheetNameTextBox
            // 
            this.sheetNameTextBox.Location = new System.Drawing.Point(133, 206);
            this.sheetNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sheetNameTextBox.Name = "sheetNameTextBox";
            this.sheetNameTextBox.Size = new System.Drawing.Size(266, 22);
            this.sheetNameTextBox.TabIndex = 2;
            this.sheetNameTextBox.Text = "Unname";
            // 
            // titleBlocksLabel
            // 
            this.titleBlocksLabel.AutoSize = true;
            this.titleBlocksLabel.Location = new System.Drawing.Point(13, 19);
            this.titleBlocksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleBlocksLabel.Name = "titleBlocksLabel";
            this.titleBlocksLabel.Size = new System.Drawing.Size(103, 17);
            this.titleBlocksLabel.TabIndex = 3;
            this.titleBlocksLabel.Text = "ViewTemplates";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(299, 252);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // oKButton
            // 
            this.oKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.oKButton.Location = new System.Drawing.Point(186, 252);
            this.oKButton.Margin = new System.Windows.Forms.Padding(4);
            this.oKButton.Name = "oKButton";
            this.oKButton.Size = new System.Drawing.Size(100, 28);
            this.oKButton.TabIndex = 3;
            this.oKButton.Text = "&OK";
            this.oKButton.UseVisualStyleBackColor = true;
            this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
            // 
            // AllViewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 352);
            this.Controls.Add(this.GenerateSheetGroupBox);
            this.Controls.Add(this.allViewsGroupBox);
            this.Name = "AllViewsForm";
            this.Text = "AllViewsForm";
            this.Load += new System.EventHandler(this.AllViewsForm_Load);
            this.allViewsGroupBox.ResumeLayout(false);
            this.GenerateSheetGroupBox.ResumeLayout(false);
            this.GenerateSheetGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox allViewsGroupBox;
        private System.Windows.Forms.TreeView allViewsTreeView;
        private System.Windows.Forms.GroupBox GenerateSheetGroupBox;
        private System.Windows.Forms.ListBox titleBlocksListBox;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.TextBox sheetNameTextBox;
        private System.Windows.Forms.Label titleBlocksLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button oKButton;
    }
}