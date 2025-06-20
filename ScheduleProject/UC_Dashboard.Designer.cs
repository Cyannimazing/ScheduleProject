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
            this.generate_report = new System.Windows.Forms.Button();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbLecturer = new System.Windows.Forms.ComboBox();
            this.lblLecturer = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.scheduleGridPanel = new System.Windows.Forms.Panel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.generate_report);
            this.filterPanel.Controls.Add(this.cmbRoom);
            this.filterPanel.Controls.Add(this.lblRoom);
            this.filterPanel.Controls.Add(this.cmbLecturer);
            this.filterPanel.Controls.Add(this.lblLecturer);
            this.filterPanel.Controls.Add(this.cmbClass);
            this.filterPanel.Controls.Add(this.lblClass);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1143, 83);
            this.filterPanel.TabIndex = 0;
            // 
            // generate_report
            // 
            this.generate_report.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.generate_report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.generate_report.FlatAppearance.BorderSize = 0;
            this.generate_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate_report.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_report.ForeColor = System.Drawing.SystemColors.Control;
            this.generate_report.Location = new System.Drawing.Point(952, 20);
            this.generate_report.Name = "generate_report";
            this.generate_report.Size = new System.Drawing.Size(188, 45);
            this.generate_report.TabIndex = 7;
            this.generate_report.Text = "Generate Report";
            this.generate_report.UseVisualStyleBackColor = false;
            this.generate_report.Click += new System.EventHandler(this.generate_report_Click);
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(563, 29);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(177, 29);
            this.cmbRoom.TabIndex = 5;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRoom.Location = new System.Drawing.Point(502, 32);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(55, 21);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room:";
            // 
            // cmbLecturer
            // 
            this.cmbLecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLecturer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbLecturer.FormattingEnabled = true;
            this.cmbLecturer.Location = new System.Drawing.Point(79, 29);
            this.cmbLecturer.Name = "cmbLecturer";
            this.cmbLecturer.Size = new System.Drawing.Size(177, 29);
            this.cmbLecturer.TabIndex = 3;
            // 
            // lblLecturer
            // 
            this.lblLecturer.AutoSize = true;
            this.lblLecturer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLecturer.Location = new System.Drawing.Point(3, 32);
            this.lblLecturer.Name = "lblLecturer";
            this.lblLecturer.Size = new System.Drawing.Size(70, 21);
            this.lblLecturer.TabIndex = 2;
            this.lblLecturer.Text = "Lecturer:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(318, 29);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(177, 29);
            this.cmbClass.TabIndex = 1;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblClass.Location = new System.Drawing.Point(263, 32);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(49, 21);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Class:";
            // 
            // scheduleGridPanel
            // 
            this.scheduleGridPanel.AutoScroll = true;
            this.scheduleGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleGridPanel.Location = new System.Drawing.Point(0, 83);
            this.scheduleGridPanel.Name = "scheduleGridPanel";
            this.scheduleGridPanel.Size = new System.Drawing.Size(1143, 462);
            this.scheduleGridPanel.TabIndex = 2;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scheduleGridPanel);
            this.Controls.Add(this.filterPanel);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1143, 545);
            this.Load += new System.EventHandler(this.UC_Dashboard_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button generate_report;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbLecturer;
        private System.Windows.Forms.Label lblLecturer;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Panel scheduleGridPanel;
        private System.Windows.Forms.ToolTip tooltip;
    }
}