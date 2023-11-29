namespace Assignment_oNeillo
{
    partial class Save
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Save));
            txt_Save = new TextBox();
            btn_saveGame = new Button();
            btn_newGame = new Button();
            SuspendLayout();
            // 
            // txt_Save
            // 
            txt_Save.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Save.Location = new Point(54, 44);
            txt_Save.Multiline = true;
            txt_Save.Name = "txt_Save";
            txt_Save.ReadOnly = true;
            txt_Save.Size = new Size(528, 275);
            txt_Save.TabIndex = 0;
            txt_Save.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_saveGame
            // 
            btn_saveGame.Location = new Point(109, 343);
            btn_saveGame.Name = "btn_saveGame";
            btn_saveGame.Size = new Size(162, 67);
            btn_saveGame.TabIndex = 1;
            btn_saveGame.Text = "Yes";
            btn_saveGame.UseVisualStyleBackColor = true;
            btn_saveGame.Click += btn_SaveGame_Click;
            // 
            // btn_newGame
            // 
            btn_newGame.Location = new Point(354, 343);
            btn_newGame.Name = "btn_newGame";
            btn_newGame.Size = new Size(158, 67);
            btn_newGame.TabIndex = 2;
            btn_newGame.Text = "No";
            btn_newGame.UseVisualStyleBackColor = true;
            btn_newGame.Click += btn_newGame_Click;
            // 
            // Save
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 450);
            Controls.Add(btn_newGame);
            Controls.Add(btn_saveGame);
            Controls.Add(txt_Save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Save";
            ShowInTaskbar = false;
            Text = "Save Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Save;
        private Button btn_saveGame;
        private Button btn_newGame;
    }
}