using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
namespace QuanChi
{
    public class PictureFrame
    {
        public char Wall;
        public int Width;
        public int Hight;

        public PictureFrame(char wall, int width, int hight)
        {
            this.Wall = wall;
            this.Hight = hight;
            this.Width = width;
        }
        //Geting the picture
        public void PictureDraw(string imagePath)
        {
            Image Picture = Image.FromFile(imagePath);
            Console.SetBufferSize((Picture.Width * 0x2), (Picture.Height * 0x2));
            FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
            int FrameCount = Picture.GetFrameCount(Dimension);
            int Left = Console.WindowLeft, Top = Console.WindowTop;
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            Picture.SelectActiveFrame(Dimension, 0x0);
            for (int i = 0x0; i < Picture.Height; i++)
            {
                for (int x = 0x0; x < Picture.Width; x++)
                {
                    Color Color = ((Bitmap)Picture).GetPixel(x, i);
                    int Gray = (Color.R + Color.G + Color.B) / 0x3;
                    int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
            }
            Console.SetCursorPosition(Left, Top);
            Console.Read();
        }
        public void Draw(Position frameLeftTop, Position frameRightTop, Position frameRightBottom, Position frameLeftBottom)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = frameLeftTop.X; i < frameRightTop.Y; i++)
            {
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = this.Wall;

                Console.Write(this.Wall);
            }

            for (int i = frameLeftTop.X; i < frameLeftBottom.X; i++)
            {
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = this.Wall;
                Console.Write(this.Wall);
                Console.WriteLine();
            }
            for (int i = frameLeftBottom.Y; i <= frameRightBottom.Y; i++)
            {
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = this.Wall;
                Console.Write(this.Wall);
            }

            for (int k = frameRightTop.X; k < frameRightBottom.X; k++)
            {
                Console.SetCursorPosition(frameRightTop.Y, k);
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = this.Wall;
                Console.Write(this.Wall);
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
