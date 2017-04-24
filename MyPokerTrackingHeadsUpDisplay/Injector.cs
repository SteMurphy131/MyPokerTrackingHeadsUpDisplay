using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using EasyHook;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Injector
    {
        public static string ChannelName = null;
        public static string DllPath = "PokerHookDll.dll";

        public static bool InjectDll(Controller cont)
        {
            try
            {
                RemoteHooking.IpcCreateServer<RemoteMonitor>(ref ChannelName, WellKnownObjectMode.SingleCall);
                var processId = -1;

                foreach (var p in Process.GetProcessesByName("PokerStars"))
                {
                    processId = p.Id;
                    break;
                }

                if (processId == -1)
                {
                    Console.WriteLine("No PokerStars.exe process running");
                    Console.ReadLine();
                }

                RemoteHooking.Inject(processId, InjectionOptions.DoNotRequireStrongName, DllPath, DllPath, ChannelName);
                return true;
            }
            catch (Exception ex)
            {
                cont.Log.Error($"Error: {ex}");
                cont.InjectorErrorMessage = ex.Message;
                return false;
            }
        }
    }
}