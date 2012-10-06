namespace PDFViewer
{
    partial class frmPDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDFViewer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvwOutline = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabView = new System.Windows.Forms.TabControl();
            this.tpvPDF = new System.Windows.Forms.TabPage();
            this.pageViewControl1 = new PDFViewer.PageViewer();
            this.tpvText = new System.Windows.Forms.TabPage();
            this.txtTextView = new System.Windows.Forms.TextBox();
            this.tpvImages = new System.Windows.Forms.TabPage();
            this.tsImages = new System.Windows.Forms.ToolStrip();
            this.tsImagesUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsImagesSave = new System.Windows.Forms.ToolStripButton();
            this.pdfImagesThumbView1 = new PDFViewer.PDFImagesThumbView();
            this.tpWordList = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintAs = new System.Windows.Forms.ToolStripButton();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.txtPage = new System.Windows.Forms.ToolStripTextBox();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbAntialias = new System.Windows.Forms.ToolStripButton();
            this.tsbVectorAntialias = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ttpLink = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgLoadPages = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabView.SuspendLayout();
            this.tpvPDF.SuspendLayout();
            this.tpvText.SuspendLayout();
            this.tpvImages.SuspendLayout();
            this.tsImages.SuspendLayout();
            this.tpWordList.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Font = null;
            this.ttpLink.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.tabView);
            this.splitContainer1.Panel2.Font = null;
            this.ttpLink.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.ttpLink.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleDescription = null;
            this.tabControl1.AccessibleName = null;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.BackgroundImage = null;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.ttpLink.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Controls.Add(this.tvwOutline);
            this.tabPage1.Font = null;
            this.tabPage1.Name = "tabPage1";
            this.ttpLink.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvwOutline
            // 
            this.tvwOutline.AccessibleDescription = null;
            this.tvwOutline.AccessibleName = null;
            resources.ApplyResources(this.tvwOutline, "tvwOutline");
            this.tvwOutline.BackgroundImage = null;
            this.tvwOutline.Name = "tvwOutline";
            this.ttpLink.SetToolTip(this.tvwOutline, resources.GetString("tvwOutline.ToolTip"));
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Font = null;
            this.tabPage2.Name = "tabPage2";
            this.ttpLink.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.AccessibleDescription = null;
            this.listView2.AccessibleName = null;
            resources.ApplyResources(this.listView2, "listView2");
            this.listView2.BackgroundImage = null;
            this.listView2.Font = null;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.OwnerDraw = true;
            this.ttpLink.SetToolTip(this.listView2, resources.GetString("listView2.ToolTip"));
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            this.listView2.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView2_DrawItem);
            // 
            // tabView
            // 
            this.tabView.AccessibleDescription = null;
            this.tabView.AccessibleName = null;
            resources.ApplyResources(this.tabView, "tabView");
            this.tabView.BackgroundImage = null;
            this.tabView.Controls.Add(this.tpvPDF);
            this.tabView.Controls.Add(this.tpvText);
            this.tabView.Controls.Add(this.tpvImages);
            this.tabView.Controls.Add(this.tpWordList);
            this.tabView.Font = null;
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.ttpLink.SetToolTip(this.tabView, resources.GetString("tabView.ToolTip"));
            this.tabView.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabView_Selected);
            // 
            // tpvPDF
            // 
            this.tpvPDF.AccessibleDescription = null;
            this.tpvPDF.AccessibleName = null;
            resources.ApplyResources(this.tpvPDF, "tpvPDF");
            this.tpvPDF.BackgroundImage = null;
            this.tpvPDF.Controls.Add(this.pageViewControl1);
            this.tpvPDF.Font = null;
            this.tpvPDF.Name = "tpvPDF";
            this.ttpLink.SetToolTip(this.tpvPDF, resources.GetString("tpvPDF.ToolTip"));
            this.tpvPDF.UseVisualStyleBackColor = true;
            // 
            // pageViewControl1
            // 
            this.pageViewControl1.AccessibleDescription = null;
            this.pageViewControl1.AccessibleName = null;
            resources.ApplyResources(this.pageViewControl1, "pageViewControl1");
            this.pageViewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pageViewControl1.BackgroundImage = null;
            this.pageViewControl1.BorderColor = System.Drawing.Color.Black;
            this.pageViewControl1.DrawBorder = false;
            this.pageViewControl1.DrawShadow = true;
            this.pageViewControl1.Font = null;
            this.pageViewControl1.Name = "pageViewControl1";
            this.pageViewControl1.PageColor = System.Drawing.Color.White;
            this.pageViewControl1.PageSize = new System.Drawing.Size(0, 0);
            this.pageViewControl1.PaintMethod = PDFViewer.PageViewer.DoubleBufferMethod.BuiltInOptimizedDoubleBuffer;
            this.pageViewControl1.ScrollPosition = new System.Drawing.Point(-10, -10);
            this.ttpLink.SetToolTip(this.pageViewControl1, resources.GetString("pageViewControl1.ToolTip"));
            this.pageViewControl1.PreviousPage += new PDFViewer.PageViewer.MovePageHandler(this.doubleBufferControl1_PreviousPage);
            this.pageViewControl1.NextPage += new PDFViewer.PageViewer.MovePageHandler(this.doubleBufferControl1_NextPage);
            this.pageViewControl1.PaintControl += new PDFViewer.PageViewer.PaintControlHandler(this.doubleBufferControl1_PaintControl);
            // 
            // tpvText
            // 
            this.tpvText.AccessibleDescription = null;
            this.tpvText.AccessibleName = null;
            resources.ApplyResources(this.tpvText, "tpvText");
            this.tpvText.BackgroundImage = null;
            this.tpvText.Controls.Add(this.txtTextView);
            this.tpvText.Font = null;
            this.tpvText.Name = "tpvText";
            this.ttpLink.SetToolTip(this.tpvText, resources.GetString("tpvText.ToolTip"));
            this.tpvText.UseVisualStyleBackColor = true;
            // 
            // txtTextView
            // 
            this.txtTextView.AccessibleDescription = null;
            this.txtTextView.AccessibleName = null;
            resources.ApplyResources(this.txtTextView, "txtTextView");
            this.txtTextView.BackgroundImage = null;
            this.txtTextView.Font = null;
            this.txtTextView.Name = "txtTextView";
            this.txtTextView.TabStop = false;
            this.ttpLink.SetToolTip(this.txtTextView, resources.GetString("txtTextView.ToolTip"));
            // 
            // tpvImages
            // 
            this.tpvImages.AccessibleDescription = null;
            this.tpvImages.AccessibleName = null;
            resources.ApplyResources(this.tpvImages, "tpvImages");
            this.tpvImages.BackgroundImage = null;
            this.tpvImages.Controls.Add(this.tsImages);
            this.tpvImages.Controls.Add(this.pdfImagesThumbView1);
            this.tpvImages.Font = null;
            this.tpvImages.Name = "tpvImages";
            this.ttpLink.SetToolTip(this.tpvImages, resources.GetString("tpvImages.ToolTip"));
            this.tpvImages.UseVisualStyleBackColor = true;
            // 
            // tsImages
            // 
            this.tsImages.AccessibleDescription = null;
            this.tsImages.AccessibleName = null;
            resources.ApplyResources(this.tsImages, "tsImages");
            this.tsImages.BackgroundImage = null;
            this.tsImages.Font = null;
            this.tsImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImagesUpdate,
            this.tsImagesSave});
            this.tsImages.Name = "tsImages";
            this.ttpLink.SetToolTip(this.tsImages, resources.GetString("tsImages.ToolTip"));
            // 
            // tsImagesUpdate
            // 
            this.tsImagesUpdate.AccessibleDescription = null;
            this.tsImagesUpdate.AccessibleName = null;
            resources.ApplyResources(this.tsImagesUpdate, "tsImagesUpdate");
            this.tsImagesUpdate.BackgroundImage = null;
            this.tsImagesUpdate.Image = global::PDFViewer.Properties.Resources.RefreshDocView;
            this.tsImagesUpdate.Name = "tsImagesUpdate";
            this.tsImagesUpdate.Click += new System.EventHandler(this.tsImagesUpdate_Click);
            // 
            // tsImagesSave
            // 
            this.tsImagesSave.AccessibleDescription = null;
            this.tsImagesSave.AccessibleName = null;
            resources.ApplyResources(this.tsImagesSave, "tsImagesSave");
            this.tsImagesSave.BackgroundImage = null;
            this.tsImagesSave.Image = global::PDFViewer.Properties.Resources.Save;
            this.tsImagesSave.Name = "tsImagesSave";
            this.tsImagesSave.Click += new System.EventHandler(this.tsImagesSave_Click);
            // 
            // pdfImagesThumbView1
            // 
            this.pdfImagesThumbView1.AccessibleDescription = null;
            this.pdfImagesThumbView1.AccessibleName = null;
            resources.ApplyResources(this.pdfImagesThumbView1, "pdfImagesThumbView1");
            this.pdfImagesThumbView1.BackgroundImage = null;
            this.pdfImagesThumbView1.Font = null;
            this.pdfImagesThumbView1.Name = "pdfImagesThumbView1";
            this.ttpLink.SetToolTip(this.pdfImagesThumbView1, resources.GetString("pdfImagesThumbView1.ToolTip"));
            this.pdfImagesThumbView1.UseCompatibleStateImageBehavior = false;
            // 
            // tpWordList
            // 
            this.tpWordList.AccessibleDescription = null;
            this.tpWordList.AccessibleName = null;
            resources.ApplyResources(this.tpWordList, "tpWordList");
            this.tpWordList.BackgroundImage = null;
            this.tpWordList.Controls.Add(this.listView1);
            this.tpWordList.Font = null;
            this.tpWordList.Name = "tpWordList";
            this.ttpLink.SetToolTip(this.tpWordList, resources.GetString("tpWordList.ToolTip"));
            this.tpWordList.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AccessibleDescription = null;
            this.listView1.AccessibleName = null;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.BackgroundImage = null;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Font = null;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.ttpLink.SetToolTip(this.listView1, resources.GetString("listView1.ToolTip"));
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = null;
            this.toolStrip1.AccessibleName = null;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.Font = null;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbPrintAs,
            this.tsbPrev,
            this.txtPage,
            this.tsbNext,
            this.tsbSearch,
            this.tsbPrint,
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripButton2,
            this.tsbAntialias,
            this.tsbVectorAntialias,
            this.toolStripButton4,
            this.toolStripButton5,
            this.tsbAbout});
            this.toolStrip1.Name = "toolStrip1";
            this.ttpLink.SetToolTip(this.toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // tsbOpen
            // 
            this.tsbOpen.AccessibleDescription = null;
            this.tsbOpen.AccessibleName = null;
            resources.ApplyResources(this.tsbOpen, "tsbOpen");
            this.tsbOpen.BackgroundImage = null;
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::PDFViewer.Properties.Resources.dmdskres_373_9_16x16x32;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbPrintAs
            // 
            this.tsbPrintAs.AccessibleDescription = null;
            this.tsbPrintAs.AccessibleName = null;
            resources.ApplyResources(this.tsbPrintAs, "tsbPrintAs");
            this.tsbPrintAs.BackgroundImage = null;
            this.tsbPrintAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintAs.Image = global::PDFViewer.Properties.Resources.PrintBrmUi_102_6_16x16x32;
            this.tsbPrintAs.Name = "tsbPrintAs";
            this.tsbPrintAs.Click += new System.EventHandler(this.tsbPrintAs_Click);
            // 
            // tsbPrev
            // 
            this.tsbPrev.AccessibleDescription = null;
            this.tsbPrev.AccessibleName = null;
            resources.ApplyResources(this.tsbPrev, "tsbPrev");
            this.tsbPrev.BackgroundImage = null;
            this.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrev.Image = global::PDFViewer.Properties.Resources.netshell_21611_1_16x16x32;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // txtPage
            // 
            this.txtPage.AccessibleDescription = null;
            this.txtPage.AccessibleName = null;
            resources.ApplyResources(this.txtPage, "txtPage");
            this.txtPage.Name = "txtPage";
            this.txtPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPage_KeyDown);
            // 
            // tsbNext
            // 
            this.tsbNext.AccessibleDescription = null;
            this.tsbNext.AccessibleName = null;
            resources.ApplyResources(this.tsbNext, "tsbNext");
            this.tsbNext.BackgroundImage = null;
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = global::PDFViewer.Properties.Resources.netshell_1611_1_16x16x32;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.AccessibleDescription = null;
            this.tsbSearch.AccessibleName = null;
            resources.ApplyResources(this.tsbSearch, "tsbSearch");
            this.tsbSearch.BackgroundImage = null;
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = global::PDFViewer.Properties.Resources.SearchFolder_323_3_16x16x32;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.AccessibleDescription = null;
            this.tsbAbout.AccessibleName = null;
            resources.ApplyResources(this.tsbAbout, "tsbAbout");
            this.tsbAbout.BackgroundImage = null;
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::PDFViewer.Properties.Resources.psr_206_4_16x16x32;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.AccessibleDescription = null;
            this.tsbPrint.AccessibleName = null;
            resources.ApplyResources(this.tsbPrint, "tsbPrint");
            this.tsbPrint.BackgroundImage = null;
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = global::PDFViewer.Properties.Resources.FeedbackTool_109_12_16x16x32;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AccessibleDescription = null;
            this.toolStripButton3.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.BackgroundImage = null;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AccessibleDescription = null;
            this.toolStripButton1.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.BackgroundImage = null;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PDFViewer.Properties.Resources.ZoomIn;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AccessibleDescription = null;
            this.toolStripButton2.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.BackgroundImage = null;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::PDFViewer.Properties.Resources.ZoomOut;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbAntialias
            // 
            this.tsbAntialias.AccessibleDescription = null;
            this.tsbAntialias.AccessibleName = null;
            resources.ApplyResources(this.tsbAntialias, "tsbAntialias");
            this.tsbAntialias.BackgroundImage = null;
            this.tsbAntialias.Checked = true;
            this.tsbAntialias.CheckOnClick = true;
            this.tsbAntialias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbAntialias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAntialias.Name = "tsbAntialias";
            this.tsbAntialias.Click += new System.EventHandler(this.tsbAntialias_Click);
            // 
            // tsbVectorAntialias
            // 
            this.tsbVectorAntialias.AccessibleDescription = null;
            this.tsbVectorAntialias.AccessibleName = null;
            resources.ApplyResources(this.tsbVectorAntialias, "tsbVectorAntialias");
            this.tsbVectorAntialias.BackgroundImage = null;
            this.tsbVectorAntialias.CheckOnClick = true;
            this.tsbVectorAntialias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVectorAntialias.Name = "tsbVectorAntialias";
            this.tsbVectorAntialias.Click += new System.EventHandler(this.tsbVectorAntialias_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AccessibleDescription = null;
            this.toolStripButton4.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.BackgroundImage = null;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AccessibleDescription = null;
            this.toolStripButton5.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.BackgroundImage = null;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Name = "statusStrip1";
            this.ttpLink.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // StatusLabel
            // 
            this.StatusLabel.AccessibleDescription = null;
            this.StatusLabel.AccessibleName = null;
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BackgroundImage = null;
            this.StatusLabel.Name = "StatusLabel";
            // 
            // bgLoadPages
            // 
            this.bgLoadPages.WorkerReportsProgress = true;
            this.bgLoadPages.WorkerSupportsCancellation = true;
            // 
            // frmPDFViewer
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "frmPDFViewer";
            this.ttpLink.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPDFViewer_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabView.ResumeLayout(false);
            this.tpvPDF.ResumeLayout(false);
            this.tpvText.ResumeLayout(false);
            this.tpvText.PerformLayout();
            this.tpvImages.ResumeLayout(false);
            this.tpvImages.PerformLayout();
            this.tsImages.ResumeLayout(false);
            this.tsImages.PerformLayout();
            this.tpWordList.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwOutline;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripTextBox txtPage;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolTip ttpLink;
        private System.Windows.Forms.ToolStripButton tsbPrintAs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tsbAntialias;
        private System.Windows.Forms.ToolStripButton tsbVectorAntialias;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage tpvPDF;
        private PageViewer pageViewControl1;
        private System.Windows.Forms.TabPage tpvText;
        private System.Windows.Forms.TextBox txtTextView;
        private System.Windows.Forms.TabPage tpvImages;
        private System.Windows.Forms.ToolStrip tsImages;
        private System.Windows.Forms.ToolStripButton tsImagesUpdate;
        private System.Windows.Forms.ToolStripButton tsImagesSave;
        private PDFImagesThumbView pdfImagesThumbView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker bgLoadPages;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.TabPage tpWordList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

