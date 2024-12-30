namespace Login
{
    partial class Form1
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
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.labelemail = new System.Windows.Forms.Label();
            this.labelpassword = new System.Windows.Forms.Label();
            this.labelerror = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(319, 43);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(213, 22);
            this.txtemail.TabIndex = 0;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(319, 94);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(213, 22);
            this.txtpassword.TabIndex = 1;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(329, 188);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btncancle
            // 
            this.btncancle.Location = new System.Drawing.Point(476, 188);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(75, 23);
            this.btncancle.TabIndex = 3;
            this.btncancle.Text = "cancle";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click_1);
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.Location = new System.Drawing.Point(209, 49);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(40, 16);
            this.labelemail.TabIndex = 4;
            this.labelemail.Text = "email";
            // 
            // labelpassword
            // 
            this.labelpassword.AutoSize = true;
            this.labelpassword.Location = new System.Drawing.Point(209, 100);
            this.labelpassword.Name = "labelpassword";
            this.labelpassword.Size = new System.Drawing.Size(67, 16);
            this.labelpassword.TabIndex = 5;
            this.labelpassword.Text = "Password";
            // 
            // labelerror
            // 
            this.labelerror.AutoSize = true;
            this.labelerror.Location = new System.Drawing.Point(435, 326);
            this.labelerror.Name = "labelerror";
            this.labelerror.Size = new System.Drawing.Size(0, 16);
            this.labelerror.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelerror);
            this.Controls.Add(this.labelpassword);
            this.Controls.Add(this.labelemail);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtemail);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.Label labelpassword;
        private System.Windows.Forms.Label labelerror;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}

