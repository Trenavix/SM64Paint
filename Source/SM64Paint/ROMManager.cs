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
using System.IO;

public class ROMManager
{
    public static bool ReadytoLoad = false;
    public static ROM SM64ROM;

    public static void LoadROM(String BinDirectory)
    {
        using (FileStream fs = new FileStream(BinDirectory, FileMode.Open, FileAccess.Read))
        {
            byte[] binFile = new byte[fs.Length];
            fs.Read(binFile, 0, (int)fs.Length);
            ROM NewBTBin = new ROM(binFile);
            SM64ROM = NewBTBin;
            fs.Close();
        }
        ROMManager.InitialiseModelLoad();
    }
    
    public static void SetVertRGBA(uint Addr, byte R, byte G, byte B, byte A)
    {
        UInt32 colour = (uint)((R << 24) | (G << 16) | (B << 8) | A);
        if (colour == SM64ROM.ReadFourBytes(Addr + 12)) return; //If it's the same, don't do anything
        for (uint i = 29; i >= 1 && i <= 29; i--) //Shift all mem back one
        {
            Vertex.OriginalVertexMem[i] = Vertex.OriginalVertexMem[i - 1];
        }
        Vertex.OriginalVertexMem[0] = new UInt32[2]; //Set up new undo level
        Vertex.OriginalVertexMem[0][0] = Addr+12;
        Vertex.OriginalVertexMem[0][1] = SM64ROM.ReadFourBytes(Addr+12); //Initial RGBA
        SM64ROM.changeByte(Addr + 12, R);
        SM64ROM.changeByte(Addr + 13, G);
        SM64ROM.changeByte(Addr + 14, B);
        SM64ROM.changeByte(Addr + 15, A);
    }

    public static void ForceVertRGBA(bool Opaque)
    {
        uint[] addresses;
        if(Opaque) addresses = GeoLayouts.OpaqueModels;
        else addresses = GeoLayouts.AlphaModels;
        for (int i = 0; i < addresses.Length; i++)
        {
            ForceVertRGBAJump(addresses[i], Opaque);
        }
    }

    public static void ForceVertNorms(bool Opaque)
    {
        uint[] addresses;
        if (Opaque) addresses = GeoLayouts.OpaqueModels;
        else addresses = GeoLayouts.AlphaModels;
        for (int i = 0; i < addresses.Length; i++)
        {
            ForceVertNormsJump(addresses[i]);
        }
    }

    private static void ForceVertRGBAJump(uint addr, bool Opaque)
    {
        bool B7Added = false;
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8) //Check if B7 is already at end of DL
        {
            if (SM64ROM.getByte(j) == 0xB8)
            {
                if (SM64ROM.getByte(j - 8) == 0xB7) B7Added = true;
                break;
            }
        }
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8) //Stuff is changed here
        {
            if (SM64ROM.getByte(j) == 0xB6)
            {
                SM64ROM.changeByte(j + 5, 0x02);
                if (SM64ROM.getSegmentStart(0x0E) >= 0x1200000 && !B7Added) SM64ROM.changeByte(j, 0xB7);
            }
            else if (SM64ROM.getByte(j) == 0xB7)
            {
                SM64ROM.changeByte(j + 5, 0x02);
                if (SM64ROM.getSegmentStart(0x0E) >= 0x1200000 && !B7Added) SM64ROM.changeByte(j, 0xB6);
            }
            else if (SM64ROM.getByte(j) == 0x03) SM64ROM.changeByte(j, 0x00);
            else if (SM64ROM.getByte(j) == 0x06) ForceVertRGBAJump(SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(j + 4)), Opaque);
            else if (SM64ROM.getByte(j) == 0xB8)
            {
                if (B7Added) return; // if B7 was already added, just get OUT
                if (!Opaque && SM64ROM.getSegmentStart(0x0E) >= 0x1200000)
                {
                    uint layeroffset = GeoLayouts.ExtAlphaDLPointer + 1;
                    if (SM64ROM.getByte(layeroffset) == 0x04) SM64ROM.changeByte(layeroffset, 0x05); //change layer 04 to layer 05 for translucency
                    SM64ROM.changeByte(j, 0xB7); SM64ROM.changeByte(j + 5, 0x02);
                    SM64ROM.changeByte(j + 8, 0xB8); for(uint k = j+9; k<j+16; k++) { SM64ROM.changeByte(k, 0x00); }
                }
                if (Opaque && SM64ROM.getSegmentStart(0x0E) >= 0x1200000)
                {
                    SM64ROM.changeByte(j, 0xB7); SM64ROM.changeByte(j + 5, 0x02);
                    uint EndAddr = LevelScripts.Ext0EBankEnd-8;
                    SM64ROM.copyBytes(j + 8, j + 16, EndAddr - (j + 8)); // Shift 8 bytes to make room for new command
                    AddToSegAddr(GeoLayouts.ExtAlphaDLPointer+4, 8); //Repoint alpha DL from movement
                    AddToSegAddr(LevelScripts.ExtCollisionPointer + 4, 8); //Repoint collision from movement
                    SM64ROM.changeByte(j + 8, 0xB8); for (uint k = j + 9; k < j + 16; k++) { SM64ROM.changeByte(k, 0x00); }
                }
                return;
            } 
        }
    }

    private static void ForceVertNormsJump(uint addr)
    {
        for (uint j = addr; j < SM64ROM.getEndROMAddr(); j += 8)
        {
            if (SM64ROM.getByte(j) == 0xB6 || SM64ROM.getByte(j) == 0xB7) SM64ROM.changeByte(j + 5, 0x00);
            else if (SM64ROM.getByte(j) == 0x00) SM64ROM.changeByte(j, 0x03);
            else if (SM64ROM.getByte(j) == 0x06) ForceVertNormsJump(SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(j + 4)));
            else if (SM64ROM.getByte(j) == 0xB8) return;
        }
    }

    private static void AddToSegAddr(uint addr, uint addamount)
    {
        UInt32 SegAddr = SM64ROM.ReadFourBytes(addr);
        SegAddr += addamount;
        SM64ROM.WriteFourBytes(addr, SegAddr);
    }

    public static void InitialiseModelLoad()
    {
        Textures.currentTexAddr = 0;
        Textures.TextureArray = new int[0];
        Textures.TextureAddrArray = new uint[0][];
        Vertex.CurrentVertexList = new UInt32[0];
        GeoLayouts.OpaqueModels = new uint[0];
        GeoLayouts.AlphaModels = new uint[0];
        Textures.FirstTexLoad = true;
        Textures.S_Scale = 1f;
        Textures.T_Scale = 1f;
    }
}
