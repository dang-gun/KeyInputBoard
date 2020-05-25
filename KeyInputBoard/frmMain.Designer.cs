namespace KeyInputBoard
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPortRefresh = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboboxPorts = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvMatching = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.btnItemEdit = new System.Windows.Forms.Button();
            this.txtItemPin = new System.Windows.Forms.TextBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbAlt = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.cbCtrl = new System.Windows.Forms.CheckBox();
            this.cbShift = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.lvLog = new System.Windows.Forms.ListView();
            this.tsmiFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPortRefresh
            // 
            this.btnPortRefresh.Location = new System.Drawing.Point(187, 1);
            this.btnPortRefresh.Name = "btnPortRefresh";
            this.btnPortRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnPortRefresh.TabIndex = 0;
            this.btnPortRefresh.Text = "Refresh";
            this.btnPortRefresh.UseVisualStyleBackColor = true;
            this.btnPortRefresh.Click += new System.EventHandler(this.btnPortRefresh_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(5, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(175, 66);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboboxPorts);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnPortRefresh);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(186, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 66);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboboxPorts
            // 
            this.comboboxPorts.FormattingEnabled = true;
            this.comboboxPorts.Location = new System.Drawing.Point(59, 3);
            this.comboboxPorts.Name = "comboboxPorts";
            this.comboboxPorts.Size = new System.Drawing.Size(121, 20);
            this.comboboxPorts.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvMatching);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(272, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 410);
            this.panel2.TabIndex = 4;
            // 
            // lvMatching
            // 
            this.lvMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvMatching.FullRowSelect = true;
            this.lvMatching.HideSelection = false;
            this.lvMatching.Location = new System.Drawing.Point(3, 160);
            this.lvMatching.Name = "lvMatching";
            this.lvMatching.Size = new System.Drawing.Size(388, 247);
            this.lvMatching.TabIndex = 3;
            this.lvMatching.UseCompatibleStateImageBehavior = false;
            this.lvMatching.View = System.Windows.Forms.View.Details;
            this.lvMatching.SelectedIndexChanged += new System.EventHandler(this.lvMatching_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pin";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Explanation";
            this.columnHeader3.Width = 240;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtExplanation);
            this.panel3.Controls.Add(this.btnItemDelete);
            this.panel3.Controls.Add(this.btnItemEdit);
            this.panel3.Controls.Add(this.txtItemPin);
            this.panel3.Controls.Add(this.btnItemAdd);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 151);
            this.panel3.TabIndex = 2;
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(97, 65);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(200, 79);
            this.txtExplanation.TabIndex = 7;
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Location = new System.Drawing.Point(303, 104);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(80, 40);
            this.btnItemDelete.TabIndex = 1;
            this.btnItemDelete.Text = "Delete";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Location = new System.Drawing.Point(303, 58);
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.Size = new System.Drawing.Size(80, 40);
            this.btnItemEdit.TabIndex = 1;
            this.btnItemEdit.Text = "Edit";
            this.btnItemEdit.UseVisualStyleBackColor = true;
            this.btnItemEdit.Click += new System.EventHandler(this.btnItemEdit_Click);
            // 
            // txtItemPin
            // 
            this.txtItemPin.Location = new System.Drawing.Point(97, 14);
            this.txtItemPin.Name = "txtItemPin";
            this.txtItemPin.Size = new System.Drawing.Size(200, 21);
            this.txtItemPin.TabIndex = 6;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(303, 12);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(80, 40);
            this.btnItemAdd.TabIndex = 0;
            this.btnItemAdd.Text = "Add";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbAlt);
            this.panel4.Controls.Add(this.txtKey);
            this.panel4.Controls.Add(this.cbCtrl);
            this.panel4.Controls.Add(this.cbShift);
            this.panel4.Location = new System.Drawing.Point(94, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(203, 25);
            this.panel4.TabIndex = 6;
            // 
            // cbAlt
            // 
            this.cbAlt.AutoSize = true;
            this.cbAlt.Location = new System.Drawing.Point(160, 3);
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.Size = new System.Drawing.Size(38, 16);
            this.cbAlt.TabIndex = 2;
            this.cbAlt.Text = "Alt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(3, 3);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(50, 21);
            this.txtKey.TabIndex = 5;
            this.txtKey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtKey_PreviewKeyDown);
            // 
            // cbCtrl
            // 
            this.cbCtrl.AutoSize = true;
            this.cbCtrl.Location = new System.Drawing.Point(111, 4);
            this.cbCtrl.Name = "cbCtrl";
            this.cbCtrl.Size = new System.Drawing.Size(43, 16);
            this.cbCtrl.TabIndex = 1;
            this.cbCtrl.Text = "Ctrl";
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.AutoSize = true;
            this.cbShift.Location = new System.Drawing.Point(57, 3);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(48, 16);
            this.cbShift.TabIndex = 0;
            this.cbShift.Text = "Shift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Explanation : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Action : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pin : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.devToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(668, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile_Save,
            this.tsmiFile_Load});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // devToolStripMenuItem
            // 
            this.devToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDataLoad});
            this.devToolStripMenuItem.Name = "devToolStripMenuItem";
            this.devToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.devToolStripMenuItem.Text = "Dev";
            // 
            // tsmiDataLoad
            // 
            this.tsmiDataLoad.Name = "tsmiDataLoad";
            this.tsmiDataLoad.Size = new System.Drawing.Size(129, 22);
            this.tsmiDataLoad.Text = "Data Load";
            this.tsmiDataLoad.Click += new System.EventHandler(this.tsmiDataLoad_Click);
            // 
            // lvLog
            // 
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(5, 129);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(257, 306);
            this.lvLog.TabIndex = 6;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.List;
            // 
            // tsmiFile_Save
            // 
            this.tsmiFile_Save.Name = "tsmiFile_Save";
            this.tsmiFile_Save.Size = new System.Drawing.Size(180, 22);
            this.tsmiFile_Save.Text = "Save";
            this.tsmiFile_Save.Click += new System.EventHandler(this.tsmiFile_Save_Click);
            // 
            // tsmiFile_Load
            // 
            this.tsmiFile_Load.Name = "tsmiFile_Load";
            this.tsmiFile_Load.Size = new System.Drawing.Size(180, 22);
            this.tsmiFile_Load.Text = "Load";
            this.tsmiFile_Load.Click += new System.EventHandler(this.tsmiFile_Load_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 444);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Key Input Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPortRefresh;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboboxPorts;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtExplanation;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.Button btnItemEdit;
        private System.Windows.Forms.TextBox txtItemPin;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbAlt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.CheckBox cbCtrl;
        private System.Windows.Forms.CheckBox cbShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvMatching;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataLoad;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Save;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Load;
    }
}

