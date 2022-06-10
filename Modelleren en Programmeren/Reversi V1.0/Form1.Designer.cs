namespace Reversi_Update
{
    partial class Reversi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReversiPanel = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.labelReferee = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.kleurPlayer1 = new System.Windows.Forms.ComboBox();
            this.labelColorPlayer1 = new System.Windows.Forms.Label();
            this.labelColorPlayer2 = new System.Windows.Forms.Label();
            this.kleurPlayer2 = new System.Windows.Forms.ComboBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.BoardSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelTurnPlayer = new System.Windows.Forms.Label();
            this.checkBoxBot = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxEasy = new System.Windows.Forms.RadioButton();
            this.checkBoxHard = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ReversiPanel
            // 
            this.ReversiPanel.BackColor = System.Drawing.Color.White;
            this.ReversiPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReversiPanel.Location = new System.Drawing.Point(6, 6);
            this.ReversiPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ReversiPanel.Name = "ReversiPanel";
            this.ReversiPanel.Size = new System.Drawing.Size(300, 313);
            this.ReversiPanel.TabIndex = 0;
            this.ReversiPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ReversiPanel_Paint);
            this.ReversiPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReversiPanel_MouseClick);
            // 
            // StartButton
            // 
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Location = new System.Drawing.Point(379, 164);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(80, 22);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // labelReferee
            // 
            this.labelReferee.AutoSize = true;
            this.labelReferee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReferee.Location = new System.Drawing.Point(6, 327);
            this.labelReferee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelReferee.Name = "labelReferee";
            this.labelReferee.Size = new System.Drawing.Size(119, 17);
            this.labelReferee.TabIndex = 1;
            this.labelReferee.Text = "Start the game!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(414, 6);
            this.labelSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(121, 31);
            this.labelSettings.TabIndex = 3;
            this.labelSettings.Text = "Settings";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.Location = new System.Drawing.Point(471, 164);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(80, 22);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // kleurPlayer1
            // 
            this.kleurPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kleurPlayer1.FormattingEnabled = true;
            this.kleurPlayer1.Items.AddRange(new object[] {
            "Blue",
            "Green",
            "Cadet Blue"});
            this.kleurPlayer1.Location = new System.Drawing.Point(399, 56);
            this.kleurPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.kleurPlayer1.Name = "kleurPlayer1";
            this.kleurPlayer1.Size = new System.Drawing.Size(62, 21);
            this.kleurPlayer1.TabIndex = 5;
            // 
            // labelColorPlayer1
            // 
            this.labelColorPlayer1.AutoSize = true;
            this.labelColorPlayer1.Location = new System.Drawing.Point(322, 58);
            this.labelColorPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelColorPlayer1.Name = "labelColorPlayer1";
            this.labelColorPlayer1.Size = new System.Drawing.Size(72, 13);
            this.labelColorPlayer1.TabIndex = 6;
            this.labelColorPlayer1.Text = "Player 1 Color";
            // 
            // labelColorPlayer2
            // 
            this.labelColorPlayer2.AutoSize = true;
            this.labelColorPlayer2.Location = new System.Drawing.Point(469, 58);
            this.labelColorPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelColorPlayer2.Name = "labelColorPlayer2";
            this.labelColorPlayer2.Size = new System.Drawing.Size(72, 13);
            this.labelColorPlayer2.TabIndex = 7;
            this.labelColorPlayer2.Text = "Player 2 Color";
            // 
            // kleurPlayer2
            // 
            this.kleurPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kleurPlayer2.FormattingEnabled = true;
            this.kleurPlayer2.Items.AddRange(new object[] {
            "Red",
            "Orange",
            "Magenta"});
            this.kleurPlayer2.Location = new System.Drawing.Point(546, 56);
            this.kleurPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.kleurPlayer2.Name = "kleurPlayer2";
            this.kleurPlayer2.Size = new System.Drawing.Size(62, 21);
            this.kleurPlayer2.TabIndex = 8;
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(342, 93);
            this.labelBoardSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(55, 13);
            this.labelBoardSize.TabIndex = 9;
            this.labelBoardSize.Text = "BoardSize";
            // 
            // BoardSize
            // 
            this.BoardSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoardSize.FormatString = "N0";
            this.BoardSize.FormattingEnabled = true;
            this.BoardSize.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12",
            "14"});
            this.BoardSize.Location = new System.Drawing.Point(399, 93);
            this.BoardSize.Margin = new System.Windows.Forms.Padding(2);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(62, 21);
            this.BoardSize.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(339, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Player1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(480, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "Player 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(443, 255);
            this.labelScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(50, 17);
            this.labelScore.TabIndex = 13;
            this.labelScore.Text = "Score";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Score.ForeColor = System.Drawing.Color.Blue;
            this.labelPlayer1Score.Location = new System.Drawing.Point(377, 255);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(21, 24);
            this.labelPlayer1Score.TabIndex = 14;
            this.labelPlayer1Score.Text = "2";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Score.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer2Score.Location = new System.Drawing.Point(530, 255);
            this.labelPlayer2Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(21, 24);
            this.labelPlayer2Score.TabIndex = 15;
            this.labelPlayer2Score.Text = "2";
            // 
            // labelTurnPlayer
            // 
            this.labelTurnPlayer.AutoSize = true;
            this.labelTurnPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnPlayer.Location = new System.Drawing.Point(377, 289);
            this.labelTurnPlayer.Name = "labelTurnPlayer";
            this.labelTurnPlayer.Size = new System.Drawing.Size(174, 17);
            this.labelTurnPlayer.TabIndex = 16;
            this.labelTurnPlayer.Text = "Player 2, it\'s your turn!";
            // 
            // checkBoxBot
            // 
            this.checkBoxBot.AutoSize = true;
            this.checkBoxBot.Location = new System.Drawing.Point(472, 93);
            this.checkBoxBot.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxBot.Name = "checkBoxBot";
            this.checkBoxBot.Size = new System.Drawing.Size(83, 17);
            this.checkBoxBot.TabIndex = 17;
            this.checkBoxBot.Text = "Singleplayer";
            this.checkBoxBot.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bot Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 21;
            // 
            // checkBoxEasy
            // 
            this.checkBoxEasy.AutoSize = true;
            this.checkBoxEasy.Location = new System.Drawing.Point(472, 141);
            this.checkBoxEasy.Name = "checkBoxEasy";
            this.checkBoxEasy.Size = new System.Drawing.Size(48, 17);
            this.checkBoxEasy.TabIndex = 22;
            this.checkBoxEasy.TabStop = true;
            this.checkBoxEasy.Text = "Easy";
            this.checkBoxEasy.UseVisualStyleBackColor = true;
            // 
            // checkBoxHard
            // 
            this.checkBoxHard.AutoSize = true;
            this.checkBoxHard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHard.Location = new System.Drawing.Point(411, 141);
            this.checkBoxHard.Name = "checkBoxHard";
            this.checkBoxHard.Size = new System.Drawing.Size(48, 17);
            this.checkBoxHard.TabIndex = 23;
            this.checkBoxHard.TabStop = true;
            this.checkBoxHard.Text = "Hard";
            this.checkBoxHard.UseVisualStyleBackColor = true;
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 353);
            this.Controls.Add(this.checkBoxHard);
            this.Controls.Add(this.checkBoxEasy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxBot);
            this.Controls.Add(this.labelTurnPlayer);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoardSize);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.kleurPlayer2);
            this.Controls.Add(this.labelColorPlayer2);
            this.Controls.Add(this.labelColorPlayer1);
            this.Controls.Add(this.kleurPlayer1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelReferee);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ReversiPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Reversi";
            this.Text = "Reversi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ReversiPanel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label labelReferee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.ComboBox kleurPlayer1;
        private System.Windows.Forms.Label labelColorPlayer1;
        private System.Windows.Forms.Label labelColorPlayer2;
        private System.Windows.Forms.ComboBox kleurPlayer2;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.ComboBox BoardSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.Label labelTurnPlayer;
        private System.Windows.Forms.CheckBox checkBoxBot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton checkBoxEasy;
        private System.Windows.Forms.RadioButton checkBoxHard;
    }
}

