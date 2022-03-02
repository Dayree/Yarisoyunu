
namespace Yaris.Desktop
{
    partial class SkorGoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkorGoster));
            this.txtSkor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtSkor
            // 
            this.txtSkor.Location = new System.Drawing.Point(12, 12);
            this.txtSkor.Name = "txtSkor";
            this.txtSkor.Size = new System.Drawing.Size(386, 245);
            this.txtSkor.TabIndex = 0;
            this.txtSkor.Text = "";
            // 
            // SkorGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 269);
            this.Controls.Add(this.txtSkor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SkorGoster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skor Tablosu";
            this.Load += new System.EventHandler(this.SkorGoster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSkor;
    }
}