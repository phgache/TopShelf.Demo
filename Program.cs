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
            container.Register<IClock, Clock>();

            // Top shelf setup
            HostFactory.Run(
                config =>
                    {
                        config.UseSimpleInjector(container);
                        config.UseLog4Net("log4net.xml");

                        config.Service<Clock>(
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
}
