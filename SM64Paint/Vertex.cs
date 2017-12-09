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
    public static UInt32[][][] OriginalVertexMem = new UInt32[30][][]; //30 undo levels
    public static UInt32[][][] EditedVertexMem = new UInt32[30][][]; //30 redo levels
    Int16 X;
    Int16 Y;
    Int16 Z;
    Int16 U;
    Int16 V;
    byte R;
    byte G;
    byte B;
    byte A;
    UInt32 Addr;

    Vertex(Int16 X, Int16 Y, Int16 Z, Int16 U, Int16 V, byte R, byte G, byte B, byte A, UInt32 Addr)
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
            (short)SM64ROM.ReadTwoBytes(Addr + 8),
            (short)SM64ROM.ReadTwoBytes(Addr + 10),
            SM64ROM.getByte(Addr + 12),
            SM64ROM.getByte(Addr + 13),
            SM64ROM.getByte(Addr + 14),
            SM64ROM.getByte(Addr + 15),
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
        return new Vector2((float)U / (0x400) / Textures.S_Scale, (float)V / (0x400) / Textures.T_Scale);
    }

    public Vector4 getRGBAVector()
    {
        return new Vector4(R, G, B, A);
    }

    public Color4 getRGBAColor()
    {
        return new Color4((float)R / 255, (float)G / 255, (float)B / 255, (float)A / 255);
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

    public static UInt32 getAddrFromTriIndex(UInt32 VTXStartAddr, byte index)
    {
        UInt32 offset = (uint)(index / 0x0A) * 16;
        UInt32 addr = (UInt32)(VTXStartAddr + offset);
        return addr;
    }

    public static double[][] UVChecker(double[][] UVs)
    {
        bool reoccur = true;
        while (reoccur)
        {
            bool UMinusRange = false;
            bool VMinusRange = false;
            bool URange = false;
            bool VRange = false;
            for (int i = 0; i < 3; i++)
            {
                if (UVs[0][i] > 0x7FFF) URange = true;
                else if (UVs[0][i] < -0x8000) UMinusRange = true;
                if (UVs[1][i] > 0x7FFF) VRange = true;
                else if (UVs[1][i] < -0x8000) VMinusRange = true;
            }
            if (!UMinusRange && !VMinusRange && !URange && !VRange) reoccur = false;
            for (int i = 0; i < 3; i++)
            {
                if (URange) UVs[0][i] -= 0x7FFF;
                else if (UMinusRange) UVs[0][i] += 0x8000;
                if (VRange) UVs[1][i] -= 0x7FFF;
                else if (VMinusRange) UVs[1][i] += 0x8000;
            }
        }
        return UVs;
    }



}