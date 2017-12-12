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
using OpenTK.Graphics.OpenGL;
using System.Drawing;

public class GeoLayouts
{
    static uint JumpAddr;
    static uint increment = 0;
    static byte drawlayer;
    public static bool OpaqueRendered = false;
    public static uint[] OpaqueModels;
    public static uint[] AlphaModels;
    public static uint ExtAlphaDLPointer = 0; //Needed to repoint in extended roms
    public static uint[][] ExtDLPointers;

    public static void ParseGeoLayout(ROM SM64ROM, uint offset, bool ColourBuffer)
    {
        if (SM64ROM == null) return;
        if (Textures.FirstTexLoad)
        {
            ExtDLPointers = new uint[7][];
            for (int i = 0; i < 7; i++) ExtDLPointers[i] = new uint[0];
        } 
        OpaqueRendered = false;
        DecodeGeoLayout(SM64ROM, offset, ColourBuffer);
        OpaqueRendered = true;
        DecodeGeoLayout(SM64ROM, offset, ColourBuffer);
        if(!ColourBuffer) Textures.FirstTexLoad = false;
    }
    public static void DecodeGeoLayout(ROM SM64ROM, uint offset, bool ColourBuffer)
    {
        for (uint i = offset; i < SM64ROM.getEndROMAddr();)
        {
            if (SM64ROM.getByte(i) > 0x20) return;
            uint segaddr;
            switch (SM64ROM.getByte(i))
            {
                case 0:
                    increment = 8;
                    break;
                case 1:;
                    return;
                case 2:
                    JumpAddr = SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(i + 4));
                    GeoLayouts.DecodeGeoLayout(SM64ROM, JumpAddr, ColourBuffer);
                    if (SM64ROM.getByte(i + 1) == 0) return;
                    increment = 8;
                    break;
                case 3:
                    return;
                case 4:
                    //open node
                    increment = 4;
                    break;
                case 5:
                    //close node
                    increment = 4;
                    break;
                case 8:
                    increment = 12;
                    break;
                case 9:
                    increment = 4;
                    break;
                case 0x0A:
                    if (SM64ROM.getByte(i + 1) > 0) increment = 12;
                    else increment = 8;
                    break;
                case 0x0B:
                    increment = 4;
                    break;
                case 0x0C:
                    increment = 4;
                    break;
                case 0x0D:
                    increment = 8;
                    break;
                case 0x0E:
                    increment = 8;
                    break;
                case 0x0F:
                    increment = 0x14;
                    break;
                case 0x10:
                    //rotate
                    increment = 16;
                    break;
                case 0x13:
                    //Load DL with rotation
                    increment = 12;
                    if (SM64ROM.getByte(i + 8) == 0) break;
                    drawlayer = SM64ROM.getByte(i + 1);
                    if (drawlayer > 4 && !GeoLayouts.OpaqueRendered) break;
                    if (drawlayer <= 4 && GeoLayouts.OpaqueRendered) break;
                    segaddr = SM64ROM.ReadFourBytes(i + 8);
                    DecideBufferAndAddr(SM64ROM.getByte(i + 1), segaddr, ColourBuffer);
                    F3D.ParseF3DDL(SM64ROM, segaddr, ColourBuffer);
                    break;
                case 0x14:
                    //billboard
                    increment = 8;
                    break;
                case 0x15:
                    //Load DL
                    increment = 8;
                    drawlayer = SM64ROM.getByte(i + 1);
                    if (drawlayer >= 4) ExtAlphaDLPointer = i;
                    if (drawlayer > 4 && !GeoLayouts.OpaqueRendered) break;
                    if (drawlayer <= 4 && GeoLayouts.OpaqueRendered) break;
                    segaddr = SM64ROM.ReadFourBytes(i + 4);
                    DecideBufferAndAddr(SM64ROM.ReadEightBytes(i), segaddr, ColourBuffer);
                    F3D.ParseF3DDL(SM64ROM, segaddr, ColourBuffer);
                    if (!Textures.FirstTexLoad) break;
                    Array.Resize(ref ExtDLPointers[drawlayer], ExtDLPointers[drawlayer].Length + 1); //Increase size by one to add
                    ExtDLPointers[drawlayer][ExtDLPointers[drawlayer].Length-1] = i; //set last index to addr
                    break;
                case 0x16:
                    increment = 8;
                    break;
                case 0x17:
                    increment = 4;
                    break;
                case 0x18:
                    increment = 8;
                    break;
                case 0x19:
                    increment = 8;
                    break;
                case 0x1A:
                    increment = 8;
                    break;
                case 0x1D:
                    //scale, can be 12 length in rare occurence
                    increment = 8;
                    break;
                case 0x1E:
                    increment = 8;
                    break;
                case 0x1F:
                    increment = 16;
                    break;
                case 0x20:
                    increment = 4;
                    break;
            }
            /*if(Textures.FirstTexLoad)using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"e:\test4.txt", true)) //Debug Txt
            {
                file.Write(i.ToString("x") + ": ");
                for (uint j = i; j < i + increment; j++)
                {
                    file.Write(SM64ROM.getByte(j).ToString("x") + " ");
                }
                file.WriteLine("\n");
                file.Close();
            }*/
            i += increment;

        }
    }

    public static Int32 readSegmentAddr(byte[] cmd)
    {
        Int32 value = 0;
        for (int i = 5; i < 8; i++)
        {
            value = (value << 8) | cmd[i];
        }
        return value;
    }

    private static void DecideBufferAndAddr(ulong CMD, uint segaddr, bool ColourBuffer)
    {
        byte layer = (byte)((CMD >> 48) & 0xFF);
        if (layer == 2 || layer == 6) GL.DepthRange(0.00001, 0.99999f);
        else GL.DepthRange(0, 1f);
        if (ColourBuffer || F3D.RenderEdges)
        {
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Light0);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.AlphaTest);
            if (F3D.RenderEdges)
            {
                GL.DepthRange(0.00001, 0.99999f);
            }
            return;
        }
        if (layer > 4)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }
        else GL.Disable(EnableCap.Blend);
        if (layer == 4)
        {
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Greater, 0.0f);
        }
        else GL.Disable(EnableCap.AlphaTest);
        if (drawlayer >= 4 && Textures.FirstTexLoad) //Add alpha or opaque model addresses to array
        {
            Array.Resize(ref AlphaModels, AlphaModels.Length + 1);
            AlphaModels[AlphaModels.Length - 1] = ROMManager.SM64ROM.readSegmentAddr(segaddr);
        }
        else if (drawlayer < 4 && Textures.FirstTexLoad)
        {
            Array.Resize(ref OpaqueModels, OpaqueModels.Length + 1);
            OpaqueModels[OpaqueModels.Length - 1] = ROMManager.SM64ROM.readSegmentAddr(segaddr);
        }
    }
}


