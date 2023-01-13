using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Game
{
    class Player : RectangleItem
    {
        public readonly DateTime date;
        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Player(string name, Color backColor) : base(backColor)
        {
            this.Name = name;
            this.date = DateTime.Now;
        }
        public void recordPerformanceAsync(int score)
        {
            string read = "";
            string fileName = "recordPerfomance.txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName)) ////https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files
                {
                    read = reader.ReadToEnd();
                }
            }
            catch { }
            string divider = "----------------------------------------\n";
            string text = divider;
            text += Name + "\n";
            text += date + "\n";
            text += score + "\n";
            text += divider;
            using (StreamWriter writer = new StreamWriter(fileName)) 
            {
                writer.WriteLine(read + text);
            }
        }
    }
}
