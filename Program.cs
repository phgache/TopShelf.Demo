using SimpleInjector;

using Topshelf;
using Topshelf.Logging;
using Topshelf.SimpleInjector;

namespace TopShelf.Demo
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Configure container
            var container = new Container();
            container.Register<IRunningService, RunningService>();

            // Top shelf setup
            HostFactory.Run(
                config =>
                    {
                        config.UseSimpleInjector(container);
                        config.UseLog4Net();

                        config.BeforeInstall(() => HostLogger.Current.Get("Logger").Info("Installing service."));
                        config.AfterInstall(() => HostLogger.Current.Get("Logger").Info("Service installed."));
                        config.BeforeUninstall(() => HostLogger.Current.Get("Logger").Info("Uninstalling service."));
                        config.AfterUninstall(() => HostLogger.Current.Get("Logger").Info("Service {0} uninstalled."));

                        config.Service<RunningService>(
                            s =>
                                {
                                    s.ConstructUsingSimpleInjector();
                                    s.WhenStarted(tc => tc.Start());
                                    s.WhenStopped(tc => tc.Stop());
                                });

                        config.SetDescription("TopShelf Demo service");
                        config.SetDisplayName("TopShelf Demo");
                        config.SetServiceName("TopShelfDemo");
                    });
        }
    }

    internal interface IRunningService
    {
        void Start();

        void Stop();
    }

    internal class RunningService : IRunningService
    {
        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }
    }
}
