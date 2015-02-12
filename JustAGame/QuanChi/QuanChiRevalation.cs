using System;
using System.Threading;

namespace QuanChi
{
    class QuanChi
    {
        static void Main()
        {
            // Console.WindowHeight = 100;
            Console.BufferHeight = Console.WindowHeight = 120;
            Console.BufferWidth = Console.WindowWidth = 90;

            PictureFrame pictureFrame = new PictureFrame(Constants.Wall, Constants.PictureFrameWidth, Constants.PictureFrameHeight);

            Position frameLeftTop = new Position(0, 0);
            Position frameRightTop = new Position(0, pictureFrame.Width);
            Position frameRightBottom = new Position(pictureFrame.Hight, pictureFrame.Width);
            Position frameLeftBottom = new Position(pictureFrame.Hight, 0);

            pictureFrame.Draw(frameLeftTop, frameRightTop, frameRightBottom, frameLeftBottom);

            Snake snake = new Snake(Constants.SnakeElement, new Position(40, 20));

            while (true)
            {
                snake.Draw();                

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    snake.MoveSnakeUp();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    snake.MoveSnakeDown();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    snake.MoveSnakeRight();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    snake.MoveSnakeLeft();
                }

                //TODO: check if snake is in wall
                if (false)
                {
                    //TODO: check if picture should be shown (Using DFS or BFS)
                    if (false)
                    {
                        RecursivelyShowPictureSpace();
                    }
                }
            }

        }

        private static void RecursivelyShowPictureSpace()
        {
            throw new NotImplementedException();
        }
    }
}