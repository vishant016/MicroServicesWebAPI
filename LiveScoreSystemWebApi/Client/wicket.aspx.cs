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
    public partial class wicket : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44382/api/Team");

            var batteamr = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + (int)Session["batteamid"]);
            Team batteam = batteamr.Content.ReadAsAsync<Team>().Result;

          //  Team batteam = client.getTeamDetails((int)Session["batteamid"]);

            //For all wickets down
            if (batteam.Wickets == 10)
            {
                Response.Redirect("inning.aspx");
            }


            var teamr1 = await client.GetAsync(client.BaseAddress + "/getTeamName/" + (int)Session["team1id"]);
            var teamr2 = await client.GetAsync(client.BaseAddress + "/getTeamName/" + (int)Session["team2id"]);

            lbteam1.Text = teamr1.Content.ReadAsStringAsync().Result.ToString();
            lbteam2.Text = teamr2.Content.ReadAsStringAsync().Result.ToString();

            //string team1 = client.getTeamName((int)Session["team1id"]);
            //string team2 = client.getTeamName((int)Session["team2id"]);
            //lbteam1.Text = team1;
            //lbteam2.Text = team2;

            var matchTitler = await client.GetAsync(client.BaseAddress + "/getMatchTitle/" + (int)Session["matchid"]);
            lbmatchtitle.Text = matchTitler.Content.ReadAsStringAsync().Result.ToString();

            //  lbmatchtitle.Text = client.getMatchTitle((int)Session["matchid"]);

            var pr = await client.GetAsync(client.BaseAddress + "/getNextBatsmans/" + (int)Session["batteamid"]);
            List<Player> p = pr.Content.ReadAsAsync<List<Player>>().Result;

         //   List<Player> p = client.getNextBatsmans((int)Session["batteamid"]).ToList();
            int notoutpid;
            var strikerr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + (int)Session["striker"]);
            Player striker = strikerr.Content.ReadAsAsync<Player>().Result;

           // Player striker = client.getPlayerDetails((int)Session["striker"]);
            //Striker is out
            if (striker.Status == (int)Player.OutStatus.OUT)
            {
                notoutpid = (int)Session["nonstriker"];
            }
            //Non striker is out
            else
            {
                notoutpid = (int)Session["striker"];
            }
            if (ddlnextbat.Items.Count == 1)
            {
                foreach (Player a in p)
                {
                    if (a.Id == notoutpid)
                        continue;
                    ddlnextbat.Items.Add(new ListItem(a.Name, a.Id.ToString()));
                }
            }
        }

        protected async void ddlnextbat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlbat.Items.Clear();
            int notoutpid = -1;
            var strikerr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + (int)Session["striker"]);
            Player striker = strikerr.Content.ReadAsAsync<Player>().Result;
          //  Player striker = client.getPlayerDetails((int)Session["striker"]);
            //Striker is out
            if (striker.Status == (int)Player.OutStatus.OUT)
            {
                notoutpid = (int)Session["nonstriker"];
            }
            //Non striker is out
            else
            {
                notoutpid = (int)Session["striker"];
            }
            var notoutpr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + notoutpid);
            Player notoutp = notoutpr.Content.ReadAsAsync<Player>().Result;

            //Player notoutp = client.getPlayerDetails(notoutpid);
            ddlbat.Items.Add(new ListItem(notoutp.Name, notoutp.Id.ToString()));
            int nextbatid = Int32.Parse(ddlnextbat.SelectedValue);

            var nr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + nextbatid);
            Player n = nr.Content.ReadAsAsync<Player>().Result;
           // Player n = client.getPlayerDetails(nextbatid);
            ddlbat.Items.Add(new ListItem(n.Name, n.Id.ToString()));
        }

        protected void GoBtn_Click(object sender, EventArgs e)
        {
            int strikerid = Int32.Parse(ddlbat.SelectedValue);
            Session["striker"] = strikerid;
            foreach (ListItem a in ddlbat.Items)
            {
                if (strikerid != Int32.Parse(a.Value))
                {
                    Session["nonstriker"] = Int32.Parse(a.Value);
                    break;
                }
            }
            double overs = (double)Session["overs"];
            double temp = overs - (int)Math.Floor(overs);
            temp = Math.Round((Double)temp, 1);
            if (temp == 0.6)
                Response.Redirect("over.aspx",false);
            else
                Response.Redirect("scoreboard.aspx",false);
        }
    }
}