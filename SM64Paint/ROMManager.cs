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
using System.Drawing;
using System.IO;

public class ROMManager
{
    public static bool ReadytoLoad = false;
    public static ROM SM64ROM;
    public static readonly bool debug = false;

    public static void LoadROM(String BinDirectory, Rectangle ClientRectangle, GLControl RenderPanel, int Width = 0, int Height = 0)
    {
        using (FileStream fs = new FileStream(BinDirectory, FileMode.Open, FileAccess.Read))
        {
            byte[] ROMFile = new byte[fs.Length];
            fs.Read(ROMFile, 0, (int)fs.Length);
            ROM NewSM64ROM = new ROM(ROMFile);
            SM64ROM = NewSM64ROM;
            fs.Close();
        }
        InitialiseModelLoad(ClientRectangle, RenderPanel, Width, Height);
    }

    public static void SetVertRGBA(uint Addr, UInt32 colour, bool AlphaOnly)
    {
        byte alpha = (byte)(colour & 0xFF);
        if (AlphaOnly) SM64ROM.changeByte(Addr + 15, alpha);
        else SM64ROM.WriteFourBytes(Addr + 12, colour);
        if (debug)
        {
            if (AlphaOnly) Console.Write("Wrote 0x" + alpha.ToString("x2") + " to ROM addr 0x" + Addr.ToString("x8") + " (Vertex RGBA)\n");
            else Console.Write("Wrote 0x" + alpha.ToString("x2") + " to ROM addr 0x" + Addr.ToString("x8") + " (Vertex RGBA)\n");
        }
    }

    public static void SetVertAlpha(uint Addr, byte alpha)
    {
        SM64ROM.changeByte(Addr + 15, alpha);
        if (debug) Console.Write("Wrote 0x" + alpha.ToString("x2") + " to ROM addr 0x" + Addr.ToString("x8") + " (Vertex Alpha)\n");
    }

    public static void ForceVertRGBA(bool Opaque)
    {
        int addresscount;
        if (Opaque) addresscount = GeoLayouts.OpaqueModels.Length;
        else addresscount = GeoLayouts.AlphaModels.Length;
        for (int i = 0; i < addresscount; i++)
        {
            if (Opaque) ForceVertRGBAJump(GeoLayouts.OpaqueModels[i], true);
            else ForceVertRGBAJump(GeoLayouts.AlphaModels[i], false);
            InitialiseModelLoad(Rectangle.Empty, new GLControl()); //init without rendering
            GeoLayouts.ParseGeoLayout(ROMManager.SM64ROM, LevelScripts.getGeoAddress(Renderer.LevelArea), false);
        }
    }

    private static void ForceVertRGBAJump(uint addr, bool Opaque)
    {
        uint B8Addr = addr;
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8) //Check if B7 is already at end of DL
        {
            if (SM64ROM.getByte(j) == 0xB8)
            {
                if (SM64ROM.ReadEightBytes(j - 8) == 0xB700000000020000) return;
                else B8Addr = j;
                break;
            }
        }
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8) //Stuff is changed here
        {
            uint Shadefix = 0x86; // fixes forcergba in rom manager roms made with newer versions of rom manager
			if (LevelScripts.IsRomManager == true) { Shadefix = 0x88; }
            if (SM64ROM.getByte(j) == 0x03 && SM64ROM.getByte(j + 1) == Shadefix)
            {
                SM64ROM.WriteEightBytes(j, 0xB700000000020000);
                SM64ROM.cutBytes(j, B8Addr - 8, 8);
                SM64ROM.WriteEightBytes(j, 0xB600000000020000);
            }
            else if (SM64ROM.getByte(j) == 0xB8) return;
            else if (SM64ROM.getByte(j) == 0xB7 && SM64ROM.getByte(j + 5) == 0) SM64ROM.WriteEightBytes(j, 0xB700000000020000);
            else if (SM64ROM.getByte(j) == 0xB7 && SM64ROM.getByte(j + 5) == 1) SM64ROM.WriteEightBytes(j, 0xB600000000020000);
        }
    }


    private static void AddToSegAddr(uint addr, uint addamount)
    {
        UInt32 SegAddr = SM64ROM.ReadFourBytes(addr);
        SegAddr += addamount;
        SM64ROM.WriteFourBytes(addr, SegAddr);
    }

    public static void InitialiseModelLoad(Rectangle ClientRectangle, GLControl RenderPanel, int Width = 0, int Height = 0)
    {
        Textures.currentTexAddr = 0;
        Textures.TextureArray = new int[0];
        Textures.TextureAddrArray = new uint[0][];
        Textures.F5CMDArray = new uint[0][];
        Vertex.CurrentVertexList = new UInt32[0];
        GeoLayouts.OpaqueModels = new uint[0];
        GeoLayouts.AlphaModels = new uint[0];
        Textures.FirstTexLoad = true;
        Textures.S_Scale = 1f;
        Textures.T_Scale = 1f;
        if (Width == 0 || Height == 0) return;
        Renderer.Render(ClientRectangle, Width, Height, RenderPanel);
    }

    public static void AdjustAlphaCombiners()
    {
        if (GeoLayouts.AlphaModels.Length < 1) return;
        for (uint i = 0; i < GeoLayouts.AlphaModels.Length; i++)
        {
            uint addr = GeoLayouts.AlphaModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xFC)
                {
                    UInt64 setcombine = SM64ROM.ReadEightBytes(j);
                    if (setcombine == 0xFC122E24FFFFFBFD || setcombine == 0xFC121824FF33F238)
                        SM64ROM.WriteEightBytes(j, 0xFC121824FF33FFFF); //Fix combiner
                }
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
    }
    public static void AdjustOpaqueCombiners()
    {
        if (GeoLayouts.OpaqueModels.Length < 1) return;
        for (uint i = 0; i < GeoLayouts.OpaqueModels.Length; i++)
        {
            uint addr = GeoLayouts.OpaqueModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xFC)
                {
                    UInt64 setcombine = SM64ROM.ReadEightBytes(j);
                    if (setcombine == 0xFC122E24FFFFFBFD || setcombine == 0xFC121824FF33F238 || setcombine == 0xFC127FFFFFFFF838)
                        SM64ROM.WriteEightBytes(j, 0xFC127E24FFFFF9FC); //Fix opaque combiner
                }
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
    }

    public static void RemoveEnvColour(bool key)
    {
        if (key == true) 
    { 
       RemoveOpaqueEnvColour(); 
    }
    RemoveAlphaEnvColour();
    }
    public static void RemoveOpaqueEnvColour()
    {
        if (GeoLayouts.OpaqueModels.Length < 1) return;
        for (uint i = 0; i < GeoLayouts.OpaqueModels.Length; i++)
        {
            uint addr = GeoLayouts.OpaqueModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xFB) SM64ROM.WriteEightBytes(j, 0xFC127E24FFFFFDFE); //Get rid of env colour combiners with a NOP
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
    }

    public static void RemoveAlphaEnvColour()
    {
        if (GeoLayouts.AlphaModels.Length < 1) return;
        for (uint i = 0; i < GeoLayouts.AlphaModels.Length; i++)
        {
            uint addr = GeoLayouts.AlphaModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xFB) SM64ROM.WriteEightBytes(j, 0xFC121E24FF3FF9FC); //Get rid of env colour combiners with a NOP
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
    }

    public static bool LevelHasLighting()
    {
        for (int i = 0; i < GeoLayouts.AlphaModels.Length; i++)
        {
            uint addr = GeoLayouts.AlphaModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0x03) return true;
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
        for (int i = 0; i < GeoLayouts.OpaqueModels.Length; i++)
        {
            uint addr = GeoLayouts.OpaqueModels[i];
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0x03) return true;
                else if (SM64ROM.getByte(j) == 0xB8) break;
            }
        }
        return false;
    }

    public static void LayerSwap(byte layer1, byte layer2, uint LevelArea)
    {
        for (uint i = 0; i < GeoLayouts.ExtDLPointers[layer1].Length; i++)
        {
            UInt32 Addr = GeoLayouts.ExtDLPointers[1][i] + 1;
            ROMManager.SM64ROM.changeByte(Addr, layer2);
            if (debug) Console.Write("Wrote 0x" + layer2.ToString("x1") + " to ROM addr 0x" + Addr.ToString("x8") + " (GeoLayout LayerSwap)\n");
            GeoLayouts.ParseGeoLayout(ROMManager.SM64ROM, LevelScripts.getGeoAddress(LevelArea), false);
        }
    }

    public static UInt32 findu32(uint addr, UInt32 value, bool f3d)
    {
        if (f3d)
        {
            for (uint i = addr; i < SM64ROM.getEndROMAddr(); i += 8)
            {
                if (SM64ROM.ReadFourBytes(i) == value) return i;
                else if (SM64ROM.ReadFourBytes(i) == 0xB8000000) return 0;
            }
            return 0;
        }
        else return 0; //todo: implement
    }
}
