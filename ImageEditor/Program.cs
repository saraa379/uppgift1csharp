using System;
using System.Drawing;

namespace ImageEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Image Editor is starting");
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a image path");
                string path = Console.ReadLine();
                ImgEditor.EditImage(path);
            }
            else
            {
                string imageLink = args[0];
                Console.WriteLine("Argument is passed: " + imageLink);
                ImgEditor.EditImage(imageLink);
                

            }
            
        }
    }
}

