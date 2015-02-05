using System;
using System.Timers;
using Topshelf.Logging;

namespace TopShelf.Demo
{
    internal class Clock : IClock
    {
        private Timer timer;
        
        public void Start()
        {
            timer = new Timer(5000);
            timer.Elapsed += (sender, args) => HostLogger.Current.Get("Logger").Debug(DateTime.Now);
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}