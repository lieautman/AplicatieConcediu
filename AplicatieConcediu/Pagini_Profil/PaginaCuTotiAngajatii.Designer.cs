﻿namespace AplicatieConcediu.Pagini_Profil
{
    partial class PaginaCuTotiAngajatii
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.treeView4 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(297, 182);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(160, 118);
            this.treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(297, 55);
            this.treeView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(160, 118);
            this.treeView2.TabIndex = 1;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // treeView3
            // 
            this.treeView3.Location = new System.Drawing.Point(569, 55);
            this.treeView3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(160, 118);
            this.treeView3.TabIndex = 2;
            this.treeView3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterSelect);
            // 
            // treeView4
            // 
            this.treeView4.Location = new System.Drawing.Point(845, 55);
            this.treeView4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView4.Name = "treeView4";
            this.treeView4.Size = new System.Drawing.Size(160, 118);
            this.treeView4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Vizualizare toti angajatii";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PaginaCuTotiAngajatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView4);
            this.Controls.Add(this.treeView3);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PaginaCuTotiAngajatii";
            this.Text = "PaginaCuTotiAngajatii";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.TreeView treeView4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}