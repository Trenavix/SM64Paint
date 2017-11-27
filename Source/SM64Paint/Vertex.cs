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

public struct Vertex
{
    public static readonly int MaxInt16 = 0x7FFF;
    public static UInt32[] CurrentVertexList = new UInt32[0];
    Int16 X;
    Int16 Y;
    Int16 Z;
    float U;
    float V;
    float R;
    float G;
    float B;
    float A;
    UInt32 Addr;

    Vertex(Int16 X, Int16 Y, Int16 Z, float U, float V, float R, float G, float B, float A, UInt32 Addr)
    {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.U = U;
        this.V = V;
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
        this.Addr = Addr;
    }

    public static Vertex getVertex(UInt32 Addr, ROM SM64ROM)
    {
            Vertex NewVert = new Vertex
            (
            (short)SM64ROM.ReadTwoBytes(Addr),
            (short)SM64ROM.ReadTwoBytes(Addr + 2),
            (short)SM64ROM.ReadTwoBytes(Addr + 4),
            (float)((short)SM64ROM.ReadTwoBytes(Addr + 8)) / (0x400),
            (float)((short)SM64ROM.ReadTwoBytes(Addr + 10)) / (0x400),
            (float)SM64ROM.getByte(Addr + 12) / 255,
            (float)SM64ROM.getByte(Addr + 13) / 255,
            (float)SM64ROM.getByte(Addr + 14) / 255,
            (float)SM64ROM.getByte(Addr + 15) / 255,
            Addr
            );
        if (Textures.FirstTexLoad)
        {
            Array.Resize(ref CurrentVertexList, CurrentVertexList.Length + 1);
            CurrentVertexList[CurrentVertexList.Length - 1] = Addr;
        }
        return NewVert;
    }

    public Vector3 getCoordVector()
    {
        return new Vector3(X, Y, Z);
    }

    public UInt32 getAddr()
    {
        return Addr;
    }

    public Vector2 getUVVector()
    {
        return new Vector2(U / Textures.S_Scale, V / Textures.T_Scale);
    }

    public Vector4 getRGBAVector()
    {
        return new Vector4(R, G, B, A);
    }

    public Color4 getRGBAColor()
    {
        return new Color4(R, G, B, A);
    }
    public Vector3 getRGBColor()
    {
        return new Vector3(R, G, B);
    }
    public Vector3 getNormals()
    {
        float x = (sbyte)R / 127f;
        float y = (sbyte)G / 127f;
        float z = (sbyte)B / 127f;
        return new Vector3(x, y, z);
    }

}