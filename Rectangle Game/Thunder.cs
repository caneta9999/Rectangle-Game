using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Game
{
    class Thunder
    {
        public readonly int type;//1(slow) or 2(fast)
        public Boolean apparition; //Thunder appears first in the sky
        private int apparitionTime;
        private int thunderTime;
        public Boolean finished;
        public RectangleItem[] apparitionBody;
        public RectangleItem[] thunderBody;
        public readonly int column;
        public Thunder(int column=-1)
        {
            this.type = Settings.rnd.Next(1,3);
            this.apparition = true;
            this.finished = false;
            if (column == -1)
                this.column = Settings.rnd.Next(Settings.proportionX);
            else
                this.column = column;
            this.apparitionTime = Settings.rnd.Next(2,5);
            this.apparitionBody = new RectangleItem[2];
            this.apparitionBody[0] = new RectangleItem(this.type, this.column, 0);
            this.apparitionBody[1] = new RectangleItem(this.type, this.column, 1);
            this.thunderBody = new RectangleItem[Settings.proportionY - Settings.proportionY * 1 / 4];
        }
        public void run()
        {
            if (this.apparition)
            {
                runApparition();
            }
            else
            {
                runThunder();
            }
        }
        private void runApparition()
        {
            if(this.apparitionTime > 0)
            {
                this.apparitionTime -= 1;
            }
            else
            {
                this.apparition = false;
                this.apparitionBody = null;
            }
        }
        private void runThunder()
        {
            if(type == 2)
            {
                if(this.thunderBody[0] == null)
                {
                    for(int i = 0; i < thunderBody.Length ; i++)
                    {
                        this.thunderBody[i] = new RectangleItem(this.type, column, 2 + i);
                        thunderTime = 2;
                    }
                }
                else if(thunderTime == 0)
                {
                    this.thunderBody = null;
                    this.finished = true;
                }
                else if(thunderTime > 0)
                {
                    thunderTime -= 1;
                }
            }else if(type == 1)
            {
                if(!finished && thunderBody[0] == null && thunderBody[thunderBody.Length - 1] == null) {
                    thunderBody[0] = new RectangleItem(this.type, column, 2);
                }
                else
                {
                    if (thunderBody[thunderBody.Length - 1] == null)
                    {
                        if (thunderBody[0] == null)
                        {
                            thunderBody[0] = new RectangleItem(this.type, column, 2);
                        }
                    }
                    Boolean descent = thunderBody[0] != null && thunderBody[thunderBody.Length - 1] != null;
                    
                    for (int i = (thunderBody != null? thunderBody.Length - 1 : 0); i > 0; i--)
                    {
                        if (thunderBody[i-1] != null && !descent)
                        {
                            thunderBody[i] = (RectangleItem)thunderBody[i - 1].Clone();
                            thunderBody[i].Y += 1;
                        } else
                        {
                            if (descent)
                            {
                                thunderBody[0] = null;
                            }
                            else
                            {
                                thunderBody[i] = null;
                            }
                        }
                        if(thunderBody[0] == null && thunderBody[thunderBody.Length - 1] == null)
                        {
                            this.finished = true;
                            this.thunderBody = null;
                            break;
                        }
                    }
                }
            }

        }
    }
}
