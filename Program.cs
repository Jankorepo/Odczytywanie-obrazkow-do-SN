using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<InputsAndOutputs> celnosc = new List<InputsAndOutputs>();
            List<InputsAndOutputs> predkosc = new List<InputsAndOutputs>();
            List<InputsAndOutputs> regeneracja = new List<InputsAndOutputs>();
            List<InputsAndOutputs> wytrzymalosc = new List<InputsAndOutputs>();
            List<InputsAndOutputs> ogien = new List<InputsAndOutputs>();
            List<InputsAndOutputs> powietrze = new List<InputsAndOutputs>();
            List<InputsAndOutputs> woda = new List<InputsAndOutputs>();
            List<InputsAndOutputs> ziemia = new List<InputsAndOutputs>();


            DirectoryInfo dir = new DirectoryInfo("Narysowane znaki16, Przemek");
            foreach (var item in dir.GetFiles())
            {
                if (!item.Name.Contains("json"))
                {
                    Bitmap myBitmap = new Bitmap(Image.FromFile(dir.Name + "/" + item.Name));
                    List<double> input = ChangeBitMapToList(myBitmap);
                    if (item.Name.Contains("celn"))
                        celnosc.Add(new InputsAndOutputs(input, new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0 }));
                    else if (item.Name.Contains("dko"))
                        predkosc.Add(new InputsAndOutputs(input, new List<int>() { 0, 1, 0, 0, 0, 0, 0, 0 }));
                    else if (item.Name.Contains("regen"))
                        regeneracja.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 1, 0, 0, 0, 0, 0 }));
                    else if (item.Name.Contains("wytrz"))
                        wytrzymalosc.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 0, 1, 0, 0, 0, 0 }));
                    else if (item.Name.Contains("gie"))
                        ogien.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 0, 0, 1, 0, 0, 0 }));
                    else if (item.Name.Contains("owiet"))
                        powietrze.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 0, 0, 0, 1, 0, 0 }));
                    else if (item.Name.Contains("oda"))
                        woda.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 0, 0, 0, 0, 1, 0 }));
                    else if (item.Name.Contains("iem"))
                        ziemia.Add(new InputsAndOutputs(input, new List<int>() { 0, 0, 0, 0, 0, 0, 0, 1 }));
                }
            }



            List<InputsAndOutputs> list2 = new List<InputsAndOutputs>();

            list2.AddRange(celnosc);
            list2.AddRange(predkosc);
            list2.AddRange(regeneracja);
            list2.AddRange(wytrzymalosc);
            list2.AddRange(ogien);
            list2.AddRange(powietrze);
            list2.AddRange(woda);
            list2.AddRange(ziemia);
            File.WriteAllText(@"Zapisane znaki.json", JsonConvert.SerializeObject(list2));
        }
        public static List<double> ChangeBitMapToList(Bitmap bitmap)
        {
            var imageAsList = new List<double>();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var xx = Convert.ToDouble(bitmap.GetPixel(x,y).A);
                    if (xx>40)
                        imageAsList.Add(0);
                    else if (xx<=40)
                        imageAsList.Add(1);
                }
            }
            return imageAsList;
        }
        //public static Bitmap ChangeListsToBitmap(List<List<double>> image)
        //{
        //    var bitmap = new Bitmap(image[0].Count, image.Count);
        //    for (int y = 0; y < bitmap.Height; y++)
        //    {
        //        for (int x = 0; x < bitmap.Width; x++)
        //        {
        //            int value = Convert.ToInt32(image[y][x] * 255);
        //            bitmap.SetPixel(x,y, Color.FromArgb(255, value, value, value));
        //        }
        //    }
        //    return bitmap;
        //}
        //public static List<List<double>> Swap1DListTo2DList(List<double> array)
        //{
        //    List<List<double>> image2D = new List<List<double>>();
        //    for (int i = 0; i < array.Count /24; i ++)
        //    {
        //        image2D.Add(new List<double>());
        //        for (int j = 0; j < 24; j++)
        //        {
        //            image2D.Last().Add(array[(i*24) + j]);
        //        }
        //    }
        //    return image2D;
        //}
    }
}
