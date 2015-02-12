using System;
using System.Threading;
namespace QuanChi
{
    class QuanChi
    {
        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                  Console.WriteLine();
            }
            
            Console.BufferHeight = Console.WindowHeight = 80;
            Console.BufferWidth = Console.WindowWidth = 60;
           
          
            Console.Write(String.Format("\t --------QUAN Chi REVALATION ------"));
            for (int i = 0; i <10; i++)
            {
                Console.WriteLine();    
            }
           
            //Description of the game ruols
        
            Console.Write("\tTHE GAME HAS THE FALOWING ROULS");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("\t"+@"DISPLAING PICTURE IN A FRAME USING SNAKE ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("\tPLEASE CHOSE ONE OF THE 5 PICTURES BELOW");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("\t\t{0,10}", "1: PICTURE ");
            Console.WriteLine();
            Console.WriteLine("\t\t{0,10}", "2: PICTURE  ");
            Console.WriteLine();
            Console.WriteLine("\t\t{0,10}", "3: PICTURE  ");
            Console.WriteLine();
            Console.WriteLine("\t\t{0,10}", "4: PICTURE ");
            Console.WriteLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":

                    Console.Clear();
                    string pathPicture1 = @"";

                    StartTheGame();
                    break;
                case "2":

                    Console.Clear();
                    string pathPicture2 = @"";

                    StartTheGame();
                    break;
                case "3":

                    Console.Clear();
                    string pathPicture3 = @"";

                    StartTheGame();
                    break;
                case "4":

                    Console.Clear();
                    string pathPicture4 = @"";

                    StartTheGame();
                    break;
                case "5":

                    Console.Clear();
                    string pathPicture5 = @"";

                    StartTheGame();
                    break;
            }



        }

        private static void StartTheGame()
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