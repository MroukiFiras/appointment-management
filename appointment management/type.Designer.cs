namespace appointment_management
{
    partial class type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(type));
            this.panelSec = new System.Windows.Forms.Panel();
            this.panelDoctor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelSec
            // 
            this.panelSec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSec.BackgroundImage")));
            this.panelSec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSec.CausesValidation = false;
            this.panelSec.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSec.Location = new System.Drawing.Point(0, 0);
            this.panelSec.Name = "panelSec";
            this.panelSec.Size = new System.Drawing.Size(557, 592);
            this.panelSec.TabIndex = 0;
            this.panelSec.Click += new System.EventHandler(this.panelSec_Click);
            // 
            // panelDoctor
            // 
            this.panelDoctor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDoctor.BackgroundImage")));
            this.panelDoctor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelDoctor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDoctor.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDoctor.Location = new System.Drawing.Point(535, 0);
            this.panelDoctor.Name = "panelDoctor";
            this.panelDoctor.Size = new System.Drawing.Size(516, 592);
            this.panelDoctor.TabIndex = 1;
            this.panelDoctor.Click += new System.EventHandler(this.panelDoctor_Click);
            // 
            // type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 592);
            this.Controls.Add(this.panelDoctor);
            this.Controls.Add(this.panelSec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSec;
        private System.Windows.Forms.Panel panelDoctor;
    }
}