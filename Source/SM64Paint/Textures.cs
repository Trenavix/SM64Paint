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

public class Textures
{
    public static bool FirstTexLoad = false;
    public static int[] TextureArray = new int[0];
    public static uint[][] TextureAddrArray = new uint[0][]; //Array of Addr and format
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

    public static int LoadTexture(ROM SM64ROM)
    {
        int CICount = currentPalette.Length;
        int NewTexture = 0;
        if (MODE == CIMODE) { NewTexture = LoadCITexture(SM64ROM); }
        else if (MODE == RGBAMODE && BitSize == 16) { NewTexture = LoadRGBA16Texture(SM64ROM); }
        else if (MODE == RGBAMODE && BitSize == 32) { NewTexture = LoadRGBA32Texture(SM64ROM); }
        else if (MODE == IAMODE && BitSize == 8) { NewTexture = LoadIA8Texture(SM64ROM); }
        else if (MODE == IAMODE && BitSize == 16) { NewTexture = LoadIA16Texture(SM64ROM); }
        else throw new System.TypeLoadException("Unimplemented Texture Format");
        return NewTexture;
    }

    public static int LoadCITexture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] CITex;
        short[] NewTexture;
        if (currentPalette.Length <= 16)
        {
            CITex = SM64ROM.copyBytestoArray(currentTexAddr, Width*Height/2);//4bpp
            NewTexture = CI4ToRGB5A1(CITex, currentPalette);
        }
        else
        {
            CITex = SM64ROM.copyBytestoArray(currentTexAddr, Width*Height);//8bpp
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
        short[] TexData = LoadRGBA16TextureData(Width*Height, SM64ROM);
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
        Int32[] TexData = new Int32[Width*Height]; //actually FloatsToLoad but accounted for as Shorts
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

    public static int LoadIA8Texture(ROM SM64ROM)
    {
        int id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        byte[] TexData = SM64ROM.copyBytestoArray(currentTexAddr, Width*Height);

        GL.TexImage2D
            (
            TextureTarget.Texture2D, 
            0, 
            PixelInternalFormat.Alpha,
            (int)Width,
            (int)Height, 
            0, 
            OpenTK.Graphics.OpenGL.PixelFormat.Alpha, 
            PixelType.UnsignedByte, 
            TexData
            );
        getTSFlags();
        getSTDTextureFilters();
        return id;
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
    {;
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
}