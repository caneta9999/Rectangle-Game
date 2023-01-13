namespace Rectangle_Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gamePicBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.lblCommands = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLives = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitleScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePicBox
            // 
            this.gamePicBox.BackColor = System.Drawing.Color.Gainsboro;
            this.gamePicBox.Location = new System.Drawing.Point(12, 124);
            this.gamePicBox.Name = "gamePicBox";
            this.gamePicBox.Size = new System.Drawing.Size(960, 160);
            this.gamePicBox.TabIndex = 0;
            this.gamePicBox.TabStop = false;
            this.gamePicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintPictureBox);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(80, 26);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 23);
            this.nameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(32, 76);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(148, 23);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartGame);
            // 
            // lblCommands
            // 
            this.lblCommands.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCommands.Location = new System.Drawing.Point(746, 11);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(180, 103);
            this.lblCommands.TabIndex = 4;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScore.Location = new System.Drawing.Point(549, 29);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(180, 85);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = " ";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 400;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // lblLives
            // 
            this.lblLives.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLives.ForeColor = System.Drawing.Color.Red;
            this.lblLives.Location = new System.Drawing.Point(270, 76);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(258, 38);
            this.lblLives.TabIndex = 6;
            this.lblLives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(270, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rectangle Game";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleScore
            // 
            this.lblTitleScore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleScore.Location = new System.Drawing.Point(549, 11);
            this.lblTitleScore.Name = "lblTitleScore";
            this.lblTitleScore.Size = new System.Drawing.Size(194, 18);
            this.lblTitleScore.TabIndex = 8;
            this.lblTitleScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 293);
            this.Controls.Add(this.lblTitleScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblCommands);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.gamePicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gamePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox gamePicBox;
        private TextBox nameBox;
        private Label label1;
        private Button startBtn;
        private Label lblCommands;
        private Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private Label lblLives;
        private Label label2;
        private Label lblTitleScore;
    }
}