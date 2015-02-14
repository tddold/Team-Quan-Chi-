using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanChi
{
    public static class Constants
    {
        public const char Wall = '*';

        public const int PictureFrameHeight = 37;

        public const int PictureFrameWidth = 90;

        public const char SnakeElement = '\u263B';

        public static char[,] Matrix = new char[Constants.PictureFrameHeight + 1, Constants.PictureFrameWidth + 1];

    }
}
