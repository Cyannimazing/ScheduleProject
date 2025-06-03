namespace ScheduleProject
{
    partial class UC_Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbLecturer = new System.Windows.Forms.ComboBox();
            this.lblLecturer = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.weekNavPanel = new System.Windows.Forms.Panel();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.lblCurrentWeek = new System.Windows.Forms.Label();
            this.btnPrevWeek = new System.Windows.Forms.Button();
            this.scheduleGridPanel = new System.Windows.Forms.Panel();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.filterPanel.SuspendLayout();
            this.weekNavPanel.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.btnApplyFilter);
            this.filterPanel.Controls.Add(this.cmbRoom);
            this.filterPanel.Controls.Add(this.lblRoom);
            this.filterPanel.Controls.Add(this.cmbLecturer);
            this.filterPanel.Controls.Add(this.lblLecturer);
            this.filterPanel.Controls.Add(this.cmbClass);
            this.filterPanel.Controls.Add(this.lblClass);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(686, 43);
            this.filterPanel.TabIndex = 0;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.Location = new System.Drawing.Point(574, 8);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(69, 22);
            this.btnApplyFilter.TabIndex = 6;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Items.AddRange(new object[] {
            "All Rooms",
            "Room 101",
            "Room 102",
            "Room 103",
            "Lab 201",
            "Lab 202"});
            this.cmbRoom.Location = new System.Drawing.Point(420, 9);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(129, 21);
            this.cmbRoom.TabIndex = 5;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(376, 13);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(38, 13);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room:";
            // 
            // cmbLecturer
            // 
            this.cmbLecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLecturer.FormattingEnabled = true;
            this.cmbLecturer.Items.AddRange(new object[] {
            "All Lecturers",
            "Prof. John Smith",
            "Dr. Maria Garcia",
            "Mr. Robert Johnson",
            "Ms. Sarah Williams"});
            this.cmbLecturer.Location = new System.Drawing.Point(240, 8);
            this.cmbLecturer.Name = "cmbLecturer";
            this.cmbLecturer.Size = new System.Drawing.Size(129, 21);
            this.cmbLecturer.TabIndex = 3;
            // 
            // lblLecturer
            // 
            this.lblLecturer.AutoSize = true;
            this.lblLecturer.Location = new System.Drawing.Point(185, 11);
            this.lblLecturer.Name = "lblLecturer";
            this.lblLecturer.Size = new System.Drawing.Size(49, 13);
            this.lblLecturer.TabIndex = 2;
            this.lblLecturer.Text = "Lecturer:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "All Classes",
            "",
            "BSIT-1A",
            "",
            "BSIT",
            "1B",
            "BSIT-2A",
            "BSCS-1A",
            "BSCS-2A",
            "BSIS-1A"});
            this.cmbClass.Location = new System.Drawing.Point(43, 8);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(103, 21);
            this.cmbClass.TabIndex = 1;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(9, 11);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Class:";
            // 
            // weekNavPanel
            // 
            this.weekNavPanel.Controls.Add(this.btnNextWeek);
            this.weekNavPanel.Controls.Add(this.lblCurrentWeek);
            this.weekNavPanel.Controls.Add(this.btnPrevWeek);
            this.weekNavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.weekNavPanel.Location = new System.Drawing.Point(0, 43);
            this.weekNavPanel.Name = "weekNavPanel";
            this.weekNavPanel.Size = new System.Drawing.Size(686, 35);
            this.weekNavPanel.TabIndex = 1;
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNextWeek.Location = new System.Drawing.Point(557, 4);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(86, 22);
            this.btnNextWeek.TabIndex = 2;
            this.btnNextWeek.Text = "Next Week";
            this.btnNextWeek.UseVisualStyleBackColor = true;
            // 
            // lblCurrentWeek
            // 
            this.lblCurrentWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentWeek.Location = new System.Drawing.Point(257, 4);
            this.lblCurrentWeek.Name = "lblCurrentWeek";
            this.lblCurrentWeek.Size = new System.Drawing.Size(171, 22);
            this.lblCurrentWeek.TabIndex = 1;
            this.lblCurrentWeek.Text = "June 02 - June 06, 2025";
            this.lblCurrentWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.Location = new System.Drawing.Point(43, 4);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(86, 22);
            this.btnPrevWeek.TabIndex = 0;
            this.btnPrevWeek.Text = "Previous Week";
            this.btnPrevWeek.UseVisualStyleBackColor = true;
            // 
            // scheduleGridPanel
            // 
            this.scheduleGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleGridPanel.Location = new System.Drawing.Point(0, 78);
            this.scheduleGridPanel.Name = "scheduleGridPanel";
            this.scheduleGridPanel.Size = new System.Drawing.Size(686, 399);
            this.scheduleGridPanel.TabIndex = 2;
            // 
            // loadingPanel
            // 
            this.loadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingPanel.Controls.Add(this.loadingLabel);
            this.loadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingPanel.Location = new System.Drawing.Point(0, 78);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(686, 399);
            this.loadingPanel.TabIndex = 3;
            this.loadingPanel.Visible = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(300, 173);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(54, 13);
            this.loadingLabel.TabIndex = 0;
            this.loadingLabel.Text = "Loading...";
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.scheduleGridPanel);
            this.Controls.Add(this.weekNavPanel);
            this.Controls.Add(this.filterPanel);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(686, 477);
            this.Load += new System.EventHandler(this.UC_Dashboard_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.weekNavPanel.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            this.loadingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbLecturer;
        private System.Windows.Forms.Label lblLecturer;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Panel weekNavPanel;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Label lblCurrentWeek;
        private System.Windows.Forms.Button btnPrevWeek;
        private System.Windows.Forms.Panel scheduleGridPanel;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ToolTip tooltip;
    }
}