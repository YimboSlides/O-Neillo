namespace GameBoardTest
{
    partial class boardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(boardForm));
            lbl_ScoreOne = new Label();
            lbl_name1 = new Label();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            save1ToolStripMenuItem = new ToolStripMenuItem();
            save2ToolStripMenuItem = new ToolStripMenuItem();
            save3ToolStripMenuItem = new ToolStripMenuItem();
            save4ToolStripMenuItem = new ToolStripMenuItem();
            save5ToolStripMenuItem = new ToolStripMenuItem();
            loadGameToolStripMenuItem = new ToolStripMenuItem();
            load1 = new ToolStripMenuItem();
            load2 = new ToolStripMenuItem();
            load3 = new ToolStripMenuItem();
            load4 = new ToolStripMenuItem();
            load5 = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            changeNamesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pnl_info = new Panel();
            pbox_arrow2 = new PictureBox();
            pbox_arrow1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lbl_ScoreTwo = new Label();
            lbl_name2 = new Label();
            menuStrip1.SuspendLayout();
            pnl_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbox_arrow2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbox_arrow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_ScoreOne
            // 
            lbl_ScoreOne.AutoSize = true;
            lbl_ScoreOne.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ScoreOne.Location = new Point(240, 80);
            lbl_ScoreOne.Margin = new Padding(6, 0, 6, 0);
            lbl_ScoreOne.Name = "lbl_ScoreOne";
            lbl_ScoreOne.Size = new Size(38, 45);
            lbl_ScoreOne.TabIndex = 1;
            lbl_ScoreOne.Text = "0";
            // 
            // lbl_name1
            // 
            lbl_name1.AutoSize = true;
            lbl_name1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_name1.Location = new Point(192, 15);
            lbl_name1.Margin = new Padding(6, 0, 6, 0);
            lbl_name1.Name = "lbl_name1";
            lbl_name1.Size = new Size(151, 54);
            lbl_name1.TabIndex = 3;
            lbl_name1.Text = "Player1";
            lbl_name1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.PaleGreen;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1483, 40);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveGameToolStripMenuItem, loadGameToolStripMenuItem, newGameToolStripMenuItem, exitToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(96, 36);
            gameToolStripMenuItem.Text = "Game";
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { save1ToolStripMenuItem, save2ToolStripMenuItem, save3ToolStripMenuItem, save4ToolStripMenuItem, save5ToolStripMenuItem });
            saveGameToolStripMenuItem.Enabled = false;
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(283, 44);
            saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // save1ToolStripMenuItem
            // 
            save1ToolStripMenuItem.Name = "save1ToolStripMenuItem";
            save1ToolStripMenuItem.Size = new Size(217, 44);
            save1ToolStripMenuItem.Text = "Save 1";
            save1ToolStripMenuItem.Click += save1ToolStripMenuItem_Click;
            // 
            // save2ToolStripMenuItem
            // 
            save2ToolStripMenuItem.Name = "save2ToolStripMenuItem";
            save2ToolStripMenuItem.Size = new Size(217, 44);
            save2ToolStripMenuItem.Text = "Save 2";
            save2ToolStripMenuItem.Click += save2ToolStripMenuItem_Click;
            // 
            // save3ToolStripMenuItem
            // 
            save3ToolStripMenuItem.Name = "save3ToolStripMenuItem";
            save3ToolStripMenuItem.Size = new Size(217, 44);
            save3ToolStripMenuItem.Text = "Save 3";
            save3ToolStripMenuItem.Click += save3ToolStripMenuItem_Click;
            // 
            // save4ToolStripMenuItem
            // 
            save4ToolStripMenuItem.Name = "save4ToolStripMenuItem";
            save4ToolStripMenuItem.Size = new Size(217, 44);
            save4ToolStripMenuItem.Text = "Save 4";
            save4ToolStripMenuItem.Click += save4ToolStripMenuItem_Click;
            // 
            // save5ToolStripMenuItem
            // 
            save5ToolStripMenuItem.Name = "save5ToolStripMenuItem";
            save5ToolStripMenuItem.Size = new Size(217, 44);
            save5ToolStripMenuItem.Text = "Save 5";
            save5ToolStripMenuItem.Click += save5ToolStripMenuItem_Click;
            // 
            // loadGameToolStripMenuItem
            // 
            loadGameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { load1, load2, load3, load4, load5 });
            loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            loadGameToolStripMenuItem.Size = new Size(283, 44);
            loadGameToolStripMenuItem.Text = "Load Game";
            // 
            // load1
            // 
            load1.Name = "load1";
            load1.Size = new Size(217, 44);
            load1.Text = "Save 1";
            load1.Click += load1_Click;
            // 
            // load2
            // 
            load2.Name = "load2";
            load2.Size = new Size(217, 44);
            load2.Text = "Save 2";
            load2.Click += load2_Click;
            // 
            // load3
            // 
            load3.Name = "load3";
            load3.Size = new Size(217, 44);
            load3.Text = "Save 3";
            load3.Click += load3_Click;
            // 
            // load4
            // 
            load4.Name = "load4";
            load4.Size = new Size(217, 44);
            load4.Text = "Save 4";
            load4.Click += load4_Click;
            // 
            // load5
            // 
            load5.Name = "load5";
            load5.Size = new Size(217, 44);
            load5.Text = "Save 5";
            load5.Click += load5_Click;
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(283, 44);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(283, 44);
            exitToolStripMenuItem.Text = "Exit to Menu";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { informationPanelToolStripMenuItem, speakToolStripMenuItem, changeNamesToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(120, 36);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckOnClick = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(336, 44);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += informationPanelToolStripMenuItem_Click;
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.CheckOnClick = true;
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(336, 44);
            speakToolStripMenuItem.Text = "Speak";
            speakToolStripMenuItem.Click += speakToolStripMenuItem_Click;
            // 
            // changeNamesToolStripMenuItem
            // 
            changeNamesToolStripMenuItem.Name = "changeNamesToolStripMenuItem";
            changeNamesToolStripMenuItem.Size = new Size(336, 44);
            changeNamesToolStripMenuItem.Text = "Change Names";
            changeNamesToolStripMenuItem.Click += changeNamesToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 36);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(212, 44);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // pnl_info
            // 
            pnl_info.BackColor = Color.PaleGreen;
            pnl_info.BorderStyle = BorderStyle.FixedSingle;
            pnl_info.Controls.Add(pbox_arrow2);
            pnl_info.Controls.Add(pbox_arrow1);
            pnl_info.Controls.Add(pictureBox2);
            pnl_info.Controls.Add(pictureBox1);
            pnl_info.Controls.Add(lbl_name1);
            pnl_info.Controls.Add(lbl_ScoreTwo);
            pnl_info.Controls.Add(lbl_ScoreOne);
            pnl_info.Controls.Add(lbl_name2);
            pnl_info.Location = new Point(57, 1305);
            pnl_info.Name = "pnl_info";
            pnl_info.Size = new Size(1364, 200);
            pnl_info.TabIndex = 6;
            // 
            // pbox_arrow2
            // 
            pbox_arrow2.Image = (Image)resources.GetObject("pbox_arrow2.Image");
            pbox_arrow2.Location = new Point(697, 41);
            pbox_arrow2.Name = "pbox_arrow2";
            pbox_arrow2.Size = new Size(152, 100);
            pbox_arrow2.SizeMode = PictureBoxSizeMode.Zoom;
            pbox_arrow2.TabIndex = 9;
            pbox_arrow2.TabStop = false;
            // 
            // pbox_arrow1
            // 
            pbox_arrow1.Image = (Image)resources.GetObject("pbox_arrow1.Image");
            pbox_arrow1.Location = new Point(375, 41);
            pbox_arrow1.Name = "pbox_arrow1";
            pbox_arrow1.Size = new Size(136, 100);
            pbox_arrow1.SizeMode = PictureBoxSizeMode.Zoom;
            pbox_arrow1.TabIndex = 8;
            pbox_arrow1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(878, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(134, 126);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(52, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 138);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lbl_ScoreTwo
            // 
            lbl_ScoreTwo.AutoSize = true;
            lbl_ScoreTwo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ScoreTwo.Location = new Point(1073, 80);
            lbl_ScoreTwo.Margin = new Padding(6, 0, 6, 0);
            lbl_ScoreTwo.Name = "lbl_ScoreTwo";
            lbl_ScoreTwo.Size = new Size(38, 45);
            lbl_ScoreTwo.TabIndex = 2;
            lbl_ScoreTwo.Text = "0";
            // 
            // lbl_name2
            // 
            lbl_name2.AutoSize = true;
            lbl_name2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_name2.Location = new Point(1021, 15);
            lbl_name2.Margin = new Padding(6, 0, 6, 0);
            lbl_name2.Name = "lbl_name2";
            lbl_name2.Size = new Size(151, 54);
            lbl_name2.TabIndex = 4;
            lbl_name2.Text = "Player2";
            lbl_name2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1483, 1517);
            Controls.Add(pnl_info);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6);
            Name = "Board";
            Text = "O'Neillo Game";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnl_info.ResumeLayout(false);
            pnl_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbox_arrow2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbox_arrow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_ScoreOne;
        private Label lbl_name1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Panel pnl_info;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem loadGameToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private PictureBox pbox_arrow2;
        private PictureBox pbox_arrow1;
        private Label lbl_ScoreTwo;
        private Label lbl_name2;
        private ToolStripMenuItem save1ToolStripMenuItem;
        private ToolStripMenuItem load1;
        private ToolStripMenuItem load2;
        private ToolStripMenuItem save2ToolStripMenuItem;
        private ToolStripMenuItem save3ToolStripMenuItem;
        private ToolStripMenuItem save4ToolStripMenuItem;
        private ToolStripMenuItem save5ToolStripMenuItem;
        private ToolStripMenuItem load3;
        private ToolStripMenuItem load4;
        private ToolStripMenuItem load5;
        private ToolStripMenuItem changeNamesToolStripMenuItem;
    }
}