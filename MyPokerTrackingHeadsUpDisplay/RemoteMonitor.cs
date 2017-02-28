using System;
using System.Text;
using System.Threading;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class RemoteMonitor : MarshalByRefObject
    {
        private Thread _workerThread;
        private readonly MessageHandler _messageHandler = new MessageHandler();

        public void HandleFileWriteBuffer(byte[] buffer)
        {
            var result = Encoding.Default.GetString(buffer);

            if (result.Contains("HOLE") || result.Contains("FLOP") || result.Contains("TURN") ||
                result.Contains("RIVER") || result.Contains("SHOW DOWN") || result.Contains("SUMMARY"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessHandHistoryState(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("SteMurphy131") && result.Contains("collected"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessHandWon(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("Game #"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessGameNumber(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("Hand #"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessHandNumber(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("updateBoard"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessUpdateBoardMessage(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("UpdateMyCard"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessUpdateHoleCardMessage(result));
                _workerThread.Start();
                return;
            }
            if (result.Contains("RaiseX"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessRaise());
                _workerThread.Start();
                return;
            }
            if (result.Contains("Fold"))
            {
                _workerThread = new Thread(() => _messageHandler.ProcessFold());
                _workerThread.Start();
                return;
            }
        }

        public void IsInstalled(int inClientPid)
        {
            Console.WriteLine($"Successfully injected into PID {inClientPid}");
        }

        public void ErrorHandler(Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }
    }
}