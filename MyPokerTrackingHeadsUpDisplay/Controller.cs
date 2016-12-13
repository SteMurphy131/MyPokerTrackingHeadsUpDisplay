using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using EasyHook;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Controller
    {
        public string ChannelName = null;
        public string DllPath = "C:\\Users\\SteMu\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\MyPokerTrackingHeadsUpDisplay\\PokerHookDll\\bin\\Debug\\PokerHookDll.dll";

        public MainWindow _mainWindow { get; set; }
        public MessageHandler _messageHandler { get; set; }

        private static volatile Controller _instance = null;
        private static readonly object _mutex = new object();

        private Controller(){}

        public static Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_mutex)
                    {
                        if (_instance == null)
                        {
                            _instance = new Controller();
                        }
                    }
                }
                return _instance;
            }
        }

        public void InitEvents()
        {
            _messageHandler.updateHole += UpdateHoleCard;
            _messageHandler.updateBoard += UpdateBoardCard;
        }

        public void UpdateHoleCard(Card c, int num)
        {
            if (num == 0)
                _mainWindow.UpdateHoleOne(c);
            else if (num == 1)
            {
                _mainWindow.UpdateHoleTwo(c);
                _mainWindow.ClearBoardCards();
            }
        }

        public void UpdateBoardCard(Card c, int num)
        {
            if (num == 0)
                _mainWindow.UpdateBoardOne(c);
            else if (num == 1)
                _mainWindow.UpdateBoardTwo(c);
            else if (num == 2)
                _mainWindow.UpdateBoardThree(c);
            else if (num == 3)
                _mainWindow.UpdateBoardFour(c);
            else if (num == 4)
                _mainWindow.UpdateBoardFive(c);
        }

        public bool InjectDll()
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
