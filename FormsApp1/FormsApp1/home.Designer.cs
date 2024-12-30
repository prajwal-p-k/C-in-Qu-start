namespace FormsApp1
{
    partial class home
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
            lblname = new Button();
            SuspendLayout();
            // 
            // lblname
            // 
            lblname.Location = new Point(427, 64);
            lblname.Name = "lblname";
            lblname.Size = new Size(94, 29);
            lblname.TabIndex = 0;
            lblname.Text = "button1";
            lblname.UseVisualStyleBackColor = true;
            // 
            // home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblname);
            Name = "home";
            Text = "home";
            Load += home_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button lblname;
    }
}