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

namespace SM64Paint
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        MouseState state;
        Vector2 oldXYDelta = new Vector2(0, 0);
        Vector2 XYEnd = new Vector2(0,0);
        String currentROMPath;
        bool VertexReading = false;

        public Form1()
        {
            InitializeComponent();
            RenderPanel.Dock = DockStyle.Fill;
            OpenTK.Toolkit.Init();
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
        }

        private static OpenFileDialog OFD() => new OpenFileDialog();

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an early beta of a vertex painter for SM64.\n"+
                "This program was coded entirely by Trenavix, and is far from finished.\n"+
                "It is licensed by GPL and is available at: \nGitHub.com/Trenavix/SM64Paint\n"+
                "Author's pages:\nYouTube.com/Trenavix\nPatreon.com/Trenavix\n" + 
                "(SM64Paint Icon was designed entirely by Quasmok)", 
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
            if (!VertexReading) RenderPanel.Invalidate();
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
            if (state[MouseButton.Left] && pt.X > 0 && pt.Y > 0 && pt.X < Boundaries.X && pt.Y < Boundaries.Y && this.ContainsFocus==true) //Left Click in GLControl & windowfocused
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
            else //When not clicking, track mouse position
            {
                lastMousePos.X = Control.MousePosition.X;
                lastMousePos.Y = Control.MousePosition.Y;
            }
            if (state[MouseButton.Left] && pt.Y > 104 && pt.Y < 245 && pt.X > RenderPanel.Width-149 && pt.X < RenderPanel.Width-9 && ControlPanel.Visible) //Colour Picker
            {
                Point cursor = new Point();
                GetCursorPos(ref cursor);
                //StatusLabel.Text += cursor.ToString();
                System.Drawing.Color PxColor = GetColorAt(cursor);
                this.BackColor = PxColor;
                RedNum.Value = PxColor.R;
                GreenNum.Value = PxColor.G;
                BlueNum.Value = PxColor.B;
                //AlphaNum.Value = PxColor.A; //All alpha here is 255 so don't copy it
            }
            if (state[MouseButton.Right])
            {
                Renderer.EditVertex(ClientRectangle, Width, Height, RenderPanel, pt, (byte)RedNum.Value, (byte)GreenNum.Value, (byte)BlueNum.Value, (byte)AlphaNum.Value);
            }
            else Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
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
                    KeyboardState state = Keyboard.GetState();
                    if (!state[Key.AltRight]) break;
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
            }
                    
        }

        void RenderPanel_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(Renderer.cam.MoveSpeed > 0f) Renderer.cam.MoveSpeed += 0.0000001f*e.Delta;
            if(Renderer.cam.MoveSpeed <= 0f) Renderer.cam.MoveSpeed = 0.000005f;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            /*while (RenderPanel.IsIdle)
            {
                Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
            }*/
        }
       
        private void SaveROMAs_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the bin  
            SaveFileDialog SaveROM = new SaveFileDialog();
            SaveROM.Filter = "SM64 ROM File|*.z64;*.rom;*.v64;*.n64";
            SaveROM.Title = "Save a SM64 ROM file.";
            if (SaveROM.ShowDialog() == System.Windows.Forms.DialogResult.OK && SaveROM.FileName != "") // If the file name is not an empty string open it for saving. 
                {
                        File.WriteAllBytes(SaveROM.FileName, ROMManager.SM64ROM.getCurrentROM());
                }
        }
        
        private void OpenROM_Click(object sender, EventArgs e)
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
                    ROMManager.LoadROM(OpenROM.FileName);
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
            ROMManager.InitialiseModelLoad();
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
            UpdateStatusText();
        }

        private void LevelArea_SelectedIndexChange(object sender, EventArgs e)
        {
            Renderer.LevelArea = (uint)AreaComboBox.SelectedIndex;
            ROMManager.InitialiseModelLoad();
            Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
            UpdateStatusText();
        }

        private void ForceVertRGBAButton_Click(object sender, EventArgs e)
        {
            ROMManager.ForceVertRGBA(ForceOpaqueRGBA.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ROMManager.ForceVertNorms(ForceOpaqueRGBA.Checked);
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
            for (int i = 0; i < Vertex.CurrentVertexList.Length; i++)
            {
                ROMManager.SetVertRGBA(Vertex.CurrentVertexList[i], (byte)RedNum.Value, (byte)GreenNum.Value, (byte)BlueNum.Value, (byte)AlphaNum.Value);
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

        void RenderPanel_KeyDown(object sender, KeyEventArgs e)
        {

        }

        void RenderPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        void RenderPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }

    

    
}
