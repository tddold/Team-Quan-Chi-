using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanChi
{
    class BadBoys
    {

        public BadBoys(char badBoy, Position posBadBoy)
        {
            this.BadBoyElement = badBoy;
            this.BadBoy = posBadBoy;
        }
        public char BadBoyElement
        {
            get;
            set;
        }


        public Position BadBoy
        {
            get;
            set;
        }

        public Position lastBadBoyElement
        {
            get;
            set;
        }


        public void DrawBadBoy()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(this.BadBoy.X, this.BadBoy.Y);
            Console.Write(this.BadBoyElement);
        }

        public void MoveBadBoysUpRight()
        {
            var newBadBoy = new Position(this.BadBoy.X + 1, this.BadBoy.Y - 1);
            RemoveLastBadBoyElements();
            this.BadBoy = newBadBoy;

        }

        public void MoveBadBoysUpLeft()
        {
            var newBadBoy = new Position(this.BadBoy.X - 1, this.BadBoy.Y - 1);
            RemoveLastBadBoyElements();
            this.BadBoy = newBadBoy;
        }

        public void MoveBadBoysDownRight()
        {
            var newBadBoy = new Position(this.BadBoy.X + 1, this.BadBoy.Y + 1);
            RemoveLastBadBoyElements();
            this.BadBoy = newBadBoy;

        }

        public void MoveBadBoysDownLeft()
        {
            var newBadBoy = new Position(this.BadBoy.X - 1, this.BadBoy.Y + 1);
            RemoveLastBadBoyElements();
            this.BadBoy = newBadBoy;

        }

        public void RemoveLastBadBoyElements()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(this.BadBoy.X, this.BadBoy.Y);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
