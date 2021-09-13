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
    public partial class matchEnd : System.Web.UI.Page
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

                int team1id = (int)Session["team1id"];
                int team2id = (int)Session["team2id"];
                ddlwinteam.Items.Add(new ListItem(teamr1.Content.ReadAsStringAsync().Result.ToString(), team1id.ToString()));
                ddlwinteam.Items.Add(new ListItem(teamr2.Content.ReadAsStringAsync().Result.ToString(), team2id.ToString()));
            }
        }

        protected async void EndBtn_Click(object sender, EventArgs e)
        {
            int winteamid = Int32.Parse(ddlwinteam.SelectedValue);
            int matchid = (int)Session["matchid"];
            string endcom = taendcom.Text;
            DateTime endtime = DateTime.Now;

            var matchidr = JsonConvert.SerializeObject(matchid);
            var matchidc = new StringContent(matchidr, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(client.BaseAddress + "/putupdateWinner/" + winteamid, matchidc);

            //  client.updateWinner(winteamid, matchid);
            var endcomr = JsonConvert.SerializeObject(endcom);
            var endcomrc = new StringContent(endcomr, Encoding.UTF8, "application/json");
            var response2 = await client.PutAsync(client.BaseAddress + "/putupdateEndComm/" + matchid, endcomrc);

            // client.updateEndComm(endcom, matchid);
            var endtimer = JsonConvert.SerializeObject(endtime);
            var endtimec = new StringContent(endtimer, Encoding.UTF8, "application/json");
            var response3 = await client.PutAsync(client.BaseAddress + "/putupdateEndTime/" + matchid, endtimec);

            //  client.updateEndTime(endtime, matchid);


            var response4 = await client.DeleteAsync(client.BaseAddress + "/deleteComm");

           // client.deleteComm();
            Response.Redirect("scorecard.aspx",false);
        }
    }
}