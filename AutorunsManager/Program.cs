using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AutorunsManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
            //{
            //    String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            //    System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args.Name);
            //    String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

            //    using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            //    {
            //        Byte[] assemblyData = new Byte[stream.Length];
            //        stream.Read(assemblyData, 0, assemblyData.Length);
            //        return System.Reflection.Assembly.Load(assemblyData);
            //    }
            //};
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AutorunsManager());         
        }
    }
}
