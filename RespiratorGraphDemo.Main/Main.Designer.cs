﻿namespace RespiratorGraphDemo.Main
{
    partial class Main
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart2 = new LiveCharts.Wpf.CartesianChart();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart3 = new LiveCharts.Wpf.CartesianChart();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(12, 12);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(730, 230);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(12, 248);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(730, 230);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.cartesianChart2;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(12, 487);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(730, 230);
            this.elementHost3.TabIndex = 2;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.cartesianChart3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Name = "Main";
            this.Text = "Fan Graph Demo";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private LiveCharts.Wpf.CartesianChart cartesianChart2;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private LiveCharts.Wpf.CartesianChart cartesianChart3;
    }
}

