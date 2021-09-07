using CommandLine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandbyStopper
{
    static class Program
    {

        public class Options
        {
            [Option('t', "timed", Required = false)]
            public bool Timed { get; set; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
            {
                if (o.Timed)
                {
                    //Load hidden system
                    Stopper.Run();

                } else
                {
                    //Load regular form for testing
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMain());
                }

            });


            
        }
    }
}
