/****************************************************************************
*                                                                           *
* SM64Paint - A vertex painting tool for SM64                               *
* https://www.YouTube.com/Trenavix/                                         *
* Copyright (C) 2017 Trenavix. All rights reserved.                         *
*                                                                           *
* License:                                                                  *
* GNU/GPLv2 http://www.gnu.org/licenses/gpl-2.0.html                        *
*                                                                           *
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ROM;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using static OpenTK.GLControl;
using static Renderer;
using System.Windows.Media;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace SM64Paint
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        MouseState state; KeyboardState keystate;
        Vector2 oldXYDelta = new Vector2(0, 0);
        Vector2 XYEnd = new Vector2(0,0);
        String currentROMPath;

        public MainForm()
        {
            InitializeComponent();
            RenderPanel.Dock = DockStyle.Fill;
            OpenTK.Toolkit.Init();
            SPropertiesBox.SelectedIndex = 0;
            TPropertiesBox.SelectedIndex = 0;
            TexFormatBox.SelectedIndex = 0;
            BitsizeBox.SelectedIndex = 0;
            Bitmap white = new Bitmap(16, 1); Graphics whiteGraphics = Graphics.FromImage(white);
            whiteGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, 16, 1); ColourPreview.Image = white;
            lastMousePos.X = (Bounds.Left + Bounds.Width / 2);
            RenderPanel.MouseDown += new MouseEventHandler(RenderPanel_MouseDown);
            RenderPanel.MouseMove += new MouseEventHandler (RenderPanel_MouseMove);
            RenderPanel.MouseUp += new MouseEventHandler(RenderPanel_MouseUp);
            RenderPanel.MouseWheel += new MouseEventHandler(RenderPanel_MouseWheel);
            RenderPanel.KeyDown += new KeyEventHandler(RenderPanel_KeyDown);
            RenderPanel.KeyUp += new KeyEventHandler(RenderPanel_KeyUp);
            RenderPanel.Resize += new EventHandler(panel1_Resize);
            RenderPanel.Paint += new PaintEventHandler(RenderPanel_Paint);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            this.TexturePreview.ContextMenuStrip = this.RightClickTexture;
        }

        private static OpenFileDialog OFD() => new OpenFileDialog();
        private static SaveFileDialog SFD() => new SaveFileDialog();

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("**************************************************************\n" + 
                "*                                   SM64Paint v0.3                                       *\n" +
                "**************************************************************\n" + 
                "This is an early beta of a vertex painter for SM64.\n" +
                "This program was coded entirely by Trenavix, and is far from finished.\n"+
                "It is licensed by GPL and is available at: \nGitHub.com/Trenavix/SM64Paint\n"+
                "Author's pages:\nYouTube.com/Trenavix\nPatreon.com/Trenavix\n" + 
                "(SM64Paint Icon was designed entirely by Quasmok)\n" +
                "Also, huge shoutout to DavidSM64 and shygoo for various notes and tips.", 
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W/S: Move Forward/Backward\n" +
                "A/S: Move Left/Right\n" +
                "Q/E: Move Up/Down\n" +
                "Mouse Scroll: Increment Movement Speed\n" +
                "Mouse Click & Drag: Rotate Camera\n" +
                "Right Mouse Click: Paint Nearest Vertex\n" +
                "Ctrl+Z: Undo Vertex Paint\n" +
                "Ctrl+Y: Redo Vertex Paint\n" +
                "Ctrl+O: Open ROM\n" +
                "Ctrl+S: Save ROM\n" +
                "Left Shift: Double Movement Speed\n" +
                "T: Toggle Textures\n" +
                "F: Toggle WireFrame\n" +
                "R: Hide Control Panel\n" +
                "Space: Toggle Edges\n" +
                "Alt+Enter or Esc: Toggle Fullscreen",
                "Controls", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderPanel.Invalidate();
        }
        private void RenderPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.ContainsFocus) { Renderer.cam.WASDMoveMent(); }
            Control control = sender as Control;
            state = Mouse.GetState();
            Point pt = control.PointToClient(Control.MousePosition);
            Vector2 Boundaries = new Vector2(RenderPanel.Width, RenderPanel.Height);
            if (ControlPanel.Visible) Boundaries.X -= ControlPanel.Size.Width; //shorten boundaries if control panel is open
            //StatusLabel.Text = "CAMERA: " + Renderer.cam.CamRotation + ", MOUSE: " + pt;
            if (state[MouseButton.Left]) 
            {
                if (pt.X > 0 && pt.Y > 0 && pt.X < Boundaries.X && pt.Y < Boundaries.Y && this.ContainsFocus == true)//Left Click in GLControl & windowfocused
                {
                    float movementX = oldXYDelta.X + ((Control.MousePosition.X - lastMousePos.X)); //last rotation + new rotation (Both are differences)
                    float movementY = oldXYDelta.Y + ((Control.MousePosition.Y - lastMousePos.Y));
                    if (movementY > 285) movementY = 285;// limit Y axis rotation
                    else if (movementY < -314) movementY = -314;
                    Renderer.cam.AddRotation(movementX, movementY);
                    XYEnd.X = movementX;
                    XYEnd.Y = movementY;
                    //StatusLabel.Text += ", MOVEMENTX: " + movementX.ToString() + ", MOVEMENTY: " + movementY.ToString();
                }
                if (ControlPanel.Visible) // Colour Picker
                {
                    Point cursor = new Point();
                    GetCursorPos(ref cursor);
                    Point PaletteLocation = VertexRGBA.PointToScreen(RGBPalette.Location);
                    Point AlphaPaletteLocation = VertexRGBA.PointToScreen(AlphaPalette.Location);
                    if (cursor.X > PaletteLocation.X && cursor.X < PaletteLocation.X + RGBPalette.Size.Width && cursor.Y > PaletteLocation.Y && cursor.Y < PaletteLocation.Y + RGBPalette.Size.Height)
                    {
                        System.Drawing.Color PxColor = GetColorAt(cursor);
                        this.BackColor = PxColor;
                        RedNum.Value = PxColor.R;
                        GreenNum.Value = PxColor.G;
                        BlueNum.Value = PxColor.B;
                        //AlphaNum.Value = PxColor.A; //All alpha here is 255 so don't copy it
                    }
                    else if (cursor.X >= AlphaPaletteLocation.X && cursor.X <= AlphaPaletteLocation.X + AlphaPalette.Size.Width && cursor.Y > AlphaPaletteLocation.Y && cursor.Y < AlphaPaletteLocation.Y + AlphaPalette.Size.Height)
                    {
                        int right = AlphaPaletteLocation.X + AlphaPalette.Size.Width;
                        //StatusLabel.Text += cursor.X+", "+right + ", " + AlphaPalette.Size.Width;
                        int alpha = Convert.ToInt32((double)((double)(right - cursor.X) / AlphaPalette.Size.Width) * (double)255);
                        if (alpha >= 252) alpha = 255;
                        else if (alpha <= 4) alpha = 0;
                        AlphaNum.Value = alpha;
                    }
                }
            }
            else //When not clicking, track mouse position
            {
                lastMousePos.X = Control.MousePosition.X;
                lastMousePos.Y = Control.MousePosition.Y;
            }
            if (state[MouseButton.Right] && pt.X > 0 && pt.Y > 0 && pt.X < Boundaries.X && pt.Y < Boundaries.Y && this.ContainsFocus == true) Renderer.EditVertex
                (
                ClientRectangle, 
                Width, 
                Height, 
                RenderPanel, 
                pt, 
                (byte)Math.Round(RedNum.Value * ((decimal)Brightness.Value / 100)),
                (byte)Math.Round(GreenNum.Value * ((decimal)Brightness.Value / 100)),
                (byte)Math.Round(BlueNum.Value * ((decimal)Brightness.Value / 100)), 
                (byte)AlphaNum.Value
                );
            Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
        }

        Bitmap screenPixel = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        public System.Drawing.Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        void RenderPanel_KeyUp(object sender, KeyEventArgs e)
        {
            keystate = Keyboard.GetState();
            switch (e.KeyCode)
            {
                case Keys.F:
                    Renderer.WireFrameMode = !Renderer.WireFrameMode;
                    if (Renderer.WireFrameMode)
                    {
                        EdgesOption.Checked = false;
                        Renderer.EdgesOption = false;
                    }
                    break;
                case Keys.T:
                    Renderer.TextureEnabler = !Renderer.TextureEnabler;
                    break;
                case Keys.R:
                    if (ROMManager.SM64ROM == null) break;
                    ControlPanel.Visible = !ControlPanel.Visible;
                    if (ControlPanel.Visible) { RenderPanel.Width -= ControlPanel.Width;}
                    else RenderPanel.Width += ControlPanel.Width;
                    break;
                case Keys.Enter:
                    if (!keystate[Key.AltRight]) break;
                    ToggleFullscreen();
                    break;
                case Keys.Escape:
                    ToggleFullscreen();
                    break;
                case Keys.Space:
                    EdgesOption.Checked = !EdgesOption.Checked;
                    Renderer.EdgesOption = EdgesOption.Checked;
                    break;
            }

        }

        void RenderPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    oldXYDelta.X = XYEnd.X;
                    oldXYDelta.Y = XYEnd.Y;
                    break;
                case MouseButtons.Right:
                    break;
            }     
        }

        void RenderPanel_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(Renderer.cam.MoveSpeed > 0f) Renderer.cam.MoveSpeed += 0.000000001f*e.Delta;
            if(Renderer.cam.MoveSpeed <= 0f) Renderer.cam.MoveSpeed = 0.00000005f;
        }
       
        private void SaveROMAs_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the bin  
            SaveFileDialog SaveROM = SFD();
            SaveROM.Filter = "SM64 ROM File|*.z64;*.rom;*.v64;*.n64";
            SaveROM.Title = "Save a SM64 ROM file.";
            if (SaveROM.ShowDialog() == System.Windows.Forms.DialogResult.OK && SaveROM.FileName != "") // If the file name is not an empty string open it for saving. 
            {
                    File.WriteAllBytes(SaveROM.FileName, ROMManager.SM64ROM.getCurrentROM());
            }
        }
        
        private void OpenROM_Click(object sender, EventArgs e)
        {
            OpenROM();
        }

        private void OpenROM()
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog OpenROM = OFD();
            OpenROM.Filter = "ROM Files|*.z64;*.rom;*.v64;*.n64";
            OpenROM.Title = "Select a SM64 ROM File";
            if (OpenROM.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isSM64ROM = false;
                using (FileStream fs = new FileStream(OpenROM.FileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] Header = new byte[0x40]; fs.Read(Header, 0, 0x40); //Load header into bytearray
                    if (Header[0x3c] == 0x53 && Header[0x3d] == 0x4D && Header[0x3e] == 0x45 && Header[0x3f] == 0) isSM64ROM = true; //Check if header is correct
                    fs.Close();
                }
                if (isSM64ROM)
                {
                    ROMManager.LoadROM(OpenROM.FileName, ClientRectangle, RenderPanel, Width, Height);
                    SaveROMAs.Enabled = true; SaveROMAs.Enabled = true;
                    currentROMPath = OpenROM.FileName;
                    LevelComboBox.Enabled = true;
                    String[] LevelList = LevelScripts.getLevelList();
                    LevelComboBox.Items.Clear();
                    for (int i = 0; i < LevelList.Length; i++)
                    {
                        LevelComboBox.Items.Add(LevelList[i]);
                    }
                    LevelComboBox.SelectedIndex = 12;
                    ControlPanel.Visible = true;
                    ViewMenu.Visible = true;
                }
                else { MessageBox.Show("File is not a SM64 US ROM! Please try again.", "Invalid File!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void UpdateStatusText()
        {
            StatusLabel.Text = Renderer.TriCount.ToString() + " triangles (" + Renderer.VertexCount.ToString() + " vertices) have been loaded to the preview.";
        }

        private void Level_SelectedIndexChange(object sender, EventArgs e)
        {
            LevelScripts.SelectedLevel = (uint)LevelComboBox.SelectedIndex;
            LevelScripts.ExitDecode = false;
            ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel); //init without rendering
            LevelScripts.ParseLevelScripts(ROMManager.SM64ROM, LevelScripts.LVLSCRIPTSTART);
            AreaComboBox.Items.Clear();
            for (int i = 0; i < LevelScripts.GeoLayoutOffsets.Length; i++)
            {
                AreaComboBox.Items.Add(i+1);
            }
            AreaComboBox.SelectedIndex = 0;
            Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
            if (AreaComboBox.Items.Count > 1) AreaComboBox.Enabled = true;
            else AreaComboBox.Enabled = false;
            TextureNumBox.Items.Clear();
            UpdateStatusText();
            if (ROMManager.SM64ROM.getSegmentStart(0x0E) < 0x1200000) { TexturesGroupBox.Visible = false; return; }
            groupBoxForce.Visible = ROMManager.LevelHasLighting();
            TexturesGroupBox.Visible = true;
            for (uint i = 0; i < Textures.TextureArray.Length; i++)
            {
                TextureNumBox.Items.Add("Tex" + (i+1));
            }
            TextureNumBox.SelectedIndex = 0;
        }

        private void LevelArea_SelectedIndexChange(object sender, EventArgs e)
        {
            Renderer.LevelArea = (uint)AreaComboBox.SelectedIndex;
            ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
            UpdateStatusText();
            if(ROMManager.SM64ROM.getSegmentStart(0x0E) >= 0x1200000) ROMManager.AdjustCombiners();
        }

        private void ForceVertRGBAButton_Click(object sender, EventArgs e)
        {
            DialogResult warningchoice = MessageBox.Show("Forcing VertRGBA should only be done on levels imported with SM64e and not modified. This is NOT safe and you" +
                " should back up your ROM in case. Force VertRGBA?", "Warning!", MessageBoxButtons.YesNo);
            if (warningchoice == DialogResult.No) return;
            Cursor.Current = Cursors.WaitCursor;
            if (!ForceOpaqueRGBA.Checked)
            {
                ROMManager.ForceVertRGBA(ForceOpaqueRGBA.Checked);
            }
            else ROMManager.ForceVertRGBA(ForceOpaqueRGBA.Checked);
            Cursor.Current = Cursors.Default;
        }

        private void ToggleFullscreen()
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                RenderPanel.Location = new Point(0, 0);
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                RenderPanel.Location = new Point(0, 44);
            }
            StatusLabel.Visible = !StatusLabel.Visible; statusStrip1.Visible = !statusStrip1.Visible;
            menuStrip1.Visible = !menuStrip1.Visible;
            LevelLabel.Visible = !LevelLabel.Visible; LevelComboBox.Visible = !LevelComboBox.Visible;
            AreaLabel.Visible = !AreaLabel.Visible; AreaComboBox.Visible = !AreaComboBox.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (uint j = 29; j >= 1 && j <= 29; j--) //Shift all mem back one
            {
                Vertex.OriginalVertexMem[j] = Vertex.OriginalVertexMem[j - 1];
            }
            Vertex.OriginalVertexMem[0] = new UInt32[Vertex.CurrentVertexList.Length][]; //Set up new undo level with all combos
            for (uint i = 0; i < Vertex.CurrentVertexList.Length; i++)
            {
                Vertex.OriginalVertexMem[0][i] = new UInt32[2];
                Vertex.OriginalVertexMem[0][i][0] = Vertex.CurrentVertexList[i] + 12;
                Vertex.OriginalVertexMem[0][i][1] = ROMManager.SM64ROM.ReadFourBytes(Vertex.CurrentVertexList[i] + 12); //Initial RGBA
            }
            byte R = (byte)Math.Round(RedNum.Value * ((decimal)Brightness.Value / 100));
            byte G = (byte)Math.Round(GreenNum.Value * ((decimal)Brightness.Value / 100));
            byte B = (byte)Math.Round(BlueNum.Value * ((decimal)Brightness.Value / 100));
            byte A = (byte)AlphaNum.Value;
            UInt32 colour = (uint)((R << 24) | (G << 16) | (B << 8) | A);
            for (int i = 0; i < Vertex.CurrentVertexList.Length; i++)
            {
                ROMManager.SetVertRGBA(Vertex.CurrentVertexList[i], colour);
            }
        }

        private void EdgesOption_Click(object sender, EventArgs e)
        {
            EdgesOption.Checked = !EdgesOption.Checked;
            Renderer.EdgesOption = EdgesOption.Checked;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Load(object sender, EventArgs e)
        {

        }
        void panel1_Resize(object sender, EventArgs e)
        {

        }
        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }

        void RenderPanel_KeyDown(object sender, KeyEventArgs e) //Undo and redo, CLEAN THIS CODE SOON PLS
        {
            keystate = Keyboard.GetState();
            switch (e.KeyCode)
            {
                case Keys.Z:
                    if (!keystate[Key.ControlLeft] || Vertex.OriginalVertexMem[0] == null) break;
                    for (int j = 29; j > 0; j--) { Vertex.EditedVertexMem[j] = Vertex.EditedVertexMem[j - 1]; } //shift all mem back one (make room for redo)
                    Vertex.EditedVertexMem[0] = new UInt32[Vertex.OriginalVertexMem[0].Length][];
                    for (int i = 0; i < Vertex.EditedVertexMem[0].Length; i++) { Vertex.EditedVertexMem[0][i] = new UInt32[2]; }//set new space to this undo
                    for (uint i = 0; i < Vertex.OriginalVertexMem[0].Length; i++)
                    {
                        Vertex.EditedVertexMem[0][i][0] = Vertex.OriginalVertexMem[0][i][0];
                        Vertex.EditedVertexMem[0][i][1] = ROMManager.SM64ROM.ReadFourBytes(Vertex.OriginalVertexMem[0][i][0]); //Write @ addr this colour for all addr+rgba in collection
                    }
                    for (uint i = 0; i < Vertex.OriginalVertexMem[0].Length; i++)
                    {
                        ROMManager.SM64ROM.WriteFourBytes(Vertex.OriginalVertexMem[0][i][0], Vertex.OriginalVertexMem[0][i][1]); //Write @ addr this colour for all addr+rgba in collection
                    }
                    for (uint i = 0; i < 29; i++) { Vertex.OriginalVertexMem[i] = Vertex.OriginalVertexMem[i + 1]; } //Shift all mem forward one (forget the undo)
                    break;
                case Keys.Y:
                    if (!keystate[Key.ControlLeft] || Vertex.EditedVertexMem[0] == null) break;
                    for (int j = 29; j > 0; j--) { Vertex.OriginalVertexMem[j] = Vertex.OriginalVertexMem[j - 1]; } //Shift all mem back one (make room for undo)
                    Vertex.OriginalVertexMem[0] = new UInt32[Vertex.EditedVertexMem[0].Length][];
                    for (int i = 0; i < Vertex.OriginalVertexMem[0].Length; i++) { Vertex.OriginalVertexMem[0][i] = new UInt32[2]; }//set new space to this undo
                    for (uint i = 0; i < Vertex.EditedVertexMem[0].Length; i++)
                    {
                        Vertex.OriginalVertexMem[0][i][0] = Vertex.EditedVertexMem[0][i][0];
                        Vertex.OriginalVertexMem[0][i][1] = ROMManager.SM64ROM.ReadFourBytes(Vertex.EditedVertexMem[0][i][0]); //Write @ addr this colour for all addr+rgba in collection
                    }
                    for (uint i = 0; i < Vertex.EditedVertexMem[0].Length; i++)
                    {
                        ROMManager.SM64ROM.WriteFourBytes(Vertex.EditedVertexMem[0][i][0], Vertex.EditedVertexMem[0][i][1]); //Write @ addr this colour for all addr+rgba in collection
                    }
                    for (uint i = 0; i < 29; i++) { Vertex.EditedVertexMem[i] = Vertex.EditedVertexMem[i + 1]; } //Shift all mem forward one (forget the redo)
                    break;
                case Keys.S:
                    if (!keystate[Key.ControlLeft]) break;
                    Cursor.Current = Cursors.WaitCursor;
                    File.WriteAllBytes(currentROMPath, ROMManager.SM64ROM.getCurrentROM()); //Ctrl+S to save
                    StatusLabel.Text = "ROM Saved to " + currentROMPath;
                    Cursor.Current = Cursors.Default;
                    break;
                case Keys.O:
                    if (!keystate[Key.ControlLeft]) break;
                    OpenROM(); //Ctrl+O to open
                    break;

            }
        }

        void RenderPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        void RenderPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void nonRGBAModelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNonRGBA.Checked = !ViewNonRGBA.Checked;
            Renderer.ViewNonRGBA = ViewNonRGBA.Checked;
        }

        private void ControlPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void TextureNumBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextureNum();
        }

        private void UpdateTextureNum()
        {
            Bitmap Texture;
            uint index = (uint)TextureNumBox.SelectedIndex;
            if (Textures.F5CMDArray[index].Length < 1) { TextureNumBox.SelectedIndex -= 1; return; }
            Texture = Textures.TextureToBitMap
                (
                Textures.TextureAddrArray[index][0],
                Textures.TextureAddrArray[index][3],
                Textures.TextureAddrArray[index][4],
                Textures.TextureAddrArray[index][1],
                Textures.TextureAddrArray[index][2]
                );
            TexturePreview.Image = Texture;
            int Sparam = ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 6) & 3;
            int Tparam = ((ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 5) >> 2) & 3);
            int format = ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 1) >> 5;
            int Bitsize = ((ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 1) >> 3) & 3);
            SPropertiesBox.SelectedIndex = Sparam;
            TPropertiesBox.SelectedIndex = Tparam;
            TexFormatBox.SelectedIndex = format;
            BitsizeBox.SelectedIndex = Bitsize;
            TextureResLabel.Text = Textures.TextureAddrArray[index][3].ToString() + "x" + Textures.TextureAddrArray[index][4].ToString();
        }

        private void SPropertiesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Textures.FirstTexLoad || ROMManager.SM64ROM == null) return;
            uint index = (uint)TextureNumBox.SelectedIndex;
            byte SParamByte = ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 6);
            int Sparam = (SParamByte & 0x03);
            int dif = SPropertiesBox.SelectedIndex-Sparam;
            for (uint i = 0; i < Textures.F5CMDArray[index].Length; i++)
            { ROMManager.SM64ROM.changeByte(Textures.F5CMDArray[index][i] + 6, (byte)(SParamByte + dif)); }
            ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
        }

        private void TPropertiesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Textures.FirstTexLoad || ROMManager.SM64ROM == null) return;
            uint index = (uint)TextureNumBox.SelectedIndex;
            byte TParamByte = ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 5);
            int Tparam = ((TParamByte >> 2) & 0x03);
            int dif = TPropertiesBox.SelectedIndex - Tparam;
            for (uint i = 0; i < Textures.F5CMDArray[index].Length; i++)
            { ROMManager.SM64ROM.changeByte(Textures.F5CMDArray[index][i] + 5, (byte)(TParamByte + (dif * 4))); } //*4 for << 2 with negative carried
            ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
        }

        private static bool WaitToRender = false;

        private void TexFormatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaitToRender = true;
            BitSizeCheck();
            if (Textures.FirstTexLoad || ROMManager.SM64ROM == null) { WaitToRender = false; return; }
            uint index = (uint)TextureNumBox.SelectedIndex;
            byte FormatByte = ROMManager.SM64ROM.getByte(Textures.F5CMDArray[index][0] + 1);
            int Format = FormatByte >> 5;
            int dif = TexFormatBox.SelectedIndex - Format;
            for (uint i = 0; i < Textures.F5CMDArray[index].Length; i++)
            { ROMManager.SM64ROM.changeByte(Textures.F5CMDArray[index][i] + 1, (byte)(FormatByte + (dif*32))); } //*32 for << 5 with negative carried
            ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
            UpdateTextureNum();
            WaitToRender = false;
        }

        private void BitsizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BitSizeCheck();
            if (Textures.FirstTexLoad || ROMManager.SM64ROM == null) return;
            ROM SM64ROM = ROMManager.SM64ROM;
            UInt32[] F5CMDs = Textures.F5CMDArray[TextureNumBox.SelectedIndex];
            byte BitsizeByte = SM64ROM.getByte(F5CMDs[0] + 1);
            int BitsizePWR = ((BitsizeByte >> 3) & 0x03);
            int dif = BitsizeBox.SelectedIndex - BitsizePWR;
            byte bitsize = (byte)(BitsizeByte + (dif * 8)); //*8 for << 3 with negative carried
            for (uint i = 0; i < F5CMDs.Length; i++) 
            {
                SM64ROM.changeByte(F5CMDs[i] + 1, bitsize);
            }
            uint[] F5CMD = Textures.F5CMDArray[(uint)TextureNumBox.SelectedIndex];
            byte WidthsizeByte = SM64ROM.getByte(F5CMD[0] + 7);
            ushort HeightsizeShort = SM64ROM.ReadTwoBytes(F5CMD[0] + 5);
            int ogHeightPower = (HeightsizeShort >> 6 & 0x0F);
            int ogWidthPower = (WidthsizeByte >> 4);
            if(ogWidthPower < ogHeightPower) Textures.ResizeTexture(TextureNumBox.SelectedIndex, ogWidthPower - dif, ogHeightPower);
            else Textures.ResizeTexture(TextureNumBox.SelectedIndex, ogWidthPower, ogHeightPower-dif);
            if (!WaitToRender)ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
            if (!WaitToRender) UpdateTextureNum();
        }

        private void BitSizeCheck()
        {
            if (TexFormatBox.SelectedIndex == 4 && BitsizeBox.SelectedIndex > 1) BitsizeBox.SelectedIndex = 1; //Prevent bitsize > 8bpp on I mode
            else if (TexFormatBox.SelectedIndex == 3 && BitsizeBox.SelectedIndex > 2) BitsizeBox.SelectedIndex = 2; //Prevent bitsize > 16bpp on IA mode
            else if (TexFormatBox.SelectedIndex == 0 && BitsizeBox.SelectedIndex < 2) BitsizeBox.SelectedIndex = 2; //Prevent bitsize < 16bpp on RGBA mode
            else if (TexFormatBox.SelectedIndex == 2 && BitsizeBox.SelectedIndex > 0) BitsizeBox.SelectedIndex = 0; //Prevent bitsize > 8bpp on CI mode (only 4bpp atm, update later)
            else if (TexFormatBox.SelectedIndex == 1 && BitsizeBox.SelectedIndex != 2) BitsizeBox.SelectedIndex = 2; //Prevent bitsize that's not 16bpp on YUV
        }

        private void ImportTexture_Click(object sender, EventArgs e)
        {
            int index = TextureNumBox.SelectedIndex;
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog OpenTexture = OFD();
            OpenTexture.Filter = "Image Files|*.png;*.bmp;*.jpg";
            OpenTexture.Title = "Select a texture image file";
            if (OpenTexture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap TextureBMP = (Bitmap)Image.FromFile(OpenTexture.FileName);
                double widthpower = Math.Log(TextureBMP.Width, 2);
                double heightpower = Math.Log(TextureBMP.Height, 2);
                if ((widthpower % 1) != 0 || (heightpower % 1) != 0)
                {
                    MessageBox.Show("Only texture sizes in powers of 2 \n(ie 16x16, 32x32, 64x64, 128x64) are supported!", "Invalid texture resolution");
                    return;
                }
                Vector2 originalpowers = Textures.getWidthHeightPowers(index);
                if ((Math.Pow(2, originalpowers.X) * Math.Pow(2, originalpowers.Y)) < (Math.Pow(2, widthpower) * Math.Pow(2, heightpower)))
                {
                    MessageBox.Show("Texture is beyond the max data for this tile! \nTry lowering resolution or bitsize.", "Texture data too large!");
                    return;
                }
                else if (TexFormatBox.SelectedIndex == 2 && ((Math.Pow(2, originalpowers.X) * Math.Pow(2, originalpowers.Y)) < (Math.Pow(2, widthpower + 1) * Math.Pow(2, heightpower)))) //CI4 needs twice data atm for palette
                {
                    MessageBox.Show("Texture is beyond the max data for this tile! \nTry lowering resolution or bitsize.\n(CI needs extra data for palette and commands)", "Texture data too large!");
                    return;
                }
                else if (TexFormatBox.SelectedIndex == 2 && BitsizeBox.SelectedIndex == 0 && Textures.getImageColors(TextureBMP).Length > 16)
                {
                    MessageBox.Show("Texture has too many colours for CI4.\nPlease reduce colour count to 16."); return;
                }
                Textures.ResizeTexture(index, Convert.ToInt32(widthpower), Convert.ToInt32(heightpower));
                Textures.ImportBMPtoTexture(TextureBMP, index);
                UInt32[] F5CMDs = Textures.F5CMDArray[TextureNumBox.SelectedIndex]; ROM SM64ROM = ROMManager.SM64ROM;
                ROMManager.InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
                UpdateTextureNum();
                int width = TextureBMP.Width;
                int selectedbitsize = (int)(4*Math.Pow(2, BitsizeBox.SelectedIndex));
                ushort linesperword = Convert.ToUInt16((64d * 2048d) / ((double)TextureBMP.Width * selectedbitsize));
                ushort texelcount = (ushort)((double)(TextureBMP.Width * TextureBMP.Height) * ((double)selectedbitsize / 16d) - 1);
                for (uint i = 0; i < F5CMDs.Length; i++) //Update F5 scanline width 
                {
                    uint F5 = F5CMDs[i];
                    if (SM64ROM.getByte(F5 - 0x10) == 0xF3) SM64ROM.WriteEightBytes(F5-0x10, 0xF300000007000000 | (uint)(texelcount << 12) | linesperword);
                    SM64ROM.WriteTwoBytes(F5 + 1, (ushort)((SM64ROM.ReadTwoBytes(F5CMDs[i] + 1) & 0xFC00) | ((width * selectedbitsize / 64) << 1)));
                }
                TextureBMP.Dispose();
            }
        }

        private void UpdatePreviewColour()
        {
            Bitmap colour = new Bitmap(16, 1);
            byte A = (byte)AlphaNum.Value;
            byte R = (byte)Math.Round(RedNum.Value * ((decimal)Brightness.Value / 100));
            byte G = (byte)Math.Round(GreenNum.Value * ((decimal)Brightness.Value / 100));
            byte B = (byte)Math.Round(BlueNum.Value * ((decimal)Brightness.Value / 100));
            Graphics colourGraphics = Graphics.FromImage(colour);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(A, R, G, B));
            colourGraphics.FillRectangle(brush, 0, 0, 16, 1);
            ColourPreview.Image = colour;
        }
        //Update preview on any of these calls:
        private void Brightness_Scroll(object sender, EventArgs e) { UpdatePreviewColour(); }
        private void RedNum_ValueChanged(object sender, EventArgs e) { UpdatePreviewColour(); }
        private void GreenNum_ValueChanged(object sender, EventArgs e) { UpdatePreviewColour(); }
        private void BlueNum_ValueChanged(object sender, EventArgs e) { UpdatePreviewColour(); }
        private void AlphaNum_ValueChanged(object sender, EventArgs e) { UpdatePreviewColour(); }
        //PaletteBoxes
        private void PaletteBox1_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox1, e); }
        private void PaletteBox2_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox2, e); }
        private void PaletteBox3_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox3, e); }
        private void PaletteBox4_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox4, e); }
        private void PaletteBox5_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox5, e); }
        private void PaletteBox6_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox6, e); }
        private void PaletteBox7_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox7, e); }
        private void PaletteBox8_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox8, e); }
        private void PaletteBox9_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox9, e); }
        private void PaletteBox10_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox10, e); }
        private void PaletteBox11_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox11, e); }
        private void PaletteBox12_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox12, e); }
        private void PaletteBox13_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox13, e); }
        private void PaletteBox14_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox14, e); }
        private void PaletteBox15_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox15, e); }
        private void PaletteBox16_Click(object sender, EventArgs e) { PaletteSelection(PaletteBox16, e); }
        private void PaletteSelection(PictureBox PaletteBoxNum, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs)e;
            if (me.Button == MouseButtons.Left && PaletteBoxNum.Image != null)
            {
                Bitmap palettecolour = (Bitmap)PaletteBoxNum.Image;
                System.Drawing.Color colour = palettecolour.GetPixel(0, 0);
                RedNum.Value = colour.R;
                GreenNum.Value = colour.G;
                BlueNum.Value = colour.B;
                AlphaNum.Value = colour.A;
            }
            else if (me.Button == MouseButtons.Right)
            {
                Bitmap colour = new Bitmap(16, 1);
                byte A = (byte)AlphaNum.Value;
                byte R = (byte)RedNum.Value;
                byte G = (byte)GreenNum.Value;
                byte B = (byte)BlueNum.Value;
                Graphics colourGraphics = Graphics.FromImage(colour);
                SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(A, R, G, B));
                colourGraphics.FillRectangle(brush, 0, 0, 16, 1);
                PaletteBoxNum.Image = colour;
            }
        }

        private void saveTextureAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveTexture = SFD();
            SaveTexture.Filter = "Image File|*.png;*.bmp;*.jpg";
            SaveTexture.Title = "Save a texture image file.";
            if (SaveTexture.ShowDialog() == System.Windows.Forms.DialogResult.OK && SaveTexture.FileName != "") // If the file name is not an empty string open it for saving. 
            {
                if (TexturePreview != null && SaveTexture.FileName != null)
                {
                    TexturePreview.Image.Save(SaveTexture.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        public void writeToStatusLabel(string text)
        {
            StatusLabel.Text = text;
        }
    }

    

    
}
