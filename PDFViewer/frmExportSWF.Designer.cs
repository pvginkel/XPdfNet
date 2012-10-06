namespace PDFViewer
{
    partial class frmExportSWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportSWF));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmdChoseFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optRange = new System.Windows.Forms.RadioButton();
            this.txtPagesRange = new System.Windows.Forms.TextBox();
            this.optPrintCurrent = new System.Windows.Forms.RadioButton();
            this.udTopage = new System.Windows.Forms.NumericUpDown();
            this.udFromPage = new System.Windows.Forms.NumericUpDown();
            this.optFromPage = new System.Windows.Forms.RadioButton();
            this.optPrintAll = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLoaderSWF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtViewerSWF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.udQuality = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.udResolution = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optFullBitmap = new System.Windows.Forms.RadioButton();
            this.optPolyToBitmap = new System.Windows.Forms.RadioButton();
            this.cmdToDefault = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboFlashVersion = new System.Windows.Forms.ComboBox();
            this.colorPicker1 = new PJLControls.ColorPicker();
            this.chkStoreFonts = new System.Windows.Forms.CheckBox();
            this.chkFontsToShapes = new System.Windows.Forms.CheckBox();
            this.chkAddPageStop = new System.Windows.Forms.CheckBox();
            this.chkEnableLinks = new System.Windows.Forms.CheckBox();
            this.chkIgnoreDrawOrder = new System.Windows.Forms.CheckBox();
            this.chkFlattenSWF = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkOpenInNewWindow = new System.Windows.Forms.CheckBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTopage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFromPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udResolution)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // txtFileName
            // 
            this.txtFileName.AccessibleDescription = null;
            this.txtFileName.AccessibleName = null;
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.BackgroundImage = null;
            this.txtFileName.Font = null;
            this.txtFileName.Name = "txtFileName";
            // 
            // cmdChoseFile
            // 
            this.cmdChoseFile.AccessibleDescription = null;
            this.cmdChoseFile.AccessibleName = null;
            resources.ApplyResources(this.cmdChoseFile, "cmdChoseFile");
            this.cmdChoseFile.BackgroundImage = null;
            this.cmdChoseFile.Font = null;
            this.cmdChoseFile.Name = "cmdChoseFile";
            this.cmdChoseFile.UseVisualStyleBackColor = true;
            this.cmdChoseFile.Click += new System.EventHandler(this.cmdChoseFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.txtPagesRange);
            this.groupBox1.Controls.Add(this.optPrintCurrent);
            this.groupBox1.Controls.Add(this.udTopage);
            this.groupBox1.Controls.Add(this.udFromPage);
            this.groupBox1.Controls.Add(this.optFromPage);
            this.groupBox1.Controls.Add(this.optPrintAll);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.optRange);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // optRange
            // 
            this.optRange.AccessibleDescription = null;
            this.optRange.AccessibleName = null;
            resources.ApplyResources(this.optRange, "optRange");
            this.optRange.BackgroundImage = null;
            this.optRange.Font = null;
            this.optRange.Name = "optRange";
            this.optRange.TabStop = true;
            this.optRange.UseVisualStyleBackColor = true;
            // 
            // txtPagesRange
            // 
            this.txtPagesRange.AccessibleDescription = null;
            this.txtPagesRange.AccessibleName = null;
            resources.ApplyResources(this.txtPagesRange, "txtPagesRange");
            this.txtPagesRange.BackgroundImage = null;
            this.txtPagesRange.Font = null;
            this.txtPagesRange.Name = "txtPagesRange";
            // 
            // optPrintCurrent
            // 
            this.optPrintCurrent.AccessibleDescription = null;
            this.optPrintCurrent.AccessibleName = null;
            resources.ApplyResources(this.optPrintCurrent, "optPrintCurrent");
            this.optPrintCurrent.BackgroundImage = null;
            this.optPrintCurrent.Font = null;
            this.optPrintCurrent.Name = "optPrintCurrent";
            this.optPrintCurrent.UseVisualStyleBackColor = true;
            // 
            // udTopage
            // 
            this.udTopage.AccessibleDescription = null;
            this.udTopage.AccessibleName = null;
            resources.ApplyResources(this.udTopage, "udTopage");
            this.udTopage.Font = null;
            this.udTopage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTopage.Name = "udTopage";
            this.udTopage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // udFromPage
            // 
            this.udFromPage.AccessibleDescription = null;
            this.udFromPage.AccessibleName = null;
            resources.ApplyResources(this.udFromPage, "udFromPage");
            this.udFromPage.Font = null;
            this.udFromPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFromPage.Name = "udFromPage";
            this.udFromPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // optFromPage
            // 
            this.optFromPage.AccessibleDescription = null;
            this.optFromPage.AccessibleName = null;
            resources.ApplyResources(this.optFromPage, "optFromPage");
            this.optFromPage.BackgroundImage = null;
            this.optFromPage.Font = null;
            this.optFromPage.Name = "optFromPage";
            this.optFromPage.UseVisualStyleBackColor = true;
            this.optFromPage.CheckedChanged += new System.EventHandler(this.optFromPage_CheckedChanged);
            // 
            // optPrintAll
            // 
            this.optPrintAll.AccessibleDescription = null;
            this.optPrintAll.AccessibleName = null;
            resources.ApplyResources(this.optPrintAll, "optPrintAll");
            this.optPrintAll.BackgroundImage = null;
            this.optPrintAll.Checked = true;
            this.optPrintAll.Font = null;
            this.optPrintAll.Name = "optPrintAll";
            this.optPrintAll.TabStop = true;
            this.optPrintAll.UseVisualStyleBackColor = true;
            this.optPrintAll.CheckedChanged += new System.EventHandler(this.optPrintAll_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Font = null;
            this.label7.Name = "label7";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // pgBar
            // 
            this.pgBar.AccessibleDescription = null;
            this.pgBar.AccessibleName = null;
            resources.ApplyResources(this.pgBar, "pgBar");
            this.pgBar.BackgroundImage = null;
            this.pgBar.Font = null;
            this.pgBar.Name = "pgBar";
            // 
            // dlgSave
            // 
            resources.ApplyResources(this.dlgSave, "dlgSave");
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLoaderSWF
            // 
            this.txtLoaderSWF.AccessibleDescription = null;
            this.txtLoaderSWF.AccessibleName = null;
            resources.ApplyResources(this.txtLoaderSWF, "txtLoaderSWF");
            this.txtLoaderSWF.BackgroundImage = null;
            this.txtLoaderSWF.Font = null;
            this.txtLoaderSWF.Name = "txtLoaderSWF";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = null;
            this.button2.Font = null;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtViewerSWF
            // 
            this.txtViewerSWF.AccessibleDescription = null;
            this.txtViewerSWF.AccessibleName = null;
            resources.ApplyResources(this.txtViewerSWF, "txtViewerSWF");
            this.txtViewerSWF.BackgroundImage = null;
            this.txtViewerSWF.Font = null;
            this.txtViewerSWF.Name = "txtViewerSWF";
            // 
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Font = null;
            this.label8.Name = "label8";
            // 
            // udQuality
            // 
            this.udQuality.AccessibleDescription = null;
            this.udQuality.AccessibleName = null;
            resources.ApplyResources(this.udQuality, "udQuality");
            this.udQuality.Font = null;
            this.udQuality.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.udQuality.Name = "udQuality";
            this.udQuality.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // udResolution
            // 
            this.udResolution.AccessibleDescription = null;
            this.udResolution.AccessibleName = null;
            resources.ApplyResources(this.udResolution, "udResolution");
            this.udResolution.Font = null;
            this.udResolution.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udResolution.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.udResolution.Name = "udResolution";
            this.udResolution.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.optFullBitmap);
            this.groupBox2.Controls.Add(this.optPolyToBitmap);
            this.groupBox2.Controls.Add(this.udQuality);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.udResolution);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // optFullBitmap
            // 
            this.optFullBitmap.AccessibleDescription = null;
            this.optFullBitmap.AccessibleName = null;
            resources.ApplyResources(this.optFullBitmap, "optFullBitmap");
            this.optFullBitmap.BackgroundImage = null;
            this.optFullBitmap.Font = null;
            this.optFullBitmap.Name = "optFullBitmap";
            this.optFullBitmap.TabStop = true;
            this.optFullBitmap.UseVisualStyleBackColor = true;
            // 
            // optPolyToBitmap
            // 
            this.optPolyToBitmap.AccessibleDescription = null;
            this.optPolyToBitmap.AccessibleName = null;
            resources.ApplyResources(this.optPolyToBitmap, "optPolyToBitmap");
            this.optPolyToBitmap.BackgroundImage = null;
            this.optPolyToBitmap.Font = null;
            this.optPolyToBitmap.Name = "optPolyToBitmap";
            this.optPolyToBitmap.TabStop = true;
            this.optPolyToBitmap.UseVisualStyleBackColor = true;
            // 
            // cmdToDefault
            // 
            this.cmdToDefault.AccessibleDescription = null;
            this.cmdToDefault.AccessibleName = null;
            resources.ApplyResources(this.cmdToDefault, "cmdToDefault");
            this.cmdToDefault.BackgroundImage = null;
            this.cmdToDefault.Font = null;
            this.cmdToDefault.Image = global::PDFViewer.Properties.Resources.button_ok;
            this.cmdToDefault.Name = "cmdToDefault";
            this.cmdToDefault.UseVisualStyleBackColor = true;
            this.cmdToDefault.Click += new System.EventHandler(this.cmdToDefault_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = null;
            this.groupBox3.AccessibleName = null;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackgroundImage = null;
            this.groupBox3.Controls.Add(this.cboFlashVersion);
            this.groupBox3.Controls.Add(this.colorPicker1);
            this.groupBox3.Controls.Add(this.chkStoreFonts);
            this.groupBox3.Controls.Add(this.chkFontsToShapes);
            this.groupBox3.Controls.Add(this.chkAddPageStop);
            this.groupBox3.Controls.Add(this.chkEnableLinks);
            this.groupBox3.Controls.Add(this.chkIgnoreDrawOrder);
            this.groupBox3.Controls.Add(this.chkFlattenSWF);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.chkOpenInNewWindow);
            this.groupBox3.Font = null;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cboFlashVersion
            // 
            this.cboFlashVersion.AccessibleDescription = null;
            this.cboFlashVersion.AccessibleName = null;
            resources.ApplyResources(this.cboFlashVersion, "cboFlashVersion");
            this.cboFlashVersion.BackgroundImage = null;
            this.cboFlashVersion.Font = null;
            this.cboFlashVersion.FormattingEnabled = true;
            this.cboFlashVersion.Items.AddRange(new object[] {
            resources.GetString("cboFlashVersion.Items"),
            resources.GetString("cboFlashVersion.Items1"),
            resources.GetString("cboFlashVersion.Items2"),
            resources.GetString("cboFlashVersion.Items3"),
            resources.GetString("cboFlashVersion.Items4")});
            this.cboFlashVersion.Name = "cboFlashVersion";
            // 
            // colorPicker1
            // 
            this.colorPicker1.AccessibleDescription = null;
            this.colorPicker1.AccessibleName = null;
            resources.ApplyResources(this.colorPicker1, "colorPicker1");
            this.colorPicker1.BackgroundImage = null;
            this.colorPicker1.Color = System.Drawing.Color.Blue;
            this.colorPicker1.DisplayColorName = true;
            this.colorPicker1.Font = null;
            this.colorPicker1.Name = "colorPicker1";
            // 
            // chkStoreFonts
            // 
            this.chkStoreFonts.AccessibleDescription = null;
            this.chkStoreFonts.AccessibleName = null;
            resources.ApplyResources(this.chkStoreFonts, "chkStoreFonts");
            this.chkStoreFonts.BackgroundImage = null;
            this.chkStoreFonts.Font = null;
            this.chkStoreFonts.Name = "chkStoreFonts";
            this.chkStoreFonts.UseVisualStyleBackColor = true;
            // 
            // chkFontsToShapes
            // 
            this.chkFontsToShapes.AccessibleDescription = null;
            this.chkFontsToShapes.AccessibleName = null;
            resources.ApplyResources(this.chkFontsToShapes, "chkFontsToShapes");
            this.chkFontsToShapes.BackgroundImage = null;
            this.chkFontsToShapes.Font = null;
            this.chkFontsToShapes.Name = "chkFontsToShapes";
            this.chkFontsToShapes.UseVisualStyleBackColor = true;
            // 
            // chkAddPageStop
            // 
            this.chkAddPageStop.AccessibleDescription = null;
            this.chkAddPageStop.AccessibleName = null;
            resources.ApplyResources(this.chkAddPageStop, "chkAddPageStop");
            this.chkAddPageStop.BackgroundImage = null;
            this.chkAddPageStop.Font = null;
            this.chkAddPageStop.Name = "chkAddPageStop";
            this.chkAddPageStop.UseVisualStyleBackColor = true;
            // 
            // chkEnableLinks
            // 
            this.chkEnableLinks.AccessibleDescription = null;
            this.chkEnableLinks.AccessibleName = null;
            resources.ApplyResources(this.chkEnableLinks, "chkEnableLinks");
            this.chkEnableLinks.BackgroundImage = null;
            this.chkEnableLinks.Font = null;
            this.chkEnableLinks.Name = "chkEnableLinks";
            this.chkEnableLinks.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreDrawOrder
            // 
            this.chkIgnoreDrawOrder.AccessibleDescription = null;
            this.chkIgnoreDrawOrder.AccessibleName = null;
            resources.ApplyResources(this.chkIgnoreDrawOrder, "chkIgnoreDrawOrder");
            this.chkIgnoreDrawOrder.BackgroundImage = null;
            this.chkIgnoreDrawOrder.Font = null;
            this.chkIgnoreDrawOrder.Name = "chkIgnoreDrawOrder";
            this.chkIgnoreDrawOrder.UseVisualStyleBackColor = true;
            // 
            // chkFlattenSWF
            // 
            this.chkFlattenSWF.AccessibleDescription = null;
            this.chkFlattenSWF.AccessibleName = null;
            resources.ApplyResources(this.chkFlattenSWF, "chkFlattenSWF");
            this.chkFlattenSWF.BackgroundImage = null;
            this.chkFlattenSWF.Font = null;
            this.chkFlattenSWF.Name = "chkFlattenSWF";
            this.chkFlattenSWF.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = null;
            this.label10.AccessibleName = null;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Font = null;
            this.label10.Name = "label10";
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Font = null;
            this.label9.Name = "label9";
            // 
            // chkOpenInNewWindow
            // 
            this.chkOpenInNewWindow.AccessibleDescription = null;
            this.chkOpenInNewWindow.AccessibleName = null;
            resources.ApplyResources(this.chkOpenInNewWindow, "chkOpenInNewWindow");
            this.chkOpenInNewWindow.BackgroundImage = null;
            this.chkOpenInNewWindow.Font = null;
            this.chkOpenInNewWindow.Name = "chkOpenInNewWindow";
            this.chkOpenInNewWindow.UseVisualStyleBackColor = true;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            resources.ApplyResources(this.dlgOpen, "dlgOpen");
            // 
            // btnExport
            // 
            this.btnExport.AccessibleDescription = null;
            this.btnExport.AccessibleName = null;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.BackgroundImage = null;
            this.btnExport.Font = null;
            this.btnExport.Image = global::PDFViewer.Properties.Resources.files_export;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = null;
            this.btnCancel.Image = global::PDFViewer.Properties.Resources.cancel_16;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmExportSWF
            // 
            this.AcceptButton = this.btnExport;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdToDefault);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtViewerSWF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLoaderSWF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdChoseFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "frmExportSWF";
            this.Load += new System.EventHandler(this.frmExportSWF_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportJpg_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTopage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFromPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udResolution)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button cmdChoseFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udTopage;
        private System.Windows.Forms.NumericUpDown udFromPage;
        private System.Windows.Forms.RadioButton optFromPage;
        private System.Windows.Forms.RadioButton optPrintAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.RadioButton optPrintCurrent;
        private System.Windows.Forms.TextBox txtPagesRange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLoaderSWF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtViewerSWF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton optRange;
        private System.Windows.Forms.NumericUpDown udQuality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udResolution;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optFullBitmap;
        private System.Windows.Forms.RadioButton optPolyToBitmap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdToDefault;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkOpenInNewWindow;
        private PJLControls.ColorPicker colorPicker1;
        private System.Windows.Forms.CheckBox chkStoreFonts;
        private System.Windows.Forms.CheckBox chkFontsToShapes;
        private System.Windows.Forms.CheckBox chkAddPageStop;
        private System.Windows.Forms.CheckBox chkEnableLinks;
        private System.Windows.Forms.CheckBox chkIgnoreDrawOrder;
        private System.Windows.Forms.CheckBox chkFlattenSWF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFlashVersion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        
    }
}