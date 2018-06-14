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
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

public class Textures
{
    public static bool FirstTexLoad = false;
    public static int[] TextureArray = new int[0];
    public static uint[][] TextureAddrArray = new uint[0][]; //Array of Addr and properties
    public static uint[][] F5CMDArray = new uint[0][]; //List of rendertile F5 commands for each texture, used for S/T param modding 
    public static readonly byte RGBAMODE = 0;
    public static readonly byte YUVMODE = 1;
    public static readonly byte CIMODE = 2;
    public static readonly byte IAMODE = 3;
    public static readonly byte IMODE = 4;
    public static byte MODE = 0;
    public static byte BitSize = 0;
    public static bool MipMapping = false;

    public static uint currentSegment = 0;
    public static uint currentTexAddr = 0;

    public static short[] currentPalette = new short[0]; //Init with size or error!
    public static uint Height = 32;
    public static uint Width = 32;
    public static int TMEMOffset = 0;
    public static uint TFlags = 0;
    public static uint SFlags = 0;
    public static float S_Scale = 1;
    public static float T_Scale = 1;
    public static bool ResizeFailure = false;

    public static int LoadTexture(ROM SM64ROM)
    {
        int CICount = currentPalette.Length;
        int NewTexture = 0;
        if (MODE == RGBAMODE && BitSize == 16) { NewTexture = LoadRGBA16Texture(SM64ROM); }
        else if (MODE == RGBAMODE && BitSize == 32) { NewTexture = LoadRGBA32Texture(SM64ROM); }
        else if (MODE == CIMODE) { NewTexture = LoadCITexture(SM64ROM); }
        else if (MODE == IAMODE && BitSize == 4) { NewTexture = LoadIA4Texture(SM64ROM); }
        else if (MODE == IAMODE && BitSize == 8) { NewTexture = LoadIA8Texture(SM64ROM); }
        else if (MODE == IAMODE && BitSize == 16) { NewTexture = LoadIA16Texture(SM64ROM); }
        else if (MODE == IMODE && BitSize == 4) { NewTexture = LoadI4Texture(SM64ROM); }
        else if (MODE == IMODE && BitSize == 8) { NewTexture = LoadI8Texture(SM64ROM); }
        else if (MODE == YUVMODE && BitSize == 16) { NewTexture = LoadRGBA16Texture(SM64ROM); } //TODO
        else throw new System.TypeLoadException("Unimplemented Texture Format");
        return NewTexture;
    }

    public static int LoadCITexture(ROM SM64ROM)
    {
        if (currentPalette.Length == 0) return 0; //If no palette, return blank texture
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] CITex;
        short[] NewTexture;
        if (currentPalette.Length <= 16)
        {
            CITex = SM64ROM.copyBytestoArray(currentTexAddr, Width * Height / 2);//4bpp
            NewTexture = CI4ToRGB5A1(CITex, currentPalette);
        }
        else
        {
            CITex = SM64ROM.copyBytestoArray(currentTexAddr, Width * Height);//8bpp
            NewTexture = CI8ToRGB5A1(CITex, currentPalette);
        }
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgb5A1,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedShort5551,
            NewTexture
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static int LoadRGBA16Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        short[] TexData = LoadRGBA16TextureData(Width * Height, SM64ROM);
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgb5A1,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedShort5551,
            TexData
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static int LoadRGBA32Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        Int32[] TexData = new Int32[Width * Height]; //actually FloatsToLoad but accounted for as Shorts
        for (int i = 0; i < TexData.Length; i++)
        {
            TexData[i] = (int)SM64ROM.ReadFourBytes(currentTexAddr + (uint)(i * 4));
        }
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgba32f,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedInt8888,
            TexData
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static int LoadIA4Texture(ROM SM64ROM) // TODO: USE 3 BITS I, 1 BIT A.
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] IA4Data = SM64ROM.copyBytestoArray(currentTexAddr, (Width * Height) / 2);
        short[] IA16Data = new short[IA4Data.Length * 2];
        for (int i = 0; i < IA4Data.Length; i++)
        {
            byte i1 = (byte)((IA4Data[i] & 0xE0) | ((IA4Data[i] & 0xE0) >> 3) | (IA4Data[i] & 0xE0) >> 6);
            byte a1 = (byte)(((IA4Data[i] & 0x10) >> 4) * 0xFF);
            byte i2 = (byte)((((IA4Data[i] & 0x0E) << 4)) | ((IA4Data[i] & 0x0E) << 1) | ((IA4Data[i] & 0x0E) >> 2));
            byte a2 = (byte)((IA4Data[i] & 1) * 0xFF);
            IA16Data[i * 2] = (short)((i1 << 8) | a1);
            IA16Data[i * 2 + 1] = (short)((i2 << 8) | a2);
        }
        Int32[] RGBA32Data = IA16toRGBA32(IA16Data);
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgba32f,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedInt8888,
            RGBA32Data
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static int LoadIA8Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] TexData = SM64ROM.copyBytestoArray(currentTexAddr, Width * Height);
        short[] IA16Data = IA8toIA16(TexData);
        Int32[] RGBA32 = IA16toRGBA32(IA16Data);
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgba32f,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedInt8888,
            RGBA32
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static short[] IA8toIA16(byte[] IA8)
    {
        short[] IA16 = new short[IA8.Length];
        for (uint i = 0; i < IA8.Length; i++)
        {
            IA16[i] = (Int16)(((((IA8[i] & 0xF0) >> 4) * 0x11) << 8) | (IA8[i] & 0x0F) * 0x11);
        }
        return IA16;
    }

    public static int LoadIA16Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        short[] TexData = LoadRGBA16TextureData(Width * Height, SM64ROM); //abusing method for 16bit texels

        Int32[] RGBA32 = IA16toRGBA32(TexData);
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgba32f,
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
            PixelType.UnsignedInt8888,
            RGBA32
            );
        getTSFlags();
        getSTDTextureFilters();
        return id; ;
    }

    public static int LoadI8Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] TexData = SM64ROM.copyBytestoArray(currentTexAddr, Width * Height);

        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgb8, //intensity8 is alpha is wanted
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Luminance,
            PixelType.UnsignedByte,
            TexData
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static int LoadI4Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] TexData = SM64ROM.copyBytestoArray(currentTexAddr, (Width * Height) / 2);
        byte[] TexData2 = new byte[TexData.Length * 2];
        for (int i = 0; i < TexData.Length; i++)
        {
            TexData2[i * 2] = (byte)((TexData[i] >> 4) * 17);
            TexData2[i * 2 + 1] = (byte)((TexData[i] & 0x0F) * 17);
        }
        GL.TexImage2D
            (
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Rgb8, //intensity8 is alpha is wanted
            (int)Width,
            (int)Height,
            0,
            OpenTK.Graphics.OpenGL.PixelFormat.Luminance,
            PixelType.UnsignedByte,
            TexData2
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
    }

    public static short[] CI4ToRGB5A1(byte[] data, short[] palette)
    {
        short[] newtexture = new short[data.Length * 2];

        for (int i = 0; i < data.Length; i++)
        {
            int idx_a = (data[i] & 0xF0) >> 4;
            int idx_b = data[i] & 0x0F;

            short color_a = palette[idx_a];
            short color_b = palette[idx_b];

            int new_idx = i * 2;

            newtexture[new_idx] = color_a;
            newtexture[new_idx + 1] = color_b;
        }
        return newtexture;
    }

    public static short[] CI8ToRGB5A1(byte[] data, short[] palette)
    {
        short[] newtexture = new short[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            int idx = data[i];
            short color = palette[idx];
            newtexture[i] = color;
        }
        return newtexture;
    }

    public static Int32[] IA16toRGBA32(short[] ia16)
    {
        Int32[] rgba = new Int32[ia16.Length];
        for (int i = 0; i < ia16.Length; i++)
        {
            byte grey = (byte)(ia16[i] >> 8);
            byte alpha = (byte)(ia16[i] & 0x00FF);
            rgba[i] = (grey << 24) | (grey << 16) | (grey << 8) | alpha;
        }
        return rgba;
    }

    public static short[] LoadRGBA16TextureData(uint ShortsToLoad, ROM SM64ROM)
    {
        ;
        short[] data = new short[ShortsToLoad];
        for (int i = 0; i < ShortsToLoad; i++)
        {
            data[i] = (short)SM64ROM.ReadTwoBytes(currentTexAddr + (uint)(i * 2));
        }
        return data;
    }

    public static Vector2 ClampMode(byte F5CmdByte6, byte F5CmdByte7)
    {
        int ClampT = (F5CmdByte6 & 0x0F) >> 2;
        int ClampS = (F5CmdByte7 & 0x0F) & 7;
        return new Vector2(ClampS, ClampT);
    }

    public static void getTSFlags()
    {
        if (SFlags == 2) { GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); }
        else if (SFlags == 1) { GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.MirroredRepeat); }
        else GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        if (TFlags == 2) { GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge); }
        else if (TFlags == 1) { GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.MirroredRepeat); }
        else { GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat); }
    }

    public static void getSTDTextureFilters()
    {
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
    }


    public static Bitmap TextureToBitMap(uint texaddr, uint width, uint height, uint format, uint bitsize)
    {
        ROM SM64ROM = ROMManager.SM64ROM;
        if (width == 0 || height == 0) return new Bitmap(1, 1);
        Bitmap texture = new Bitmap((Int32)width, (Int32)height);
        Graphics textureGraphics = Graphics.FromImage(texture);
        uint pxaddr = 0;
        uint texel = 0;
        Color[] palette = new Color[0];
        if (format == CIMODE)
        {
            palette = new Color[(int)Math.Pow(2, bitsize)];
            uint paletteaddr = texaddr + (width * height * bitsize / 0x08); //halfway into texture
            for (uint i = 0; i < palette.Length; i++)
            {
                palette[i] = RGBA16TexeltoColor(paletteaddr + (i * 2));
            }
        }
        for (uint y = 0; y < height; y++)
        {
            for (uint x = 0; x < width; x++)
            {
                if (bitsize >= 8) pxaddr = texaddr + texel * (bitsize / 8);
                else pxaddr = texaddr + texel;
                SolidBrush brush = new SolidBrush(Color.HotPink);
                if ((format == RGBAMODE && bitsize == 16) || format == YUVMODE) //Todo: YUV
                {
                    brush = new SolidBrush(RGBA16TexeltoColor(pxaddr));
                }
                else if (format == RGBAMODE && bitsize == 32) //RGBA32
                {
                    byte red = SM64ROM.getByte(pxaddr);
                    byte green = SM64ROM.getByte(pxaddr + 1);
                    byte blue = SM64ROM.getByte(pxaddr + 2);
                    byte alpha = SM64ROM.getByte(pxaddr + 3);
                    brush = new SolidBrush(Color.FromArgb(alpha, red, green, blue));
                }
                else if (format == IAMODE && bitsize == 4) //IA4
                {
                    byte pixels = SM64ROM.getByte(pxaddr);
                    byte I1 = (byte)((pixels & 0xE0) | ((pixels & 0xE0) >> 3) | (pixels & 0xE0) >> 6);
                    byte A1 = (byte)(((pixels & 0x10) >> 4) * 0xFF);
                    brush = new SolidBrush(Color.FromArgb(A1, I1, I1, I1));
                    textureGraphics.FillRectangle(brush, x, y, 1, 1);
                    x++; if (x >= width) { x = 0; y++; } //increment
                    byte I2 = (byte)((((pixels & 0x0E) << 4)) | ((pixels & 0x0E) << 1) | ((pixels & 0x0E) >> 2));
                    byte A2 = (byte)((pixels & 1) * 0xFF);
                    brush = new SolidBrush(Color.FromArgb(A2, I2, I2, I2));
                }
                else if (format == IAMODE && bitsize == 8) //IA8
                {
                    byte pixel = SM64ROM.getByte(pxaddr);
                    byte I1 = (byte)((pixel & 0xF0) | ((pixel & 0xF0) >> 4));
                    byte A1 = (byte)(((pixel & 0x0F) << 4) | (pixel & 0x0F));
                    brush = new SolidBrush(Color.FromArgb(A1, I1, I1, I1));
                }
                else if (format == IAMODE && bitsize == 16) //IA16
                {
                    byte I = SM64ROM.getByte(pxaddr);
                    byte A = SM64ROM.getByte(pxaddr + 1);
                    brush = new SolidBrush(Color.FromArgb(A, I, I, I));
                }
                else if (format == IMODE && bitsize == 8) //I8
                {
                    byte I = SM64ROM.getByte(pxaddr);
                    brush = new SolidBrush(Color.FromArgb((byte)255, I, I, I));
                }
                else if (format == IMODE && bitsize == 4) //I4
                {
                    byte I1 = (byte)((SM64ROM.getByte(pxaddr) >> 4) * 17); //*17 for >>4 with 0x0F range
                    brush = new SolidBrush(Color.FromArgb((byte)255, I1, I1, I1));
                    textureGraphics.FillRectangle(brush, x, y, 1, 1);
                    x++; if (x >= width) { x = 0; y++; } //increment
                    byte I2 = (byte)((SM64ROM.getByte(pxaddr) & 0x0F) * 17); //*17 for >>4 with 0x0F range
                    brush = new SolidBrush(Color.FromArgb((byte)255, I2, I2, I2));
                }
                else if (format == CIMODE && bitsize == 4) //CI4
                {
                    int px1 = SM64ROM.getByte(pxaddr) >> 4;
                    brush = new SolidBrush(palette[px1]);
                    textureGraphics.FillRectangle(brush, x, y, 1, 1);
                    x++; if (x >= width) { x = 0; y++; } //increment
                    int px2 = SM64ROM.getByte(pxaddr) & 0x0F;
                    brush = new SolidBrush(palette[px2]);
                }
                textureGraphics.FillRectangle(brush, x, y, 1, 1);
                texel++;
            }

        }
        return texture;
    }
    public static Color RGBA16TexeltoColor(uint pxaddr)
    {
        ROM SM64ROM = ROMManager.SM64ROM;
        byte red = (byte)Math.Round((SM64ROM.getByte(pxaddr) >> 3) * 8.225);
        byte green = (byte)Math.Round((((SM64ROM.getByte(pxaddr) << 2) & 0x1F) | (SM64ROM.getByte(pxaddr + 1) >> 6)) * 8.225);
        byte blue = (byte)Math.Round(((SM64ROM.getByte(pxaddr + 1) >> 1) & 0x1F) * 8.225);
        byte alpha = (byte)((SM64ROM.getByte(pxaddr + 1) & 0x01) * 255);
        return Color.FromArgb(alpha, red, green, blue);
    }

    public static void ImportBMPtoTexture(Bitmap bmp, int index)
    {
        ROM SM64ROM = ROMManager.SM64ROM;
        bool RGBAMode = TextureAddrArray[index][1] == RGBAMODE;
        bool IAMode = TextureAddrArray[index][1] == IAMODE;
        bool IMode = TextureAddrArray[index][1] == IMODE;
        bool CIMode = TextureAddrArray[index][1] == CIMODE;
        bool YUVMode = TextureAddrArray[index][1] == YUVMODE;
        uint bitsize = TextureAddrArray[index][2];
        UInt32 addr = TextureAddrArray[index][0];
        UInt32[] inttexels = new UInt32[bmp.Width * bmp.Height];
        ushort[] shorttexels = new ushort[bmp.Width * bmp.Height];
        byte[] bytetexels;
        int x = 0;
        int y = 0;
        switch (bitsize)
        {
            case 16:
                if (RGBAMode) //RGBA16
                {
                    for (uint i = 0; i < shorttexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        byte alpha = texel.A;
                        if (alpha > 0) alpha = 1; else alpha = 0;
                        ushort colour = (ushort)
                            (
                            ((byte)(texel.R >> 3) << 11) |
                            ((byte)(texel.G >> 3) << 6) |
                            ((byte)(texel.B >> 3) << 1) |
                            ((byte)(alpha))
                            );
                        shorttexels[i] = colour;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < shorttexels.Length; i++)
                    {
                        SM64ROM.WriteTwoBytes(addr + i * 2, shorttexels[i]);
                    }
                }
                else if (IAMode) //IA16
                {
                    for (uint i = 0; i < shorttexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        ushort intensity = (ushort)((((texel.R + texel.G + texel.B) / 3) << 8) | texel.A);
                        shorttexels[i] = intensity;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < shorttexels.Length; i++)
                    {
                        SM64ROM.WriteTwoBytes(addr + i * 2, shorttexels[i]);
                    }
                }
                return;
            case 32: //RGBA32
                for (uint i = 0; i < inttexels.Length; i++)
                {
                    System.Drawing.Color texel = bmp.GetPixel(x, y);
                    UInt32 colour = (UInt32)((texel.R << 24) | (texel.G << 16) | (texel.B << 8) | texel.A);
                    inttexels[i] = colour;
                    x++; if (x >= bmp.Width) { x = 0; y++; }
                }
                for (uint i = 0; i < inttexels.Length; i++)
                {
                    SM64ROM.WriteFourBytes(addr + i * 4, inttexels[i]);
                }
                return;
            case 8:
                bytetexels = new byte[bmp.Width * bmp.Height];
                if (IMode) //I8
                {
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        byte intensity = (byte)((texel.R + texel.G + texel.B) / 3);
                        bytetexels[i] = intensity;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        SM64ROM.changeByte(addr + i, bytetexels[i]);
                    }
                }
                else if (IAMode) //IA8
                {
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        byte intensity = (byte)((byte)((texel.R + texel.G + texel.B) / 3) & 0xF0);
                        byte alpha = (byte)((texel.A & 0xF0) >> 4);
                        byte IA = (byte)(intensity | alpha);
                        bytetexels[i] = IA;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        SM64ROM.changeByte(addr + i, bytetexels[i]);
                    }
                }
                return;
            case 4:
                bytetexels = new byte[(bmp.Width * bmp.Height) / 2];
                if (IMode) //I4
                {
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        byte intensity1 = (byte)((byte)((texel.R + texel.G + texel.B) / 3) & 0xF0);
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                        System.Drawing.Color texel2 = bmp.GetPixel(x, y);
                        byte intensity2 = (byte)(((byte)((texel2.R + texel2.G + texel2.B) / 3) & 0xF0) >> 4);
                        byte ii = (byte)(intensity1 | intensity2);
                        bytetexels[i] = ii;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        SM64ROM.changeByte(addr + i, bytetexels[i]);
                    }
                }
                else if (IAMode) //IA4
                {
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        System.Drawing.Color texel = bmp.GetPixel(x, y);
                        byte intensity1 = (byte)((byte)(((texel.R + texel.G + texel.B) / 3) >> 5) << 5);
                        byte alpha1 = (byte)(((texel.A) >> 7) << 4);
                        byte ia1 = (byte)(intensity1 | alpha1);
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                        System.Drawing.Color texel2 = bmp.GetPixel(x, y);
                        byte intensity2 = (byte)((byte)(((texel2.R + texel2.G + texel2.B) / 3) >> 5) << 1);
                        byte alpha2 = (byte)((texel2.A) >> 7);
                        byte ia2 = (byte)(intensity2 | alpha2);
                        byte iaia = (byte)(ia1 | ia2);
                        bytetexels[i] = iaia;
                        x++; if (x >= bmp.Width) { x = 0; y++; }
                    }
                    for (uint i = 0; i < bytetexels.Length; i++)
                    {
                        SM64ROM.changeByte(addr + i, bytetexels[i]);
                    }
                }
                else if (CIMode) //CI4
                {
                    if (bmp.Width * bmp.Height > 0x1000)
                    { MessageBox.Show("CI4 cannot be above 64x64 due to\nTMEM limitations with palettes.", "Texture too large"); return; }
                    Color[] colours = getImageColors(bmp);
                    UInt32 paletteaddr = (UInt32)(addr + (bmp.Width * bmp.Height / 2)); //Put palette right after CI data
                    for (int i = 0; i < colours.Length; i++)
                    {
                        byte alpha = colours[i].A;
                        if (alpha > 0) alpha = 1; else alpha = 0;
                        ushort colour = (ushort)
                            (
                            ((byte)(colours[i].R >> 3) << 11) |
                            ((byte)(colours[i].G >> 3) << 6) |
                            ((byte)(colours[i].B >> 3) << 1) |
                            ((byte)(alpha))
                            );
                        SM64ROM.WriteTwoBytes((UInt32)(paletteaddr + (i * 2)), colour);
                    }
                    byte[] CIData = getCIData(bmp, colours);
                    for (uint i = 0; i < CIData.Length; i++)
                    { SM64ROM.changeByte(i + addr, CIData[i]); } //Write CI data over texture taking up **half** memory compared to RGBA16
                    UInt32 branchDLAddr = (UInt32)(paletteaddr + 0x20); //palette size is 0x20 for ci4
                    UInt32 branchDLSegAddr = 0x0E000000 | (branchDLAddr - SM64ROM.getSegmentStart(0x0E));
                    UInt32[] F5CMDs = Textures.F5CMDArray[index];
                    ushort linesperword = Convert.ToUInt16((64d * 2048d) / ((double)bmp.Width * bitsize));
                    for (uint i = 0; i < F5CMDs.Length; i++)
                    {
                        SM64ROM.changeByte(F5CMDs[i] + 1, 0x40); //CI4 format
                        bool firsttexture = (i == 0 && SM64ROM.getByte(F5CMDs[0] + 0x10) == 0xFD);
                        for (uint j = F5CMDs[i]; j > F5CMDs[i] - 0x30; j -= 8) // Update 0xFD
                        {
                            if (SM64ROM.getByte(j) == 0xF3) SM64ROM.WriteEightBytes(j, 0xF3000000073FF000 | linesperword);
                            else if (SM64ROM.getByte(j) == 0xFD || firsttexture) //includes first texture check
                            {
                                if (firsttexture) j += 0x10;
                                SM64ROM.changeByte(j + 1, 0x50); //Format and bitsize byte, 0x50 for CI4
                                SM64ROM.copyBytes(j, branchDLAddr + 0x28, 8);
                                SM64ROM.WriteTwoBytes(j, 0x0600); //Branch to load routine
                                SM64ROM.WriteFourBytes(j + 4, branchDLSegAddr);
                                if (SM64ROM.getByte(j + 0x10) == 0x06)
                                    SM64ROM.WriteEightBytes(j + 0x10, 0xE600000000000000); //Revert the TMEM shift undo (This tex still needs TMEM shift)
                                break;
                            }
                        }
                    }
                    for (uint i = 0; i < F5CMDs.Length; i++)
                    {
                        bool firsttexture = (i == 0 && SM64ROM.getByte(F5CMDs[0] + 0x10) == 0xFD);
                        for (uint j = F5CMDs[i]; j < SM64ROM.getEndROMAddr(); j += 8)
                        {
                            if (firsttexture && SM64ROM.getByte(j + 0x20) == 0xF3)
                            { j += 0x20; SM64ROM.WriteEightBytes(j + 0x20, 0xF3000000073FF000 | linesperword); } //Update first texture command
                            if (SM64ROM.getByte(j) == 0x06) break; //If next texture is CI then don't revert the tmem shift
                            else if (SM64ROM.getByte(j) == 0xE6)
                            {
                                if (SM64ROM.getByte(j - 0x10) == 0x06) break; //If there is already a CI jump, escape from reverting it
                                SM64ROM.changeByte(j, 0x06);
                                SM64ROM.WriteFourBytes(j + 4, branchDLSegAddr + 56);
                                break;
                            }
                            else if (SM64ROM.getByte(j) == 0xB8)
                            {
                                for (uint k = j; k > j - 0x30; k -= 8)
                                {
                                    if (SM64ROM.getByte(k) == 0xBB)
                                    {
                                        SM64ROM.changeByte(k, 0x06); SM64ROM.WriteFourBytes(k + 4, branchDLSegAddr + 80);
                                        /*throw new Exception(branchDLSegAddr.ToString("x")+"\n"+branchDLAddr.ToString("x")+"\n");*/
                                        break;
                                    }
                                }
                                break; //allow last texture to jump and revert TMEM shift
                            }
                        }
                    }
                    SM64ROM.WriteEightBytes(branchDLAddr, 0xE700000000000000); // Loadsync
                    SM64ROM.WriteEightBytes(branchDLAddr + 8, 0xFD10000000000000 | (branchDLSegAddr - 0x20)); //load palette
                    SM64ROM.WriteEightBytes(branchDLAddr + 16, 0xF500010001000000); //Settile (palette)
                    SM64ROM.WriteEightBytes(branchDLAddr + 24, 0xF00000000103C000); //Load palette into TMEM
                    SM64ROM.WriteEightBytes(branchDLAddr + 32, 0xBA000E0200008000); //shift TMEM to palette
                    SM64ROM.WriteEightBytes(branchDLAddr + 48, 0xB800000000000000); //Break out of jump
                    SM64ROM.WriteEightBytes(branchDLAddr + 56, 0xE600000000000000); //Loadsync for next texture
                    SM64ROM.WriteEightBytes(branchDLAddr + 64, 0xBA000E0200000000); //shift TMEM back
                    SM64ROM.WriteEightBytes(branchDLAddr + 72, 0xB800000000000000); //Break from jump
                    SM64ROM.WriteEightBytes(branchDLAddr + 80, 0xBB000000FFFFFFFF); //Disable tex at end of DL
                    SM64ROM.WriteEightBytes(branchDLAddr + 88, 0xBA000E0200000000); //shift TMEM back
                    SM64ROM.WriteEightBytes(branchDLAddr + 96, 0xB800000000000000); //Break out of jump
                }
                return;
        }

    }
    public static void ResizeTexture(int F5index, int widthpower, int heightpower, out bool isFailedToResize)
    {
        uint[] F5CMDs = Textures.F5CMDArray[F5index]; ROM SM64ROM = ROMManager.SM64ROM;
        bool isFailedToResizeUVs = false;
        byte WidthsizeByte = SM64ROM.getByte(F5CMDs[0] + 7);
        ushort HeightsizeShort = SM64ROM.ReadTwoBytes(F5CMDs[0] + 5);
        int ogHeightPower = (HeightsizeShort >> 6 & 0x0F);
        int ogWidthPower = (WidthsizeByte >> 4);
        int difx = widthpower - ogWidthPower;
        int dify = heightpower - ogHeightPower;
        int width = (int)Math.Pow(2, widthpower);
        int height = (int)Math.Pow(2, heightpower);
        UInt32 clamp = (UInt32)((((width - 1) << 2) << 12) | ((height - 1) << 2));
        for (uint i = 0; i < F5CMDs.Length; i++)
        {
            SM64ROM.changeByte(F5CMDs[i] + 7, (byte)(WidthsizeByte + (difx * 16)));//*8 for << 4 with negative carried
            SM64ROM.WriteTwoBytes(F5CMDs[i] + 5, (ushort)(HeightsizeShort + (dify * 64)));//*8 for << 6 with negative carried
            SM64ROM.WriteFourBytes(F5CMDs[i] + 12, clamp); //F2 command follows F5 rendertile
            bool exitUVcorrection = false;
            for (uint j = F5CMDs[i] + 8; j < SM64ROM.getEndROMAddr(); j += 8) //UV automatic correction
            {
                if (exitUVcorrection) break;
                switch (SM64ROM.getByte(j))
                {
                    case 0xBF:
                        UInt32 UVStart = 0;
                        double[][] UVs = new double[2][]; for (int k = 0; k < 2; k++) { UVs[k] = new double[3]; }
                        for (uint k = j; k > j - 0x800; k -= 8)
                        {
                            if (SM64ROM.getByte(k) == 0x04)
                            {
                                UVStart = SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(k + 4)) + 8; break;
                            }
                        }
                        if (UVStart == 0) break;
                        for (uint k = 5; k < 8; k++)
                        {
                            UInt32 addr = Vertex.getAddrFromTriIndex(UVStart, SM64ROM.getByte(j + k));
                            double U = (short)SM64ROM.ReadTwoBytes(addr);
                            double V = (short)SM64ROM.ReadTwoBytes(addr + 2);
                            U *= Math.Pow(2, difx);
                            V *= Math.Pow(2, dify);
                            UVs[0][k - 5] = U;
                            UVs[1][k - 5] = V;
                        }
                        UVs = Vertex.UVChecker(UVs, out isFailedToResizeUVs);
                        if (isFailedToResizeUVs)
                        {
                            isFailedToResize = true; // recover file
                            return;
                        }
                        for (uint k = 5; k < 8; k++)
                        {
                            UInt32 addr = Vertex.getAddrFromTriIndex(UVStart, SM64ROM.getByte(j + k));
                            if (UVs[0][k - 5] > 0x7fff || UVs[0][k - 5] < -0x8000)
                            {
                                isFailedToResize = true;
                                return;
                            }
                            SM64ROM.WriteTwoBytes(addr, (ushort)Convert.ToInt16(UVs[0][k - 5]));
                            SM64ROM.WriteTwoBytes(addr + 2, (ushort)Convert.ToInt16(UVs[1][k - 5]));
                        }
                        break;
                    case 0xFD:
                        exitUVcorrection = true;
                        break;
                    case 0x06:
                        exitUVcorrection = true;
                        break;
                    case 0xB8:
                        exitUVcorrection = true;
                        break;
                }
            }
        }
        isFailedToResize = false;
        return;
    }

    public static void CentreUVs(bool ChangeU, int F5index, int width, int height)
    {
        uint[] F5CMDs = Textures.F5CMDArray[F5index]; ROM SM64ROM = ROMManager.SM64ROM;
        for (uint i = 0; i < F5CMDs.Length; i++)
        {
            bool exitUVcorrection = false;
            for (uint j = F5CMDs[i] + 8; j < SM64ROM.getEndROMAddr(); j += 8)
            {
                if (exitUVcorrection) break;
                switch (SM64ROM.getByte(j))
                {
                    case 0xBF:
                        UInt32 UVStart = 0;
                        short[][] UVs = new short[2][]; for (int k = 0; k < 2; k++) { UVs[k] = new short[3]; }
                        for (uint k = j; k > j - 0x800; k -= 8)
                        {
                            if (SM64ROM.getByte(k) == 0x04)
                            {
                                UVStart = SM64ROM.readSegmentAddr(SM64ROM.ReadFourBytes(k + 4)) + 8; break;
                            }
                        }
                        if (UVStart == 0) break;
                        for (uint k = 5; k < 8; k++)
                        {
                            UInt32 addr = Vertex.getAddrFromTriIndex(UVStart, SM64ROM.getByte(j + k));
                            UVs[0][k - 5] = (short)SM64ROM.ReadTwoBytes(addr);
                            UVs[1][k - 5] = (short)SM64ROM.ReadTwoBytes(addr + 2);
                        }
                        UVs = Vertex.CentreTRIUVs(UVs, width, height, ChangeU);
                        for (uint k = 5; k < 8; k++)
                        {
                            UInt32 addr = Vertex.getAddrFromTriIndex(UVStart, SM64ROM.getByte(j + k));
                            if (ChangeU) SM64ROM.WriteTwoBytes(addr, (ushort)UVs[0][k - 5]);
                            else SM64ROM.WriteTwoBytes(addr + 2, (ushort)UVs[1][k - 5]);
                        }
                        break;
                    case 0xFD:
                        exitUVcorrection = true;
                        break;
                    case 0x06:
                        exitUVcorrection = true;
                        break;
                    case 0xB8:
                        exitUVcorrection = true;
                        break;
                }
            }

        }

    }

    public static Vector2 getWidthHeightPowers(int F5Index)
    {
        uint[] F5CMD = Textures.F5CMDArray[F5Index]; ROM SM64ROM = ROMManager.SM64ROM;
        byte WidthsizeByte = SM64ROM.getByte(F5CMD[0] + 7);
        ushort HeightsizeShort = SM64ROM.ReadTwoBytes(F5CMD[0] + 5);
        int ogHeightPower = (HeightsizeShort >> 6 & 0x0F);
        int ogWidthPower = (WidthsizeByte >> 4);
        return new Vector2(ogWidthPower, ogHeightPower);
    }

    public static Color[] getImageColors(Bitmap bmp)
    {
        Color[] colours = new Color[0];
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                bool newcolour = true;
                System.Drawing.Color texel = bmp.GetPixel(x, y);
                for (int z = 0; z < colours.Length; z++)
                {
                    if (colours[z].Equals(texel)) { newcolour = false; break; }
                }
                if (newcolour || colours.Length == 0)
                {
                    Array.Resize(ref colours, colours.Length + 1);
                    colours[colours.Length - 1] = texel;
                }
            }
        }
        return colours;
    }

    public static byte[] getCIData(Bitmap bmp, Color[] colours)
    {
        byte[] CIData = new byte[bmp.Width * bmp.Height / 2]; //CI4
        if (colours.Length > 16) Array.Resize(ref CIData, CIData.Length * 2); //if CI8, resize twice length
        int byteidx = 0;
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                System.Drawing.Color texel = bmp.GetPixel(x, y);
                for (int z = 0; z < colours.Length; z++)
                {
                    if (colours.Length <= 16) if (colours[z].Equals(texel))
                        {
                            if (x % 2 == 0) CIData[byteidx] = (byte)(z << 4); //If even, shift to left nybble
                            else CIData[byteidx] |= (byte)z; //if odd..
                            if (x % 2 != 0) byteidx++;
                            break;
                        }
                    if (colours[z].Equals(texel))
                    {
                        CIData[y * bmp.Width + x] = (byte)z;
                    }
                }
            }
        }
        return CIData;
    }

    public static void RGBA32Check(int F5CMDsIDX, int bitsize, int width)
    {
        ROM SM64ROM = ROMManager.SM64ROM;
        UInt32[] F5CMDs = F5CMDArray[F5CMDsIDX];
        for (uint i = 0; i < F5CMDs.Length; i++)
        {
            if (bitsize == 32)
            {
                SM64ROM.changeByte(F5CMDs[i] + 2, (byte)(width / 2)); // rgba32 special case: linesperword
            }
            for (uint j = F5CMDs[i]; j > F5CMDs[i] - 0x30; j -= 8) //RGBA32 special case: different settile and loadblock
            {
                switch (SM64ROM.getByte(j))
                {
                    case 0xF3:
                        if (bitsize != 32) break; //if not rgba32, break
                        ushort texelcount = (ushort)((SM64ROM.ReadTwoBytes(j + 5) >> 4) + 1);
                        texelcount /= 2; texelcount--;
                        texelcount <<= 4;
                        SM64ROM.WriteTwoBytes(j + 5, texelcount);
                        break;
                    case 0xF5:
                        if (SM64ROM.getByte(j + 4) != 0x07) break; //if not settile, break
                        if (bitsize == 32) SM64ROM.changeByte(j + 1, 0x18);
                        else SM64ROM.changeByte(j + 1, 0x10);
                        break;
                    case 0xFD:
                        if (bitsize == 32) SM64ROM.changeByte(j + 1, 0x18);
                        else SM64ROM.changeByte(j + 1, 0x10);
                        return;
                }
            }
        }
    }
    public static bool isTextureCI(int index)
    {
        UInt32 Addr = F5CMDArray[index][0];
        if (ROMManager.SM64ROM.ReadFourBytes(Addr - 0x28) == 0x06000000) return true;
        else return false;
    }
    public static void RevertCI(int index)
    {
        if (!isTextureCI(index)) return;
        UInt32[] F5CMDs = F5CMDArray[index]; ROM SM64ROM = ROMManager.SM64ROM;
        uint texaddr = 0;
        for (uint i = 0; i < F5CMDs.Length; i++) //Update F5 scanline width 
        {
            uint F5 = F5CMDs[i];
            if (SM64ROM.ReadFourBytes(F5 - 0x28) == 0x06000000)
            {
                UInt32 Jumpaddr = SM64ROM.getSegmentStart(0x0E) + (SM64ROM.ReadFourBytes(F5 - 0x24) & 0xFFFFFF);
                texaddr = SM64ROM.ReadFourBytes(Jumpaddr + 0x2C);
                UInt64 FDCMD = 0xFD10000000000000 | texaddr;
                SM64ROM.WriteEightBytes(F5 - 0x28, FDCMD); //write FD cmd over 06 cmd
                UInt32 NextF3CMD = ROMManager.findu32(F5, 0xF3000000, true);
                if (NextF3CMD != 0 && SM64ROM.ReadFourBytes(NextF3CMD - 8) == 0x06000000) SM64ROM.WriteEightBytes(NextF3CMD - 8, 0xE600000000000000);
            }
        }
        byte WidthsizeByte = SM64ROM.getByte(F5CMDs[0] + 7);
        ushort HeightsizeShort = SM64ROM.ReadTwoBytes(F5CMDs[0] + 5);
        int ogHeightPower = (HeightsizeShort >> 6 & 0x0F);
        int ogWidthPower = (WidthsizeByte >> 4);
        if (ogWidthPower <= ogHeightPower) ResizeTexture(index, ogWidthPower + 1, ogHeightPower, out bool isFailedtoResize); //double res x
        else ResizeTexture(index, ogWidthPower, ogHeightPower + 1, out bool isFailedToResize); //double res y
    }
}