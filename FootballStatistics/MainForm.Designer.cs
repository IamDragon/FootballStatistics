namespace FootballStatistics
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
            this.button1 = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.playersSearchResultsBox = new System.Windows.Forms.ListBox();
            this.searctxtBox = new System.Windows.Forms.TextBox();
            this.playerslbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teamSearchResultsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(434, 12);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(638, 342);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Log in";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Sign up";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // playersSearchResultsBox
            // 
            this.playersSearchResultsBox.FormattingEnabled = true;
            this.playersSearchResultsBox.Location = new System.Drawing.Point(230, 54);
            this.playersSearchResultsBox.Name = "playersSearchResultsBox";
            this.playersSearchResultsBox.Size = new System.Drawing.Size(306, 108);
            this.playersSearchResultsBox.TabIndex = 5;
            this.playersSearchResultsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.searchResultsBox_MouseDoubleClick);
            // 
            // searctxtBox
            // 
            this.searctxtBox.Location = new System.Drawing.Point(230, 15);
            this.searctxtBox.Name = "searctxtBox";
            this.searctxtBox.Size = new System.Drawing.Size(198, 20);
            this.searctxtBox.TabIndex = 6;
            // 
            // playerslbl
            // 
            this.playerslbl.AutoSize = true;
            this.playerslbl.Location = new System.Drawing.Point(227, 38);
            this.playerslbl.Name = "playerslbl";
            this.playerslbl.Size = new System.Drawing.Size(41, 13);
            this.playerslbl.TabIndex = 7;
            this.playerslbl.Text = "Players";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Teams";
            // 
            // teamSearchResultsBox
            // 
            this.teamSearchResultsBox.FormattingEnabled = true;
            this.teamSearchResultsBox.Location = new System.Drawing.Point(230, 190);
            this.teamSearchResultsBox.Name = "teamSearchResultsBox";
            this.teamSearchResultsBox.Size = new System.Drawing.Size(306, 108);
            this.teamSearchResultsBox.TabIndex = 8;
            this.teamSearchResultsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.teamSearchResultsBox_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Matches";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(230, 330);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(306, 108);
            this.listBox2.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teamSearchResultsBox);
            this.Controls.Add(this.playerslbl);
            this.Controls.Add(this.searctxtBox);
            this.Controls.Add(this.playersSearchResultsBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox playersSearchResultsBox;
        private System.Windows.Forms.TextBox searctxtBox;
        private System.Windows.Forms.Label playerslbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox teamSearchResultsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
    }
}