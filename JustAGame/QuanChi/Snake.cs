using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanChi
{
    public class Snake
    {
        public Snake(char snakeElement, Position head)
        {
            this.SnakeElement = snakeElement;
            this.Head = head;
            this.Body = new List<Position>();
            this.Body.Add(head);
        }

        public char SnakeElement
        {
            get;
            set;
        }

        public List<Position> Body
        {
            get;
            set;
        }

        public Position Head
        {
            get;
            set;
        }

        public Position LastHead
        {
            get;
            set;
        }

        public void ResetBody()
        {
            this.Body = new List<Position>();
        }

        public void DrawOnField()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(this.Head.X, this.Head.Y);
            Constants.Matrix[Console.CursorTop, Console.CursorLeft] = '@';
            Console.Write(this.SnakeElement);

            if (this.LastHead != null)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(this.LastHead.X, this.LastHead.Y);
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = '@';
                Console.Write(" ");   
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void DrawOnFrame()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(this.Head.X, this.Head.Y);
            // Constants.Matrix[Console.CursorTop, Console.CursorLeft] = this.SnakeElement;
            Console.Write(this.SnakeElement);

            if (this.LastHead != null)
            {
                Console.SetCursorPosition(this.LastHead.X, this.LastHead.Y);
                Constants.Matrix[Console.CursorTop, Console.CursorLeft] = '@';
                Console.Write(Constants.Wall);
            }

            Console.BackgroundColor = ConsoleColor.Black;

        }

        public void MoveSnakeUp()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X, this.Head.Y - 1);
            if (newHead.Y < 0)
            {
                return;
            }

            this.LastHead = this.Head;
            this.Body.Add(newHead);
            this.Head = newHead;
        }

        public void MoveSnakeDown()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X, this.Head.Y + 1);
            if (newHead.Y > Constants.PictureFrameHeight)
            {
                return;
            }

            this.LastHead = this.Head;
            this.Body.Add(newHead);
            this.Head = newHead;
        }

        public void MoveSnakeLeft()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X - 1, this.Head.Y);
            if (newHead.X < 0)
            {
                return;
            }

            this.LastHead = this.Head;
            this.Body.Add(newHead);
            this.Head = newHead;
        }

        public void MoveSnakeRight()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X + 1, this.Head.Y);
            if (newHead.X > Constants.PictureFrameWidth)
            {
                return;
            }

            this.LastHead = this.Head;
            this.Body.Add(newHead);
            this.Head = newHead;

        }
    }
}
