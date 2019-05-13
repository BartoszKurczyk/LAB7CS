using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LAB7
{
    class Program
    {
        static void Main(string[] args)
        {
            int width=0, height=0;
            string input=Environment.CurrentDirectory+"\\input.png", output= Environment.CurrentDirectory + "\\output.png";
            Console.WriteLine(input);
            foreach (var arg in args)
                {
                var opt = arg;
                if (opt.Contains("-res"))
                {
                    opt = opt.Replace("-res=", "");
                    //Console.WriteLine(opt);
                    var res = opt.Split('x');
                    width = Convert.ToInt32(res[0]);
                    height = Convert.ToInt32(res[1]);
                    Console.WriteLine(width);
                    Console.WriteLine(height);
                }
                if(opt.Contains("-input="))
                {
                    opt = opt.Replace("-input=", "");
                    input = opt;
                }
                if (opt.Contains("-output="))
                {
                    opt = opt.Replace("-output=", "");
                    output = opt;
                }

                //Console.WriteLine(width);
                //Console.WriteLine(height);
            }

            Size newSize = new Size(width,height);
            var img = Image.FromFile(input);
            Bitmap bm = (Bitmap)img;
            bm.SetResolution(10,10);
            bm.Save(output);
            img = ResizeImage(img, newSize);
            img.Save(output);
            //img.res
        }
        private static Image ResizeImage(Image image, Size newSize)
        {
            Image newImage = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics GFX = Graphics.FromImage((Bitmap)newImage))
            {
                GFX.DrawImage(image, new Rectangle(Point.Empty, newSize));
            }
            return newImage;
        }
    }
}
