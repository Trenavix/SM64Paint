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
    
    public static void SetVertRGBA(uint Addr, UInt32 colour)
    {
        SM64ROM.WriteFourBytes(Addr + 12, colour);
    }

    public static void SetVertAlpha(uint Addr, byte alpha)
    {
        SM64ROM.changeByte(Addr + 15, alpha);
    }

    public static void ForceVertRGBA(bool Opaque)
    {
        int addresscount;
        if(Opaque) addresscount = GeoLayouts.OpaqueModels.Length;
        else addresscount = GeoLayouts.AlphaModels.Length;
        for (int i = 0; i < addresscount; i++)
        {
            if(Opaque)ForceVertRGBAJump(GeoLayouts.OpaqueModels[i], true);
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
            if (SM64ROM.getByte(j) == 0x03 && SM64ROM.getByte(j+1) == 0x86)
            {
                SM64ROM.WriteEightBytes(j, 0xB700000000020000);
                SM64ROM.cutBytes(j, B8Addr - 8, 8);
                SM64ROM.WriteEightBytes(j, 0xB600000000020000);
            }
            else if (SM64ROM.getByte(j) == 0xB8) return;
            else if (SM64ROM.getByte(j) == 0xB7 && SM64ROM.getByte(j + 5) == 0) SM64ROM.WriteEightBytes(j, 0xB700000000020000);
            else if (SM64ROM.getByte(j) == 0xB7 && SM64ROM.getByte(j + 5) == 1) SM64ROM.WriteEightBytes(j, 0xB600000000020000);
            /*else if (SM64ROM.getByte(j) == 0x03) SM64ROM.WriteEightBytes(j, 0xE700000000000000);
            else if (SM64ROM.getByte(j) == 0x06) ForceVertRGBAJump(SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(j + 4)), Opaque);
            else if (SM64ROM.getByte(j) == 0xB8)
            {
                if (B7Added) return; // if B7 was already added, just get OUT (Catch for opaque models)
                uint EndAddr = 0;
                uint start = GeoLayouts.AlphaModels[GeoLayouts.AlphaModels.Length - 1];
                if (GeoLayouts.AlphaModels.Length > 0) for (uint i = start; i < SM64ROM.getEndROMAddr(); i += 8) //Find last alpha DL in bank
                    { if (SM64ROM.getByte(i) == 0xB8) { EndAddr = i + 8; break; } }
                else for (uint i = SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(LevelScripts.ExtCollisionPointer + 4)); i < SM64ROM.getEndROMAddr(); i+=4) //If no alpha use collision end
                    { if (SM64ROM.ReadFourBytes(i) == 0x00410042) { EndAddr = i + 8; break; } }
                if (EndAddr == 0) throw new Exception("Unstable Memory Shift!");
                uint SegEndAddr = EndAddr - SM64ROM.getSegmentStart(0x0e);
                SM64ROM.WriteEightBytes(EndAddr, 0xBB000000FFFFFFFF);
                SM64ROM.WriteEightBytes(EndAddr+8, 0xB700000000020000);
                SM64ROM.WriteEightBytes(EndAddr+16, 0xB800000000000000);
                SM64ROM.WriteEightBytes(j - 8, (ulong)(0x060000000E000000 + SegEndAddr));
                return;
            }*/
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

    public static void AdjustCombiners()
    {
        if (GeoLayouts.AlphaModels.Length < 1) return;
        for (uint i = 0; i < GeoLayouts.AlphaModels.Length; i++)
        {
            uint addr = GeoLayouts.AlphaModels[i];
            uint endaddr = 0;
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xB8) { endaddr = j + 8; break; }
            }
            for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (SM64ROM.getByte(j) == 0xFB) SM64ROM.WriteEightBytes(j, 0xE700000000000000); //Get rid of env colour combiners
                else if (SM64ROM.getByte(j) == 0xFC && SM64ROM.ReadEightBytes(j) == 0xFC122E24FFFFFBFD) SM64ROM.WriteEightBytes(j, 0xFC121824FF33FFFF); //Fix combiner
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
    
    /*public static void ForceVertNorms(bool Opaque)
    {
        uint[] addresses;
        if (Opaque) addresses = GeoLayouts.OpaqueModels;
        else addresses = GeoLayouts.AlphaModels;
        for (int i = 0; i < addresses.Length; i++)
        {
            ForceVertNormsJump(addresses[i]);
        }
    }
    private static void ForceVertNormsJump(uint addr)
    {
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
        {
            if (SM64ROM.getByte(j) == 0xB6 || SM64ROM.getByte(j) == 0xB7) SM64ROM.changeByte(j + 5, 0x00);
            else if (SM64ROM.getByte(j) == 0xE7 && SM64ROM.getByte(j + 8) == 0xE7)
            {
                SM64ROM.WriteEightBytes(j, 0x038600100E000000);
                SM64ROM.WriteEightBytes(j+8, 0x038800100E000008);
            }
            else if (SM64ROM.getByte(j) == 0x06) ForceVertNormsJump(SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(j + 4)));
            else if (SM64ROM.getByte(j) == 0xB8) return;
        }
    }*/
}
