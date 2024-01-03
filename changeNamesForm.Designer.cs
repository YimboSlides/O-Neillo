namespace Assignment_oNeillo
{
    partial class changeNamesForm
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
            label1 = new Label();
            label2 = new Label();
            btn_submit = new Button();
            btn_cancel = new Button();
            txt_changeName1 = new TextBox();
            txt_changeName2 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 60);
            label1.Name = "label1";
            label1.Size = new Size(96, 32);
            label1.TabIndex = 0;
            label1.Text = "Player1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 116);
            label2.Name = "label2";
            label2.Size = new Size(96, 32);
            label2.TabIndex = 1;
            label2.Text = "Player2:";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(186, 179);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(150, 46);
            btn_submit.TabIndex = 2;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(342, 179);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(150, 46);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // txt_changeName1
            // 
            txt_changeName1.Location = new Point(186, 60);
            txt_changeName1.Name = "txt_changeName1";
            txt_changeName1.Size = new Size(306, 39);
            txt_changeName1.TabIndex = 4;
            // 
            // txt_changeName2
            // 
            txt_changeName2.Location = new Point(186, 116);
            txt_changeName2.Name = "txt_changeName2";
            txt_changeName2.Size = new Size(306, 39);
            txt_changeName2.TabIndex = 5;
            // 
            // Enter_Names
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 263);
            Controls.Add(txt_changeName2);
            Controls.Add(txt_changeName1);
            Controls.Add(btn_cancel);
            Controls.Add(btn_submit);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Enter_Names";
            Text = "Change Names";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btn_submit;
        private Button btn_cancel;
        private TextBox txt_changeName1;
        private TextBox txt_changeName2;
    }
}