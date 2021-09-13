using LiveScoreSystemWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class over : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44382/api/Team");

            var teamr1 = await client.GetAsync(client.BaseAddress + "/getTeamName/" + (int)Session["team1id"]);
            var teamr2 = await client.GetAsync(client.BaseAddress + "/getTeamName/" + (int)Session["team2id"]);

            lbteam1.Text = teamr1.Content.ReadAsStringAsync().Result.ToString();
            lbteam2.Text = teamr2.Content.ReadAsStringAsync().Result.ToString();

            //string team1 = client.getTeamName((int)Session["team1id"]);
            //string team2 = client.getTeamName((int)Session["team2id"]);
            //lbteam1.Text = team1;
            //lbteam2.Text = team2;
            int matchid = (int)Session["matchid"];
            var matchTitler = await client.GetAsync(client.BaseAddress + "/getMatchTitle/" + (int)Session["matchid"]);
            lbmatchtitle.Text = matchTitler.Content.ReadAsStringAsync().Result.ToString();

            //  lbmatchtitle.Text = client.getMatchTitle((int)Session["matchid"]);
            double overs = (double)Session["overs"];

            //Converting #.6 over to #.0
            overs = Math.Ceiling(overs);
            Session["overs"] = overs;
            lbover.Text = overs.ToString();

            int bowlerid = (int)Session["bowler"];
            int bowlteamid = (int)Session["bowlteamid"];
            int batteamid = (int)Session["batteamid"];
            var bowlerr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + bowlerid);
            Player bowler = bowlerr.Content.ReadAsAsync<Player>().Result;
            double bowlovers = bowler.Overs;
          //  double bowlovers = client.getPlayerDetails(bowlerid).Overs;
            bowlovers = Math.Ceiling(bowlovers);

            //Updating over

            var bowloversr = JsonConvert.SerializeObject(bowlovers);
            var bowloversc = new StringContent(bowloversr, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(client.BaseAddress + "/putupdateBowlOver/" + bowlerid, bowloversc);
            // client.updateBowlOver(bowlovers, bowlerid);
            var oversr = JsonConvert.SerializeObject(overs);
            var oversc = new StringContent(oversr, Encoding.UTF8, "application/json");
            var response2 = await client.PutAsync(client.BaseAddress + "/putupdateTeamOver/" + batteamid, oversc);
            //  client.updateTeamOver(overs, batteamid);

            //For all overs done
            var moversr = await client.GetAsync(client.BaseAddress + "/getMatchOvers/" + matchid);
            int movers =Int32.Parse( moversr.Content.ReadAsStringAsync().Result);

          //  int movers = client.getMatchOvers(matchid);
            //Match m = client.getMatchDetails((int)Session["matchid"]);
            if (overs == (double)movers)
            {
                Response.Redirect("inning.aspx",false);
            }

            //Adding bowlers to dropdownlist
            //ddlnextbowl.Items.Clear();
            if (ddlnextbowl.Items.Count == 0)
            {
                var br = await client.GetAsync(client.BaseAddress + "/getBowlers/" + bowlteamid);
                List<Player> b = br.Content.ReadAsAsync<List<Player>>().Result;


               // List<Player> b = client.getBowlers(bowlteamid).ToList<Player>();
                foreach (Player p in b)
                {
                    //Current bowler cannot bowl again
                    if (p.Id == bowlerid)
                        continue;
                    ddlnextbowl.Items.Add(new ListItem(p.Name, p.Id.ToString()));
                }
            }
        }

        protected void GoBtn_Click(object sender, EventArgs e)
        {
            //Change strike
            int temp1 = (int)Session["striker"];
            Session["striker"] = (int)Session["nonstriker"];
            Session["nonstriker"] = temp1;

            //Change bowler
            Session["bowler"] = Int32.Parse(ddlnextbowl.SelectedValue);
            Response.Redirect("scoreboard.aspx",false);
        }
    }
}