using System;
using System.Runtime.InteropServices;


namespace InputTrackingExample
{
    public class KeyboardInput : IDisposable
    {
        public event EventHandler<EventArgs> KeyBoardKeyPressed;

        private WindowsHookHelper.HookDelegate keyBoardDelegate;
        private IntPtr keyBoardHandle;
        private const Int32 WH_KEYBOARD_LL = 13;
        private bool disposed;
        public int savedKey = 49;

        public KeyboardInput()
        {
            keyBoardDelegate = KeyboardHookDelegate;
            keyBoardHandle = WindowsHookHelper.SetWindowsHookEx(
                WH_KEYBOARD_LL, keyBoardDelegate, IntPtr.Zero, 0);
        }

        private IntPtr KeyboardHookDelegate(
            Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
            {

                
                return WindowsHookHelper.CallNextHookEx(
                    keyBoardHandle, Code, wParam, lParam);
                    
            }

            if (KeyBoardKeyPressed != null)
            {
                KeyBoardKeyPressed(this, new EventArgs());
                if ((int)wParam == 256)//keydown
                {
                    int key = (int)Marshal.ReadInt32(lParam);
                    Console.WriteLine("key wPara: " + wParam);
                    Console.WriteLine("key code?: " + key);
                    if (key == 48)//0
                    {
                        //onOff
                    }
                    if (key == 49)
                    {
                        savedKey = key;
                    }
                    if (key == 50)
                    {
                        savedKey = key;
                    }
                }
            }
           // Console.WriteLine("key Code: " + Code);
            //Console.WriteLine("key wPara: " + wParam);
            //Console.WriteLine("key lPara: " + lParam);
           // Console.WriteLine("key hand: " + keyBoardHandle);


            return WindowsHookHelper.CallNextHookEx(
                keyBoardHandle, Code, wParam, lParam);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public int GetKey()
        {
            return savedKey;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (keyBoardHandle != IntPtr.Zero)
                {
                    WindowsHookHelper.UnhookWindowsHookEx(
                        keyBoardHandle);
                }

                disposed = true;
            }
        }

        ~KeyboardInput()
        {
            Dispose(false);
        }
    }
}