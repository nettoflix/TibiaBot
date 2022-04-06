using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstForm
{
    static class MemoryUtils
    {
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYUP = 0x0101;
        public const uint VK_SPACE = 0x20;
        public const uint VK_N = 0x4E;
        public const uint VK_F1 = 0x70;
        public const uint VK_F2 = 0x71;
        public const uint VK_F3 = 0x72;
        public const uint VK_F4 = 0x73;
        public const uint VK_F5 = 0x74;
        public const uint VK_F6 = 0x75;
        public const uint VK_F7 = 0x76;
        public const uint VK_F8 = 0x77;
        public const uint VK_F9 = 0x78;
        public const uint VK_F10 = 0x79;
        public const uint VK_F11 = 0x7A;	
        public const uint VK_F12= 0x7B;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public static int ReadMemoryWithOffsets(IntPtr processHandle, int BaseAddress, int[] Offsets)
        {
            int bytesRead = 0;
            byte[] bufferOut = new byte[4];
            int address = BaseAddress;
            foreach (int offset in Offsets)
            {
                ReadProcessMemory((int)processHandle, address, bufferOut, bufferOut.Length, ref bytesRead);
                address = BitConverter.ToInt32(bufferOut,0) + offset;
            }
            ReadProcessMemory((int)processHandle, address, bufferOut, bufferOut.Length, ref bytesRead);
            return BitConverter.ToInt32(bufferOut, 0);
        }
        public static void SendKeyToWindow(string wndName, uint keyCode)
        {
            string lpClassName = wndName; //taleon window class name
            IntPtr hwnd = FindWindow(lpClassName, null);
            SendMessage(hwnd, (int)WM_KEYDOWN, (IntPtr)keyCode, (IntPtr)0);
        }

        public static uint getKeyCodeFromString(string str)
        {
            switch (str)
            {
                case "F1":
                    return VK_F1;
                    break;

                case "F2":
                    return VK_F2;
                    break;
                case "F3":
                    return VK_F3;
                    break;
                case "F4":
                    return VK_F4;
                    break;
                case "F5":
                    return VK_F5;
                    break;
                case "F6":
                    return VK_F6;
                case "F7":
                    return VK_F7;
                case "F8":
                    return VK_F8;
                case "F9":
                    return VK_F9;
                case "F10":
                    return VK_F10;
                case "F11":
                    return VK_F11;
                case "F12":
                    return VK_F12;
                    break;

                default:
                    return 0;
                    break;
            }
        }
    }
}
