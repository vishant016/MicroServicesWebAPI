using LiveScoreSystemWebAPI.Models;
using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class toss : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {

            client.BaseAddress = new Uri("https://localhost:44382/api/Team");

            var teamr1 = await client.GetAsync(client.BaseAddress+ "/getTeamName/"+(int)Session["team1id"]);
            var teamr2 = await client.GetAsync(client.BaseAddress + "/getTeamName/" + (int)Session["team2id"]);

            lbteam1.Text = teamr1.Content.ReadAsStringAsync().Result.ToString();
            lbteam2.Text = teamr2.Content.ReadAsStringAsync().Result.ToString();

            var matchTitler = await client.GetAsync(client.BaseAddress + "/getMatchTitle/" + (int)Session["matchid"]);

            lbmatchtitle.Text = matchTitler.Content.ReadAsStringAsync().Result.ToString();
            if (ddlbatfirst.Items.Count == 1)
            {
                ddlbatfirst.Items.Add(new ListItem(teamr1.Content.ReadAsStringAsync().Result.ToString(), Session["team1id"].ToString()));
                ddlbatfirst.Items.Add(new ListItem(teamr2.Content.ReadAsStringAsync().Result.ToString(), Session["team2id"].ToString()));
            }
        }

        protected async void StartBtn_ClickAsync(object sender, EventArgs e)
        {
            int mid = (int)Session["matchid"];
            int bid = Int32.Parse(ddlbatfirst.SelectedValue);
            Session["batteamid"] = bid;
            int team1id = (int)Session["team1id"];
            int team2id = (int)Session["team2id"];
            if (bid == team1id)
                Session["bowlteamid"] = team2id;
            else
                Session["bowlteamid"] = team1id;
            string tc = tatosscom.Text;



            var tcr = JsonConvert.SerializeObject(tc);
            var tcc = new StringContent(tcr, Encoding.UTF8, "application/json");

          
            var response= await client.PutAsync(client.BaseAddress + "/putupdateToss/"+mid+"/"+bid,tcc);
            
            //  client.updateToss(mid, bid, tc);


            var obr = await client.GetAsync(client.BaseAddress + "/getOpeners/" + bid);
            List<Player> ob = obr.Content.ReadAsAsync<List<Player>>().Result;
            //List<Player> ob = client.getOpeners(bid).ToList<Player>();
            Session["striker"] = ob[0].Id;
            Session["nonstriker"] = ob[1].Id;
            Session["bowler"] = Int32.Parse(ddlfbowl.SelectedValue);
            Response.Redirect("scoreboard.aspx",false);
        }

        protected async void ddlbatfirst_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            ddlfbowl.Items.Clear();
            int bid = Int32.Parse(ddlbatfirst.SelectedValue);
            int bwid;
            if (bid == (int)Session["team1id"])
                bwid = (int)Session["team2id"];
            else
                bwid = (int)Session["team1id"];

            var br = await client.GetAsync(client.BaseAddress + "/getBowlers/" + bwid);
            List<Player> b = br.Content.ReadAsAsync<List<Player>>().Result;
         //   List<Player> b = client.getBowlers(bwid).ToList<Player>();
            foreach (Player p in b)
            {
                ddlfbowl.Items.Add(new ListItem(p.Name, p.Id.ToString()));
            }
        }
    }
}