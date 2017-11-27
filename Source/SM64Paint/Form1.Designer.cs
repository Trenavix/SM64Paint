namespace SM64Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveROMAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderPanel = new OpenTK.GLControl();
            this.LevelComboBox = new System.Windows.Forms.ComboBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.VertexRGBA = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.AlphaNum = new System.Windows.Forms.NumericUpDown();
            this.BlueNum = new System.Windows.Forms.NumericUpDown();
            this.GreenNum = new System.Windows.Forms.NumericUpDown();
            this.RedNum = new System.Windows.Forms.NumericUpDown();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            this.groupBoxForce = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ForceOpaqueRGBA = new System.Windows.Forms.RadioButton();
            this.ForceAlphaRGBA = new System.Windows.Forms.RadioButton();
            this.ForceVertRGBAButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.VertexRGBA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).BeginInit();
            this.groupBoxForce.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ViewMenu,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBinToolStripMenuItem,
            this.SaveROMAs});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openBinToolStripMenuItem
            // 
            this.openBinToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.openBinToolStripMenuItem.Name = "openBinToolStripMenuItem";
            this.openBinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openBinToolStripMenuItem.Text = "Open ROM";
            this.openBinToolStripMenuItem.Click += new System.EventHandler(this.OpenROM_Click);
            // 
            // SaveROMAs
            // 
            this.SaveROMAs.BackColor = System.Drawing.Color.Silver;
            this.SaveROMAs.Enabled = false;
            this.SaveROMAs.Name = "SaveROMAs";
            this.SaveROMAs.Size = new System.Drawing.Size(152, 22);
            this.SaveROMAs.Text = "Save ROM as...";
            this.SaveROMAs.Click += new System.EventHandler(this.SaveROMAs_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdgesOption});
            this.ViewMenu.ForeColor = System.Drawing.Color.Silver;
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "View";
            this.ViewMenu.Visible = false;
            // 
            // EdgesOption
            // 
            this.EdgesOption.BackColor = System.Drawing.Color.Silver;
            this.EdgesOption.Name = "EdgesOption";
            this.EdgesOption.Size = new System.Drawing.Size(152, 22);
            this.EdgesOption.Text = "Edges";
            this.EdgesOption.Click += new System.EventHandler(this.EdgesOption_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.Color.Silver;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // RenderPanel
            // 
            this.RenderPanel.AutoSize = true;
            this.RenderPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RenderPanel.BackColor = System.Drawing.Color.Black;
            this.RenderPanel.Location = new System.Drawing.Point(0, 24);
            this.RenderPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RenderPanel.MaximumSize = new System.Drawing.Size(3840, 2160);
            this.RenderPanel.MinimumSize = new System.Drawing.Size(556, 390);
            this.RenderPanel.Name = "RenderPanel";
            this.RenderPanel.Size = new System.Drawing.Size(556, 390);
            this.RenderPanel.TabIndex = 4;
            this.RenderPanel.VSync = true;
            this.RenderPanel.Load += new System.EventHandler(this.panel1_Load);
            this.RenderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderPanel_Paint);
            // 
            // LevelComboBox
            // 
            this.LevelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelComboBox.Enabled = false;
            this.LevelComboBox.ForeColor = System.Drawing.Color.Silver;
            this.LevelComboBox.FormattingEnabled = true;
            this.LevelComboBox.Location = new System.Drawing.Point(344, 3);
            this.LevelComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(278, 21);
            this.LevelComboBox.TabIndex = 5;
            this.LevelComboBox.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChange);
            // 
            // LevelLabel
            // 
            this.LevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.LevelLabel.ForeColor = System.Drawing.Color.Silver;
            this.LevelLabel.Location = new System.Drawing.Point(308, 5);
            this.LevelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(36, 13);
            this.LevelLabel.TabIndex = 6;
            this.LevelLabel.Text = "Level:";
            // 
            // AreaComboBox
            // 
            this.AreaComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AreaComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AreaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaComboBox.Enabled = false;
            this.AreaComboBox.ForeColor = System.Drawing.Color.Silver;
            this.AreaComboBox.FormattingEnabled = true;
            this.AreaComboBox.Location = new System.Drawing.Point(661, 3);
            this.AreaComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AreaComboBox.Name = "AreaComboBox";
            this.AreaComboBox.Size = new System.Drawing.Size(32, 21);
            this.AreaComboBox.TabIndex = 7;
            this.AreaComboBox.SelectedIndexChanged += new System.EventHandler(this.LevelArea_SelectedIndexChange);
            // 
            // AreaLabel
            // 
            this.AreaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.AreaLabel.ForeColor = System.Drawing.Color.Silver;
            this.AreaLabel.Location = new System.Drawing.Point(626, 5);
            this.AreaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(32, 13);
            this.AreaLabel.TabIndex = 8;
            this.AreaLabel.Text = "Area:";
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ControlPanel.Controls.Add(this.VertexRGBA);
            this.ControlPanel.Controls.Add(this.groupBoxForce);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(543, 24);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(160, 400);
            this.ControlPanel.TabIndex = 9;
            this.ControlPanel.Visible = false;
            // 
            // VertexRGBA
            // 
            this.VertexRGBA.Controls.Add(this.pictureBox1);
            this.VertexRGBA.Controls.Add(this.button2);
            this.VertexRGBA.Controls.Add(this.AlphaNum);
            this.VertexRGBA.Controls.Add(this.BlueNum);
            this.VertexRGBA.Controls.Add(this.GreenNum);
            this.VertexRGBA.Controls.Add(this.RedNum);
            this.VertexRGBA.Controls.Add(this.AlphaLabel);
            this.VertexRGBA.Controls.Add(this.BlueLabel);
            this.VertexRGBA.Controls.Add(this.GreenLabel);
            this.VertexRGBA.Controls.Add(this.RedLabel);
            this.VertexRGBA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.VertexRGBA.Location = new System.Drawing.Point(8, 90);
            this.VertexRGBA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VertexRGBA.Name = "VertexRGBA";
            this.VertexRGBA.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VertexRGBA.Size = new System.Drawing.Size(145, 282);
            this.VertexRGBA.TabIndex = 4;
            this.VertexRGBA.TabStop = false;
            this.VertexRGBA.Text = "Vertex RGBA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(45, 238);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Apply as base coat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlphaNum
            // 
            this.AlphaNum.BackColor = System.Drawing.Color.DarkGray;
            this.AlphaNum.Location = new System.Drawing.Point(75, 211);
            this.AlphaNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AlphaNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AlphaNum.Name = "AlphaNum";
            this.AlphaNum.Size = new System.Drawing.Size(40, 20);
            this.AlphaNum.TabIndex = 7;
            this.AlphaNum.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // BlueNum
            // 
            this.BlueNum.BackColor = System.Drawing.Color.DarkGray;
            this.BlueNum.Location = new System.Drawing.Point(75, 196);
            this.BlueNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BlueNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueNum.Name = "BlueNum";
            this.BlueNum.Size = new System.Drawing.Size(40, 20);
            this.BlueNum.TabIndex = 6;
            this.BlueNum.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // GreenNum
            // 
            this.GreenNum.BackColor = System.Drawing.Color.DarkGray;
            this.GreenNum.Location = new System.Drawing.Point(75, 180);
            this.GreenNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GreenNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenNum.Name = "GreenNum";
            this.GreenNum.Size = new System.Drawing.Size(40, 20);
            this.GreenNum.TabIndex = 5;
            this.GreenNum.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // RedNum
            // 
            this.RedNum.BackColor = System.Drawing.Color.DarkGray;
            this.RedNum.Location = new System.Drawing.Point(75, 164);
            this.RedNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RedNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedNum.Name = "RedNum";
            this.RedNum.Size = new System.Drawing.Size(40, 20);
            this.RedNum.TabIndex = 4;
            this.RedNum.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.ForeColor = System.Drawing.Color.Silver;
            this.AlphaLabel.Location = new System.Drawing.Point(32, 211);
            this.AlphaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(37, 13);
            this.AlphaLabel.TabIndex = 3;
            this.AlphaLabel.Text = "Alpha:";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.BlueLabel.Location = new System.Drawing.Point(32, 196);
            this.BlueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(31, 13);
            this.BlueLabel.TabIndex = 2;
            this.BlueLabel.Text = "Blue:";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.GreenLabel.Location = new System.Drawing.Point(32, 180);
            this.GreenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(39, 13);
            this.GreenLabel.TabIndex = 1;
            this.GreenLabel.Text = "Green:";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RedLabel.Location = new System.Drawing.Point(32, 164);
            this.RedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(30, 13);
            this.RedLabel.TabIndex = 0;
            this.RedLabel.Text = "Red:";
            // 
            // groupBoxForce
            // 
            this.groupBoxForce.Controls.Add(this.button1);
            this.groupBoxForce.Controls.Add(this.ForceOpaqueRGBA);
            this.groupBoxForce.Controls.Add(this.ForceAlphaRGBA);
            this.groupBoxForce.Controls.Add(this.ForceVertRGBAButton);
            this.groupBoxForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxForce.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxForce.Location = new System.Drawing.Point(8, 12);
            this.groupBoxForce.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxForce.Name = "groupBoxForce";
            this.groupBoxForce.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxForce.Size = new System.Drawing.Size(146, 75);
            this.groupBoxForce.TabIndex = 3;
            this.groupBoxForce.TabStop = false;
            this.groupBoxForce.Text = "Attempt VertRGBA";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(25, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Force VNorm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ForceOpaqueRGBA
            // 
            this.ForceOpaqueRGBA.AutoSize = true;
            this.ForceOpaqueRGBA.Checked = true;
            this.ForceOpaqueRGBA.Location = new System.Drawing.Point(19, 15);
            this.ForceOpaqueRGBA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ForceOpaqueRGBA.Name = "ForceOpaqueRGBA";
            this.ForceOpaqueRGBA.Size = new System.Drawing.Size(63, 17);
            this.ForceOpaqueRGBA.TabIndex = 1;
            this.ForceOpaqueRGBA.TabStop = true;
            this.ForceOpaqueRGBA.Text = "Opaque";
            this.ForceOpaqueRGBA.UseVisualStyleBackColor = true;
            // 
            // ForceAlphaRGBA
            // 
            this.ForceAlphaRGBA.AutoSize = true;
            this.ForceAlphaRGBA.Location = new System.Drawing.Point(81, 15);
            this.ForceAlphaRGBA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ForceAlphaRGBA.Name = "ForceAlphaRGBA";
            this.ForceAlphaRGBA.Size = new System.Drawing.Size(52, 17);
            this.ForceAlphaRGBA.TabIndex = 2;
            this.ForceAlphaRGBA.Text = "Alpha";
            this.ForceAlphaRGBA.UseVisualStyleBackColor = true;
            // 
            // ForceVertRGBAButton
            // 
            this.ForceVertRGBAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForceVertRGBAButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ForceVertRGBAButton.Location = new System.Drawing.Point(81, 31);
            this.ForceVertRGBAButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ForceVertRGBAButton.Name = "ForceVertRGBAButton";
            this.ForceVertRGBAButton.Size = new System.Drawing.Size(46, 34);
            this.ForceVertRGBAButton.TabIndex = 0;
            this.ForceVertRGBAButton.Text = "Force RGBA";
            this.ForceVertRGBAButton.UseVisualStyleBackColor = true;
            this.ForceVertRGBAButton.Click += new System.EventHandler(this.ForceVertRGBAButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 17);
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(703, 446);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.AreaLabel);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.LevelComboBox);
            this.Controls.Add(this.RenderPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(719, 485);
            this.Name = "Form1";
            this.Text = "SM64Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.VertexRGBA.ResumeLayout(false);
            this.VertexRGBA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).EndInit();
            this.groupBoxForce.ResumeLayout(false);
            this.groupBoxForce.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveROMAs;
        private OpenTK.GLControl RenderPanel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ComboBox LevelComboBox;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.ComboBox AreaComboBox;
        private System.Windows.Forms.Label AreaLabel;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button ForceVertRGBAButton;
        private System.Windows.Forms.GroupBox groupBoxForce;
        private System.Windows.Forms.RadioButton ForceOpaqueRGBA;
        private System.Windows.Forms.RadioButton ForceAlphaRGBA;
        private System.Windows.Forms.GroupBox VertexRGBA;
        private System.Windows.Forms.NumericUpDown AlphaNum;
        private System.Windows.Forms.NumericUpDown BlueNum;
        private System.Windows.Forms.NumericUpDown GreenNum;
        private System.Windows.Forms.NumericUpDown RedNum;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem EdgesOption;
    }
}

