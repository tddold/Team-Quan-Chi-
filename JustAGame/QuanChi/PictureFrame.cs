using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Draw(Position frameLeftTop, Position frameRightTop, Position frameRightBottom, Position frameLeftBottom)
        {
            for (int i = frameLeftTop.X; i < frameRightTop.Y; i++)
            {
                Console.Write(this.Wall);
            }

            for (int i = frameLeftTop.X; i < frameLeftBottom.X; i++)
            {
                Console.Write(this.Wall);
                Console.WriteLine();
            }
            for (int i = frameLeftBottom.Y; i <= frameRightBottom.Y; i++)
            {
                Console.Write(this.Wall);
            }

            for (int k = frameRightTop.X; k < frameRightBottom.X; k++)
            {
                Console.SetCursorPosition(frameRightTop.Y, k);
                Console.Write(this.Wall);
                Console.WriteLine();
            }
        }

    }
}
