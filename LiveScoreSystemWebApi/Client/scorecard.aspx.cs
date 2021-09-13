using LiveScoreSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class scorecard : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected int i = 0;
        protected List<Player> bat1;
        protected List<Player> bowl1;
        protected List<Player> bat2;
        protected List<Player> bowl2;
        protected async void Page_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44382/api/Team");

            int matchid = (int)Session["matchid"];
            int team2 = (int)Session["batteamid"];
            int team1 = (int)Session["bowlteamid"];
            var bat1r = await client.GetAsync(client.BaseAddress + "/getAllBatsman/" + team1);
             bat1 = bat1r.Content.ReadAsAsync<List<Player>>().Result;
            var bat2r = await client.GetAsync(client.BaseAddress + "/getAllBatsman/" + team2);
            bat2 = bat2r.Content.ReadAsAsync<List<Player>>().Result;

            //bat1 = client.getAllBatsman(team1).ToList();
            //bat2 = client.getAllBatsman(team2).ToList();

            var bowl1r = await client.GetAsync(client.BaseAddress + "/getBowlers/" + team2);
            bowl1 = bowl1r.Content.ReadAsAsync<List<Player>>().Result;
            var bowl2r = await client.GetAsync(client.BaseAddress + "/getBowlers/" + team1);
            bowl2 = bowl2r.Content.ReadAsAsync<List<Player>>().Result;
            //bowl1 = client.getBowlers(team2).ToList();
            //bowl2 = client.getBowlers(team1).ToList();

            var winidr = await client.GetAsync(client.BaseAddress + "/getWinnerId/" + matchid);
            int winid = Int32.Parse(winidr.Content.ReadAsStringAsync().Result);

            //int winid = client.getWinnerId(matchid);


            var rr = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + winid);
            lbwinner.Text  = rr.Content.ReadAsAsync<Team>().Result.Name;

            //lbwinner.Text = client.getTeamDetails(winid).Name;
            var trr = await client.GetAsync(client.BaseAddress + "/getEndComm/" + matchid);
            lbendcom.Text = trr.Content.ReadAsStringAsync().Result.ToString();

          //  lbendcom.Text = client.getEndComm(matchid);

            //Team1 stats

            var t1r = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + team1);
            Team t1 = t1r.Content.ReadAsAsync<Team>().Result;
          //  Team t1 = client.getTeamDetails(team1);
            lbteam1.Text = t1.Name;
            lbscore1.Text = t1.Score.ToString();
            lbwick1.Text = t1.Wickets.ToString();
            lbover1.Text = t1.Overs.ToString();
            lbrr1.Text = t1.Runrate.ToString();
            lbwide1.Text = t1.Wideball.ToString();
            lbnoball1.Text = t1.Noball.ToString();

            //Team2 stats
            var t2r = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + team2);
            Team t2 = t2r.Content.ReadAsAsync<Team>().Result;
           // Team t2 = client.getTeamDetails(team2);
            lbteam2.Text = t2.Name;
            lbscore2.Text = t2.Score.ToString();
            lbwick2.Text = t2.Wickets.ToString();
            lbover2.Text = t2.Overs.ToString();
            lbrr2.Text = t2.Runrate.ToString();
            lbwide2.Text = t2.Wideball.ToString();
            lbnoball2.Text = t2.Noball.ToString();
        }
    }
}