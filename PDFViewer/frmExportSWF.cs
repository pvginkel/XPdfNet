using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFViewer
{
    public partial class frmExportSWF : Form
    {
        PDFLibNet.PDFWrapper _doc;
        private bool _bCancel = false;
        public delegate bool ProgressInvoker(int pageCount, int currentPage);
        public delegate void FinishedInvoker();

        public frmExportSWF(PDFLibNet.PDFWrapper doc, string fileName)
        {
            InitializeComponent();
            txtFileName.Text = fileName;
            _doc = doc;
            udTopage.Maximum = _doc.PageCount;
            udFromPage.Maximum = _doc.PageCount - 1;
            udTopage.Value = _doc.PageCount;
            LoadDefaults();
         
        }

        private bool UpdateProgress(int pageCount, int currentPage)
        {
            pgBar.Maximum = pageCount;
            pgBar.Value = currentPage;
            return true;
        }
        private void Finished()
        {
            if (!_bCancel)
                MessageBox.Show(Resources.UIStrings.MsgExportFinished, Text,  MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.Close();
            btnExport.Enabled = true;
            btnCancel.Enabled = true;
            cmdChoseFile.Enabled = true;

            _doc.ExportSwfProgress -= new PDFLibNet.ExportJpgProgressHandler(_doc_ExportSwfProgress);
            _doc.ExportSwfFinished -= new PDFLibNet.ExportJpgFinishedHandler(_doc_ExportSwfFinished);
            
        }

        void _doc_ExportSwfFinished()
        {
            Invoke(new FinishedInvoker(Finished));
        }

        bool _doc_ExportSwfProgress(int pageCount, int currentPage)
        {
            return (bool)Invoke(new ProgressInvoker(UpdateProgress), pageCount, currentPage);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            _doc.ExportSwfProgress += new PDFLibNet.ExportJpgProgressHandler(_doc_ExportSwfProgress);
            _doc.ExportSwfFinished += new PDFLibNet.ExportJpgFinishedHandler(_doc_ExportSwfFinished);

            ExportSWFParams ex = new ExportSWFParams();
            ex.AddPageStop = chkAddPageStop.Checked;
            ex.DefaultLoaderViewer = string.IsNullOrEmpty(txtLoaderSWF.Text) && string.IsNullOrEmpty(txtViewerSWF.Text);
            ex.EnableLinks = chkEnableLinks.Checked;
            int flashVersion = 9;
            if (int.TryParse(cboFlashVersion.Text, out flashVersion))
                ex.FlashVersion =(short)flashVersion;
            ex.FlattenSWF = chkFlattenSWF.Checked;
            ex.FontsToShapes = chkFontsToShapes.Checked;
            ex.IgnoreDrawOrder = chkIgnoreDrawOrder.Checked;
            ex.LinksColor = string.Format("{0:x}{1:x}{2:x}", colorPicker1.Color.R, colorPicker1.Color.G, colorPicker1.Color.B);
            ex.Loader = txtLoaderSWF.Text;
            ex.OpenLinksInSameWindow = !chkOpenInNewWindow.Checked;
            if (optFromPage.Checked)
                ex.PageRange = string.Format("{0}-{1}", udFromPage.Value, udTopage.Value);
            else if (optRange.Checked)
                ex.PageRange = txtPagesRange.Text;
            else if (optPrintCurrent.Checked)
                ex.PageRange = _doc.CurrentPage.ToString();
            ex.PolyToBitmap = optPolyToBitmap.Checked;
            ex.StoreFonts = chkStoreFonts.Checked;
            ex.ToFullBitmap = optFullBitmap.Checked;
            ex.Viewer = txtViewerSWF.Text;

            string subKey = @"Software\xPDFWin\swftools\InstallPath";
            var sk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
            if (sk == null)
            {
                string sPath = Environment.CurrentDirectory;
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = Resources.UIStrings.TitleSelectSWFSDirs;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (!System.IO.File.Exists(dlg.SelectedPath + @"\PreLoaderTemplate.swf"))
                    {
                        MessageBox.Show("PreLoaderTemplate.swf not found!");
                        return;
                    }
                    else
                        sPath = System.IO.Path.GetDirectoryName(dlg.SelectedPath);
                }

                var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);
                key.SetValue(null, sPath);
                key.Close();

            }
            else
                sk.Close();


            _doc.ExportSWF(txtFileName.Text, ex);
            
        }

        private void cmdChoseFile_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlgSave.FileName;
                btnExport.Enabled = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnExport.Enabled)
                Close();
            else
            {
                _bCancel = true;
                btnCancel.Enabled = false;
                _doc.CancelSwfExport();
            }
        }

        private void optPrintAll_CheckedChanged(object sender, EventArgs e)
        {
            udFromPage.Enabled = optFromPage.Checked;
            udTopage.Enabled = optFromPage.Checked;
        }

        private void frmExportJpg_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if(_doc.IsSwfBusy)
            {
                switch (MessageBox.Show("Cancel exporting?", "Close form", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        _doc.CancelSwfExport();
                        while(_doc.IsSwfBusy);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }*/
            _doc.ExportSwfProgress -= new PDFLibNet.ExportJpgProgressHandler(_doc_ExportSwfProgress);
            _doc.ExportSwfFinished -= new PDFLibNet.ExportJpgFinishedHandler(_doc_ExportSwfFinished);
        }

        private void optFromPage_CheckedChanged(object sender, EventArgs e)
        {
            udFromPage.Enabled = optFromPage.Checked;
            udTopage.Enabled = optFromPage.Checked;
        }

        private void udQuality_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmExportSWF_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Movie Flash (*.swf)|*.swf";
            dlgSave.OverwritePrompt = false;
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                
                this.txtLoaderSWF.Text = dlgSave.FileName;
                btnExport.Enabled = System.IO.File.Exists(txtViewerSWF.Text) && System.IO.File.Exists(txtLoaderSWF.Text) && !string.IsNullOrEmpty(txtFileName.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Movie Flash (*.swf)|*.swf";
            dlgSave.OverwritePrompt = false;
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                this.txtViewerSWF.Text = dlgSave.FileName;
                btnExport.Enabled = System.IO.File.Exists(txtViewerSWF.Text) && System.IO.File.Exists(txtLoaderSWF.Text) && !string.IsNullOrEmpty(txtFileName.Text);
            }
        }

        private void LoadDefaults()
        {
            ExportSWFParams ex = new ExportSWFParams();
            chkAddPageStop.Checked = ex.AddPageStop;
            chkEnableLinks.Checked = ex.EnableLinks;
            chkFlattenSWF.Checked = ex.FlattenSWF;
            chkFontsToShapes.Checked = ex.FontsToShapes;
            chkIgnoreDrawOrder.Checked = ex.IgnoreDrawOrder;
            chkOpenInNewWindow.Checked = !ex.OpenLinksInSameWindow;
            chkStoreFonts.Checked = ex.StoreFonts;
            cboFlashVersion.Text = ex.FlashVersion.ToString();
            optPolyToBitmap.Checked = ex.PolyToBitmap;
            optFullBitmap.Checked = ex.ToFullBitmap;
            txtLoaderSWF.Text = ex.Loader;
            txtViewerSWF.Text = ex.Viewer;

        }
        private void cmdToDefault_Click(object sender, EventArgs e)
        {
            LoadDefaults();
        }
    }
}