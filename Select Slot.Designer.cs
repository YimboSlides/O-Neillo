namespace Assignment_oNeillo
{
    partial class Select_Slot
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
            lbl_choose = new Label();
            cmbo_saveDrop = new ComboBox();
            btn_submit = new Button();
            SuspendLayout();
            // 
            // lbl_choose
            // 
            lbl_choose.AutoSize = true;
            lbl_choose.Location = new Point(48, 83);
            lbl_choose.Name = "lbl_choose";
            lbl_choose.Size = new Size(223, 32);
            lbl_choose.TabIndex = 0;
            lbl_choose.Text = "Choose a Save Slot:";
            // 
            // cmbo_saveDrop
            // 
            cmbo_saveDrop.FormattingEnabled = true;
            cmbo_saveDrop.Location = new Point(48, 127);
            cmbo_saveDrop.Name = "cmbo_saveDrop";
            cmbo_saveDrop.Size = new Size(300, 40);
            cmbo_saveDrop.TabIndex = 1;
            cmbo_saveDrop.Text = "Select Save";
            cmbo_saveDrop.SelectedIndexChanged += cmbo_saveDrop_SelectedIndexChanged;
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(394, 123);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(150, 46);
            btn_submit.TabIndex = 2;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // Select_Slot
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 234);
            Controls.Add(btn_submit);
            Controls.Add(cmbo_saveDrop);
            Controls.Add(lbl_choose);
            Name = "Select_Slot";
            Text = "Select Slot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_choose;
        private ComboBox cmbo_saveDrop;
        private Button btn_submit;
    }
}