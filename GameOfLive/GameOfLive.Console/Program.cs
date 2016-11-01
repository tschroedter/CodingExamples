using System.Collections.Generic;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GameOfLive.Interfaces;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");

            using ( var container = new WindsorContainer() )
            {
                container.Install(FromAssembly.Containing(typeof ( Installer )));

                var converter = container.Resolve <IStringToCellInformationConverter>();
                IEnumerable <ICellInformation> cells = converter.Convert(CreateStillLife());

                var manager = container.Resolve <IBoardManager>();
                manager.Update(cells);

                var converterToText = container.Resolve <ICellInformationToStringConverter>();

                for ( var i = 1 ; i <= 100 ; i++ )
                {
                    IEnumerable <string> text = converterToText.Convert(manager.LivingCells());

                    Display(text);

                    manager.NextGeneration();
                }

                container.Release(converter);
                container.Release(converterToText);
                container.Release(manager);
            }

            System.Console.ReadLine();
        }

        private static void Display(IEnumerable <string> lines)
        {
            System.Console.Clear();

            foreach ( string line in lines )
            {
                string text = string.Join("",
                                          line);
                System.Console.WriteLine(text);
            }

            System.Console.WriteLine("Press 'Return' key for next generation..");

            System.Console.ReadLine();
        }

        // ReSharper disable once UnusedMember.Local
        private static string[] CreateStillLife()
        {
            return new[]
                   {
                       "    ",
                       " ** ",
                       " ** ",
                       "    "
                   };
        }

        // ReSharper disable once UnusedMember.Local
        private static string[] CreateBlinker()
        {
            return new[]
                   {
                       "     ",
                       " *** ",
                       "     "
                   };
        }

        // ReSharper disable once UnusedMember.Local
        private static string[] CreateBeacon()
        {
            return new[]
                   {
                       "**  ",
                       "**  ",
                       "  **",
                       "  **"
                   };
        }
    }
}