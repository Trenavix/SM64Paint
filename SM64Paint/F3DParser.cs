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
using System.Drawing;
using System.Collections;

public class F3D
{
    static uint CICount = 0;
    static uint TextureIndex = 0;
    static Vertex[] VTXBuffer = new Vertex[16]; //Only 16 verts in buffer for F3D v1.0 :(
    static bool LightingEnabled = false;
    static bool EnvMapping = false;
    static bool ColourCombiner = false;
    public static bool RenderEdges = false;
    public static bool Culling = true;
    public static String[] DebugText;
    public static UInt32 GeoMode = 0; 

    public static void ParseF3DDL(ROM SM64ROM, uint SegOffset, bool ColourBuffer)
    {
        F3D.DecodeF3DCommands(SM64ROM, SegOffset, ColourBuffer);
        GL.Disable(EnableCap.Texture2D);
        CICount = 0;
        TextureIndex = 0;
        ColourCombiner = false;
    }

    private static void DecodeF3DCommands(ROM SM64ROM, uint SegOffset, bool ColourBuffer)
    {
        uint Offset = SM64ROM.readSegmentAddr(SegOffset);
        uint CMDCount = 0;
        for (uint i = Offset; i < SM64ROM.getEndROMAddr(); i += 8)
        {
            if (SM64ROM.getByte(i) == 0xB8)
            {
                CMDCount = ((i - Offset) / 8) + 1;//Plus one command for B8
                break;
            }
        }
        byte[][] DisplayList = new byte[CMDCount][];
        //Copy DL into 2D Byte array with double loop 
        for (uint i = 0; i < CMDCount; i++)
        {
            DisplayList[i] = new byte[8];
            for (uint j = 0; j < 8; j++)
            {
                DisplayList[i][j] = SM64ROM.getByte(Offset + (i * 8) + j);
            }
        }

        for (uint i = 0; i < SM64ROM.getEndROMAddr(); i++)
        {
            byte[] CMD = DisplayList[i];
            if (Textures.FirstTexLoad && ROMManager.debug) //Debug Txt
            {
                Array.Resize(ref DebugText, DebugText.Length + 1);
                DebugText[DebugText.Length - 1] = (Offset + (i * 8)).ToString("x") + ": "; //Addr: 
                for (uint j = 0; j < 8; j++)
                {
                    DebugText[DebugText.Length-1] += CMD[j].ToString("x") + " "; //F3D CMD bytes in hex
                }
            } 
            if (!ColourBuffer) switch (DisplayList[i][0])
            {
                case 0x01: //G_MTX
                    break;
                case 0x03: //movemem
                    if (RenderEdges) break;
                    if (CMD[1] == 0x86)
                    {
                        float[] light0_diffuse = new float[4];
                        uint rgbaAddr = SM64ROM.readSegmentAddr(returnSegmentAddr(CMD));
                        for (uint j = 0; j < 4; j++)
                        {
                            light0_diffuse[j] = (float)SM64ROM.getByte(rgbaAddr + j) / 255f;
                        }
                        GL.Light(LightName.Light0, LightParameter.Diffuse, light0_diffuse);
                        GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.Diffuse);
                    }
                    else if (CMD[1] == 0x88)
                    {
                        float[] light0_ambient = new float[4];
                        uint rgbaAddr = SM64ROM.readSegmentAddr(returnSegmentAddr(CMD));
                        for (uint j = 0; j < 4; j++)
                        {
                            light0_ambient[j] = (((float)SM64ROM.getByte(rgbaAddr + j) / 255f) - 0.2f) * 1.25f;
                        }
                        GL.Light(LightName.Light0, LightParameter.Ambient, light0_ambient);
                        GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.Ambient);
                    }
                    GL.Enable(EnableCap.ColorMaterial);
                    break;
                case 0x04: //G_VTX
                    UInt32 VTXStart = SM64ROM.readSegmentAddr(returnSegmentAddr(CMD));
                    short numVerts = (short)((CMD[1] >> 4) + 1);
                    int bufferIndex = CMD[1] & 0x0F;
                    for (int j = 0; j < numVerts; j++)
                    {
                        VTXBuffer[bufferIndex + j] = Vertex.getVertex(VTXStart + (uint)(j * 0x10), SM64ROM);
                    }
                    Renderer.VertexCount += (uint)numVerts;
                    break;
                case 0x06: //LoadDL (jump)
                        F3D.DecodeF3DCommands(SM64ROM, returnSegmentAddr(CMD), ColourBuffer);
                    if (CMD[1] == 1) return;
                    break;
                case 0xB1:
                    //0xB1 (TRI2) is not used in F3D v1.0
                    break;
                case 0xB2: // Unused in F3D v1.0
                    break;
                case 0xB3: //G_RDP_Half2
                    break;
                case 0xB4: //G_RDP_Half1 
                    break;
                case 0xB5: //G_Quad (Unused in F3D v1.0)
                    break;
                case 0xB6: //ClearGeoMode
                    if (RenderEdges) break;
                    UInt32 ClearBits = (UInt32)((CMD[4] << 24) | (CMD[5] << 16) | (CMD[6] << 8) | CMD[7]);
                    GeoMode &= ~ClearBits;
                    SetGeoMode(ColourBuffer);
                    break;
                case 0xB7: //SetGeoMode   
                    if (RenderEdges) break;
                    UInt32 SetBits = (UInt32)((CMD[4] << 24) | (CMD[5] << 16) | (CMD[6] << 8) | CMD[7]);
                    GeoMode |= SetBits;
                    SetGeoMode(ColourBuffer);
                    break;
                case 0xB9: //SetOtherMode
                    break;
                case 0xBA: //SetOtherMode
                    break;
                case 0xBB: //G_Texture
                    Vertex.U_Scale = Convert.ToSingle((CMD[4] << 8) | CMD[5]) / Convert.ToSingle(0xFFFF);
                    Vertex.V_Scale = Convert.ToSingle((CMD[6] << 8) | CMD[7]) / Convert.ToSingle(0xFFFF);
                    if (CMD[3] == 0x01 && Renderer.TextureEnabler && !RenderEdges) { GL.Enable(EnableCap.Texture2D); }
                    else
                    {
                        GL.Disable(EnableCap.Texture2D);
                        Textures.T_Scale = 1f; Textures.S_Scale = 1f;
                    }
                    if (DisplayList[i][2] == 0x12)
                    {
                        Textures.MipMapping = true;
                        Textures.T_Scale = 1f; Textures.S_Scale = 1f;//Revert mipmapping for now
                    }
                    break;
                case 0xBC: //moveword
                    break;
                case 0xBD: //PopMTX
                    break;
                case 0xBF: //TRI1
                    if (LightingEnabled && !Renderer.ViewNonRGBA) break;
                    GL.Begin(BeginMode.Triangles);
                    for (int j = 5; j < 8; j++)
                    {
                        int VertIndex = CMD[j] / 0x0A;
                        if (!EnvMapping) GL.TexCoord2(VTXBuffer[VertIndex].getUVVector());

                            if (LightingEnabled) //Normals
                            {
                                Vector3 normals = new Vector3(VTXBuffer[VertIndex].getRGBColor());
                                if (!EnvMapping) { GL.Normal3(Vector3.Normalize(normals)); }
                                else
                                {
                                    Vector4 normals4 = new Vector4(normals, 1f);
                                    normals4 = Vector4.Normalize(Renderer.projection * normals4);
                                    Vector3 newnorms = new Vector3(normals4.X, normals4.Y, normals4.Z);
                                    GL.Normal3(newnorms);
                                }
                                GL.Color4(1f, 1f, 1f, VTXBuffer[VertIndex].getRGBAColor().A);

                            }
                            



                        else GL.Color4(VTXBuffer[VertIndex].getRGBAColor()); //RGBA
                        if (RenderEdges) GL.Color4(0, 0, 0, 0xFF);
                        GL.Vertex3(VTXBuffer[VertIndex].getCoordVector());
                    }
                    if(!RenderEdges)Renderer.TriCount++;
                    GL.End();
                    break;
                case 0xF0: //LoadTLUT
                    if (!Textures.FirstTexLoad) break;
                    CICount = (uint)((((CMD[5] << 4) + ((CMD[6] & 0xF0) >> 4)) >> 2) + 1);
                    Textures.currentPalette = Textures.LoadRGBA16TextureData(CICount, SM64ROM);
                    break;
                case 0xF2: //Settilesize
                    Textures.S_Scale = Convert.ToSingle((((CMD[5] << 4)| ((CMD[6] &0xF0) >> 4)) >> 2) + 1);
                    Textures.T_Scale = Convert.ToSingle(((((CMD[6] & 0x0F) << 8) | CMD[7]) >> 2) +1);
                    break;
                case 0xF3: //LoadBlock
                    if(SM64ROM.getSegmentStart(0x0E) < 0x1200000 && !Renderer.ObjectView)TextureLoadRoutine(SM64ROM, 0);
                    break;
                case 0xF5: //Settile
                    Textures.MODE = (byte)(CMD[1] >> 5);
                    Textures.BitSize = (byte)(4 * Math.Pow(2, ((CMD[1] >> 3) & 3)));
                    Textures.TFlags = (uint)(CMD[5] >> 2) & 3;
                    Textures.SFlags = (uint)CMD[6] & 3;
                    int WidthBits = (((CMD[1] & 3) << 7) + CMD[2] >> 1)*64;
                    if (CMD[4] != 0) break; //If RenderTile, continue
                    int HeightPower = ((CMD[5] & 3) << 2) | (CMD[6] >> 6);
                    int WidthPower = (CMD[7] >> 4);
                    Textures.Width = (uint)Math.Pow(2, WidthPower);
                    Textures.Height = (uint)Math.Pow(2, HeightPower);
                    if(Textures.currentTexAddr == 0) break;
                    TextureLoadRoutine(SM64ROM, Offset + (uint)(i * 8));
                    break;
                case 0xFB: //Set Env Colour
                    if (RenderEdges) break;
                    ColourCombiner = true;
                    GL.Color4((float)CMD[4]/255f, (float)CMD[5] / 255f, (float)CMD[6] / 255f, (float)CMD[7] / 255f);
                    break;
                case 0xFC: //Setcombine
                    if (CMD[7] == 0x3C && CMD[6] == 0x79 && CMD[5] == 0xFE) GL.Disable(EnableCap.Texture2D);
                    else if(Renderer.TextureEnabler) GL.Enable(EnableCap.Texture2D);
                    break;
                case 0xFD: //SetTIMG
                    Textures.currentSegment = CMD[4];
                    Textures.currentTexAddr = SM64ROM.readSegmentAddr(returnSegmentAddr(CMD));
                    if (!Textures.FirstTexLoad) break;
                    Textures.BitSize = (byte)(4 * Math.Pow(2, ((CMD[1] >> 3) & 3)));
                    Textures.MODE = (byte)(CMD[1] >> 5);
                    break;
                case 0xB8: //End DL
                    return;
            }
            else switch (DisplayList[i][0]) //Vertex Selection Colour buffer here
                {
                    case 0x03:
                        break;
                    case 0x04:
                        UInt32 VTXStart = SM64ROM.readSegmentAddr(returnSegmentAddr(CMD));
                        short numVerts = (short)((CMD[1] >> 4) + 1);
                        int bufferIndex = CMD[1] & 0x0F;
                        for (int j = 0; j < numVerts; j++)
                        {
                            VTXBuffer[bufferIndex + j] = Vertex.getVertex(VTXStart + (uint)(j * 0x10), SM64ROM);
                        }
                        Renderer.VertexCount += (uint)numVerts;
                        break;
                    case 0x06:
                        F3D.DecodeF3DCommands(SM64ROM, returnSegmentAddr(CMD), ColourBuffer);
                        if (CMD[1] == 1) return;
                        break;
                    case 0xB6:
                        if (RenderEdges) break;
                        UInt32 ClearBits = (UInt32)((CMD[4] << 24) | (CMD[5] << 16) | (CMD[6] << 8) | CMD[7]);
                        GeoMode &= ~ClearBits;
                        SetGeoMode(ColourBuffer);
                        break;
                    case 0xB7:
                        if (RenderEdges) break;
                        UInt32 SetBits = (UInt32)((CMD[4] << 24) | (CMD[5] << 16) | (CMD[6] << 8) | CMD[7]);
                        GeoMode |= SetBits;
                        SetGeoMode(ColourBuffer);
                        break;
                    case 0xBF:
                        if ( LightingEnabled && Renderer.AlphaOnlyBox == false ) break; //Disable color painting on non-RGBA meshes, allow alpha painting
                        Vertex[] Triangle = new Vertex[3];
                        Color4[] colour = new Color4[3];
                        for (int j = 5; j < 8; j++)
                        {
                            int VertIndex = CMD[j] / 0x0A;
                            Triangle[j-5] = VTXBuffer[VertIndex];
                            UInt32 Addr = Triangle[j-5].getAddr();
                            colour[j-5] = new Color4((byte)(Addr >> 24), (byte)((Addr >> 16) & 0xFF), (byte)((Addr >> 8) & 0xFF), (byte)(Addr & 0xFF)); //Addr to RGBA
                        }
                        Vector3 CentreCoord = new Vector3
                            (
                            (Triangle[0].getCoordVector().X + Triangle[1].getCoordVector().X + Triangle[2].getCoordVector().X) / 3,
                            (Triangle[0].getCoordVector().Y + Triangle[1].getCoordVector().Y + Triangle[2].getCoordVector().Y) / 3,
                            (Triangle[0].getCoordVector().Z + Triangle[1].getCoordVector().Z + Triangle[2].getCoordVector().Z) / 3
                            );
                        Vector3 OneTwoAVG = new Vector3
                            (
                            (Triangle[0].getCoordVector().X + Triangle[1].getCoordVector().X) / 2,
                            (Triangle[0].getCoordVector().Y + Triangle[1].getCoordVector().Y) / 2,
                            (Triangle[0].getCoordVector().Z + Triangle[1].getCoordVector().Z) / 2
                            );
                        Vector3 TwoThreeAVG = new Vector3
                            (
                            (Triangle[1].getCoordVector().X + Triangle[2].getCoordVector().X) / 2,
                            (Triangle[1].getCoordVector().Y + Triangle[2].getCoordVector().Y) / 2,
                            (Triangle[1].getCoordVector().Z + Triangle[2].getCoordVector().Z) / 2
                            );
                        Vector3 OneThreeAVG = new Vector3
                            (
                            (Triangle[0].getCoordVector().X + Triangle[2].getCoordVector().X) / 2,
                            (Triangle[0].getCoordVector().Y + Triangle[2].getCoordVector().Y) / 2,
                            (Triangle[0].getCoordVector().Z + Triangle[2].getCoordVector().Z) / 2
                            );

                        GL.Begin(BeginMode.Quads);
                        GL.Color4(colour[0]); //Vert 1 quad 
                        GL.Vertex3(Triangle[0].getCoordVector());
                        GL.Vertex3(OneTwoAVG);
                        GL.Vertex3(CentreCoord);
                        GL.Vertex3(OneThreeAVG);

                        GL.Color4(colour[1]); //Vert 2 quad
                        GL.Vertex3(Triangle[1].getCoordVector());
                        GL.Vertex3(TwoThreeAVG);
                        GL.Vertex3(CentreCoord);
                        GL.Vertex3(OneTwoAVG);

                        GL.Color4(colour[2]); //Vert 3 quad
                        GL.Vertex3(Triangle[2].getCoordVector());
                        GL.Vertex3(OneThreeAVG);
                        GL.Vertex3(CentreCoord);
                        GL.Vertex3(TwoThreeAVG);
                        GL.End();
                        break;
                    case 0xB8:
                        return;
                }
            }
    }

    private static void SetEnvironmentMapping()
    {
        GL.TexGen(TextureCoordName.S, TextureGenParameter.TextureGenMode, (float)TextureGenMode.SphereMap);
        GL.TexGen(TextureCoordName.T, TextureGenParameter.TextureGenMode, (float)TextureGenMode.SphereMap);
        GL.Enable(EnableCap.TextureGenS);
        GL.Enable(EnableCap.TextureGenT);
        EnvMapping = true;
        //GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
    }

    private static void RemoveEnvMapping()
    {
        GL.Disable(EnableCap.TextureGenS);
        GL.Disable(EnableCap.TextureGenT);
        EnvMapping = false;
    }

    public static UInt32 returnSegmentAddr(byte[] cmd)
    {
        UInt32 value = 0;
        for (int i = 4; i < 8; i++)
        {
            value = (value << 8) | cmd[i];
        }
        return value;
    }

    static void EnableLighting()
    {
        if (!ColourCombiner) GL.Color4(1f, 1f, 1f, 1f);
        float[] light0_position = { Math.Abs(Renderer.cam.CamRotation.X), Math.Abs(Renderer.cam.CamRotation.Y), Math.Abs(Renderer.cam.CamRotation.Z), 0.0f };
        GL.ShadeModel(ShadingModel.Smooth);
        GL.Light(LightName.Light0, LightParameter.Position, light0_position);
        GL.Enable(EnableCap.Lighting);
        GL.Enable(EnableCap.Light0);
        GL.Enable(EnableCap.Normalize);
        LightingEnabled = true;
    }

    static void DisableLighting()
    {
        GL.Disable(EnableCap.Lighting);
        LightingEnabled = false;
    }

    static void TextureLoadRoutine(ROM SM64ROM, uint F5Command)
    {
        TextureIndex = 0xFFFF;
        for (uint j = 0; j < Textures.TextureAddrArray.Length; j++) // Compare currentTexAddr to our texture address array
        {
            if (Textures.currentTexAddr == Textures.TextureAddrArray[j][0] && 
                Textures.MODE == Textures.TextureAddrArray[j][1] && 
                Textures.BitSize == Textures.TextureAddrArray[j][2] &&
                Textures.Width == Textures.TextureAddrArray[j][3] &&
                Textures.Height == Textures.TextureAddrArray[j][4] &&
                Textures.SFlags == Textures.TextureAddrArray[j][5] &&
                Textures.TFlags == Textures.TextureAddrArray[j][6]) //If all of these match...

            { TextureIndex = j; }
        }

        if (TextureIndex == 0xFFFF) //no match found
        {
            if (!Textures.FirstTexLoad) { TextureIndex = 0; return; }
            Array.Resize(ref Textures.TextureAddrArray, Textures.TextureAddrArray.Length + 1); //insert new slot for new texture
            TextureIndex = (uint)Textures.TextureAddrArray.Length - 1; //Set index to last slot
            Textures.TextureAddrArray[TextureIndex] = new uint[8]; //new addr, format, & bitsize
            Array.Resize(ref Textures.TextureArray, Textures.TextureArray.Length + 1);  //Also insert new slot for TexData
            Array.Resize(ref Textures.F5CMDArray, Textures.F5CMDArray.Length + 1);
            Textures.F5CMDArray[TextureIndex] = new uint[0];
        }

        if (Textures.FirstTexLoad)
        {
            Textures.TextureAddrArray[TextureIndex][0] = Textures.currentTexAddr; //Set addr, mode, and bitsize
            Textures.TextureAddrArray[TextureIndex][1] = Textures.MODE;
            Textures.TextureAddrArray[TextureIndex][2] = Textures.BitSize;
            Textures.TextureAddrArray[TextureIndex][3] = Textures.Width;
            Textures.TextureAddrArray[TextureIndex][4] = Textures.Height;
            Textures.TextureAddrArray[TextureIndex][5] = Textures.SFlags;
            Textures.TextureAddrArray[TextureIndex][6] = Textures.TFlags;
            Textures.TextureArray[TextureIndex] = Textures.LoadTexture(SM64ROM);
            Array.Resize(ref Textures.F5CMDArray[TextureIndex], Textures.F5CMDArray[TextureIndex].Length + 1);
            uint F5Index = (uint)Textures.F5CMDArray[TextureIndex].Length - 1;
            Textures.F5CMDArray[TextureIndex][F5Index] = F5Command;
        }
        GL.BindTexture(TextureTarget.Texture2D, Textures.TextureArray[TextureIndex]);
    }

    static void SetGeoMode(bool ColourBuffer)
    {
        byte CullMode = (byte)((GeoMode & 0x3000) >> 12);
        if (!Culling) CullMode = 0;
        GL.Enable(EnableCap.CullFace);
        switch (CullMode)
        {
            case 0:
                GL.Disable(EnableCap.CullFace);
                break;
            case 1:
                GL.CullFace(CullFaceMode.Front);
                break;
            case 2:
                GL.CullFace(CullFaceMode.Back);
                break;
            case 3:
                GL.CullFace(CullFaceMode.FrontAndBack);
                break;
        }
        if (ColourBuffer)
        {
            if ((GeoMode & 0x020000) >> 17 == 1) LightingEnabled = true;
            else LightingEnabled = false;
            return;
        }
        if (RenderEdges) return;
        if ((GeoMode & 0x010000) >> 16 == 1) GL.Enable(EnableCap.Fog);
        else GL.Disable(EnableCap.Fog);
        if ((GeoMode & 0x020000) >> 17 == 1) EnableLighting();
        else DisableLighting();
        if ((GeoMode & 0x040000) >> 18 == 1) SetEnvironmentMapping();
        else RemoveEnvMapping();
        //if ((SetBits & 0x080000) >> 19 == 1) SetLinearTexMap();
    }

    static void ClearGeoMode(UInt32 ClearBits)
    {
        byte CullMode = (byte)((ClearBits & 0x3000) >> 12);
        GL.Enable(EnableCap.CullFace);
        switch (CullMode)
        {
            case 1:
                GL.CullFace(CullFaceMode.Back);
                break;
            case 2:
                GL.CullFace(CullFaceMode.Front);
                break;
            case 3:
                GL.Disable(EnableCap.CullFace);
                break;
        }
    }
}




