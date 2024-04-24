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
            this.signupBtn = new System.Windows.Forms.Button();
            this.playersSearchResultsBox = new System.Windows.Forms.ListBox();
            this.searctxtBox = new System.Windows.Forms.TextBox();
            this.playerslbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teamSearchResultsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwprdlbl = new System.Windows.Forms.Label();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.usernametxt = new System.Windows.Forms.TextBox();
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
            // signupBtn
            // 
            this.signupBtn.Location = new System.Drawing.Point(50, 106);
            this.signupBtn.Name = "signupBtn";
            this.signupBtn.Size = new System.Drawing.Size(75, 23);
            this.signupBtn.TabIndex = 4;
            this.signupBtn.Text = "Sign up";
            this.signupBtn.UseVisualStyleBackColor = true;
            this.signupBtn.Click += new System.EventHandler(this.signupBtn_Click);
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
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(50, 77);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 16;
            this.loginBtn.Text = "Log in";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click_1);
            // 
            // passwprdlbl
            // 
            this.passwprdlbl.AutoSize = true;
            this.passwprdlbl.Location = new System.Drawing.Point(15, 44);
            this.passwprdlbl.Name = "passwprdlbl";
            this.passwprdlbl.Size = new System.Drawing.Size(53, 13);
            this.passwprdlbl.TabIndex = 15;
            this.passwprdlbl.Text = "Password";
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Location = new System.Drawing.Point(13, 18);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(55, 13);
            this.usernamelbl.TabIndex = 14;
            this.usernamelbl.Text = "Username";
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(74, 41);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(100, 20);
            this.passwordtxt.TabIndex = 13;
            // 
            // usernametxt
            // 
            this.usernametxt.Location = new System.Drawing.Point(74, 15);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(100, 20);
            this.usernametxt.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwprdlbl);
            this.Controls.Add(this.usernamelbl);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teamSearchResultsBox);
            this.Controls.Add(this.playerslbl);
            this.Controls.Add(this.searctxtBox);
            this.Controls.Add(this.playersSearchResultsBox);
            this.Controls.Add(this.signupBtn);
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
        private System.Windows.Forms.Button signupBtn;
        private System.Windows.Forms.ListBox playersSearchResultsBox;
        private System.Windows.Forms.TextBox searctxtBox;
        private System.Windows.Forms.Label playerslbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox teamSearchResultsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label passwprdlbl;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.TextBox usernametxt;
    }
}