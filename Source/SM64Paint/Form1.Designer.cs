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
            this.RGBPalette = new System.Windows.Forms.PictureBox();
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
            this.AlphaPalette = new System.Windows.Forms.PictureBox();
            this.ViewNonRGBA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.VertexRGBA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGBPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).BeginInit();
            this.groupBoxForce.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaPalette)).BeginInit();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1289, 42);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openBinToolStripMenuItem
            // 
            this.openBinToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.openBinToolStripMenuItem.Name = "openBinToolStripMenuItem";
            this.openBinToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.openBinToolStripMenuItem.Text = "Open ROM";
            this.openBinToolStripMenuItem.Click += new System.EventHandler(this.OpenROM_Click);
            // 
            // SaveROMAs
            // 
            this.SaveROMAs.BackColor = System.Drawing.Color.Silver;
            this.SaveROMAs.Enabled = false;
            this.SaveROMAs.Name = "SaveROMAs";
            this.SaveROMAs.Size = new System.Drawing.Size(242, 34);
            this.SaveROMAs.Text = "Save ROM as...";
            this.SaveROMAs.Click += new System.EventHandler(this.SaveROMAs_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdgesOption,
            this.ViewNonRGBA});
            this.ViewMenu.ForeColor = System.Drawing.Color.Silver;
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(69, 34);
            this.ViewMenu.Text = "View";
            this.ViewMenu.Visible = false;
            // 
            // EdgesOption
            // 
            this.EdgesOption.BackColor = System.Drawing.Color.Silver;
            this.EdgesOption.Name = "EdgesOption";
            this.EdgesOption.Size = new System.Drawing.Size(279, 34);
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
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.Color.Silver;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(239, 34);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // RenderPanel
            // 
            this.RenderPanel.AutoSize = true;
            this.RenderPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RenderPanel.BackColor = System.Drawing.Color.Black;
            this.RenderPanel.Location = new System.Drawing.Point(0, 44);
            this.RenderPanel.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.RenderPanel.MaximumSize = new System.Drawing.Size(7040, 3988);
            this.RenderPanel.MinimumSize = new System.Drawing.Size(1019, 720);
            this.RenderPanel.Name = "RenderPanel";
            this.RenderPanel.Size = new System.Drawing.Size(1019, 720);
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
            this.LevelComboBox.Location = new System.Drawing.Point(631, 6);
            this.LevelComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(506, 32);
            this.LevelComboBox.TabIndex = 5;
            this.LevelComboBox.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChange);
            // 
            // LevelLabel
            // 
            this.LevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.LevelLabel.ForeColor = System.Drawing.Color.Silver;
            this.LevelLabel.Location = new System.Drawing.Point(565, 9);
            this.LevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(65, 25);
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
            this.AreaComboBox.Location = new System.Drawing.Point(1212, 6);
            this.AreaComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AreaComboBox.Name = "AreaComboBox";
            this.AreaComboBox.Size = new System.Drawing.Size(55, 32);
            this.AreaComboBox.TabIndex = 7;
            this.AreaComboBox.SelectedIndexChanged += new System.EventHandler(this.LevelArea_SelectedIndexChange);
            // 
            // AreaLabel
            // 
            this.AreaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.AreaLabel.ForeColor = System.Drawing.Color.Silver;
            this.AreaLabel.Location = new System.Drawing.Point(1148, 9);
            this.AreaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(60, 25);
            this.AreaLabel.TabIndex = 8;
            this.AreaLabel.Text = "Area:";
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ControlPanel.Controls.Add(this.VertexRGBA);
            this.ControlPanel.Controls.Add(this.groupBoxForce);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(996, 42);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(293, 746);
            this.ControlPanel.TabIndex = 9;
            this.ControlPanel.Visible = false;
            // 
            // VertexRGBA
            // 
            this.VertexRGBA.Controls.Add(this.AlphaPalette);
            this.VertexRGBA.Controls.Add(this.RGBPalette);
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
            this.VertexRGBA.Location = new System.Drawing.Point(15, 166);
            this.VertexRGBA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VertexRGBA.Name = "VertexRGBA";
            this.VertexRGBA.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VertexRGBA.Size = new System.Drawing.Size(266, 576);
            this.VertexRGBA.TabIndex = 4;
            this.VertexRGBA.TabStop = false;
            this.VertexRGBA.Text = "Vertex RGBA";
            // 
            // RGBPalette
            // 
            this.RGBPalette.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RGBPalette.Image = ((System.Drawing.Image)(resources.GetObject("RGBPalette.Image")));
            this.RGBPalette.Location = new System.Drawing.Point(6, 28);
            this.RGBPalette.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RGBPalette.Name = "RGBPalette";
            this.RGBPalette.Size = new System.Drawing.Size(257, 164);
            this.RGBPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RGBPalette.TabIndex = 9;
            this.RGBPalette.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(83, 422);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 63);
            this.button2.TabIndex = 8;
            this.button2.Text = "Apply as base coat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlphaNum
            // 
            this.AlphaNum.BackColor = System.Drawing.Color.DarkGray;
            this.AlphaNum.Location = new System.Drawing.Point(138, 373);
            this.AlphaNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlphaNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AlphaNum.Name = "AlphaNum";
            this.AlphaNum.Size = new System.Drawing.Size(73, 29);
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
            this.BlueNum.Location = new System.Drawing.Point(138, 345);
            this.BlueNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BlueNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueNum.Name = "BlueNum";
            this.BlueNum.Size = new System.Drawing.Size(73, 29);
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
            this.GreenNum.Location = new System.Drawing.Point(138, 315);
            this.GreenNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GreenNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenNum.Name = "GreenNum";
            this.GreenNum.Size = new System.Drawing.Size(73, 29);
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
            this.RedNum.Location = new System.Drawing.Point(138, 286);
            this.RedNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RedNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedNum.Name = "RedNum";
            this.RedNum.Size = new System.Drawing.Size(73, 29);
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
            this.AlphaLabel.Location = new System.Drawing.Point(59, 373);
            this.AlphaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(69, 25);
            this.AlphaLabel.TabIndex = 3;
            this.AlphaLabel.Text = "Alpha:";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.BlueLabel.Location = new System.Drawing.Point(59, 345);
            this.BlueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(57, 25);
            this.BlueLabel.TabIndex = 2;
            this.BlueLabel.Text = "Blue:";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.GreenLabel.Location = new System.Drawing.Point(59, 315);
            this.GreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(72, 25);
            this.GreenLabel.TabIndex = 1;
            this.GreenLabel.Text = "Green:";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RedLabel.Location = new System.Drawing.Point(59, 286);
            this.RedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(53, 25);
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
            this.groupBoxForce.Location = new System.Drawing.Point(15, 22);
            this.groupBoxForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxForce.Name = "groupBoxForce";
            this.groupBoxForce.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxForce.Size = new System.Drawing.Size(268, 138);
            this.groupBoxForce.TabIndex = 3;
            this.groupBoxForce.TabStop = false;
            this.groupBoxForce.Text = "Attempt VertRGBA";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(46, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "Force VNorm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ForceOpaqueRGBA
            // 
            this.ForceOpaqueRGBA.AutoSize = true;
            this.ForceOpaqueRGBA.Checked = true;
            this.ForceOpaqueRGBA.Location = new System.Drawing.Point(35, 28);
            this.ForceOpaqueRGBA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ForceOpaqueRGBA.Name = "ForceOpaqueRGBA";
            this.ForceOpaqueRGBA.Size = new System.Drawing.Size(92, 24);
            this.ForceOpaqueRGBA.TabIndex = 1;
            this.ForceOpaqueRGBA.TabStop = true;
            this.ForceOpaqueRGBA.Text = "Opaque";
            this.ForceOpaqueRGBA.UseVisualStyleBackColor = true;
            // 
            // ForceAlphaRGBA
            // 
            this.ForceAlphaRGBA.AutoSize = true;
            this.ForceAlphaRGBA.Location = new System.Drawing.Point(149, 28);
            this.ForceAlphaRGBA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ForceAlphaRGBA.Name = "ForceAlphaRGBA";
            this.ForceAlphaRGBA.Size = new System.Drawing.Size(76, 24);
            this.ForceAlphaRGBA.TabIndex = 2;
            this.ForceAlphaRGBA.Text = "Alpha";
            this.ForceAlphaRGBA.UseVisualStyleBackColor = true;
            // 
            // ForceVertRGBAButton
            // 
            this.ForceVertRGBAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForceVertRGBAButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ForceVertRGBAButton.Location = new System.Drawing.Point(149, 57);
            this.ForceVertRGBAButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ForceVertRGBAButton.Name = "ForceVertRGBAButton";
            this.ForceVertRGBAButton.Size = new System.Drawing.Size(84, 63);
            this.ForceVertRGBAButton.TabIndex = 0;
            this.ForceVertRGBAButton.Text = "Force RGBA";
            this.ForceVertRGBAButton.UseVisualStyleBackColor = true;
            this.ForceVertRGBAButton.Click += new System.EventHandler(this.ForceVertRGBAButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(69, 30);
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 788);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1289, 35);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // AlphaPalette
            // 
            this.AlphaPalette.Cursor = System.Windows.Forms.Cursors.Cross;
            this.AlphaPalette.Image = ((System.Drawing.Image)(resources.GetObject("AlphaPalette.Image")));
            this.AlphaPalette.Location = new System.Drawing.Point(6, 203);
            this.AlphaPalette.Margin = new System.Windows.Forms.Padding(4);
            this.AlphaPalette.Name = "AlphaPalette";
            this.AlphaPalette.Size = new System.Drawing.Size(257, 65);
            this.AlphaPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlphaPalette.TabIndex = 10;
            this.AlphaPalette.TabStop = false;
            // 
            // ViewNonRGBA
            // 
            this.ViewNonRGBA.BackColor = System.Drawing.Color.Silver;
            this.ViewNonRGBA.Checked = true;
            this.ViewNonRGBA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewNonRGBA.Name = "ViewNonRGBA";
            this.ViewNonRGBA.Size = new System.Drawing.Size(279, 34);
            this.ViewNonRGBA.Text = "Non-RGBA Models";
            this.ViewNonRGBA.Click += new System.EventHandler(this.nonRGBAModelsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1289, 823);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1298, 841);
            this.Name = "Form1";
            this.Text = "SM64Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.VertexRGBA.ResumeLayout(false);
            this.VertexRGBA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGBPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).EndInit();
            this.groupBoxForce.ResumeLayout(false);
            this.groupBoxForce.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaPalette)).EndInit();
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
        private System.Windows.Forms.PictureBox RGBPalette;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem EdgesOption;
        private System.Windows.Forms.PictureBox AlphaPalette;
        private System.Windows.Forms.ToolStripMenuItem ViewNonRGBA;
    }
}

