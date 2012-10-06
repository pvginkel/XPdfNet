namespace PDFViewer
{
    partial class frmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassword));
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.txtOwnPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserPwd
            // 
            resources.ApplyResources(this.txtUserPwd, "txtUserPwd");
            this.txtUserPwd.Name = "txtUserPwd";
            // 
            // txtOwnPwd
            // 
            resources.ApplyResources(this.txtOwnPwd, "txtOwnPwd");
            this.txtOwnPwd.Name = "txtOwnPwd";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmdAccept
            // 
            resources.ApplyResources(this.cmdAccept, "cmdAccept");
            this.cmdAccept.Image = global::PDFViewer.Properties.Resources.button_ok;
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmCancel
            // 
            resources.ApplyResources(this.cmCancel, "cmCancel");
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Image = global::PDFViewer.Properties.Resources.cancel_16;
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // frmPassword
            // 
            this.AcceptButton = this.cmdAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ControlBox = false;
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOwnPwd);
            this.Controls.Add(this.txtUserPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.TextBox txtOwnPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmCancel;
    }
}