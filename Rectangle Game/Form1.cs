using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Rectangle_Game
{
    public partial class Form1 : Form
    {
        int score;
        Color backColor;
        RectangleItem[] obstacles = new RectangleItem[3]; // 0 - ground obstacle 1 - ground obstacle 2nd layer 2 - aerial obstacle
        Player player;
        Thunder[] thunders = new Thunder[2];
        int originalInterval;
        int intervalDivisions = 20;
        int lives;
        int invulnerability;

        int[] currentState = { 0, 0, 0 };
        //0 -> current action -> 0 (no action), 1 (low jump) and 2 (high jump)
        //1 -> current direction -> 1 (going down), 2 (standing in the air) and 3 (going up)
        //2 -> current position -> 0 to 5 -> 5 (finish point) and 0 (start point) -> low jump finish point = 2 and high jump finish point = 5

        public Form1()
        {
            InitializeComponent();
            lblCommands.Text = "Commands: \nKey Up = Low Jump\nSpace = High Jump\nKey Left = Go Left\nKey Right = Go Right";
            Settings.Height = gamePicBox.Height;
            Settings.Width = gamePicBox.Width;
            backColor = gamePicBox.BackColor;
            originalInterval = gameTimer.Interval;
        }
        
        private void StartGame(object sender, EventArgs e)
        {
            gameTimer.Interval = originalInterval;
            obstacles = new RectangleItem[3];
            thunders = new Thunder[2];
            int width = Settings.Width;
            string name = nameBox.Text;
            player = new Player(name, backColor);
            name = player.name;
            string color = player.color.ToString();
            setScore();
            setLives();
            resetCurrentState();
            gameTimer.Enabled = true;
            startBtn.Enabled = false;
            nameBox.Enabled = false;
            lives = 3;
            invulnerability = 0;
            score = 0;
        }
        private void setScore(Boolean gameOver=false)
        {
            if (gameOver)
            {
                lblTitleScore.Text = "Game is Over!!!";
                lblScore.Text = "Your score was: " + score;
            }
            else
            {
                lblTitleScore.Text = "Score";
                lblScore.Text = "" + score;
            }
        }
        private void setLives()
        {
            string livesLabelStr = "";
            for(int i = 0; i < lives; i++)
            {
                livesLabelStr += " ❤ ";
            }
            lblLives.Text = livesLabelStr;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (currentState[0] == 0)
            {
                if (e.KeyCode == Keys.Up){
                    currentState[0] = 1;
                    currentState[1] = 3;
                } else if(e.KeyCode == Keys.Space){
                    currentState[0] = 2;
                    currentState[1] = 3;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                player.X += 1;
            }
            else if (e.KeyCode == Keys.Left)
            {
                player.X -= 1;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            setScore();
            setLives();
            score += 1;
            if(score % (originalInterval/intervalDivisions) == 0)
            {
                int newInterval = gameTimer.Interval - (originalInterval/intervalDivisions);
                if((newInterval) > 100)
                {
                    gameTimer.Interval = newInterval;
                }
            }
            if (currentState[0] != 0)
            {
                manageCurrentState();
            }
            if(Settings.rnd.Next(1,4) == 1 && obstacles[0] == null)//ground obstacle
            {
                obstacles[0] = new RectangleItem(backColor, Settings.proportionY - 1);
                if(Settings.rnd.Next(1,3) == 1)
                {
                    obstacles[1] = new RectangleItem(backColor, Settings.proportionY - 2);
                } 
            }
            else if (obstacles[0] != null){
                moveObstacle(0);
                if (obstacles[1] != null)
                {
                    moveObstacle(1);
                } 
            }

            if(Settings.rnd.Next(1, 5) == 1 && obstacles[2] == null && score > 100)//aerial obstacle
            {
                obstacles[2] = new RectangleItem(backColor, Settings.rnd.Next(Settings.proportionY * 1/4, 6));
            }else if (obstacles[2] != null)
            {
                moveObstacle(2);
            }
            
            if(Settings.rnd.Next(1,9) == 1 && thunders[0] == null & score > 300)//thunder
            {
                if(thunders[1] == null){
                    thunders[0] = new Thunder();
                }
                else
                {
                    thunders[0] = new Thunder(randomThunderColumn(1));
                }
            }else if (thunders[0] != null)
            {
                if (thunders[0].finished)
                {
                    thunders[0] = null;
                }
                else
                {
                    thunders[0].run();
                }
            }

            if (Settings.rnd.Next(1, 13) == 1 && thunders[1] == null & score > 500)//thunder 2
            {
                if (thunders[0] == null)
                {
                    thunders[1] = new Thunder();
                }
                else
                {
                    thunders[1] = new Thunder(randomThunderColumn(0));
                }
            }
            else if (thunders[1] != null)
            {
                if (thunders[1].finished)
                {
                    thunders[1] = null;
                }
                else
                {
                    thunders[1].run();
                }
            }

            if (invulnerability != 0)
            {
                invulnerability -= 1;
                lblLives.ForeColor = lblLives.ForeColor == Color.Red ? Color.Yellow : Color.Red;
                lblLives.Font = lblLives.Font.Size == 18 ? new Font(lblLives.Font.FontFamily, 22) : new Font(lblLives.Font.FontFamily, 18);
            }
            else
            {
                if (collision())
                {
                    lives -= 1;
                    if (lives == 0)
                    {
                        setLives();
                        gameOver();
                    }
                    else { invulnerability = 12; }  
                }
            }
            gamePicBox.Invalidate();
        }
        private void moveObstacle(int numObstacle)
        {
            if (obstacles[numObstacle].X > 0)
            {
                obstacles[numObstacle].X -= 1;
            }
            else
            {
                obstacles[numObstacle] = null;
            }
        }
        private int randomThunderColumn(int thunderNum)
        {
            int column;
            do
            {
                column = Settings.rnd.Next(Settings.proportionX);
            } while (column == thunders[thunderNum].column);
            return column;
        }
        private void resetCurrentState()
        {
            for(int i = 0; i < currentState.Length; i++)
            {
                currentState[i] = 0;
            }
        }
        private void manageCurrentState()
        {
            if (currentState[1] == 3) // going up
            {
                currentState[2] += 1;
                player.Y -= 1;
                if ((currentState[0] == 1 && currentState[2] == 2) || currentState[2] == 5)
                {//(low jump) or (high jump)  at finish point
                    currentState[1] = 2;
                }
            } else if (currentState[1] == 2) //standing in the air
            {
                currentState[1] = 1; // set to go down
            } else if (currentState[1] == 1)
            {
                currentState[2] -= 1;
                player.Y += 1;
                if (currentState[2] == 0)//jump finished
                {
                    resetCurrentState();//reset
                }
            }
        }
        private Boolean collision()
        {
            foreach (RectangleItem obstacle in obstacles)
            {
                if (obstacle != null && player.X == obstacle.X && player.Y == obstacle.Y)
                {
                    return true;
                }
            }
            foreach (Thunder thunder in thunders)
            {
                for (int i = 0; i < (thunder != null && thunder.thunderBody != null ? thunder.thunderBody.Length : 0); i++)
                {
                    RectangleItem rectangle = thunder.thunderBody[i];
                    if (rectangle != null)
                    {
                        if (player.X == rectangle.X && player.Y == rectangle.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void PaintPictureBox(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            //RectangleItem is a class of this program, this Rectangle class below is another class that has nothing to do
            if(player != null)
            {
                canvas.FillRectangle(convertColor(player.color), new Rectangle(
                        player.X * Settings.Width,
                        player.Y * Settings.Height,
                        Settings.Width, Settings.Height
                ));
            }
            foreach(RectangleItem obstacle in obstacles)
            {
                if(obstacle != null)
                {
                        canvas.FillRectangle(convertColor(obstacle.color), new Rectangle(
                                obstacle.X * Settings.Width,
                                obstacle.Y * Settings.Height,
                                Settings.Width, Settings.Height
                        ));
                }
            }
            foreach(Thunder thunder in thunders)
            {
                if (thunder != null)
                {
                    if (thunder.apparition)
                    {
                        foreach (RectangleItem rectangle in thunder.apparitionBody)
                        {
                            canvas.FillRectangle(convertColor(rectangle.color), new Rectangle(
                                    rectangle.X * Settings.Width,
                                    rectangle.Y * Settings.Height,
                                    Settings.Width, Settings.Height
                            ));
                        }
                    }
                    else
                    {
                        if (thunder.thunderBody != null)
                        {
                            for (int i = 0; i < thunder.thunderBody.Length; i++)
                            {
                                RectangleItem rectangle = thunder.thunderBody[i];
                                if (rectangle != null)
                                {
                                    canvas.FillRectangle(convertColor(rectangle.color), new Rectangle(
                                            rectangle.X * Settings.Width,
                                            rectangle.Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                    ));
                                }
                            }
                        }
                    }
                }
            }
        }
        private SolidBrush convertColor(Color color)
        {
            //Thanks: https://stackoverflow.com/questions/5734763/system-drawing-brush-from-system-drawing-color
            SolidBrush brush = new SolidBrush(color);
            return brush;
        }

        private void gameOver()
        {
            gameTimer.Enabled = false;
            startBtn.Enabled = true;
            nameBox.Text = "";
            nameBox.Enabled = true;
            setScore(true);
            player.recordPerformanceAsync(score);
        }
    }
}