using System;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace InputTrackingExample
{

    public class MouseInput : IDisposable
    {
        public event EventHandler<EventArgs> MouseMoved;

        private WindowsHookHelper.HookDelegate mouseDelegate;
        private IntPtr mouseHandle;
        private const Int32 WH_MOUSE_LL = 14;
        private Win32.POINT myPoint;
        private bool _myTaskIsRunning = false;
        private readonly object _sync = new object();

        private bool leftDown = false;
        private bool isOn = false;



        private bool disposed;



        public MouseInput()
        {
            mouseDelegate = MouseHookDelegate;
            mouseHandle = WindowsHookHelper.SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
        }

        private IntPtr MouseHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {

            //Console.WriteLine("mouse");
            if (Code < 0)
                return WindowsHookHelper.CallNextHookEx(mouseHandle, Code, wParam, lParam);

            if (MouseMoved != null)
            {
                MouseMoved(this, new EventArgs());

                Console.WriteLine("wParam: " + wParam);

                if (wParam == (IntPtr)513)
                {
                    Console.WriteLine("left down");
                    //Location.X = Cursor.Position.X;
                    //Location.Y = Cursor.Position.Y;

                    leftDown = true;

                    if (isOn)
                    {
                        MyTaskAsync();
                    }


                    /*
                     void mouse_event(
                      DWORD     dwFlags,
                      DWORD     dx,
                      DWORD     dy,
                      DWORD     dwData,
                      ULONG_PTR dwExtraInfo
                    );
                    */


                }
                if (wParam == (IntPtr)514)
                {
                    Console.WriteLine("left up");
                    leftDown = false;
                }
                if (wParam == (IntPtr)516)
                {
                    Console.WriteLine("right down");
                }
                if (wParam == (IntPtr)517)
                {
                    Console.WriteLine("right up");
                }
                if (wParam == (IntPtr)519)
                {
                    Console.WriteLine("m down");
                    if (isOn)
                    {
                        isOn = false;
                    }
                    else
                    {
                        isOn = true;
                    }
                }
                if (wParam == (IntPtr)520)
                {
                    Console.WriteLine("m up");
                }
            }
            return WindowsHookHelper.CallNextHookEx(mouseHandle, Code, wParam, lParam);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        private void ak()
        {
            Win32.mouse_event(0x0001, -19, 27, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -3, 25, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -20, 27, 0, 0);//shot 4
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -24, 24, 0, 0);// 5
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -13, 21, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            //5
            Win32.mouse_event(0x0001, 15, 21, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 18, 21, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 18, 15, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 19, 15, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 22, 15, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }
            //10



            Win32.mouse_event(0x0001, 16, 9, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 16, 12, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 15, 15, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 10, 14, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 10, 13, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            //15
            Win32.mouse_event(0x0001, -18, 16, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -20, 16, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -24, 16, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -25, 16, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -24, 16, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }


            //20
            Win32.mouse_event(0x0001, -22, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -20, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -20, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -18, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, -18, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            //25
            Win32.mouse_event(0x0001, 25, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 27, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 27, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 27, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

            Win32.mouse_event(0x0001, 22, 11, 0, 0);
            Thread.Sleep(140);
            if (!leftDown) { return; }

        }

        private void MyMouseWorker()
        {
            Win32.GetCursorPos(out myPoint);

            Console.WriteLine("x: " + myPoint.x);
            Console.WriteLine("y: " + myPoint.y);

            Win32.POINT p = new Win32.POINT();

            p.x = myPoint.x + 10;
            p.y = myPoint.y + 10;

            ak();

        }

        public bool OnOff()
        {
            return isOn;
        }

        private delegate void MyTaskWorkerDelegate();

        public void MyTaskAsync()
        {
            MyTaskWorkerDelegate worker = new MyTaskWorkerDelegate(MyMouseWorker);
            AsyncCallback completedCallback = new AsyncCallback(MyTaskCompletedCallback);

            lock (_sync)
            {
                if (_myTaskIsRunning)
                    return;
                    //throw new InvalidOperationException("The control is currently busy.");

                AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                worker.BeginInvoke(completedCallback, async);
                _myTaskIsRunning = true;
            }
        }

        private void MyTaskCompletedCallback(IAsyncResult ar)
        {
            // get the original worker delegate and the AsyncOperation instance
            MyTaskWorkerDelegate worker =
              (MyTaskWorkerDelegate)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            worker.EndInvoke(ar);

            // clear the running task flag
            lock (_sync)
            {
                _myTaskIsRunning = false;
            }

            // raise the completed event
            AsyncCompletedEventArgs completedArgs = new AsyncCompletedEventArgs(null,
              false, null);
            async.PostOperationCompleted(
              delegate (object e) { OnMyTaskCompleted((AsyncCompletedEventArgs)e); },
              completedArgs);
        }

        public event AsyncCompletedEventHandler MyTaskCompleted;

        protected virtual void OnMyTaskCompleted(AsyncCompletedEventArgs e)
        {
            if (MyTaskCompleted != null)
                MyTaskCompleted(this, e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (mouseHandle != IntPtr.Zero)
                    WindowsHookHelper.UnhookWindowsHookEx(mouseHandle);

                disposed = true;
            }
        }

        ~MouseInput()
        {
            Dispose(false);
        }
    }
}
