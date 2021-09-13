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
    public partial class scoreboard : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected List<Commentary> c=new List<Commentary>();
        protected int i = 0;
        protected async void Page_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44382/api/Team");
            if (!IsPostBack)
            {
                int mid = (int)Session["matchid"];
                var innr = await client.GetAsync(client.BaseAddress + "/getInning/" + mid);
                //int inn = client.getInning(mid);
                int inn =Int32.Parse(innr.Content.ReadAsStringAsync().Result);
                if (inn == 1)
                {
                    var tosscommr = await client.GetAsync(client.BaseAddress + "/getTossCom/" + mid);
                    string tosscomm = tosscommr.Content.ReadAsStringAsync().Result.ToString();
                    //string tosscomm = client.getTossCom(mid);
                    lbtoss.Text = tosscomm;
                    lbinning.Text = inn.ToString() + "st Innings";
                }
                else
                {
                    var inncommr = await client.GetAsync(client.BaseAddress + "/getInnComment/" + mid);
                    string inncomm = inncommr.Content.ReadAsStringAsync().Result.ToString();
                   // string inncomm = client.getInnComment(mid);
                    lbtoss.Text = inncomm;
                    lbinning.Text = inn.ToString() + "nd Innings";
                    var bowlteamr = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + (int)Session["bowlteamid"]);
                    Team bowlteam = bowlteamr.Content.ReadAsAsync<Team>().Result;
                   // Team bowlteam = client.getTeamDetails((int)Session["bowlteamid"]);
                    int target = bowlteam.Score + 1;
                    lbtarget.Text = "Target: " + target.ToString();
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

                //lbmatchtitle.Text = client.getMatchTitle((int)Session["matchid"]);
                int bid = (int)Session["batteamid"];

                //Batting Team stats
                var tr = await client.GetAsync(client.BaseAddress + "/getTeamDetails/" + bid);
                Team t = tr.Content.ReadAsAsync<Team>().Result;
                //Team t = client.getTeamDetails(bid);
                lbbatteam.Text = t.Name;
                lbtscore.Text = t.Score.ToString();
                lbtwickets.Text = t.Wickets.ToString();
                lbtover.Text = t.Overs.ToString();
                lbtrr.Text = t.Runrate.ToString();


                var strr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + (int)Session["striker"]);
                Player str = strr.Content.ReadAsAsync<Player>().Result;

                var nonstrr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + (int)Session["nonstriker"]);
                Player nonstr = nonstrr.Content.ReadAsAsync<Player>().Result;

                var bowlr = await client.GetAsync(client.BaseAddress + "/getPlayerDetails/" + (int)Session["bowler"]);
                Player bowl = bowlr.Content.ReadAsAsync<Player>().Result;


                //Player str = client.getPlayerDetails((int)Session["striker"]);
                //Player nonstr = client.getPlayerDetails((int)Session["nonstriker"]);
                //Player bowl = client.getPlayerDetails((int)Session["bowler"]);

                //Striker stats
                lbbat1name.Text = str.Name;
                lbbat1runs.Text = str.Batruns.ToString();
                lbbat1balls.Text = str.Balls.ToString();
                lbbat1fours.Text = str.Fours.ToString();
                lbbat1sixes.Text = str.Sixes.ToString();
                lbbat1strk.Text = str.Strikerate.ToString();

                //Non Striker Stats
                lbbat2name.Text = nonstr.Name;
                lbbat2runs.Text = nonstr.Batruns.ToString();
                lbbat2balls.Text = nonstr.Balls.ToString();
                lbbat2fours.Text = nonstr.Fours.ToString();
                lbbat2sixes.Text = nonstr.Sixes.ToString();
                lbbat2strk.Text = nonstr.Strikerate.ToString();

                //Bowler stats
                lbbowl.Text = bowl.Name;
                lbbowlover.Text = bowl.Overs.ToString();
                lbbowlrun.Text = bowl.Bowlruns.ToString();
                lbbowlwick.Text = bowl.Wickets.ToString();
                lbbowleco.Text = bowl.Economy.ToString();

                var cr = await client.GetAsync(client.BaseAddress + "/getCommentary/" + mid);
                 c = cr.Content.ReadAsAsync<List<Commentary>>().Result;

                //c = client.getCommentary(mid).ToList();
            }
        }

        protected async void AddBtn_ClickAsync(object sender, EventArgs e)
        {
            //int batteamid, int bowlteamid, int strikerid, int nonstriker, int bowlerid, int runonball, int balltype, int wickettype)
            int batteamid = (int)Session["batteamid"];
            int bowlteamid = (int)Session["bowlteamid"];
            int strikerid = (int)Session["striker"];
            int nonstrikerid = (int)Session["nonstriker"];
            int bowlerid = (int)Session["bowler"];
            int runonball = Int32.Parse(ddlrun.SelectedValue);
            int balltype = Int32.Parse(ddlballtype.SelectedValue);
            int wickettype = Int32.Parse(ddlwicket.SelectedValue);


            var wickettyper = JsonConvert.SerializeObject(wickettype);
            var wickettypec = new StringContent(wickettyper, Encoding.UTF8, "application/json");


            var oversr = await client.PutAsync(client.BaseAddress + "/putupdateBall/"+batteamid+"/"+ bowlteamid+"/"+ strikerid+"/"+ nonstrikerid+"/"+ bowlerid+"/"+ runonball+"/"+ balltype, wickettypec);
            // double overs = client.updateBall(batteamid, bowlteamid, strikerid, nonstrikerid, bowlerid, runonball, balltype, wickettype);
            double overs = double.Parse(oversr.Content.ReadAsStringAsync().Result);
            int matchid = (int)Session["matchid"];
            Commentary c = new Commentary
            {
                Match_ID = matchid,
                Over = overs,
                Comment = tbcomment.Text,
            };
            //Adding Commentary
            string se_c = JsonConvert.SerializeObject(c);
            StringContent con_c = new StringContent(se_c, Encoding.UTF8, "application/json");
            System.Net.ServicePointManager.Expect100Continue = false;
            var response = await client.PostAsync(client.BaseAddress + "/insertCommentary", con_c);

           // client.insertCommentary(c);

            Session["overs"] = overs;

            //For wicket, redirect to other page
            if (wickettype != 0)
            {
                Response.Redirect("wicket.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }

            //Change strike in odd runs
            if (runonball == 1 || runonball == 3)
            {
                int temp1 = (int)Session["striker"];
                Session["striker"] = (int)Session["nonstriker"];
                Session["nonstriker"] = temp1;
            }

            double temp = overs - (int)Math.Floor(overs);
            temp = Math.Round((Double)temp, 1);
            if (temp == 0.6 && !Response.IsRequestBeingRedirected)
            {
                Response.Redirect("over.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
            if (!Response.IsRequestBeingRedirected)
            {
                Response.Redirect("scoreboard.aspx",false);
            }
        }

        protected void EndBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("matchEnd.aspx",false);
        }
    }
}