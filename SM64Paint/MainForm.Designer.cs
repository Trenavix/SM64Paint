﻿namespace SM64Paint
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveROMAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewNonRGBA = new System.Windows.Forms.ToolStripMenuItem();
            this.CullingOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectModelEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderPanel = new OpenTK.GLControl();
            this.LevelComboBox = new System.Windows.Forms.ComboBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveEnvColoursButton = new System.Windows.Forms.Button();
            this.LayersGroupBox = new System.Windows.Forms.GroupBox();
            this.Layer1To4Button = new System.Windows.Forms.Button();
            this.Layer4To5Button = new System.Windows.Forms.Button();
            this.TexturesGroupBox = new System.Windows.Forms.GroupBox();
            this.FlipYCheckBox = new System.Windows.Forms.CheckBox();
            this.CentreU = new System.Windows.Forms.Button();
            this.CentreV = new System.Windows.Forms.Button();
            this.ImportTexture = new System.Windows.Forms.Button();
            this.BitsizeBox = new System.Windows.Forms.ComboBox();
            this.TexFormatBox = new System.Windows.Forms.ComboBox();
            this.TPropertiesBox = new System.Windows.Forms.ComboBox();
            this.SPropertiesBox = new System.Windows.Forms.ComboBox();
            this.TextureNumBox = new System.Windows.Forms.ComboBox();
            this.TexturePreview = new System.Windows.Forms.PictureBox();
            this.TextureResLabel = new System.Windows.Forms.Label();
            this.VertexRGBA = new System.Windows.Forms.GroupBox();
            this.PalettePanel = new System.Windows.Forms.Panel();
            this.PaletteBox9 = new System.Windows.Forms.PictureBox();
            this.PaletteBox1 = new System.Windows.Forms.PictureBox();
            this.PaletteBox2 = new System.Windows.Forms.PictureBox();
            this.PaletteBox16 = new System.Windows.Forms.PictureBox();
            this.PaletteBox3 = new System.Windows.Forms.PictureBox();
            this.PaletteBox15 = new System.Windows.Forms.PictureBox();
            this.PaletteBox4 = new System.Windows.Forms.PictureBox();
            this.PaletteBox14 = new System.Windows.Forms.PictureBox();
            this.PaletteBox5 = new System.Windows.Forms.PictureBox();
            this.PaletteBox13 = new System.Windows.Forms.PictureBox();
            this.PaletteBox6 = new System.Windows.Forms.PictureBox();
            this.PaletteBox12 = new System.Windows.Forms.PictureBox();
            this.PaletteBox7 = new System.Windows.Forms.PictureBox();
            this.PaletteBox11 = new System.Windows.Forms.PictureBox();
            this.PaletteBox8 = new System.Windows.Forms.PictureBox();
            this.PaletteBox10 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AlphaOnlyCheckbox = new System.Windows.Forms.CheckBox();
            this.ColourPreview = new System.Windows.Forms.PictureBox();
            this.DarkLabel = new System.Windows.Forms.Label();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AlphaPalette = new System.Windows.Forms.PictureBox();
            this.RGBPalette = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.AlphaNum = new System.Windows.Forms.NumericUpDown();
            this.BlueNum = new System.Windows.Forms.NumericUpDown();
            this.GreenNum = new System.Windows.Forms.NumericUpDown();
            this.RedNum = new System.Windows.Forms.NumericUpDown();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.Brightness = new System.Windows.Forms.TrackBar();
            this.BrightLabel = new System.Windows.Forms.Label();
            this.groupBoxForce = new System.Windows.Forms.GroupBox();
            this.ForceOpaqueRGBA = new System.Windows.Forms.RadioButton();
            this.ForceAlphaRGBA = new System.Windows.Forms.RadioButton();
            this.ForceVertRGBAButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.RightClickTexture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveTextureAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectIDLabel = new System.Windows.Forms.Label();
            this.ObjectList = new System.Windows.Forms.ComboBox();
            this.SegmentLabel = new System.Windows.Forms.Label();
            this.SegmentList = new System.Windows.Forms.ComboBox();
            this.EnvColoursTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LayersGroupBox.SuspendLayout();
            this.TexturesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePreview)).BeginInit();
            this.VertexRGBA.SuspendLayout();
            this.PalettePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).BeginInit();
            this.groupBoxForce.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.RightClickTexture.SuspendLayout();
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
            this.openBinToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openBinToolStripMenuItem.Text = "Open ROM";
            this.openBinToolStripMenuItem.Click += new System.EventHandler(this.OpenROM_Click);
            // 
            // SaveROMAs
            // 
            this.SaveROMAs.BackColor = System.Drawing.Color.Silver;
            this.SaveROMAs.Enabled = false;
            this.SaveROMAs.Name = "SaveROMAs";
            this.SaveROMAs.Size = new System.Drawing.Size(151, 22);
            this.SaveROMAs.Text = "Save ROM as...";
            this.SaveROMAs.Click += new System.EventHandler(this.SaveROMAs_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdgesOption,
            this.ViewNonRGBA,
            this.CullingOption,
            this.ObjectModelEditor});
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
            this.EdgesOption.Size = new System.Drawing.Size(180, 22);
            this.EdgesOption.Text = "Edges";
            this.EdgesOption.Click += new System.EventHandler(this.EdgesOption_Click);
            // 
            // ViewNonRGBA
            // 
            this.ViewNonRGBA.BackColor = System.Drawing.Color.Silver;
            this.ViewNonRGBA.Checked = true;
            this.ViewNonRGBA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewNonRGBA.Name = "ViewNonRGBA";
            this.ViewNonRGBA.Size = new System.Drawing.Size(180, 22);
            this.ViewNonRGBA.Text = "Non-RGBA Models";
            this.ViewNonRGBA.Click += new System.EventHandler(this.nonRGBAModelsToolStripMenuItem_Click);
            // 
            // CullingOption
            // 
            this.CullingOption.BackColor = System.Drawing.Color.Silver;
            this.CullingOption.Checked = true;
            this.CullingOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CullingOption.Name = "CullingOption";
            this.CullingOption.Size = new System.Drawing.Size(180, 22);
            this.CullingOption.Text = "Culling";
            this.CullingOption.Click += new System.EventHandler(this.CullingOptionClick);
            // 
            // ObjectModelEditor
            // 
            this.ObjectModelEditor.BackColor = System.Drawing.Color.Silver;
            this.ObjectModelEditor.Name = "ObjectModelEditor";
            this.ObjectModelEditor.Size = new System.Drawing.Size(180, 22);
            this.ObjectModelEditor.Text = "Object Model Editor";
            this.ObjectModelEditor.Visible = false;
            this.ObjectModelEditor.Click += new System.EventHandler(this.objectModelEditor_Click);
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
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.Color.Silver;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // RenderPanel
            // 
            this.RenderPanel.AutoSize = true;
            this.RenderPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RenderPanel.BackColor = System.Drawing.Color.Black;
            this.RenderPanel.Location = new System.Drawing.Point(0, 24);
            this.RenderPanel.Margin = new System.Windows.Forms.Padding(6);
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
            this.LevelComboBox.Location = new System.Drawing.Point(423, 2);
            this.LevelComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(199, 21);
            this.LevelComboBox.TabIndex = 5;
            this.LevelComboBox.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChange);
            // 
            // LevelLabel
            // 
            this.LevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.LevelLabel.ForeColor = System.Drawing.Color.Silver;
            this.LevelLabel.Location = new System.Drawing.Point(381, 5);
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
            this.AreaComboBox.Location = new System.Drawing.Point(661, 2);
            this.AreaComboBox.Margin = new System.Windows.Forms.Padding(2);
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
            this.ControlPanel.AutoScroll = true;
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ControlPanel.Controls.Add(this.groupBox1);
            this.ControlPanel.Controls.Add(this.LayersGroupBox);
            this.ControlPanel.Controls.Add(this.TexturesGroupBox);
            this.ControlPanel.Controls.Add(this.VertexRGBA);
            this.ControlPanel.Controls.Add(this.groupBoxForce);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(528, 24);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(175, 400);
            this.ControlPanel.TabIndex = 9;
            this.ControlPanel.Visible = false;
            this.ControlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPanel_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveEnvColoursButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(8, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 49);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove Env Colour";
            // 
            // RemoveEnvColoursButton
            // 
            this.RemoveEnvColoursButton.ForeColor = System.Drawing.Color.Black;
            this.RemoveEnvColoursButton.Location = new System.Drawing.Point(10, 18);
            this.RemoveEnvColoursButton.Name = "RemoveEnvColoursButton";
            this.RemoveEnvColoursButton.Size = new System.Drawing.Size(128, 23);
            this.RemoveEnvColoursButton.TabIndex = 0;
            this.RemoveEnvColoursButton.Text = "Remove Env Colours";
            this.RemoveEnvColoursButton.UseVisualStyleBackColor = true;
            this.RemoveEnvColoursButton.Click += new System.EventHandler(this.RemoveEnvColoursButton_Click);
            // 
            // LayersGroupBox
            // 
            this.LayersGroupBox.Controls.Add(this.Layer1To4Button);
            this.LayersGroupBox.Controls.Add(this.Layer4To5Button);
            this.LayersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayersGroupBox.ForeColor = System.Drawing.Color.Silver;
            this.LayersGroupBox.Location = new System.Drawing.Point(8, 285);
            this.LayersGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.LayersGroupBox.Name = "LayersGroupBox";
            this.LayersGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.LayersGroupBox.Size = new System.Drawing.Size(146, 42);
            this.LayersGroupBox.TabIndex = 4;
            this.LayersGroupBox.TabStop = false;
            this.LayersGroupBox.Text = "Force Layers";
            // 
            // Layer1To4Button
            // 
            this.Layer1To4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Layer1To4Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Layer1To4Button.Location = new System.Drawing.Point(3, 16);
            this.Layer1To4Button.Margin = new System.Windows.Forms.Padding(2);
            this.Layer1To4Button.Name = "Layer1To4Button";
            this.Layer1To4Button.Size = new System.Drawing.Size(71, 19);
            this.Layer1To4Button.TabIndex = 1;
            this.Layer1To4Button.Text = "Force 1 to 4";
            this.Layer1To4Button.UseVisualStyleBackColor = true;
            this.Layer1To4Button.Click += new System.EventHandler(this.Layer1To4Button_Click);
            // 
            // Layer4To5Button
            // 
            this.Layer4To5Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Layer4To5Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Layer4To5Button.Location = new System.Drawing.Point(72, 16);
            this.Layer4To5Button.Margin = new System.Windows.Forms.Padding(2);
            this.Layer4To5Button.Name = "Layer4To5Button";
            this.Layer4To5Button.Size = new System.Drawing.Size(71, 19);
            this.Layer4To5Button.TabIndex = 0;
            this.Layer4To5Button.Text = "Force 4 to 5";
            this.Layer4To5Button.UseVisualStyleBackColor = true;
            this.Layer4To5Button.Click += new System.EventHandler(this.Layer4To5Button_Click);
            // 
            // TexturesGroupBox
            // 
            this.TexturesGroupBox.Controls.Add(this.FlipYCheckBox);
            this.TexturesGroupBox.Controls.Add(this.CentreU);
            this.TexturesGroupBox.Controls.Add(this.CentreV);
            this.TexturesGroupBox.Controls.Add(this.ImportTexture);
            this.TexturesGroupBox.Controls.Add(this.BitsizeBox);
            this.TexturesGroupBox.Controls.Add(this.TexFormatBox);
            this.TexturesGroupBox.Controls.Add(this.TPropertiesBox);
            this.TexturesGroupBox.Controls.Add(this.SPropertiesBox);
            this.TexturesGroupBox.Controls.Add(this.TextureNumBox);
            this.TexturesGroupBox.Controls.Add(this.TexturePreview);
            this.TexturesGroupBox.Controls.Add(this.TextureResLabel);
            this.TexturesGroupBox.ForeColor = System.Drawing.Color.Silver;
            this.TexturesGroupBox.Location = new System.Drawing.Point(8, 386);
            this.TexturesGroupBox.Name = "TexturesGroupBox";
            this.TexturesGroupBox.Size = new System.Drawing.Size(146, 173);
            this.TexturesGroupBox.TabIndex = 5;
            this.TexturesGroupBox.TabStop = false;
            this.TexturesGroupBox.Text = "Textures";
            // 
            // FlipYCheckBox
            // 
            this.FlipYCheckBox.AutoSize = true;
            this.FlipYCheckBox.Checked = true;
            this.FlipYCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FlipYCheckBox.Location = new System.Drawing.Point(80, 122);
            this.FlipYCheckBox.Name = "FlipYCheckBox";
            this.FlipYCheckBox.Size = new System.Drawing.Size(52, 17);
            this.FlipYCheckBox.TabIndex = 8;
            this.FlipYCheckBox.Text = "Flip Y";
            this.FlipYCheckBox.UseVisualStyleBackColor = true;
            this.FlipYCheckBox.CheckedChanged += new System.EventHandler(this.FlipYCheckBox_CheckedChanged);
            // 
            // CentreU
            // 
            this.CentreU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CentreU.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CentreU.Location = new System.Drawing.Point(10, 146);
            this.CentreU.Margin = new System.Windows.Forms.Padding(2);
            this.CentreU.Name = "CentreU";
            this.CentreU.Size = new System.Drawing.Size(57, 19);
            this.CentreU.TabIndex = 1;
            this.CentreU.Text = "Centre U";
            this.CentreU.UseVisualStyleBackColor = true;
            this.CentreU.Click += new System.EventHandler(this.CentreU_Click);
            // 
            // CentreV
            // 
            this.CentreV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CentreV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CentreV.Location = new System.Drawing.Point(74, 146);
            this.CentreV.Margin = new System.Windows.Forms.Padding(2);
            this.CentreV.Name = "CentreV";
            this.CentreV.Size = new System.Drawing.Size(61, 19);
            this.CentreV.TabIndex = 0;
            this.CentreV.Text = "Centre V";
            this.CentreV.UseVisualStyleBackColor = true;
            this.CentreV.Click += new System.EventHandler(this.CentreV_Click);
            // 
            // ImportTexture
            // 
            this.ImportTexture.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportTexture.ForeColor = System.Drawing.Color.Black;
            this.ImportTexture.Location = new System.Drawing.Point(2, 119);
            this.ImportTexture.Margin = new System.Windows.Forms.Padding(2);
            this.ImportTexture.Name = "ImportTexture";
            this.ImportTexture.Size = new System.Drawing.Size(64, 21);
            this.ImportTexture.TabIndex = 6;
            this.ImportTexture.Text = "Import Texture";
            this.ImportTexture.UseVisualStyleBackColor = true;
            this.ImportTexture.Click += new System.EventHandler(this.ImportTexture_Click);
            // 
            // BitsizeBox
            // 
            this.BitsizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BitsizeBox.FormattingEnabled = true;
            this.BitsizeBox.Items.AddRange(new object[] {
            "4bpp",
            "8bpp",
            "16bpp",
            "32bpp"});
            this.BitsizeBox.Location = new System.Drawing.Point(72, 95);
            this.BitsizeBox.Margin = new System.Windows.Forms.Padding(2);
            this.BitsizeBox.Name = "BitsizeBox";
            this.BitsizeBox.Size = new System.Drawing.Size(69, 21);
            this.BitsizeBox.TabIndex = 5;
            this.BitsizeBox.SelectedIndexChanged += new System.EventHandler(this.BitsizeBox_SelectedIndexChanged);
            // 
            // TexFormatBox
            // 
            this.TexFormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TexFormatBox.FormattingEnabled = true;
            this.TexFormatBox.Items.AddRange(new object[] {
            "RGBA",
            "YUV",
            "CI",
            "IA",
            "I"});
            this.TexFormatBox.Location = new System.Drawing.Point(72, 70);
            this.TexFormatBox.Margin = new System.Windows.Forms.Padding(2);
            this.TexFormatBox.Name = "TexFormatBox";
            this.TexFormatBox.Size = new System.Drawing.Size(69, 21);
            this.TexFormatBox.TabIndex = 4;
            this.TexFormatBox.SelectedIndexChanged += new System.EventHandler(this.TexFormatBox_SelectedIndexChanged);
            // 
            // TPropertiesBox
            // 
            this.TPropertiesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TPropertiesBox.FormattingEnabled = true;
            this.TPropertiesBox.Items.AddRange(new object[] {
            "T Repeat",
            "T Mirror",
            "T Clamp"});
            this.TPropertiesBox.Location = new System.Drawing.Point(72, 45);
            this.TPropertiesBox.Name = "TPropertiesBox";
            this.TPropertiesBox.Size = new System.Drawing.Size(69, 21);
            this.TPropertiesBox.TabIndex = 3;
            this.TPropertiesBox.SelectedIndexChanged += new System.EventHandler(this.TPropertiesBox_SelectedIndexChanged);
            // 
            // SPropertiesBox
            // 
            this.SPropertiesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SPropertiesBox.FormattingEnabled = true;
            this.SPropertiesBox.Items.AddRange(new object[] {
            "S Repeat",
            "S Mirror",
            "S Clamp"});
            this.SPropertiesBox.Location = new System.Drawing.Point(72, 20);
            this.SPropertiesBox.MaxDropDownItems = 3;
            this.SPropertiesBox.Name = "SPropertiesBox";
            this.SPropertiesBox.Size = new System.Drawing.Size(69, 21);
            this.SPropertiesBox.TabIndex = 2;
            this.SPropertiesBox.SelectedIndexChanged += new System.EventHandler(this.SPropertiesBox_SelectedIndexChanged);
            // 
            // TextureNumBox
            // 
            this.TextureNumBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextureNumBox.FormattingEnabled = true;
            this.TextureNumBox.Location = new System.Drawing.Point(3, 95);
            this.TextureNumBox.Name = "TextureNumBox";
            this.TextureNumBox.Size = new System.Drawing.Size(64, 21);
            this.TextureNumBox.TabIndex = 1;
            this.TextureNumBox.SelectedIndexChanged += new System.EventHandler(this.TextureNumBox_SelectedIndexChanged);
            // 
            // TexturePreview
            // 
            this.TexturePreview.Location = new System.Drawing.Point(3, 19);
            this.TexturePreview.Name = "TexturePreview";
            this.TexturePreview.Size = new System.Drawing.Size(64, 64);
            this.TexturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TexturePreview.TabIndex = 0;
            this.TexturePreview.TabStop = false;
            // 
            // TextureResLabel
            // 
            this.TextureResLabel.AutoSize = true;
            this.TextureResLabel.Location = new System.Drawing.Point(2, 82);
            this.TextureResLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextureResLabel.Name = "TextureResLabel";
            this.TextureResLabel.Size = new System.Drawing.Size(36, 13);
            this.TextureResLabel.TabIndex = 7;
            this.TextureResLabel.Text = "32x32";
            // 
            // VertexRGBA
            // 
            this.VertexRGBA.Controls.Add(this.PalettePanel);
            this.VertexRGBA.Controls.Add(this.label2);
            this.VertexRGBA.Controls.Add(this.AlphaOnlyCheckbox);
            this.VertexRGBA.Controls.Add(this.ColourPreview);
            this.VertexRGBA.Controls.Add(this.DarkLabel);
            this.VertexRGBA.Controls.Add(this.AlphaLabel);
            this.VertexRGBA.Controls.Add(this.BlueLabel);
            this.VertexRGBA.Controls.Add(this.RedLabel);
            this.VertexRGBA.Controls.Add(this.label1);
            this.VertexRGBA.Controls.Add(this.AlphaPalette);
            this.VertexRGBA.Controls.Add(this.RGBPalette);
            this.VertexRGBA.Controls.Add(this.button2);
            this.VertexRGBA.Controls.Add(this.AlphaNum);
            this.VertexRGBA.Controls.Add(this.BlueNum);
            this.VertexRGBA.Controls.Add(this.GreenNum);
            this.VertexRGBA.Controls.Add(this.RedNum);
            this.VertexRGBA.Controls.Add(this.GreenLabel);
            this.VertexRGBA.Controls.Add(this.Brightness);
            this.VertexRGBA.Controls.Add(this.BrightLabel);
            this.VertexRGBA.ForeColor = System.Drawing.Color.Silver;
            this.VertexRGBA.Location = new System.Drawing.Point(8, 1);
            this.VertexRGBA.Margin = new System.Windows.Forms.Padding(2);
            this.VertexRGBA.Name = "VertexRGBA";
            this.VertexRGBA.Padding = new System.Windows.Forms.Padding(2);
            this.VertexRGBA.Size = new System.Drawing.Size(145, 283);
            this.VertexRGBA.TabIndex = 4;
            this.VertexRGBA.TabStop = false;
            this.VertexRGBA.Text = "Vertex RGBA";
            // 
            // PalettePanel
            // 
            this.PalettePanel.Controls.Add(this.PaletteBox9);
            this.PalettePanel.Controls.Add(this.PaletteBox1);
            this.PalettePanel.Controls.Add(this.PaletteBox2);
            this.PalettePanel.Controls.Add(this.PaletteBox16);
            this.PalettePanel.Controls.Add(this.PaletteBox3);
            this.PalettePanel.Controls.Add(this.PaletteBox15);
            this.PalettePanel.Controls.Add(this.PaletteBox4);
            this.PalettePanel.Controls.Add(this.PaletteBox14);
            this.PalettePanel.Controls.Add(this.PaletteBox5);
            this.PalettePanel.Controls.Add(this.PaletteBox13);
            this.PalettePanel.Controls.Add(this.PaletteBox6);
            this.PalettePanel.Controls.Add(this.PaletteBox12);
            this.PalettePanel.Controls.Add(this.PaletteBox7);
            this.PalettePanel.Controls.Add(this.PaletteBox11);
            this.PalettePanel.Controls.Add(this.PaletteBox8);
            this.PalettePanel.Controls.Add(this.PaletteBox10);
            this.PalettePanel.Location = new System.Drawing.Point(7, 95);
            this.PalettePanel.Margin = new System.Windows.Forms.Padding(2);
            this.PalettePanel.Name = "PalettePanel";
            this.PalettePanel.Size = new System.Drawing.Size(133, 38);
            this.PalettePanel.TabIndex = 34;
            // 
            // PaletteBox9
            // 
            this.PaletteBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox9.Location = new System.Drawing.Point(3, 20);
            this.PaletteBox9.Name = "PaletteBox9";
            this.PaletteBox9.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox9.TabIndex = 25;
            this.PaletteBox9.TabStop = false;
            this.PaletteBox9.Click += new System.EventHandler(this.PaletteBox9_Click);
            // 
            // PaletteBox1
            // 
            this.PaletteBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox1.Location = new System.Drawing.Point(3, 5);
            this.PaletteBox1.Name = "PaletteBox1";
            this.PaletteBox1.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox1.TabIndex = 17;
            this.PaletteBox1.TabStop = false;
            this.PaletteBox1.Click += new System.EventHandler(this.PaletteBox1_Click);
            // 
            // PaletteBox2
            // 
            this.PaletteBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox2.Location = new System.Drawing.Point(19, 5);
            this.PaletteBox2.Name = "PaletteBox2";
            this.PaletteBox2.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox2.TabIndex = 18;
            this.PaletteBox2.TabStop = false;
            this.PaletteBox2.Click += new System.EventHandler(this.PaletteBox2_Click);
            // 
            // PaletteBox16
            // 
            this.PaletteBox16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox16.Location = new System.Drawing.Point(115, 20);
            this.PaletteBox16.Name = "PaletteBox16";
            this.PaletteBox16.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox16.TabIndex = 32;
            this.PaletteBox16.TabStop = false;
            this.PaletteBox16.Click += new System.EventHandler(this.PaletteBox16_Click);
            // 
            // PaletteBox3
            // 
            this.PaletteBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox3.Location = new System.Drawing.Point(35, 5);
            this.PaletteBox3.Name = "PaletteBox3";
            this.PaletteBox3.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox3.TabIndex = 19;
            this.PaletteBox3.TabStop = false;
            this.PaletteBox3.Click += new System.EventHandler(this.PaletteBox3_Click);
            // 
            // PaletteBox15
            // 
            this.PaletteBox15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox15.Location = new System.Drawing.Point(99, 20);
            this.PaletteBox15.Name = "PaletteBox15";
            this.PaletteBox15.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox15.TabIndex = 31;
            this.PaletteBox15.TabStop = false;
            this.PaletteBox15.Click += new System.EventHandler(this.PaletteBox15_Click);
            // 
            // PaletteBox4
            // 
            this.PaletteBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox4.Location = new System.Drawing.Point(51, 5);
            this.PaletteBox4.Name = "PaletteBox4";
            this.PaletteBox4.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox4.TabIndex = 20;
            this.PaletteBox4.TabStop = false;
            this.PaletteBox4.Click += new System.EventHandler(this.PaletteBox4_Click);
            // 
            // PaletteBox14
            // 
            this.PaletteBox14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox14.Location = new System.Drawing.Point(83, 20);
            this.PaletteBox14.Name = "PaletteBox14";
            this.PaletteBox14.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox14.TabIndex = 30;
            this.PaletteBox14.TabStop = false;
            this.PaletteBox14.Click += new System.EventHandler(this.PaletteBox14_Click);
            // 
            // PaletteBox5
            // 
            this.PaletteBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox5.Location = new System.Drawing.Point(67, 5);
            this.PaletteBox5.Name = "PaletteBox5";
            this.PaletteBox5.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox5.TabIndex = 21;
            this.PaletteBox5.TabStop = false;
            this.PaletteBox5.Click += new System.EventHandler(this.PaletteBox5_Click);
            // 
            // PaletteBox13
            // 
            this.PaletteBox13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox13.Location = new System.Drawing.Point(67, 20);
            this.PaletteBox13.Name = "PaletteBox13";
            this.PaletteBox13.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox13.TabIndex = 29;
            this.PaletteBox13.TabStop = false;
            this.PaletteBox13.Click += new System.EventHandler(this.PaletteBox13_Click);
            // 
            // PaletteBox6
            // 
            this.PaletteBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox6.Location = new System.Drawing.Point(83, 5);
            this.PaletteBox6.Name = "PaletteBox6";
            this.PaletteBox6.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox6.TabIndex = 22;
            this.PaletteBox6.TabStop = false;
            this.PaletteBox6.Click += new System.EventHandler(this.PaletteBox6_Click);
            // 
            // PaletteBox12
            // 
            this.PaletteBox12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox12.Location = new System.Drawing.Point(51, 20);
            this.PaletteBox12.Name = "PaletteBox12";
            this.PaletteBox12.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox12.TabIndex = 28;
            this.PaletteBox12.TabStop = false;
            this.PaletteBox12.Click += new System.EventHandler(this.PaletteBox12_Click);
            // 
            // PaletteBox7
            // 
            this.PaletteBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox7.Location = new System.Drawing.Point(99, 5);
            this.PaletteBox7.Name = "PaletteBox7";
            this.PaletteBox7.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox7.TabIndex = 23;
            this.PaletteBox7.TabStop = false;
            this.PaletteBox7.Click += new System.EventHandler(this.PaletteBox7_Click);
            // 
            // PaletteBox11
            // 
            this.PaletteBox11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox11.Location = new System.Drawing.Point(35, 20);
            this.PaletteBox11.Name = "PaletteBox11";
            this.PaletteBox11.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox11.TabIndex = 27;
            this.PaletteBox11.TabStop = false;
            this.PaletteBox11.Click += new System.EventHandler(this.PaletteBox11_Click);
            // 
            // PaletteBox8
            // 
            this.PaletteBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox8.Location = new System.Drawing.Point(115, 5);
            this.PaletteBox8.Name = "PaletteBox8";
            this.PaletteBox8.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox8.TabIndex = 24;
            this.PaletteBox8.TabStop = false;
            this.PaletteBox8.Click += new System.EventHandler(this.PaletteBox8_Click);
            // 
            // PaletteBox10
            // 
            this.PaletteBox10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaletteBox10.Location = new System.Drawing.Point(19, 20);
            this.PaletteBox10.Name = "PaletteBox10";
            this.PaletteBox10.Size = new System.Drawing.Size(16, 16);
            this.PaletteBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox10.TabIndex = 26;
            this.PaletteBox10.TabStop = false;
            this.PaletteBox10.Click += new System.EventHandler(this.PaletteBox10_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 9);
            this.label2.TabIndex = 16;
            this.label2.Text = "Current Colour:";
            // 
            // AlphaOnlyCheckbox
            // 
            this.AlphaOnlyCheckbox.AutoSize = true;
            this.AlphaOnlyCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaOnlyCheckbox.Location = new System.Drawing.Point(24, 264);
            this.AlphaOnlyCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.AlphaOnlyCheckbox.Name = "AlphaOnlyCheckbox";
            this.AlphaOnlyCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AlphaOnlyCheckbox.Size = new System.Drawing.Size(107, 17);
            this.AlphaOnlyCheckbox.TabIndex = 33;
            this.AlphaOnlyCheckbox.Text = "Alpha-Only-Mode";
            this.AlphaOnlyCheckbox.UseVisualStyleBackColor = true;
            // 
            // ColourPreview
            // 
            this.ColourPreview.Location = new System.Drawing.Point(23, 233);
            this.ColourPreview.Name = "ColourPreview";
            this.ColourPreview.Size = new System.Drawing.Size(20, 20);
            this.ColourPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ColourPreview.TabIndex = 15;
            this.ColourPreview.TabStop = false;
            // 
            // DarkLabel
            // 
            this.DarkLabel.AutoSize = true;
            this.DarkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkLabel.ForeColor = System.Drawing.Color.White;
            this.DarkLabel.Location = new System.Drawing.Point(5, 203);
            this.DarkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DarkLabel.Name = "DarkLabel";
            this.DarkLabel.Size = new System.Drawing.Size(14, 7);
            this.DarkLabel.TabIndex = 14;
            this.DarkLabel.Text = "0%";
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.ForeColor = System.Drawing.Color.Silver;
            this.AlphaLabel.Location = new System.Drawing.Point(55, 200);
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
            this.BlueLabel.Location = new System.Drawing.Point(55, 185);
            this.BlueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(31, 13);
            this.BlueLabel.TabIndex = 2;
            this.BlueLabel.Text = "Blue:";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RedLabel.Location = new System.Drawing.Point(55, 153);
            this.RedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(30, 13);
            this.RedLabel.TabIndex = 0;
            this.RedLabel.Text = "Red:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Brightness:";
            // 
            // AlphaPalette
            // 
            this.AlphaPalette.Cursor = System.Windows.Forms.Cursors.Cross;
            this.AlphaPalette.Image = ((System.Drawing.Image)(resources.GetObject("AlphaPalette.Image")));
            this.AlphaPalette.Location = new System.Drawing.Point(3, 75);
            this.AlphaPalette.Margin = new System.Windows.Forms.Padding(2);
            this.AlphaPalette.Name = "AlphaPalette";
            this.AlphaPalette.Size = new System.Drawing.Size(140, 17);
            this.AlphaPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlphaPalette.TabIndex = 10;
            this.AlphaPalette.TabStop = false;
            // 
            // RGBPalette
            // 
            this.RGBPalette.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RGBPalette.Image = ((System.Drawing.Image)(resources.GetObject("RGBPalette.Image")));
            this.RGBPalette.Location = new System.Drawing.Point(3, 15);
            this.RGBPalette.Margin = new System.Windows.Forms.Padding(2);
            this.RGBPalette.Name = "RGBPalette";
            this.RGBPalette.Size = new System.Drawing.Size(140, 54);
            this.RGBPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RGBPalette.TabIndex = 9;
            this.RGBPalette.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(66, 226);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
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
            this.AlphaNum.Location = new System.Drawing.Point(94, 199);
            this.AlphaNum.Margin = new System.Windows.Forms.Padding(2);
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
            this.AlphaNum.ValueChanged += new System.EventHandler(this.AlphaNum_ValueChanged);
            // 
            // BlueNum
            // 
            this.BlueNum.BackColor = System.Drawing.Color.DarkGray;
            this.BlueNum.Location = new System.Drawing.Point(94, 183);
            this.BlueNum.Margin = new System.Windows.Forms.Padding(2);
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
            this.BlueNum.ValueChanged += new System.EventHandler(this.BlueNum_ValueChanged);
            // 
            // GreenNum
            // 
            this.GreenNum.BackColor = System.Drawing.Color.DarkGray;
            this.GreenNum.Location = new System.Drawing.Point(94, 168);
            this.GreenNum.Margin = new System.Windows.Forms.Padding(2);
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
            this.GreenNum.ValueChanged += new System.EventHandler(this.GreenNum_ValueChanged);
            // 
            // RedNum
            // 
            this.RedNum.BackColor = System.Drawing.Color.DarkGray;
            this.RedNum.Location = new System.Drawing.Point(94, 152);
            this.RedNum.Margin = new System.Windows.Forms.Padding(2);
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
            this.RedNum.ValueChanged += new System.EventHandler(this.RedNum_ValueChanged);
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.GreenLabel.Location = new System.Drawing.Point(55, 168);
            this.GreenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(39, 13);
            this.GreenLabel.TabIndex = 1;
            this.GreenLabel.Text = "Green:";
            // 
            // Brightness
            // 
            this.Brightness.Location = new System.Drawing.Point(20, 144);
            this.Brightness.Maximum = 100;
            this.Brightness.Name = "Brightness";
            this.Brightness.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Brightness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Brightness.Size = new System.Drawing.Size(45, 74);
            this.Brightness.TabIndex = 11;
            this.Brightness.TabStop = false;
            this.Brightness.TickFrequency = 0;
            this.Brightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Brightness.Value = 100;
            this.Brightness.Scroll += new System.EventHandler(this.Brightness_Scroll);
            // 
            // BrightLabel
            // 
            this.BrightLabel.AutoSize = true;
            this.BrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightLabel.ForeColor = System.Drawing.Color.White;
            this.BrightLabel.Location = new System.Drawing.Point(1, 153);
            this.BrightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BrightLabel.Name = "BrightLabel";
            this.BrightLabel.Size = new System.Drawing.Size(22, 7);
            this.BrightLabel.TabIndex = 13;
            this.BrightLabel.Text = "100%";
            // 
            // groupBoxForce
            // 
            this.groupBoxForce.Controls.Add(this.ForceOpaqueRGBA);
            this.groupBoxForce.Controls.Add(this.ForceAlphaRGBA);
            this.groupBoxForce.Controls.Add(this.ForceVertRGBAButton);
            this.groupBoxForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxForce.ForeColor = System.Drawing.Color.Silver;
            this.groupBoxForce.Location = new System.Drawing.Point(9, 561);
            this.groupBoxForce.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxForce.Name = "groupBoxForce";
            this.groupBoxForce.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxForce.Size = new System.Drawing.Size(146, 62);
            this.groupBoxForce.TabIndex = 3;
            this.groupBoxForce.TabStop = false;
            this.groupBoxForce.Text = "Attempt VertRGBA";
            // 
            // ForceOpaqueRGBA
            // 
            this.ForceOpaqueRGBA.AutoSize = true;
            this.ForceOpaqueRGBA.Checked = true;
            this.ForceOpaqueRGBA.Location = new System.Drawing.Point(19, 19);
            this.ForceOpaqueRGBA.Margin = new System.Windows.Forms.Padding(2);
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
            this.ForceAlphaRGBA.Location = new System.Drawing.Point(19, 35);
            this.ForceAlphaRGBA.Margin = new System.Windows.Forms.Padding(2);
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
            this.ForceVertRGBAButton.Location = new System.Drawing.Point(81, 15);
            this.ForceVertRGBAButton.Margin = new System.Windows.Forms.Padding(2);
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
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RightClickTexture
            // 
            this.RightClickTexture.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.RightClickTexture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTextureAsToolStripMenuItem});
            this.RightClickTexture.Name = "RightClickTexture";
            this.RightClickTexture.Size = new System.Drawing.Size(163, 26);
            // 
            // saveTextureAsToolStripMenuItem
            // 
            this.saveTextureAsToolStripMenuItem.Name = "saveTextureAsToolStripMenuItem";
            this.saveTextureAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveTextureAsToolStripMenuItem.Text = "Save Texture as...";
            this.saveTextureAsToolStripMenuItem.Click += new System.EventHandler(this.saveTextureAsToolStripMenuItem_Click);
            // 
            // ObjectIDLabel
            // 
            this.ObjectIDLabel.AutoSize = true;
            this.ObjectIDLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ObjectIDLabel.ForeColor = System.Drawing.Color.Silver;
            this.ObjectIDLabel.Location = new System.Drawing.Point(281, 5);
            this.ObjectIDLabel.Name = "ObjectIDLabel";
            this.ObjectIDLabel.Size = new System.Drawing.Size(41, 13);
            this.ObjectIDLabel.TabIndex = 10;
            this.ObjectIDLabel.Text = "Object:";
            this.ObjectIDLabel.Visible = false;
            // 
            // ObjectList
            // 
            this.ObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectList.FormattingEnabled = true;
            this.ObjectList.Location = new System.Drawing.Point(324, 2);
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.Size = new System.Drawing.Size(47, 21);
            this.ObjectList.TabIndex = 11;
            this.ObjectList.Visible = false;
            this.ObjectList.SelectedIndexChanged += new System.EventHandler(this.ObjectList_SelectedIndexChanged);
            // 
            // SegmentLabel
            // 
            this.SegmentLabel.AutoSize = true;
            this.SegmentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SegmentLabel.ForeColor = System.Drawing.Color.Silver;
            this.SegmentLabel.Location = new System.Drawing.Point(178, 5);
            this.SegmentLabel.Name = "SegmentLabel";
            this.SegmentLabel.Size = new System.Drawing.Size(55, 13);
            this.SegmentLabel.TabIndex = 12;
            this.SegmentLabel.Text = "Segment: ";
            this.SegmentLabel.Visible = false;
            // 
            // SegmentList
            // 
            this.SegmentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SegmentList.FormattingEnabled = true;
            this.SegmentList.Location = new System.Drawing.Point(233, 2);
            this.SegmentList.Name = "SegmentList";
            this.SegmentList.Size = new System.Drawing.Size(40, 21);
            this.SegmentList.TabIndex = 13;
            this.SegmentList.Visible = false;
            this.SegmentList.SelectedIndexChanged += new System.EventHandler(this.SegmentList_SelectedIndexChanged);
            // 
            // EnvColoursTip
            // 
            this.EnvColoursTip.Popup += new System.Windows.Forms.PopupEventHandler(this.EnvColoursTip_Popup);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(703, 446);
            this.Controls.Add(this.ObjectList);
            this.Controls.Add(this.SegmentList);
            this.Controls.Add(this.SegmentLabel);
            this.Controls.Add(this.ObjectIDLabel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.AreaLabel);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.LevelComboBox);
            this.Controls.Add(this.RenderPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(690, 462);
            this.Name = "MainForm";
            this.Text = "SM64Paint 0.3.6";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.LayersGroupBox.ResumeLayout(false);
            this.TexturesGroupBox.ResumeLayout(false);
            this.TexturesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePreview)).EndInit();
            this.VertexRGBA.ResumeLayout(false);
            this.VertexRGBA.PerformLayout();
            this.PalettePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).EndInit();
            this.groupBoxForce.ResumeLayout(false);
            this.groupBoxForce.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.RightClickTexture.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox RGBPalette;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem EdgesOption;
        private System.Windows.Forms.PictureBox AlphaPalette;
        private System.Windows.Forms.ToolStripMenuItem ViewNonRGBA;
        private System.Windows.Forms.GroupBox TexturesGroupBox;
        private System.Windows.Forms.ComboBox TextureNumBox;
        private System.Windows.Forms.PictureBox TexturePreview;
        private System.Windows.Forms.ComboBox TPropertiesBox;
        private System.Windows.Forms.ComboBox SPropertiesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar Brightness;
        private System.Windows.Forms.Label DarkLabel;
        private System.Windows.Forms.Label BrightLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ColourPreview;
        private System.Windows.Forms.PictureBox PaletteBox1;
        private System.Windows.Forms.PictureBox PaletteBox5;
        private System.Windows.Forms.PictureBox PaletteBox4;
        private System.Windows.Forms.PictureBox PaletteBox3;
        private System.Windows.Forms.PictureBox PaletteBox2;
        private System.Windows.Forms.PictureBox PaletteBox16;
        private System.Windows.Forms.PictureBox PaletteBox15;
        private System.Windows.Forms.PictureBox PaletteBox14;
        private System.Windows.Forms.PictureBox PaletteBox13;
        private System.Windows.Forms.PictureBox PaletteBox12;
        private System.Windows.Forms.PictureBox PaletteBox11;
        private System.Windows.Forms.PictureBox PaletteBox10;
        private System.Windows.Forms.PictureBox PaletteBox9;
        private System.Windows.Forms.PictureBox PaletteBox8;
        private System.Windows.Forms.PictureBox PaletteBox7;
        private System.Windows.Forms.PictureBox PaletteBox6;
        private System.Windows.Forms.ComboBox TexFormatBox;
        private System.Windows.Forms.ComboBox BitsizeBox;
        private System.Windows.Forms.Button ImportTexture;
        private System.Windows.Forms.Label TextureResLabel;
        private System.Windows.Forms.ContextMenuStrip RightClickTexture;
        private System.Windows.Forms.ToolStripMenuItem saveTextureAsToolStripMenuItem;
        private System.Windows.Forms.Label ObjectIDLabel;
        private System.Windows.Forms.ComboBox ObjectList;
        private System.Windows.Forms.Label SegmentLabel;
        private System.Windows.Forms.ComboBox SegmentList;
        private System.Windows.Forms.GroupBox LayersGroupBox;
        private System.Windows.Forms.Button Layer1To4Button;
        private System.Windows.Forms.Button Layer4To5Button;
        private System.Windows.Forms.Button CentreU;
        private System.Windows.Forms.Button CentreV;
        private System.Windows.Forms.CheckBox FlipYCheckBox;
        private System.Windows.Forms.ToolStripMenuItem CullingOption;
        private System.Windows.Forms.ToolStripMenuItem ObjectModelEditor;
        private System.Windows.Forms.Panel PalettePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RemoveEnvColoursButton;
        private System.Windows.Forms.ToolTip EnvColoursTip;
        private System.Windows.Forms.CheckBox AlphaOnlyCheckbox;
    }
}

