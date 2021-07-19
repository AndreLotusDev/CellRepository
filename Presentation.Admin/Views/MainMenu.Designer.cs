
namespace Presentation.Admin.Views
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnRegisterNewPhone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegisterNewPhone
            // 
            this.btnRegisterNewPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterNewPhone.Image")));
            this.btnRegisterNewPhone.Location = new System.Drawing.Point(12, 12);
            this.btnRegisterNewPhone.Name = "btnRegisterNewPhone";
            this.btnRegisterNewPhone.Size = new System.Drawing.Size(776, 426);
            this.btnRegisterNewPhone.TabIndex = 0;
            this.btnRegisterNewPhone.UseVisualStyleBackColor = true;
            this.btnRegisterNewPhone.Click += new System.EventHandler(this.btnRegisterNewPhone_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegisterNewPhone);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterNewPhone;
    }
}