using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    public partial class TeamComparison : Form
    {
        private List<TeamModel> teams;
        public TeamComparison(List<TeamModel> teams)
        {
            InitializeComponent();
            this.teams = teams;
            LoadData();
        }

        private void LoadData()
        {
            foreach (TeamModel team in teams)
            {
                goalChart.Series["Games"].Points.AddXY(team.TeamName, team.Games);
                goalChart.Series["Wins"].Points.AddXY(team.TeamName, team.Wins);
                goalChart.Series["Losses"].Points.AddXY(team.TeamName, team.Losses);
                goalChart.Series["Goals"].Points.AddXY(team.TeamName, team.Goals);
            }

        }

        private void goalChart_Click(object sender, EventArgs e)
        {

        }
    }
}
