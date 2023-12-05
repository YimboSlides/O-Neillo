namespace Assignment_oNeillo
{
    partial class Save_Name
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
            lbl_saveName = new Label();
            txt_saveName = new TextBox();
            btn_submit = new Button();
            SuspendLayout();
            // 
            // lbl_saveName
            // 
            lbl_saveName.AutoSize = true;
            lbl_saveName.Location = new Point(43, 80);
            lbl_saveName.Name = "lbl_saveName";
            lbl_saveName.Size = new Size(140, 32);
            lbl_saveName.TabIndex = 0;
            lbl_saveName.Text = "Save Name:";
            // 
            // txt_saveName
            // 
            txt_saveName.Location = new Point(189, 77);
            txt_saveName.Name = "txt_saveName";
            txt_saveName.Size = new Size(226, 39);
            txt_saveName.TabIndex = 1;
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(439, 73);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(150, 46);
            btn_submit.TabIndex = 2;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // Save_Name
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 187);
            Controls.Add(btn_submit);
            Controls.Add(txt_saveName);
            Controls.Add(lbl_saveName);
            Name = "Save_Name";
            Text = "Name your save";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_saveName;
        private TextBox txt_saveName;
        private Button btn_submit;
    }
}