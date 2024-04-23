namespace FootballStatistics
{
    partial class AddPlayerPage
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
            this.addbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fullNamelbl = new System.Windows.Forms.Label();
            this.fullNametxt = new System.Windows.Forms.TextBox();
            this.nationalitytxt = new System.Windows.Forms.TextBox();
            this.nationalitylbl = new System.Windows.Forms.Label();
            this.goalstxt = new System.Windows.Forms.TextBox();
            this.goalslbl = new System.Windows.Forms.Label();
            this.shotstakentxt = new System.Windows.Forms.TextBox();
            this.shotsTakenlbl = new System.Windows.Forms.Label();
            this.assiststxt = new System.Windows.Forms.TextBox();
            this.assistslbl = new System.Windows.Forms.Label();
            this.positiontxt = new System.Windows.Forms.TextBox();
            this.positionlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(713, 415);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 0;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.positiontxt);
            this.panel1.Controls.Add(this.positionlbl);
            this.panel1.Controls.Add(this.assiststxt);
            this.panel1.Controls.Add(this.assistslbl);
            this.panel1.Controls.Add(this.shotstakentxt);
            this.panel1.Controls.Add(this.shotsTakenlbl);
            this.panel1.Controls.Add(this.goalstxt);
            this.panel1.Controls.Add(this.goalslbl);
            this.panel1.Controls.Add(this.nationalitytxt);
            this.panel1.Controls.Add(this.nationalitylbl);
            this.panel1.Controls.Add(this.fullNametxt);
            this.panel1.Controls.Add(this.fullNamelbl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 404);
            this.panel1.TabIndex = 1;
            // 
            // fullNamelbl
            // 
            this.fullNamelbl.AutoSize = true;
            this.fullNamelbl.Location = new System.Drawing.Point(16, 24);
            this.fullNamelbl.Name = "fullNamelbl";
            this.fullNamelbl.Size = new System.Drawing.Size(54, 13);
            this.fullNamelbl.TabIndex = 0;
            this.fullNamelbl.Text = "Full Name";
            this.fullNamelbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // fullNametxt
            // 
            this.fullNametxt.Location = new System.Drawing.Point(125, 21);
            this.fullNametxt.Name = "fullNametxt";
            this.fullNametxt.Size = new System.Drawing.Size(100, 20);
            this.fullNametxt.TabIndex = 1;
            // 
            // nationalitytxt
            // 
            this.nationalitytxt.Location = new System.Drawing.Point(125, 47);
            this.nationalitytxt.Name = "nationalitytxt";
            this.nationalitytxt.Size = new System.Drawing.Size(100, 20);
            this.nationalitytxt.TabIndex = 3;
            // 
            // nationalitylbl
            // 
            this.nationalitylbl.AutoSize = true;
            this.nationalitylbl.Location = new System.Drawing.Point(16, 50);
            this.nationalitylbl.Name = "nationalitylbl";
            this.nationalitylbl.Size = new System.Drawing.Size(56, 13);
            this.nationalitylbl.TabIndex = 2;
            this.nationalitylbl.Text = "Nationality";
            this.nationalitylbl.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // goalstxt
            // 
            this.goalstxt.Location = new System.Drawing.Point(125, 73);
            this.goalstxt.Name = "goalstxt";
            this.goalstxt.Size = new System.Drawing.Size(100, 20);
            this.goalstxt.TabIndex = 5;
            // 
            // goalslbl
            // 
            this.goalslbl.AutoSize = true;
            this.goalslbl.Location = new System.Drawing.Point(16, 76);
            this.goalslbl.Name = "goalslbl";
            this.goalslbl.Size = new System.Drawing.Size(34, 13);
            this.goalslbl.TabIndex = 4;
            this.goalslbl.Text = "Goals";
            // 
            // shotstakentxt
            // 
            this.shotstakentxt.Location = new System.Drawing.Point(125, 99);
            this.shotstakentxt.Name = "shotstakentxt";
            this.shotstakentxt.Size = new System.Drawing.Size(100, 20);
            this.shotstakentxt.TabIndex = 7;
            // 
            // shotsTakenlbl
            // 
            this.shotsTakenlbl.AutoSize = true;
            this.shotsTakenlbl.Location = new System.Drawing.Point(16, 102);
            this.shotsTakenlbl.Name = "shotsTakenlbl";
            this.shotsTakenlbl.Size = new System.Drawing.Size(65, 13);
            this.shotsTakenlbl.TabIndex = 6;
            this.shotsTakenlbl.Text = "ShotsTaken";
            // 
            // assiststxt
            // 
            this.assiststxt.Location = new System.Drawing.Point(125, 125);
            this.assiststxt.Name = "assiststxt";
            this.assiststxt.Size = new System.Drawing.Size(100, 20);
            this.assiststxt.TabIndex = 9;
            // 
            // assistslbl
            // 
            this.assistslbl.AutoSize = true;
            this.assistslbl.Location = new System.Drawing.Point(16, 128);
            this.assistslbl.Name = "assistslbl";
            this.assistslbl.Size = new System.Drawing.Size(39, 13);
            this.assistslbl.TabIndex = 8;
            this.assistslbl.Text = "Assists";
            // 
            // positiontxt
            // 
            this.positiontxt.Location = new System.Drawing.Point(125, 151);
            this.positiontxt.Name = "positiontxt";
            this.positiontxt.Size = new System.Drawing.Size(100, 20);
            this.positiontxt.TabIndex = 11;
            // 
            // positionlbl
            // 
            this.positionlbl.AutoSize = true;
            this.positionlbl.Location = new System.Drawing.Point(16, 154);
            this.positionlbl.Name = "positionlbl";
            this.positionlbl.Size = new System.Drawing.Size(44, 13);
            this.positionlbl.TabIndex = 10;
            this.positionlbl.Text = "Position";
            // 
            // AddPlayerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addbtn);
            this.Name = "AddPlayerPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AddPlayerPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fullNamelbl;
        private System.Windows.Forms.TextBox fullNametxt;
        private System.Windows.Forms.TextBox positiontxt;
        private System.Windows.Forms.Label positionlbl;
        private System.Windows.Forms.TextBox assiststxt;
        private System.Windows.Forms.Label assistslbl;
        private System.Windows.Forms.TextBox shotstakentxt;
        private System.Windows.Forms.Label shotsTakenlbl;
        private System.Windows.Forms.TextBox goalstxt;
        private System.Windows.Forms.Label goalslbl;
        private System.Windows.Forms.TextBox nationalitytxt;
        private System.Windows.Forms.Label nationalitylbl;
    }
}

