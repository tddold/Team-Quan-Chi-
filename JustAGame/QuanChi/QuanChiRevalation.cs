using System;

class QuanChi
{
    struct GameFrame
    {
        public char Wall;
        public int Width;
        public int Hight;
        public GameFrame(char wall, int width, int hight, Position position)
        {
            this.Wall = wall;
            this.Hight = hight;
            this.Width = width;
        }
    }
    struct Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    static void Main()
    {
        //
        // Console.WindowHeight = 100;

        Console.BufferHeight = Console.WindowHeight = 120;
        Console.BufferWidth = Console.WindowWidth = 90;
        GameFrame pictureFrame = new GameFrame();

        pictureFrame.Wall = '*';
        pictureFrame.Hight = 100;
        pictureFrame.Width = 80;

        Position pictureFrameLeftTop = new Position();
        pictureFrameLeftTop.X = 0;
        pictureFrameLeftTop.Y = 0;

        Position pictFrameRight = new Position();
        pictFrameRight.X = 0;
        pictFrameRight.Y = pictureFrame.Width;

        Position pictRightBotom = new Position();
        pictRightBotom.X = pictureFrame.Hight;
        pictRightBotom.Y = pictureFrame.Width;

        Position pictleftBotom = new Position();

        pictleftBotom.X = pictureFrame.Hight;
        pictleftBotom.Y = 0;

        for (int i = pictureFrameLeftTop.X; i < pictFrameRight.Y; i++)
        {
            Console.Write(pictureFrame.Wall);
        }

        for (int i = pictureFrameLeftTop.X; i < pictleftBotom.X; i++)
        {
            Console.Write(pictureFrame.Wall);
            Console.WriteLine();
        }
        for (int i = pictleftBotom.Y; i <= pictRightBotom.Y; i++)
        {
            Console.Write(pictureFrame.Wall);
        }

        for (int k = pictFrameRight.X; k < pictRightBotom.X; k++)
        {
            Console.SetCursorPosition(pictFrameRight.Y,k );
            Console.Write(pictureFrame.Wall);
            Console.WriteLine();
        }

        while (true)
        {
            // Console.Clear();

        }


    }
}
