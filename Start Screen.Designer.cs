namespace GameBoardTest
{
    partial class Start_Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_Screen));
            lbl_Player1 = new Label();
            lbl_Player2 = new Label();
            txt_p1_name = new TextBox();
            txt_p2_name = new TextBox();
            btn_start = new Button();
            btn_quit = new Button();
            lbl_Title = new Label();
            SuspendLayout();
            // 
            // lbl_Player1
            // 
            lbl_Player1.AutoSize = true;
            lbl_Player1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Player1.Location = new Point(386, 254);
            lbl_Player1.Margin = new Padding(6, 0, 6, 0);
            lbl_Player1.Name = "lbl_Player1";
            lbl_Player1.Size = new Size(217, 72);
            lbl_Player1.TabIndex = 0;
            lbl_Player1.Text = "Player 1";
            lbl_Player1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Player2
            // 
            lbl_Player2.AutoSize = true;
            lbl_Player2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Player2.Location = new Point(804, 254);
            lbl_Player2.Margin = new Padding(6, 0, 6, 0);
            lbl_Player2.Name = "lbl_Player2";
            lbl_Player2.Size = new Size(217, 72);
            lbl_Player2.TabIndex = 1;
            lbl_Player2.Text = "Player 2";
            lbl_Player2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_p1_name
            // 
            txt_p1_name.Location = new Point(386, 339);
            txt_p1_name.Margin = new Padding(6);
            txt_p1_name.Name = "txt_p1_name";
            txt_p1_name.Size = new Size(203, 39);
            txt_p1_name.TabIndex = 2;
            // 
            // txt_p2_name
            // 
            txt_p2_name.Location = new Point(804, 332);
            txt_p2_name.Margin = new Padding(6);
            txt_p2_name.Name = "txt_p2_name";
            txt_p2_name.Size = new Size(203, 39);
            txt_p2_name.TabIndex = 3;
            // 
            // btn_start
            // 
            btn_start.BackColor = Color.PaleGreen;
            btn_start.FlatAppearance.BorderColor = Color.Black;
            btn_start.FlatAppearance.BorderSize = 4;
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_start.Location = new Point(589, 452);
            btn_start.Margin = new Padding(6);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(214, 87);
            btn_start.TabIndex = 4;
            btn_start.Text = "Start Game";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // btn_quit
            // 
            btn_quit.BackColor = Color.PaleGreen;
            btn_quit.FlatAppearance.BorderColor = Color.Black;
            btn_quit.FlatAppearance.BorderSize = 4;
            btn_quit.FlatStyle = FlatStyle.Flat;
            btn_quit.Location = new Point(589, 567);
            btn_quit.Name = "btn_quit";
            btn_quit.Size = new Size(214, 77);
            btn_quit.TabIndex = 5;
            btn_quit.Text = "Quit";
            btn_quit.UseVisualStyleBackColor = false;
            btn_quit.Click += btn_quit_Click;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Title.Location = new Point(553, 129);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(296, 89);
            lbl_Title.TabIndex = 6;
            lbl_Title.Text = "O'Neillo";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Start_Screen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1377, 960);
            Controls.Add(lbl_Title);
            Controls.Add(btn_quit);
            Controls.Add(btn_start);
            Controls.Add(txt_p2_name);
            Controls.Add(txt_p1_name);
            Controls.Add(lbl_Player2);
            Controls.Add(lbl_Player1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            MaximizeBox = false;
            Name = "Start_Screen";
            Text = "O'Neillo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Player1;
        private Label lbl_Player2;
        private TextBox txt_p1_name;
        private TextBox txt_p2_name;
        private Button btn_start;
        private Button btn_quit;
        private Label lbl_Title;
    }
}