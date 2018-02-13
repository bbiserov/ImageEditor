using ConsoleConsumer.MenuOptions;
using ImageEditor;
using System;

namespace ConsoleConsumer.MainMenu
{
    public class MainOptions
    {
        private Image image = new Image();

        private ResizerOptionsType RenderMenuResizer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Resize Menu\n");
                Console.WriteLine("There are two options: \n");
                Console.WriteLine("If you want to 'Crop' type : [C]");
                Console.WriteLine("If you want to 'Skew' type : [S]");
                Console.WriteLine("");
                Console.WriteLine("If you want to back to Main Menu type : [B]\n");

                Console.Write("Choose option : ");
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "C":
                        {
                            return ResizerOptionsType.Crop;

                        }
                
                    case "S":
                        {
                            return ResizerOptionsType.Skew;
                        }
                    case "B":
                        {
                            return ResizerOptionsType.MainMenu;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        public void ShowResizerMenu()
        {
            while (true)
            {
                ResizerOptionsType choice = RenderMenuResizer();
                try
                {
                    switch (choice)
                    {
                        case ResizerOptionsType.Crop:
                            {
                                Crop();
                                break;
                            }
                      
                        case ResizerOptionsType.Skew:
                            {
                                Skew();
                                break;
                            }
                        case ResizerOptionsType.MainMenu:
                            {
                                new ChoiceOptions().ShowMainMenu();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        private void Crop()
        {
            Console.Clear();
            Console.WriteLine("Crop Menu\n");
            Console.Write("Select a directory to input an image:(FOR EXAMPLE  C:\\User\\Desktop\\picture1.jpg)\n");
            string sourcePath = Console.ReadLine();

            Console.Write("Select a directory to save an image:(FOR EXAMPLE  C:\\User\\Desktop\\test.jpg)\n");
            string destinatonPath = Console.ReadLine();

            Console.Write("Enter  width: ");
            int width = int.Parse(Console.ReadLine());

            Console.Write("Enter height: ");
            int height = int.Parse(Console.ReadLine());

            Console.Write("Start point X: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Start point Y: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Enter 'Crop' to complete the operation: ");
            string operationType = Console.ReadLine();

            image.Resize(sourcePath, destinatonPath, (ResizeType)Enum.Parse(typeof(ResizeType), operationType, true), width, height, x, y);
        }


        private void Skew()
        {
            Console.Clear();
            Console.WriteLine("Skew Menu\n");
            Console.Write("Select a directory to input an image:(FOR EXAMPLE  C:\\User\\Desktop\\picture1.jpg)\n");
            string sourcePath = Console.ReadLine();

            Console.Write("Select a directory to save an image:(FOR EXAMPLE  C:\\User\\Desktop\\test.jpg)\n");
            string destinatonPath = Console.ReadLine();

            Console.Write("Enter Width: ");
            int width = int.Parse(Console.ReadLine());

            Console.Write("Enter height: ");
            int height = int.Parse(Console.ReadLine());

            Console.Write("Enter 'Skew' to complete the operation: ");
            string operationType = Console.ReadLine();

            image.Resize(sourcePath, destinatonPath, (ResizeType)Enum.Parse(typeof(ResizeType), operationType, true), width, height);
        }
    }
}
