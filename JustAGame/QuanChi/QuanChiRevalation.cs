using System;
using System.Threading;
using System.Media;
using System.Collections.Generic;
using System.Linq;

namespace QuanChi
{
	class QuanChi
	{
		static void Main()
		{
			////MUUUUUUUSIC
			System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.Azureflux___05___Wake_The_Fuck_Up);
			sp.PlayLooping();
			// Console.BackgroundColor = ConsoleColor.Black;


			for (int i = 0; i < 8; i++)
			{
				Console.WriteLine();
			}


			Console.WriteLine(@"        
				 ░░╦ ╦╔╗╦ ╔╗╔╗╔╦╗╔╗░░
				 ░░║║║╠ ║ ║ ║║║║║╠ ░░
				 ░░╚╩╝╚╝╚╝╚╝╚╝╩ ╩╚╝░░");
			Console.BufferHeight = Console.WindowHeight = 40;
			Console.BufferWidth = Console.WindowWidth = 120;


			Console.Write(String.Format("\t\t\t\t\t --------QUAN Chi REVALATION ------"));
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine();
			}

			//Description of the game rules

			Console.Write("\t\t\t\t\tTHE GAME HAS THE FOLLOWING RULES");
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine();
			}

			Console.WriteLine("\t\t\t\t\t" + @"DISPLAING PICTURE IN A FRAME USING SNAKE ");
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine();
			}

			Console.WriteLine("\t\t\t\t\tPLEASE CHOSE ONE OF THE 5 PICTURES BELOW");
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine();
			}
			Console.WriteLine("\t\t\t\t\t\t{0,10}", "1: PICTURE ");
			Console.WriteLine();
			Console.WriteLine("\t\t\t\t\t\t{0,10}", "2: PICTURE  ");
			Console.WriteLine();
			Console.WriteLine("\t\t\t\t\t\t{0,10}", "3: PICTURE  ");
			Console.WriteLine();
			Console.WriteLine("\t\t\t\t\t\t{0,10}", "4: PICTURE ");
			Console.WriteLine();
			Console.WriteLine("\t\t{0,10}", "5: PICTURE ");
			Console.WriteLine();
			Console.WriteLine("\t\t{0,10}", "5: PICTURE ");
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
			Console.BufferHeight = Console.WindowHeight = 40;
			Console.BufferWidth = Console.WindowWidth = 100;

			PictureFrame pictureFrame = new PictureFrame(Constants.Wall, Constants.PictureFrameWidth, Constants.PictureFrameHeight);

			Position frameLeftTop = new Position(0, 0);
			Position frameRightTop = new Position(0, pictureFrame.Width);
			Position frameRightBottom = new Position(pictureFrame.Hight, pictureFrame.Width);
			Position frameLeftBottom = new Position(pictureFrame.Hight, 0);

			pictureFrame.Draw(frameLeftTop, frameRightTop, frameRightBottom, frameLeftBottom);

			//Random randomGenerator = new Random();
			Snake snake = new Snake(Constants.SnakeElement, new Position(0, 10));
			BadBoys badBoy = new BadBoys(Constants.BadBoyElement, new Position(10, 20));
			string direction = String.Empty;
			string directionBadBoy = "down-left";
			bool onFrame = true;

			while (true)
			{
				directionBadBoy = ChangeBadBoyDirection(badBoy, directionBadBoy, snake);
				MoveBadBoy(badBoy, directionBadBoy);
				badBoy.DrawBadBoy();

				bool lastOnFrame = onFrame;
				onFrame = CheckIfOnField(snake);

				if (onFrame)
				{
					snake.DrawOnFrame();
					snake.ResetBody();
				}
				else
				{
					snake.DrawOnField();
				}

				if (!lastOnFrame && onFrame)
				{
					var badBoys = new List<BadBoys>() { badBoy };
					FillFieldDFS(badBoys);
				}

				// move without press the boton
				if (!onFrame)
				{
					if (direction == "up")
					{
						snake.MoveSnakeUp();
					}
					else if (direction == "down")
					{
						snake.MoveSnakeDown();
					}
					else if (direction == "left")
					{
						snake.MoveSnakeLeft();
					}
					else if (direction == "right")
					{
						snake.MoveSnakeRight();
					}
				}


				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.UpArrow && (direction != "down" || onFrame))
					{
						direction = "up";
						if (onFrame)
						{
							snake.MoveSnakeUp();
						}
					}
					else if (keyInfo.Key == ConsoleKey.DownArrow && (direction != "up" || onFrame))
					{
						direction = "down";
						if (onFrame)
						{
							snake.MoveSnakeDown();
						}
					}
					else if (keyInfo.Key == ConsoleKey.RightArrow && (direction != "left" || onFrame))
					{
						direction = "right";
						if (onFrame)
						{
							snake.MoveSnakeRight();
						}
					}
					else if (keyInfo.Key == ConsoleKey.LeftArrow && (direction != "right" || onFrame))
					{
						direction = "left";
						if (onFrame)
						{
							snake.MoveSnakeLeft();
						}
					}
				}

				Thread.Sleep(50);
			}
		}

		private static void FillFieldDFS(List<BadBoys> badBoys)
		{
			var visited = new bool[Constants.Matrix.GetLength(0), Constants.Matrix.GetLength(1)];
			for (int i = 0; i < badBoys.Count; i++)
			{
				RunDfs(badBoys[i].BadBoy, visited);
			}

			Console.BackgroundColor = ConsoleColor.Yellow;

			for (int row = 1; row < visited.GetLength(0) - 1; row++)
			{
				for (int col = 1; col < visited.GetLength(1) - 1; col++)
				{
					if (!visited[row, col])
					{
						Constants.Matrix[row, col] = '@';
						Console.SetCursorPosition(col, row);
						Console.Write(" ");
					}
				}
			}

			Console.BackgroundColor = ConsoleColor.Black;
		}

		private static void RunDfs(Position cell, bool[,] visited)
		{
			if (!CheckValidCell(cell) || Constants.Matrix[cell.Y, cell.X] == '@')
			{
				return;
			}

			visited[cell.Y, cell.X] = true;

			if (!visited[cell.Y, cell.X + 1])
			{
				RunDfs(new Position(cell.X + 1, cell.Y), visited);
			}
			if (!visited[cell.Y, cell.X - 1])
			{
				RunDfs(new Position(cell.X - 1, cell.Y), visited);
			}
			if (!visited[cell.Y + 1, cell.X])
			{
				RunDfs(new Position(cell.X, cell.Y + 1), visited);

			}
			if (!visited[cell.Y - 1, cell.X])
			{
				RunDfs(new Position(cell.X, cell.Y - 1), visited);

			}

		}

		private static bool CheckValidCell(Position cell)
		{
			if (cell.Y >= 1 && cell.Y < Constants.PictureFrameHeight && cell.X >= 1 && cell.X < Constants.PictureFrameWidth)
			{
				return true;
			}

			return false;
		}

		private static void MoveBadBoy(BadBoys badBoy, string directionBadBoy)
		{
			switch (directionBadBoy)
			{
				case "up-right":
					badBoy.MoveBadBoysUpRight();
					break;
				case "up-left":
					badBoy.MoveBadBoysUpLeft();
					break;
				case "down-left":
					badBoy.MoveBadBoysDownLeft();
					break;
				case "down-right":
					badBoy.MoveBadBoysDownRight();
					break;
				default:
					break;
			}
		}

		private static bool CheckIfOnField(Snake snake)
		{
			bool onFrame = false;
			if (snake.Head.X == 0 || snake.Head.Y == 0 || snake.Head.X == Constants.PictureFrameWidth || snake.Head.Y == Constants.PictureFrameHeight)
			{
				onFrame = true;
			}

			if (Constants.Matrix[snake.Head.Y, snake.Head.X] == '@')
			{
				onFrame = true;
			}

			if (snake.Body != null && snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y && b != snake.Head))
			{
				throw new ArgumentException();
			}

			return onFrame;
		}

		static string ChangeBadBoyDirection(BadBoys badBoy, string directionBadBoy, Snake snake)
		{
			var badBoyPos = badBoy.BadBoy;

			if (directionBadBoy == "up-right")
			{

				if (snake.Body.Any(b => b.X == badBoyPos.X + 1 && b.Y == badBoyPos.Y - 1))
				{
					// Game over!!!
					throw new ArgumentException();
				}

				// check is the Bad Boy is in the body and change direction
				if (Constants.Matrix[badBoyPos.Y - 1, badBoyPos.X] == '@')
				{
					directionBadBoy = "down-right";
				}
				else if (Constants.Matrix[badBoyPos.Y, badBoyPos.X + 1] == '@')
				{
					directionBadBoy = "up-left";
				}

				// change direction when is in the frame
				if (badBoy.BadBoy.Y < 2)
				{
					directionBadBoy = "down-right";

				}
				else if (badBoy.BadBoy.X >= Constants.PictureFrameWidth - 2)
				{
					directionBadBoy = "up-left";

				}
			}
			else if (directionBadBoy == "up-left")
			{
				if (snake.Body.Any(b => b.X == badBoyPos.X - 1 && b.Y == badBoyPos.Y - 1))
				{
					// Game over!!!
					throw new ArgumentException();
				}

				// check is the Bad Boy is in the body and change direction
				if (Constants.Matrix[badBoyPos.Y - 1, badBoyPos.X] == '@')
				{
					directionBadBoy = "down-left";
				}
				else if (Constants.Matrix[badBoyPos.Y, badBoyPos.X - 1] == '@')
				{
					directionBadBoy = "up-right";
				}

				// change direction when is in the frame
				if (badBoy.BadBoy.Y < 2)
				{
					directionBadBoy = "down-left";

				}
				else if (badBoy.BadBoy.X < 2)
				{
					directionBadBoy = "up-right";

				}
			}
			else if (directionBadBoy == "down-left")
			{
				if (snake.Body.Any(b => b.X == badBoyPos.X - 1 && b.Y == badBoyPos.Y + 1))
				{
					// Game over!!!
					throw new ArgumentException();
				}

				// check is the Bad Boy is in the body and change direction
				if (Constants.Matrix[badBoyPos.Y + 1, badBoyPos.X] == '@')
				{
					directionBadBoy = "up-left";
				}
				else if (Constants.Matrix[badBoyPos.Y, badBoyPos.X - 1] == '@')
				{
					directionBadBoy = "down-right";
				}

				// change direction when is in the frame
				if (badBoy.BadBoy.Y >= Constants.PictureFrameHeight - 1)
				{
					directionBadBoy = "up-left";

				}
				else if (badBoy.BadBoy.X < 2)
				{
					directionBadBoy = "down-right";

				}
			}
			else if (directionBadBoy == "down-right")
			{
				if (snake.Body.Any(b => b.X == badBoyPos.X + 1 && b.Y == badBoyPos.Y + 1))
				{
					// Game over!!!
					throw new ArgumentException();
				}

				// check is the Bad Boy is in the body and change direction
				if (Constants.Matrix[badBoyPos.Y + 1, badBoyPos.X] == '@')
				{
					directionBadBoy = "up-right";
				}
				else if (Constants.Matrix[badBoyPos.Y, badBoyPos.X + 1] == '@')
				{
					directionBadBoy = "down-left";
				}

				// change direction when is in the frame
				if (badBoy.BadBoy.Y >= Constants.PictureFrameHeight - 1)
				{
					directionBadBoy = "up-right";

				}
				else if (badBoy.BadBoy.X > Constants.PictureFrameWidth - 2)
				{
					directionBadBoy = "down-left";
				}
			}

			return directionBadBoy;
		}
	}
}