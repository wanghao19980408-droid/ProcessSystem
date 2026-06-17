using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public class CRC_Check
    {       
        public CRC_Check()
        {
           
        } 
/*-------------------------------crc method------------------------------------------*/
        UInt16[] crctableabs = {
            0x0000,0xCC01,0xD801,0x1400,0xF001,0x3C00,0x2800,0xE401,
            0xA001,0x6C00,0x7800,0xB401,0x5000,0x9C01,0x8801,0x4400
        };
        public UInt16 Crc16(Byte[] data_in, int data_length)
        {
            UInt16 crc = 0xFFFF;
            for (int i = 0; i < data_length; i++)
            {
                crc = Convert.ToUInt16(crctableabs[(data_in[i] ^ crc) & 15] ^ (crc >> 4));
                crc = Convert.ToUInt16(crctableabs[((data_in[i] >> 4) ^ crc) & 15] ^ (crc >> 4));
            }
            return crc;
        }
/*-----------------------------------------------------------------------------------*/
        UInt16[] crc16tab_Xmodem = {
            0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
            0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF
        };
        public UInt16 Crc16_Xmodem(Byte[] data_in, int data_length)
        {
            UInt16 crc = 0x0000;
            for (int i = 0; i < data_length; i++)
            {
                crc = Convert.ToUInt16(crc16tab_Xmodem[data_in[i] / 16 ^ (crc >> 12)] ^ (UInt16)(crc << 4));
                crc = Convert.ToUInt16(crc16tab_Xmodem[(data_in[i] & 0x0F) ^ (crc >> 12)] ^ (UInt16)(crc << 4));
            }
            return crc;
        }
    }
}
