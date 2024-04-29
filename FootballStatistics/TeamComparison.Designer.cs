namespace FootballStatistics
{
    partial class TeamComparison
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.goalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.goalChart)).BeginInit();
            this.SuspendLayout();
            // 
            // goalChart
            // 
            chartArea1.Name = "ChartArea1";
            this.goalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.goalChart.Legends.Add(legend1);
            this.goalChart.Location = new System.Drawing.Point(0, -3);
            this.goalChart.Name = "goalChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Games";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Wins";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Losses";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Goals";
            this.goalChart.Series.Add(series1);
            this.goalChart.Series.Add(series2);
            this.goalChart.Series.Add(series3);
            this.goalChart.Series.Add(series4);
            this.goalChart.Size = new System.Drawing.Size(801, 456);
            this.goalChart.TabIndex = 1;
            this.goalChart.Text = "Goals";
            this.goalChart.Click += new System.EventHandler(this.goalChart_Click);
            // 
            // TeamComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goalChart);
            this.Name = "TeamComparison";
            this.Text = "TeamComparison";
            ((System.ComponentModel.ISupportInitialize)(this.goalChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart goalChart;
    }
}