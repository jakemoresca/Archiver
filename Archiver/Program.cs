using Microsoft.Practices.Unity;
using System;

namespace Archiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering dependencies ...");

            var container = new UnityContainer();
            RegisterTypes(container);

            var program = container.Resolve<IProgramStarter>();
            Console.WriteLine("All done. Starting program...");
            program.Run();
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IProgramStarter, ProgramStarter>();
            container.RegisterType<IFileListingService, FileListingService>();
            container.RegisterType<IArchiverSettingService, ArchiverSettingService>();
            container.RegisterType<IZipFileFactory, ZipFileFactory>();
        }
    }
}
