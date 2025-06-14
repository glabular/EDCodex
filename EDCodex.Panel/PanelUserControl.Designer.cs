﻿namespace EDCodex.Panel
{
    partial class PanelUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_logMsgs = new System.Windows.Forms.RichTextBox();
            this.comboBox_currentRegion = new System.Windows.Forms.ComboBox();
            this.label_currentRegion = new System.Windows.Forms.Label();
            this.listView_codexEntries = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBox_logMsgs
            // 
            this.textBox_logMsgs.Location = new System.Drawing.Point(3, 373);
            this.textBox_logMsgs.Name = "textBox_logMsgs";
            this.textBox_logMsgs.Size = new System.Drawing.Size(495, 224);
            this.textBox_logMsgs.TabIndex = 0;
            this.textBox_logMsgs.Text = "";
            // 
            // comboBox_currentRegion
            // 
            this.comboBox_currentRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_currentRegion.FormattingEnabled = true;
            this.comboBox_currentRegion.Location = new System.Drawing.Point(3, 339);
            this.comboBox_currentRegion.Name = "comboBox_currentRegion";
            this.comboBox_currentRegion.Size = new System.Drawing.Size(272, 28);
            this.comboBox_currentRegion.TabIndex = 1;
            this.comboBox_currentRegion.SelectedIndexChanged += new System.EventHandler(this.comboBox_currentRegion_SelectedIndexChanged);
            // 
            // label_currentRegion
            // 
            this.label_currentRegion.AutoSize = true;
            this.label_currentRegion.Location = new System.Drawing.Point(4, 313);
            this.label_currentRegion.Name = "label_currentRegion";
            this.label_currentRegion.Size = new System.Drawing.Size(110, 20);
            this.label_currentRegion.TabIndex = 2;
            this.label_currentRegion.Text = "Current region";
            // 
            // listView_codexEntries
            // 
            this.listView_codexEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_codexEntries.HideSelection = false;
            this.listView_codexEntries.Location = new System.Drawing.Point(504, 3);
            this.listView_codexEntries.MultiSelect = false;
            this.listView_codexEntries.Name = "listView_codexEntries";
            this.listView_codexEntries.Size = new System.Drawing.Size(379, 594);
            this.listView_codexEntries.TabIndex = 3;
            this.listView_codexEntries.UseCompatibleStateImageBehavior = false;
            this.listView_codexEntries.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 140;
            // 
            // PanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_codexEntries);
            this.Controls.Add(this.label_currentRegion);
            this.Controls.Add(this.comboBox_currentRegion);
            this.Controls.Add(this.textBox_logMsgs);
            this.Name = "PanelUserControl";
            this.Size = new System.Drawing.Size(886, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox_logMsgs;
        private System.Windows.Forms.ComboBox comboBox_currentRegion;
        private System.Windows.Forms.Label label_currentRegion;
        private System.Windows.Forms.ListView listView_codexEntries;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
