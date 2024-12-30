namespace FormsApp1
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
            components = new System.ComponentModel.Container();
            Email = new Label();
            label2 = new Label();
            emailbox = new MaskedTextBox();
            passwordbox = new TextBox();
            buttonsubmit = new Button();
            buttoncancel = new Button();
            labelerror = new Label();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            SuspendLayout();
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(217, 63);
            Email.Name = "Email";
            Email.Size = new Size(46, 20);
            Email.TabIndex = 0;
            Email.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 114);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // emailbox
            // 
            emailbox.Location = new Point(285, 56);
            emailbox.Name = "emailbox";
            emailbox.Size = new Size(296, 27);
            emailbox.TabIndex = 2;
            // 
            // passwordbox
            // 
            passwordbox.Location = new Point(285, 107);
            passwordbox.Name = "passwordbox";
            passwordbox.Size = new Size(296, 27);
            passwordbox.TabIndex = 3;
            // 
            // buttonsubmit
            // 
            buttonsubmit.Location = new Point(337, 154);
            buttonsubmit.Name = "buttonsubmit";
            buttonsubmit.Size = new Size(94, 29);
            buttonsubmit.TabIndex = 4;
            buttonsubmit.Text = "Submit";
            buttonsubmit.UseVisualStyleBackColor = true;
            // 
            // buttoncancel
            // 
            buttoncancel.Location = new Point(217, 154);
            buttoncancel.Name = "buttoncancel";
            buttoncancel.Size = new Size(94, 29);
            buttoncancel.TabIndex = 5;
            buttoncancel.Text = "Cancel";
            buttoncancel.UseVisualStyleBackColor = true;
            // 
            // labelerror
            // 
            labelerror.AutoSize = true;
            labelerror.Location = new Point(285, 218);
            labelerror.Name = "labelerror";
            labelerror.Size = new Size(0, 20);
            labelerror.TabIndex = 6;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 328);
            Controls.Add(labelerror);
            Controls.Add(buttoncancel);
            Controls.Add(buttonsubmit);
            Controls.Add(passwordbox);
            Controls.Add(emailbox);
            Controls.Add(label2);
            Controls.Add(Email);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Email;
        private Label label2;
        private MaskedTextBox emailbox;
        private TextBox passwordbox;
        private Button buttonsubmit;
        private Button buttoncancel;
        private Label labelerror;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
    }
}
