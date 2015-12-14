namespace ChartFlowUI
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddingChartsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.op1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.op2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.ChartConnectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConditionalConnectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.AddingChartsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ChartConnectionMenu.SuspendLayout();
            this.ConditionalConnectionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.ContextMenuStrip = this.AddingChartsMenu;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 475);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // AddingChartsMenu
            // 
            this.AddingChartsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.op1ToolStripMenuItem,
            this.op2ToolStripMenuItem});
            this.AddingChartsMenu.Name = "contextMenuStrip1";
            this.AddingChartsMenu.Size = new System.Drawing.Size(169, 48);
            // 
            // op1ToolStripMenuItem
            // 
            this.op1ToolStripMenuItem.Name = "op1ToolStripMenuItem";
            this.op1ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.op1ToolStripMenuItem.Text = "Conditional Chart";
            this.op1ToolStripMenuItem.Click += new System.EventHandler(this.op1ToolStripMenuItem_Click);
            // 
            // op2ToolStripMenuItem
            // 
            this.op2ToolStripMenuItem.Name = "op2ToolStripMenuItem";
            this.op2ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.op2ToolStripMenuItem.Text = "Standart Chart";
            this.op2ToolStripMenuItem.Click += new System.EventHandler(this.op2ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Chart";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(263, 537);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(789, 537);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Create Simple";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ChartConnectionMenu
            // 
            this.ChartConnectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.ChartConnectionMenu.Name = "contextMenuStrip1";
            this.ChartConnectionMenu.Size = new System.Drawing.Size(162, 26);
            this.ChartConnectionMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ChartConnectionMenu_Opening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "ConnectChartTo";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ConditionalConnectionMenu
            // 
            this.ConditionalConnectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectTrueToolStripMenuItem,
            this.connectFalseToolStripMenuItem});
            this.ConditionalConnectionMenu.Name = "ConditionalConnectionMenu";
            this.ConditionalConnectionMenu.Size = new System.Drawing.Size(149, 48);
            this.ConditionalConnectionMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ConditionalConnectionMenu_Opening);
            // 
            // connectTrueToolStripMenuItem
            // 
            this.connectTrueToolStripMenuItem.Name = "connectTrueToolStripMenuItem";
            this.connectTrueToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.connectTrueToolStripMenuItem.Text = "Connect True";
            this.connectTrueToolStripMenuItem.Click += new System.EventHandler(this.connectTrueToolStripMenuItem_Click);
            // 
            // connectFalseToolStripMenuItem
            // 
            this.connectFalseToolStripMenuItem.Name = "connectFalseToolStripMenuItem";
            this.connectFalseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.connectFalseToolStripMenuItem.Text = "Connect False";
            this.connectFalseToolStripMenuItem.Click += new System.EventHandler(this.connectFalseToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 537);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "FlowChart Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AddingChartsMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ChartConnectionMenu.ResumeLayout(false);
            this.ConditionalConnectionMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip AddingChartsMenu;
        private System.Windows.Forms.ToolStripMenuItem op1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem op2ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ChartConnectionMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip ConditionalConnectionMenu;
        private System.Windows.Forms.ToolStripMenuItem connectTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectFalseToolStripMenuItem;
    }
}

