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

        public void Draw()
        {
            for (int i = 0; i < this.Body.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(this.Body[i].X, this.Body[i].Y);
                Console.Write(this.SnakeElement);
            }
        }

        public void MoveSnakeUp()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X, this.Head.Y - 1);
            this.Body.Add(newHead);
            this.Head = newHead;
            if (newHead.Y < 0)
            {
                newHead.Y = 0;
                return;
            }
        }

        public void MoveSnakeDown()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X, this.Head.Y + 1);
            this.Body.Add(newHead);
            this.Head = newHead;

            if (newHead.Y > Constants.PictureFrameHeight)
            {
                newHead.Y = Constants.PictureFrameHeight;
                return;
            }
        }

        public void MoveSnakeLeft()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X - 1, this.Head.Y);
            this.Body.Add(newHead);
            this.Head = newHead;

            if (newHead.X < 0)
            {
                newHead.X = 0;
                return;
            }
        }

        public void MoveSnakeRight()
        {
            //TODO: Check if moving out of console
            var newHead = new Position(this.Head.X + 1, this.Head.Y);
            this.Body.Add(newHead);
            this.Head = newHead;

            if (newHead.X > Constants.PictureFrameWidth)
            {
                newHead.X = Constants.PictureFrameWidth;
            }
        }
    }
}
