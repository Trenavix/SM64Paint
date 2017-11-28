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

using OpenTK;
using System;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using static OpenTK.GLControl;
using System.Drawing;

class Renderer
{
    public static bool WireFrameMode = false;
    public static bool TextureEnabler = true;
    public static bool ViewNonRGBA = true;

    public static Camera cam = new Camera();
    public static Vector2 lastMousePos = new Vector2();
    public static uint TriCount = 0;
    public static uint VertexCount = 0;
    public static uint LevelArea = 0;
    public static Matrix4 projection;
    public static Matrix4 modelview;
    //Cube Intro Screen
    public static double CubeSampleRotate = Math.PI/2;
    public static double CubeSampleScale = 0;
    public static Color4 CubeSampleColour = new Color4(0f, 0f, 1f, 1f);
    public static float CubeRealRotation = 0;
    public static bool EdgesOption = false;

    public static void InitialiseView()
    {
        GL.ClearStencil(0);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref modelview);
        GL.ClearColor(0, 0, 0, 0);
        GL.Enable(EnableCap.DepthTest);
    }

    public static void Render(Rectangle ClientRectangle, int Width, int Height, GLControl RenderPanel)
    {
        TriCount = 0;
        VertexCount = 0;
        GL.Viewport(ClientRectangle.X, ClientRectangle.Y, RenderPanel.Width, RenderPanel.Height);
        projection = cam.GetViewMatrix() * Matrix4.CreatePerspectiveFieldOfView(1.0f, Width / (float)Height, 0.0000001f, 1.0f);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projection);
        InitialiseView();
        if (WireFrameMode) GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        else GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        GL.Scale(0.000001, 0.000001, 0.000001);
        if (ROMManager.ReadytoLoad)
        {
            GL.Scale(0.01, 0.01, 0.01);
            GeoLayouts.ParseGeoLayout(ROMManager.SM64ROM, LevelScripts.getGeoAddress(LevelArea), false);
            if (EdgesOption)
            {
                GL.Disable(EnableCap.CullFace);
                F3D.RenderEdges = true;
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GeoLayouts.ParseGeoLayout(ROMManager.SM64ROM, LevelScripts.getGeoAddress(LevelArea), false);
                F3D.RenderEdges = false;
            }
        }
        else //Rotate cubes for fun idle :)
        {
            if (CubeSampleRotate >= Math.PI * 1.5) { CubeSampleRotate = Math.PI / 2; CubeSampleColour = new Color4(0f, 0f, 1f, 1f); }
            if (CubeSampleScale >= Math.PI*2) CubeSampleScale = 0;
            GL.Scale(1 + 0.25 * Math.Sin(CubeSampleScale), Math.Sin(CubeSampleScale), Math.Sin(CubeSampleScale));
            float rotation = 90 * (float)Math.Sin(CubeSampleRotate);
            CubeRealRotation = rotation;
            float newcolour = Math.Abs(rotation);
            GL.Rotate(rotation, 1, 0, 0);
            CubeSampleColour.R = (newcolour) / 45;
            CubeSampleColour.G = (newcolour) / 45;
            DrawCube();
            GL.Rotate(rotation, 1, 0, 0);
            CubeSampleColour.R = (newcolour) / 45;
            CubeSampleColour.G = (newcolour) / 45;
            DrawCube();
            GL.Rotate(rotation, 1, 0, 0);
            CubeSampleColour.R = (newcolour) / 45;
            CubeSampleColour.G = (newcolour) / 45;
            DrawCube();
            GL.Rotate(rotation, 1, 0, 0);
            CubeSampleColour.R = (newcolour) / 45;
            CubeSampleColour.G = (newcolour) / 45;
            DrawCube();
            KeyboardState state = Keyboard.GetState();
            CubeSampleScale += 0.015;
            CubeSampleRotate += 0.015;
        }
        RenderPanel.SwapBuffers();
    }

    public static void RenderColourBuffer(Rectangle ClientRectangle, int Width, int Height, GLControl RenderPanel)
    {
        GL.Viewport(ClientRectangle.X, ClientRectangle.Y, RenderPanel.Width, RenderPanel.Height);
        projection = cam.GetViewMatrix() * Matrix4.CreatePerspectiveFieldOfView(1.0f, Width / (float)Height, 0.0000001f, 1.0f);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projection);
        InitialiseView();
        GL.Scale(0.000001, 0.000001, 0.000001);
        if (ROMManager.ReadytoLoad)
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Scale(0.01, 0.01, 0.01);
            GeoLayouts.ParseGeoLayout(ROMManager.SM64ROM, LevelScripts.getGeoAddress(LevelArea), true);
        }
        //RenderPanel.SwapBuffers(); //We don't want people to see the vertex selection colour map so don't invalidate here!
    }

    public static void EditVertex(Rectangle ClientRectangle, int Width, int Height, GLControl RenderPanel, Point pt, byte R, byte G, byte B, byte A)
    {
            byte[] color = new byte[4];
            Renderer.RenderColourBuffer(ClientRectangle, Width, Height, RenderPanel);
            GL.ReadPixels(pt.X, RenderPanel.Height - pt.Y - 1, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, color);
            UInt32 Addr = (UInt32)((color[0] << 24) | (color[1] << 16) | (color[2] << 8) | color[3]);
            //StatusLabel.Text = Addr.ToString("x");
            if (Addr != 0) for (uint i = 0; i < Vertex.CurrentVertexList.Length; i++)
            {
                if (Addr == Vertex.CurrentVertexList[i])
                {
                    ROMManager.SetVertRGBA(Vertex.CurrentVertexList[i], R, G, B, A);
                    break;
                }
            }
    }

    public static void DrawCube()
    {
        //GL.BindTexture(TextureTarget.Texture2D, texture);
        GL.Begin(BeginMode.Quads);

        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, -1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, -1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, -1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, -1.0f);

        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, -1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, -1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, 1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, 1.0f);

        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, -1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, -1.0f);

        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-16.0f, -7.0f, 1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, 1.0f);

        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, -1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-16.0f, -5.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, 1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, -1.0f);

        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, -1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, -1.0f);
        GL.Color4(CubeSampleColour); GL.Vertex3(-18.0f, -5.0f, 1.0f);
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f); GL.Vertex3(-18.0f, -7.0f, 1.0f);

        GL.End();
    }
    
}

public class Camera
{
    public static Vector3 Position = Vector3.Zero;
    public Vector3 Orientation = new Vector3(0f, 0f, 0f);
    public float MoveSpeed = 0.0000002f;
    public float MouseSensitivity = 0.005f;
    public Vector3 CamRotation;

    public Matrix4 GetViewMatrix()
    {
        Vector3 lookat = new Vector3();

        lookat.X = (float)(Math.Cos((float)Orientation.X) * Math.Cos((float)Orientation.Y));
        lookat.Y = (float)Math.Sin((float)Orientation.Y);
        lookat.Z = (float)(Math.Sin((float)Orientation.X) * Math.Cos((float)Orientation.Y));
        CamRotation = lookat;
        return Matrix4.LookAt(Position, Position + lookat, Vector3.UnitY);
    }

    public void Move(float x, float y, float z)
    {
        Vector3 offset = new Vector3();

        Vector3 forward = new Vector3((float)Math.Cos((float)Orientation.X), (float)(2 * Math.Sin((float)Orientation.Y)), (float)Math.Sin((float)Orientation.X));
        Vector3 right = new Vector3(-forward.Z, 0, forward.X);

        offset += x * right;
        offset += y * forward;
        offset.Y += z;

        offset.NormalizeFast();
        offset = Vector3.Multiply(offset, MoveSpeed);

        Position += offset;
    }

    public void AddRotation(float x, float y)
    {
        Orientation.X = ((x * MouseSensitivity));
        Orientation.Y = ((-y * MouseSensitivity));
    }

    public void WASDMoveMent()
    {
        KeyboardState state = Keyboard.GetState();
        if (state[Key.W] && state[Key.ShiftLeft]) Renderer.cam.Move(0f, 1.2f, 0f);
        if (state[Key.W]) Renderer.cam.Move(0f, 0.1f, 0f);
        if (state[Key.S] && state[Key.ShiftLeft]) Renderer.cam.Move(0f, -1.2f, 0f);
        if (state[Key.S]) Renderer.cam.Move(0f, -0.1f, 0f);
        if (state[Key.A] && state[Key.ShiftLeft]) Renderer.cam.Move(-1.2f, 0f, 0f);
        if (state[Key.A]) Renderer.cam.Move(-0.1f, 0f, 0f);
        if (state[Key.D] && state[Key.ShiftLeft]) Renderer.cam.Move(1.2f, 0f, 0f);
        if (state[Key.D]) Renderer.cam.Move(0.1f, 0f, 0f);
        if (state[Key.E] && state[Key.ShiftLeft]) Renderer.cam.Move(0f, 0f, 1.2f);
        if (state[Key.E]) Renderer.cam.Move(0f, 0f, 0.1f);
        if (state[Key.Q] && state[Key.ShiftLeft]) Renderer.cam.Move(0f, 0f, -1.2f);
        if (state[Key.Q]) Renderer.cam.Move(0f, 0f, -0.1f);
    }
}



