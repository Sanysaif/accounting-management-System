namespace Accounting_Management_System
{
    partial class Login
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
            this.button13 = new System.Windows.Forms.Button();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.usr_txt = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.usernm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(170, 253);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(166, 48);
            this.button13.TabIndex = 9;
            this.button13.Text = "Login";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(301, 143);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(177, 20);
            this.pass_txt.TabIndex = 8;
            // 
            // usr_txt
            // 
            this.usr_txt.Location = new System.Drawing.Point(301, 74);
            this.usr_txt.Name = "usr_txt";
            this.usr_txt.Size = new System.Drawing.Size(177, 20);
            this.usr_txt.TabIndex = 7;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(52, 131);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(159, 37);
            this.password.TabIndex = 6;
            this.password.Text = "Password :";
            // 
            // usernm
            // 
            this.usernm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernm.Location = new System.Drawing.Point(52, 62);
            this.usernm.Name = "usernm";
            this.usernm.Size = new System.Drawing.Size(159, 36);
            this.usernm.TabIndex = 5;
            this.usernm.Text = "Username :";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 363);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.usr_txt);
            this.Controls.Add(this.password);
            this.Controls.Add(this.usernm);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.TextBox usr_txt;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label usernm;
    }
}