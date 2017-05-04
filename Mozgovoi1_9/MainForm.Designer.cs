namespace Mozgovoi1_9
{
    partial class MainForm
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
            this.lifePanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lifePanel
            // 
            this.lifePanel.BackColor = System.Drawing.Color.White;
            this.lifePanel.Location = new System.Drawing.Point(0, 1);
            this.lifePanel.Name = "lifePanel";
            this.lifePanel.Size = new System.Drawing.Size(382, 264);
            this.lifePanel.TabIndex = 0;
            this.lifePanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lifePanel_MouseDoubleClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(144, 274);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(111, 40);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Пуск";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 326);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.lifePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Жизнь Джона Конуэя";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lifePanel;
        private System.Windows.Forms.Button startButton;
    }
}

