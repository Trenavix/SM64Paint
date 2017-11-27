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

public class ROM
{
    private byte[] CurrentROM;
    private static uint[] Segments = new uint[0x1F]; //Max 0x1F RAM segments in ROM

	public ROM(byte[] newROM)
	{
       this.CurrentROM = newROM;
    }

    public byte[] getCurrentROM()
    {
        return CurrentROM;
    }

    public uint getEndROMAddr()
    {
        return (uint)CurrentROM.Length-1;
    }

    public UInt16 ReadTwoBytes(uint offset)
    {
        UInt16 value = getByte(offset);
        for (uint i = offset; i < offset+2; i++)
        {
            value = (UInt16)((value << 8) | CurrentROM[i]);
        }
        return value;
    }
    public UInt16 ReadTwoSignedBytes(uint offset)
    {
        return (UInt16)((getByte(offset + 1) << 8) | getByte(offset));
    }
    public UInt32 ReadFourBytes(uint offset)
    {
        UInt32 value = getByte(offset);
        for (uint i = offset; i < offset + 4; i++)
        {
            value = (value << 8) | CurrentROM[i];
        }
        return value;
    }

    public UInt64 ReadEightBytes(uint offset)
    {
        UInt64 value = getByte(offset);
        for (uint i = offset; i < offset+8; i++)
        {
            value = (value << 8) | CurrentROM[i];
        }
        return value;
    }
    public void WriteFourBytes(uint offset, UInt32 bytes)
    {
        byte[] currentbyte = BitConverter.GetBytes(bytes);
        for (uint i = offset; i > offset - 4; i--)
        {
            CurrentROM[i+3] = currentbyte[offset-i];
        }
    }
    public void WriteTwoBytes(uint offset, UInt16 bytes)
    {
        byte[] currentbyte = BitConverter.GetBytes(bytes);
        for (uint i = offset; i > offset - 2; i--)
        {
            CurrentROM[i+1] = currentbyte[offset-i];
        }
    }
    public void WriteEightBytes(uint offset, UInt64 bytes)
    {
        byte[] currentbyte = BitConverter.GetBytes(bytes);
        for (uint i = offset; i < offset + 8; i++)
        {
            CurrentROM[i] = currentbyte[i-offset];
        }
    }
    public byte getByte(uint offset)
    {
        return CurrentROM[offset];
    }
    public void changeByte(uint offset, byte newbyte)
    {
        if (offset > getEndROMAddr())
        {
            Array.Resize(ref CurrentROM, (int)offset+1);
        }
        CurrentROM[offset] = newbyte;
    }
    public void copyBytes(uint srcAddr, uint destAddr, uint size)
    {
        byte[] tempbuffer = new byte[size];
        for (uint i = 0; i < size; i++)
        {
            tempbuffer[i] = CurrentROM[srcAddr+i];
        }
        for (uint i = 0; i < size; i++)
        {
            changeByte(destAddr+i, tempbuffer[i]);
        }
    }
    public byte[] copyBytestoArray(uint srcAddr, uint size)
    {
        byte[] newarray = new byte[size];
        for (int i = 0; i < size; i++)
        {
            newarray[i] = CurrentROM[srcAddr + i];
        }
        return newarray;
    }
    public void writeByteArray(uint offset, byte[] array)
    {
        for (uint i=0; i < array.Length; i++)
        {
            changeByte(offset+i, array[i]);
        }
    }
    public void changeEndROMAddr(int newsize)
    {
        Array.Resize(ref CurrentROM, newsize);
    }

    public uint SegmentAddrtoROMAddr(uint segmentNum, uint segmentAddr)
    {
        return getSegmentStart(segmentNum) + segmentAddr;
    }

    public uint getSegmentStart(uint segment)
    {
        return Segments[segment];
    }

    public void setSegment(uint newsegment, uint ROMOffset)
    {
        Segments[newsegment] = ROMOffset;
    }

    public uint readSegmentAddr(UInt32 SegAddr)
    {
        uint addr = SegAddr & 0x00FFFFFF;
        uint segment = ((SegAddr & 0xFF000000) >> 24);
        return SegmentAddrtoROMAddr(segment, addr);
    }

}
