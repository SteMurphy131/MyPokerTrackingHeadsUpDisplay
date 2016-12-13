using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using MyPokerTrackingHeadsUpDisplay;

namespace PokerHookDll
{
    public class DllMain : IEntryPoint
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public delegate bool TWriteFile(
            IntPtr handle,
            IntPtr lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            [In] IntPtr lpOverlapped);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WriteFile(
            IntPtr handle,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            [In] IntPtr lpOverlapped);

        private LocalHook _writeFileHook;
        private readonly RemoteMonitor _interface;

        public DllMain(RemoteHooking.IContext inContext, string InChannelName)
        {
            try
            {
                _interface = RemoteHooking.IpcConnectClient<RemoteMonitor>(InChannelName);
                _interface.IsInstalled(RemoteHooking.GetCurrentProcessId());
            }
            catch (Exception ex)
            {
                _interface.ErrorHandler(ex);
            }
        }

        public void Run(RemoteHooking.IContext InContext, string InChannelName)
        {

            try
            {
                _writeFileHook = LocalHook.Create(LocalHook.GetProcAddress("KernelBase.dll", "WriteFile"),
                    new TWriteFile(HkWriteFile), this);
                _writeFileHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });
            }
            catch (Exception exception)
            {
                _interface.ErrorHandler(exception);
            }

            try
            {
                RemoteHooking.WakeUpProcess();
            }
            catch (Exception exception)
            {
                _interface.ErrorHandler(exception);
            }

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private static bool HkWriteFile(IntPtr handle, IntPtr lpBuffer, uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped)
        {
            try
            {
                var bytes = new byte[nNumberOfBytesToWrite];
                for (uint i = 0; i < nNumberOfBytesToWrite; i++)
                    bytes[i] = Marshal.ReadByte(lpBuffer, (int)i);

                ((DllMain)HookRuntimeInfo.Callback)._interface.HandleFileWriteBuffer(bytes);

                return WriteFile(handle, bytes, nNumberOfBytesToWrite, out lpNumberOfBytesWritten, lpOverlapped);
            }
            catch (Exception ex)
            {
                ((DllMain)HookRuntimeInfo.Callback)._interface.ErrorHandler(ex);
                lpNumberOfBytesWritten = 0;
                return false;
            }
        }
    }
}