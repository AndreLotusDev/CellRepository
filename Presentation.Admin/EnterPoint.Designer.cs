
namespace Presentation.Admin
{
    partial class EnterPoint
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gpbLogin = new System.Windows.Forms.GroupBox();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.chckLogin = new System.Windows.Forms.CheckBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.gpbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(135, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(91, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Digite seu email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(65, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(65, 173);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(241, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(135, 155);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(93, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Digite sua senha";
            // 
            // gpbLogin
            // 
            this.gpbLogin.Controls.Add(this.btnLoginRegister);
            this.gpbLogin.Controls.Add(this.chckLogin);
            this.gpbLogin.Controls.Add(this.lblUser);
            this.gpbLogin.Controls.Add(this.txtUser);
            this.gpbLogin.Controls.Add(this.lblEmail);
            this.gpbLogin.Controls.Add(this.txtPassword);
            this.gpbLogin.Controls.Add(this.txtEmail);
            this.gpbLogin.Controls.Add(this.lblPassword);
            this.gpbLogin.Location = new System.Drawing.Point(12, 12);
            this.gpbLogin.Name = "gpbLogin";
            this.gpbLogin.Size = new System.Drawing.Size(361, 337);
            this.gpbLogin.TabIndex = 4;
            this.gpbLogin.TabStop = false;
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Location = new System.Drawing.Point(145, 260);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(75, 23);
            this.btnLoginRegister.TabIndex = 7;
            this.btnLoginRegister.Text = "Login";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);
            // 
            // chckLogin
            // 
            this.chckLogin.AutoSize = true;
            this.chckLogin.Location = new System.Drawing.Point(164, 235);
            this.chckLogin.Name = "chckLogin";
            this.chckLogin.Size = new System.Drawing.Size(56, 19);
            this.chckLogin.TabIndex = 6;
            this.chckLogin.Text = "Logar";
            this.chckLogin.UseVisualStyleBackColor = true;
            this.chckLogin.CheckedChanged += new System.EventHandler(this.chckLogin_CheckedChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(135, 45);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(101, 15);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Digite seu usuário";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(65, 63);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 23);
            this.txtUser.TabIndex = 5;
            // 
            // EnterPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.gpbLogin);
            this.Name = "EnterPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter point";
            this.gpbLogin.ResumeLayout(false);
            this.gpbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox gpbLogin;
        private System.Windows.Forms.CheckBox chckLogin;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnLoginRegister;
    }
}

