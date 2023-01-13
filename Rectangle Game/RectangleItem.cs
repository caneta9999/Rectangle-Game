using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Game
{
    class RectangleItem
    {
        public readonly Color color;
        public int y;
        public int x;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value <= (Settings.Height * (Settings.proportionY-2)) && value >= 0)
                {
                    y = value;
                }
            }
        }
        public int X
        {
            get
            {
                return x;
            } 
            set
            {
                if (value < Settings.proportionX && value >= 0)
                {
                    x = value;
                }
            }
        }
        public RectangleItem(Color backColor, int y, int x=-1)//made to create the obstacles
        {
            Color randomColor;
            do
            {
                randomColor = Color.FromKnownColor(Settings.colors[Settings.rnd.Next(Settings.colors.Length)]);
            } while (randomColor == backColor);
            this.color = randomColor;
            if(x == -1)
            {
                x = Settings.proportionX - 1;
            }
            this.X = x;
            this.Y = y;
        }
        public RectangleItem(Color backColor) //made to be inherited by player class
        {
            Color randomColor;
            do
            {
                randomColor = Color.FromKnownColor(Settings.colors[Settings.rnd.Next(Settings.colors.Length)]);
            } while (randomColor == backColor);
            this.color = randomColor;
            this.X = 1;
            this.Y = Settings.proportionY - 1;
        }
        public RectangleItem(int type=1, int x=0, int y=0) //made to be used by thunder class
        {
            Color color = type == 1 ? Color.Yellow : Color.LightBlue;
            this.color = color;
            this.X = x;
            this.Y = y;
        }

        public object Clone()
        {
            //https://stackoverflow.com/questions/47806133/how-to-copy-a-class-object-in-c-sharp
            return this.MemberwiseClone();
        }

    }
}
