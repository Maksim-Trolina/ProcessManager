
namespace ProcessManagerUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listProcesses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listProcesses
            // 
            this.listProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listProcesses.FormattingEnabled = true;
            this.listProcesses.HorizontalScrollbar = true;
            this.listProcesses.ItemHeight = 15;
            this.listProcesses.Location = new System.Drawing.Point(0, 0);
            this.listProcesses.Name = "listProcesses";
            this.listProcesses.ScrollAlwaysVisible = true;
            this.listProcesses.Size = new System.Drawing.Size(800, 450);
            this.listProcesses.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listProcesses;
    }
}

