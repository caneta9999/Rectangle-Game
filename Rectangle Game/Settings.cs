using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Game
{
    public static class Settings
    {
        public readonly static Random rnd = new Random();
        public readonly static int proportionX = 10;
        public readonly static int proportionY = 8;
        private static int width;
        private static int height;
        public static int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value / proportionX;
            }
        }
        public static int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value / proportionY;
            }
        }

        public static KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
    }
}
