using LiveScoreSystemWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class team : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            string name;
            foreach (int i in Enum.GetValues(typeof(Player.PlayerType)))
            {
                name = Enum.GetName(typeof(Player.PlayerType), i);
                ddlt1p1type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p1type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p2type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p2type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p3type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p3type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p4type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p4type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p5type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p5type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p6type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p6type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p7type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p7type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p8type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p8type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p9type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p9type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p10type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p10type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p11type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p11type.Items.Add(new ListItem(name, i.ToString()));
            }
        }


        protected async void GoBtn_ClickAsync(object sender, EventArgs e)
        {
           //await  AddTeamAsync();

            client.BaseAddress = new Uri("https://localhost:44382/api/Team");
            //Adding teams
            Team team1 = new Team
            {
                Name = tbteam1.Text,
                Score = 0,
                Wideball = 0,
                Noball = 0,
                Wickets = 0,
                Overs = 0,
            };
            Team team2 = new Team
            {
                Name = tbteam2.Text,
                Score = 0,
                Wideball = 0,
                Noball = 0,
                Wickets = 0,
                Overs = 0,
            };

            string se_team1 = JsonConvert.SerializeObject(team1);
            StringContent con_team1 = new StringContent(se_team1, Encoding.UTF8, "application/json");
            string se_team2 = JsonConvert.SerializeObject(team2);
            StringContent con_team2 = new StringContent(se_team2, Encoding.UTF8, "application/json");
            System.Net.ServicePointManager.Expect100Continue = false;
            var teamr1_id = await client.PostAsync(client.BaseAddress + "/insertTeam", con_team1);
            var teamr2_id = await client.PostAsync(client.BaseAddress + "/insertTeam", con_team2);
            int team1_id = Int32.Parse(teamr1_id.Content.ReadAsStringAsync().Result);
            int team2_id = Int32.Parse(teamr2_id.Content.ReadAsStringAsync().Result);
            Session["team1id"] = team1_id;
            Session["team2id"] = team2_id;




            //Adding matches
            //Ending time is after 1 year temporarily
            //Bat first team and toss comment is selected in toss.aspx
            DateTime dt = DateTime.Now;

            //DateTime is immutable
            dt = dt.AddYears(1);
            Match match = new Match
            {
                Name = tbmatchtitle.Text,
                Starttime = DateTime.Now,
                Endtime = dt,
                Overs = Int32.Parse(ddlovers.SelectedValue),
                Batfirstid = -1,
                WinnerId = -1,
                EndComment = "",
                TossComment = "",
                Team1Id = team1_id,
                Team2Id = team2_id
            };
            var se_match = JsonConvert.SerializeObject(match);
            var con_match = new StringContent(se_match, Encoding.UTF8, "application/json");
            var matchr_id =await client.PostAsync("https://localhost:44382/api/Team/insertMatch",con_match);

            int match_id = Int32.Parse(matchr_id.Content.ReadAsStringAsync().Result);
            Session["matchid"] = match_id;




            Player player11 = new Player { Name = t1p1.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p1type.SelectedValue) };
            Player player12 = new Player { Name = t1p2.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p2type.SelectedValue) };
            Player player13 = new Player { Name = t1p3.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p3type.SelectedValue) };
            Player player14 = new Player { Name = t1p4.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p4type.SelectedValue) };
            Player player15 = new Player { Name = t1p5.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p5type.SelectedValue) };
            Player player16 = new Player { Name = t1p6.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p6type.SelectedValue) };
            Player player17 = new Player { Name = t1p7.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p7type.SelectedValue) };
            Player player18 = new Player { Name = t1p8.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p8type.SelectedValue) };
            Player player19 = new Player { Name = t1p9.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p9type.SelectedValue) };
            Player player110 = new Player { Name = t1p10.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p10type.SelectedValue) };
            Player player111 = new Player { Name = t1p11.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p11type.SelectedValue) };


            Player player21 = new Player { Name = t2p1.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p1type.SelectedValue) };
            Player player22 = new Player { Name = t2p2.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p2type.SelectedValue) };
            Player player23 = new Player { Name = t2p3.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p3type.SelectedValue) };
            Player player24 = new Player { Name = t2p4.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p4type.SelectedValue) };
            Player player25 = new Player { Name = t2p5.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p5type.SelectedValue) };
            Player player26 = new Player { Name = t2p6.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p6type.SelectedValue) };
            Player player27 = new Player { Name = t2p7.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p7type.SelectedValue) };
            Player player28 = new Player { Name = t2p8.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p8type.SelectedValue) };
            Player player29 = new Player { Name = t2p9.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p9type.SelectedValue) };
            Player player210 = new Player { Name = t2p10.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p10type.SelectedValue) };
            Player player211 = new Player { Name = t2p11.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p11type.SelectedValue) };


            var se_player11 = JsonConvert.SerializeObject(player11);
            var con_player11 = new StringContent(se_player11, Encoding.UTF8, "application/json");
           await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player11);

            var se_player12 = JsonConvert.SerializeObject(player12);
            var con_player12 = new StringContent(se_player12, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player12);

            var se_player13 = JsonConvert.SerializeObject(player13);
            var con_player13 = new StringContent(se_player13, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player13);

            var se_player14 = JsonConvert.SerializeObject(player14);
            var con_player14 = new StringContent(se_player14, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player14);

            var se_player15 = JsonConvert.SerializeObject(player15);
            var con_player15 = new StringContent(se_player15, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player15);

            var se_player16 = JsonConvert.SerializeObject(player16);
            var con_player16 = new StringContent(se_player16, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player16);

            var se_player17 = JsonConvert.SerializeObject(player17);
            var con_player17 = new StringContent(se_player17, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player17);

            var se_player18 = JsonConvert.SerializeObject(player18);
            var con_player18 = new StringContent(se_player18, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player18);

            var se_player19 = JsonConvert.SerializeObject(player19);
            var con_player19 = new StringContent(se_player19, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player19);

            var se_player110 = JsonConvert.SerializeObject(player110);
            var con_player110 = new StringContent(se_player110, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player110);

            var se_player111 = JsonConvert.SerializeObject(player111);
            var con_player111 = new StringContent(se_player111, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player111);



            //client.insertPlayer(player11);
            //client.insertPlayer(player12);
            //client.insertPlayer(player13);
            //client.insertPlayer(player14);
            //client.insertPlayer(player15);
            //client.insertPlayer(player16);
            //client.insertPlayer(player17);
            //client.insertPlayer(player18);
            //client.insertPlayer(player19);
            //client.insertPlayer(player110);
            //client.insertPlayer(player111);

            var se_player21 = JsonConvert.SerializeObject(player21);
            var con_player21 = new StringContent(se_player21, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player21);

            var se_player22 = JsonConvert.SerializeObject(player22);
            var con_player22 = new StringContent(se_player22, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player22);

            var se_player23 = JsonConvert.SerializeObject(player23);
            var con_player23 = new StringContent(se_player23, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player23);

            var se_player24 = JsonConvert.SerializeObject(player24);
            var con_player24 = new StringContent(se_player24, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player24);

            var se_player25 = JsonConvert.SerializeObject(player25);
            var con_player25 = new StringContent(se_player25, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player25);

            var se_player26 = JsonConvert.SerializeObject(player26);
            var con_player26 = new StringContent(se_player26, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player26);

            var se_player27 = JsonConvert.SerializeObject(player27);
            var con_player27 = new StringContent(se_player27, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player27);

            var se_player28 = JsonConvert.SerializeObject(player28);
            var con_player28 = new StringContent(se_player28, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player28);

            var se_player29 = JsonConvert.SerializeObject(player29);
            var con_player29 = new StringContent(se_player29, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player29);

            var se_player210 = JsonConvert.SerializeObject(player210);
            var con_player210 = new StringContent(se_player210, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player210);

            var se_player211 = JsonConvert.SerializeObject(player211);
            var con_player211 = new StringContent(se_player211, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:44382/api/Team/insertPlayer", con_player211);


            //client.insertPlayer(player21);
            //client.insertPlayer(player22);
            //client.insertPlayer(player23);
            //client.insertPlayer(player24);
            //client.insertPlayer(player25);
            //client.insertPlayer(player26);
            //client.insertPlayer(player27);
            //client.insertPlayer(player28);
            //client.insertPlayer(player29);
            //client.insertPlayer(player210);
            //client.insertPlayer(player211); 

            Response.Redirect("toss.aspx",false);
        }

        //private async Task AddTeamAsync()
        //{
           
           
        //}

    }
}