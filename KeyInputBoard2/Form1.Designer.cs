namespace KeyInputBoard2
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tsmiFile_Save = new ToolStripMenuItem();
            tsmiFile_SaveAs = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            tsmiFile_Load = new ToolStripMenuItem();
            tsmiFile_LoadSelect = new ToolStripMenuItem();
            devToolStripMenuItem = new ToolStripMenuItem();
            addLogToolStripMenuItem = new ToolStripMenuItem();
            tsmiDev_Log_TestLogAdd1 = new ToolStripMenuItem();
            panel1 = new Panel();
            btnStop = new Button();
            btnStart = new Button();
            btnPortRefresh = new Button();
            comboboxPorts = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            lvLog = new ListView();
            headTime = new ColumnHeader();
            headMessage = new ColumnHeader();
            panel3 = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtComment = new TextBox();
            panel4 = new Panel();
            cbAlt = new CheckBox();
            cbCtrl = new CheckBox();
            cbShift = new CheckBox();
            txtKey = new TextBox();
            label3 = new Label();
            btnNew = new Button();
            txtItemPin = new TextBox();
            label4 = new Label();
            label2 = new Label();
            lvMatching = new ListView();
            headerId = new ColumnHeader();
            headerPin = new ColumnHeader();
            headerAction = new ColumnHeader();
            headerComment = new ColumnHeader();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, devToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(707, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiFile_Save, tsmiFile_SaveAs, toolStripMenuItem1, tsmiFile_Load, tsmiFile_LoadSelect });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmiFile_Save
            // 
            tsmiFile_Save.Name = "tsmiFile_Save";
            tsmiFile_Save.Size = new Size(180, 22);
            tsmiFile_Save.Text = "Save";
            tsmiFile_Save.Click += tsmiFile_Save_Click;
            // 
            // tsmiFile_SaveAs
            // 
            tsmiFile_SaveAs.Name = "tsmiFile_SaveAs";
            tsmiFile_SaveAs.Size = new Size(180, 22);
            tsmiFile_SaveAs.Text = "Save as";
            tsmiFile_SaveAs.Click += tsmiFile_SaveAs_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // tsmiFile_Load
            // 
            tsmiFile_Load.Name = "tsmiFile_Load";
            tsmiFile_Load.Size = new Size(180, 22);
            tsmiFile_Load.Text = "Load";
            tsmiFile_Load.Click += tsmiFile_Load_Click;
            // 
            // tsmiFile_LoadSelect
            // 
            tsmiFile_LoadSelect.Name = "tsmiFile_LoadSelect";
            tsmiFile_LoadSelect.Size = new Size(180, 22);
            tsmiFile_LoadSelect.Text = "Load Select";
            tsmiFile_LoadSelect.Click += tsmiFile_LoadSelect_Click;
            // 
            // devToolStripMenuItem
            // 
            devToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addLogToolStripMenuItem });
            devToolStripMenuItem.Name = "devToolStripMenuItem";
            devToolStripMenuItem.Size = new Size(40, 20);
            devToolStripMenuItem.Text = "Dev";
            // 
            // addLogToolStripMenuItem
            // 
            addLogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiDev_Log_TestLogAdd1 });
            addLogToolStripMenuItem.Name = "addLogToolStripMenuItem";
            addLogToolStripMenuItem.Size = new Size(94, 22);
            addLogToolStripMenuItem.Text = "Log";
            // 
            // tsmiDev_Log_TestLogAdd1
            // 
            tsmiDev_Log_TestLogAdd1.Name = "tsmiDev_Log_TestLogAdd1";
            tsmiDev_Log_TestLogAdd1.Size = new Size(145, 22);
            tsmiDev_Log_TestLogAdd1.Text = "Test Log Add";
            tsmiDev_Log_TestLogAdd1.Click += tsmiDev_Log_TestLogAdd1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(btnPortRefresh);
            panel1.Controls.Add(comboboxPorts);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 100);
            panel1.TabIndex = 1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(177, 32);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 65);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(3, 32);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(168, 65);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnPortRefresh
            // 
            btnPortRefresh.Location = new Point(186, 3);
            btnPortRefresh.Name = "btnPortRefresh";
            btnPortRefresh.Size = new Size(81, 23);
            btnPortRefresh.TabIndex = 2;
            btnPortRefresh.Text = "Refresh";
            btnPortRefresh.UseVisualStyleBackColor = true;
            btnPortRefresh.Click += btnPortRefresh_Click;
            // 
            // comboboxPorts
            // 
            comboboxPorts.FormattingEnabled = true;
            comboboxPorts.Location = new Point(59, 3);
            comboboxPorts.Name = "comboboxPorts";
            comboboxPorts.Size = new Size(121, 23);
            comboboxPorts.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(50, 23);
            label1.TabIndex = 0;
            label1.Text = "Port : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.Controls.Add(lvLog);
            panel2.Location = new Point(0, 134);
            panel2.Name = "panel2";
            panel2.Size = new Size(270, 355);
            panel2.TabIndex = 2;
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new ColumnHeader[] { headTime, headMessage });
            lvLog.Location = new Point(3, 3);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(264, 349);
            lvLog.TabIndex = 0;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            // 
            // headTime
            // 
            headTime.Text = "Time";
            // 
            // headMessage
            // 
            headMessage.Text = "Message";
            headMessage.Width = 180;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnDelete);
            panel3.Controls.Add(btnEdit);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(txtComment);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(btnNew);
            panel3.Controls.Add(txtItemPin);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(273, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(429, 148);
            panel3.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(335, 110);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(335, 75);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 30);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(336, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 30);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(109, 58);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(220, 82);
            txtComment.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbAlt);
            panel4.Controls.Add(cbCtrl);
            panel4.Controls.Add(cbShift);
            panel4.Controls.Add(txtKey);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(3, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(327, 30);
            panel4.TabIndex = 6;
            // 
            // cbAlt
            // 
            cbAlt.AutoSize = true;
            cbAlt.Location = new Point(270, 7);
            cbAlt.Name = "cbAlt";
            cbAlt.Size = new Size(41, 19);
            cbAlt.TabIndex = 8;
            cbAlt.Text = "Alt";
            cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbCtrl
            // 
            cbCtrl.AutoSize = true;
            cbCtrl.Location = new Point(219, 7);
            cbCtrl.Name = "cbCtrl";
            cbCtrl.Size = new Size(45, 19);
            cbCtrl.TabIndex = 7;
            cbCtrl.Text = "Ctrl";
            cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            cbShift.AutoSize = true;
            cbShift.Location = new Point(162, 7);
            cbShift.Name = "cbShift";
            cbShift.Size = new Size(51, 19);
            cbShift.TabIndex = 6;
            cbShift.Text = "Shift";
            cbShift.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(106, 3);
            txtKey.Name = "txtKey";
            txtKey.ReadOnly = true;
            txtKey.Size = new Size(50, 23);
            txtKey.TabIndex = 5;
            txtKey.PreviewKeyDown += txtKey_PreviewKeyDown;
            // 
            // label3
            // 
            label3.Location = new Point(0, 2);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 2;
            label3.Text = "Action : ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(336, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(90, 30);
            btnNew.TabIndex = 5;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // txtItemPin
            // 
            txtItemPin.Location = new Point(109, 4);
            txtItemPin.Name = "txtItemPin";
            txtItemPin.Size = new Size(100, 23);
            txtItemPin.TabIndex = 4;
            // 
            // label4
            // 
            label4.Location = new Point(3, 53);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 3;
            label4.Text = "Comment : ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Pin : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lvMatching
            // 
            lvMatching.Columns.AddRange(new ColumnHeader[] { headerId, headerPin, headerAction, headerComment });
            lvMatching.FullRowSelect = true;
            lvMatching.Location = new Point(273, 182);
            lvMatching.MultiSelect = false;
            lvMatching.Name = "lvMatching";
            lvMatching.Size = new Size(429, 307);
            lvMatching.TabIndex = 4;
            lvMatching.UseCompatibleStateImageBehavior = false;
            lvMatching.View = View.Details;
            lvMatching.SelectedIndexChanged += lvMatching_SelectedIndexChanged;
            // 
            // headerId
            // 
            headerId.Text = "Id";
            headerId.Width = 25;
            // 
            // headerPin
            // 
            headerPin.Text = "Pin";
            // 
            // headerAction
            // 
            headerAction.Text = "Action";
            headerAction.Width = 120;
            // 
            // headerComment
            // 
            headerComment.Text = "Comment";
            headerComment.Width = 200;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 495);
            Controls.Add(lvMatching);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Shown += Form1_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem tsmiFile_Save;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmiFile_Load;
        private ToolStripMenuItem tsmiFile_LoadSelect;
        private ToolStripMenuItem devToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private Button btnPortRefresh;
        private ComboBox comboboxPorts;
        private Button btnStop;
        private Button btnStart;
        private Panel panel2;
        private ListView lvLog;
        private ColumnHeader headTime;
        private ColumnHeader headMessage;
        private Panel panel3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private CheckBox cbShift;
        private TextBox txtKey;
        private Button btnNew;
        private TextBox txtItemPin;
        private CheckBox cbAlt;
        private CheckBox cbCtrl;
        private Button btnAdd;
        private TextBox txtComment;
        private Button btnEdit;
        private Button btnDelete;
        private ListView lvMatching;
        private ColumnHeader headerId;
        private ColumnHeader headerPin;
        private ColumnHeader headerAction;
        private ColumnHeader headerComment;
        private ListBox listBox1;
        private ToolStripMenuItem addLogToolStripMenuItem;
        private ToolStripMenuItem tsmiDev_Log_TestLogAdd1;
        private ToolStripMenuItem tsmiFile_SaveAs;
    }
}
