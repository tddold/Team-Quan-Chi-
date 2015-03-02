using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Constants

namespace QuanChi
{
    public static class Constants
    {
        public const char Wall = '\0';

        public const int PictureFrameHeight = 37;

        public const int PictureFrameWidth = 90;

        public const char SnakeElement = '\u263B';

        public const char BadBoyElement = '\u263A';

       
        public static char[,] Matrix = new char[Constants.PictureFrameHeight + 1, Constants.PictureFrameWidth + 1];

    }
}
