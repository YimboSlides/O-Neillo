namespace Assignment_oNeillo
{
    partial class confirmSaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confirmSaveForm));
            txt_saveMsg = new TextBox();
            btn_yes = new Button();
            btn_no = new Button();
            SuspendLayout();
            // 
            // txt_saveMsg
            // 
            txt_saveMsg.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            txt_saveMsg.Location = new Point(54, 44);
            txt_saveMsg.Multiline = true;
            txt_saveMsg.Name = "txt_saveMsg";
            txt_saveMsg.ReadOnly = true;
            txt_saveMsg.Size = new Size(528, 275);
            txt_saveMsg.TabIndex = 0;
            txt_saveMsg.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_yes
            // 
            btn_yes.Location = new Point(109, 343);
            btn_yes.Name = "btn_yes";
            btn_yes.Size = new Size(162, 67);
            btn_yes.TabIndex = 1;
            btn_yes.Text = "Yes";
            btn_yes.UseVisualStyleBackColor = true;
            btn_yes.Click += btn_yes_Click;
            // 
            // btn_no
            // 
            btn_no.Location = new Point(354, 343);
            btn_no.Name = "btn_no";
            btn_no.Size = new Size(158, 67);
            btn_no.TabIndex = 2;
            btn_no.Text = "No";
            btn_no.UseVisualStyleBackColor = true;
            btn_no.Click += btn_no_Click;
            // 
            // confirmSaveForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 450);
            Controls.Add(btn_no);
            Controls.Add(btn_yes);
            Controls.Add(txt_saveMsg);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "confirmSaveForm";
            ShowInTaskbar = false;
            Text = "Save Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_saveMsg;
        private Button btn_yes;
        private Button btn_no;
    }
}