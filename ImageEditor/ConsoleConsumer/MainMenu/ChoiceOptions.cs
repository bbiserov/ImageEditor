using ConsoleConsumer.MenuOptions;
using ImageEditor;
using System;

namespace ConsoleConsumer.MainMenu
{
    public class ChoiceOptions
    {
        private Image Editor = new Image();

        private MenuOptionsType RenderMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" CONVERTER and RESIZER  ");
                Console.WriteLine("\nThere are two options : \n");
                Console.WriteLine("1.If you want to 'Convert' type : [C]");
                Console.WriteLine("2.If you want to 'Resize' type : [R]\n");
                Console.WriteLine("");
                Console.WriteLine("If you want to 'Exit' type : [E]\n");

                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "C":
                        {
                            return MenuOptionsType.Converter;
                        }
                    case "R":
                        {
                            return MenuOptionsType.Resizer;
                        }
                    case "E":
                        {
                            return MenuOptionsType.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                MenuOptionsType choice = RenderMainMenu();
                try
                {
                    switch (choice)
                    {
                        case MenuOptionsType.Converter:
                            {
                                Convert();
                                break;
                            }
                        case MenuOptionsType.Resizer:
                            {
                                new MainOptions().ShowResizerMenu();
                                break;
                            }
                        case MenuOptionsType.Exit:
                            {
                                Environment.Exit(0);
                                break;
                            }
                    }
                }
                catch (Exception exc)
                {
                    Console.Clear();
                    Console.WriteLine(exc.Message);
                    Console.ReadKey(true);
                }
            }

        }
        
        private void Convert()
        {
            Console.Clear();
            Console.Write(" Formats: JPG,GIF,PNG\n\n");
            Console.Write("Select a directory to input an image:(FOR EXAMPLE  C:\\User\\Desktop\\picture1.jpg)\n");
            string sourcePath = Console.ReadLine();

            Console.Write("Select a directory to save an image:(FOR EXAMPLE  C:\\User\\Desktop\\test.gif)\n");
            string destinatonPath = Console.ReadLine();

            Console.Write("Specify one of the above formats <JPG,GIF, PNG>>: ");
            string imageFormat = Console.ReadLine();

            Editor.Convert(sourcePath, destinatonPath,(ConvertType)Enum.Parse(typeof(ConvertType),imageFormat,true));

        }
   
    }
}
