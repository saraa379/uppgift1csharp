﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEditor
{
    static class ImgEditor
    {

        public static void EditImage(string imageLink) {
            Console.WriteLine("This is a image editor class");
            try
            {
                //Image newImage = Image.FromFile("SampImag.jpg");
                //Bitmap bm = (Bitmap) Bitmap.FromFile(argument);

                //get image name from the path
                string imageName = Path.GetFileNameWithoutExtension(imageLink);
                Console.WriteLine("Name of the image: " + imageName);

                //get image path from the link
                string imagePath = Path.GetDirectoryName(imageLink);
                Console.WriteLine("Path of the image: " + imagePath);

                Bitmap bimage = new Bitmap(imageLink);
                MakeNegative(imageLink, imageName, imagePath);

            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("Invalid directory in the file path.");
            }
            catch (OutOfMemoryException)
            {
                Console.Error.WriteLine("The file does not have a valid image format");
            }
        }

        //makes image negative
        public static void MakeNegative(string link, string imageName, string imagePath)
        {
            Console.WriteLine("This is negative method");

            Bitmap bimage = new Bitmap(link, true);

            //get image dimension
            int width = bimage.Width;
            int height = bimage.Height;

            int x, y;
            // Loop through the images pixels to reset color.
            for (x = 0; x < bimage.Width; x++)
            {
                for (y = 0; y < bimage.Height; y++)
                {
                    Color pixel = bimage.GetPixel(x, y);

                    //extract argb value from pixel
                    int a = pixel.A;
                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    //find negative value
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    //set new argb value in pixel
                    bimage.SetPixel(x, y, Color.FromArgb(a, r, g, b));     //img.SetPixel(x, y, newColor);
                }
            }//end of for

            SaveImage(bimage, "_negative", imageName, imagePath);
        }


        //saves bitmap into image file
        public static void SaveImage(Bitmap bimage, string conversionType, string name, string path)
        {
            if (bimage != null)
            {

                try
                {
                    //image.Save("c:\\negative.jpg");
                    //string link = "C:\\" + name + ".png";
                    //bimage.Save(link, System.Drawing.Imaging.ImageFormat.Png);
                    //bimage.Save("c:\\temp\\test.bmp");
                    ImageFormat imageFormat = bimage.RawFormat;
                    string imageName;
                    string newImagePath;
                   
                    if (bimage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg)) {
                        newImagePath = path + "\\" + name + conversionType + ".jpg";
                        imageName = name + conversionType + ".jpg";
                        Console.WriteLine("New image path is: " + newImagePath);
                    }
                    else {
                        newImagePath = path + "\\" + name + conversionType + ".png";
                        imageName = name + conversionType + ".png";
                        Console.WriteLine("New image path is: " + newImagePath);
                    }
                    
                    bimage.Save(imageName, ImageFormat.Png);

                }
                catch (Exception)
                {
                    Console.Error.WriteLine("There was a problem saving the negative image");
                }//end of try catch
            }
            else
            {
                Console.WriteLine("Image has not valid format");
            }//end of if else
            
        }//end of SaveIMage

    }//end of class
}//end of namespace