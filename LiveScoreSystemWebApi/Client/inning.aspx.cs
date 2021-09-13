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
    public partial class inning : System.Web.UI.Page
    {


        HttpClient client = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44382/api/Team");

            if (!IsPostBack)
            {
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

                var innr = await client.GetAsync(client.BaseAddress + "/getInning/" + matchid);

                int inn = Int32.Parse(innr.Content.ReadAsStringAsync().Result);

               // int inn = client.getInning(matchid);
                //For 2nd Innings
                if (inn == 2)
                {
                    Response.Redirect("matchEnd.aspx",false);
                }

                //Swap batteam and bowlteam
                int temp = (int)Session["batteamid"];
                Session["batteamid"] = (int)Session["bowlteamid"];
                Session["bowlteamid"] = temp;

                //Declaring striker non striker


                var obr = await client.GetAsync(client.BaseAddress + "/getOpeners/" + (int)Session["batteamid"]);
                List<Player> ob = obr.Content.ReadAsAsync<List<Player>>().Result;

               // List<Player> ob = client.getOpeners((int)Session["batteamid"]).ToList();
                Session["striker"] = ob[0].Id;
                Session["nonstriker"] = ob[1].Id;

                //Select Bowler
                if (ddlfbowl.Items.Count == 0)
                {
                    int bowlteamid = (int)Session["bowlteamid"];

                    var br = await client.GetAsync(client.BaseAddress + "/getBowlers/" + bowlteamid);
                    List<Player> b = br.Content.ReadAsAsync<List<Player>>().Result;
                   // List<Player> b = client.getBowlers(bowlteamid).ToList<Player>();
                    foreach (Player p in b)
                    {
                        ddlfbowl.Items.Add(new ListItem(p.Name, p.Id.ToString()));
                    }
                }
        }
            }
        protected async void GoBtn_ClickAsync(object sender, EventArgs e)

        {
            //Update Bowler
            Session["bowler"] = Int32.Parse(ddlfbowl.SelectedValue);

            int matchid = (int)Session["matchid"];
            //Update Innings and Inning Comment
            var matchidr = JsonConvert.SerializeObject(matchid);
            var matchidc = new StringContent(matchidr, Encoding.UTF8, "application/json");
            var response2 = await client.PutAsync(client.BaseAddress + "/putupdateInning/" + 2, matchidc);

          //  client.updateInning(2, matchid);

            string incom = tainncom.Text;
            var incomr = JsonConvert.SerializeObject(incom);
            var incomc = new StringContent(incomr, Encoding.UTF8, "application/json");
            var response3 = await client.PutAsync(client.BaseAddress + "/putupdateInningComm/" + matchid, incomc);

           // client.updateInningComm(incom, matchid);
            var response4 = await client.DeleteAsync(client.BaseAddress + "/deleteComm");
            //client.deleteComm();
            Response.Redirect("scoreboard.aspx",false);
        }
    }
}