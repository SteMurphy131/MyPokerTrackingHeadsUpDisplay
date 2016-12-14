using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using EasyHook;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Injector
    {
        public static string ChannelName = null;
        public static string DllPath = "C:\\Users\\SteMu\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\MyPokerTrackingHeadsUpDisplay\\PokerHookDll\\bin\\Debug\\PokerHookDll.dll";

        public static bool InjectDll()
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
                Console.WriteLine($"There was an error while connecting to target: \r\n {ex}");
                Console.ReadLine();
                return false;
            }
        }
    }
}