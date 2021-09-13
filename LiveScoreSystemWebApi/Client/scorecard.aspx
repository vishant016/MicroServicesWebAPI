<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="scorecard.aspx.cs" Inherits="Client.scorecard" %>


<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
            integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
            integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
            crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
            integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
            crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
            integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
            crossorigin="anonymous"></script>


        <title>scorecard</title>
        <style type="text/css">
            .auto-style1 {
                width: 166px;
            }
            .auto-style2 {
                width: 18px;
            }
            .auto-style8 {
                margin-bottom: .75rem;
                margin-left: 360px;
            }
            .auto-style9 {
                margin-bottom: .75rem;
                margin-left: 240px;
            }
        </style>
    </head>

    <body>
        <div class="container-fluid" style="padding-top:50px" style="text-align:center;">
            <form id="form1" runat="server">
                <!-- Match winner -->
                <h2>
                    <asp:Label ID="Label457" runat="server" Text="Match result"></asp:Label>
                </h2>
                <h2>Winner:&nbsp;<asp:Label ID="lbwinner" runat="server" Text="Winner"></asp:Label></h2>
                <h2><asp:Label ID="lbendcom" runat="server" Text=""></asp:Label></h2>
                <div class="row">
                    <!-- for team 1 -->
                    <div class="col col-md-6 support-article">
                        <!-- Batting order -->
                        <div class="card" style="border:groove;">
                            <div class="card-header">
                                <h3 class="card-title" style="text-align:center">
                                    &nbsp;</h3>
                                <h3 class="card-title" style="text-align:center">
                                    <asp:Label ID="lbteam1" runat="server" Text="team1"></asp:Label>
                                    
                                </h3>
                                <h3 class="card-title" style="text-align:center">
                                    <asp:Label ID="lbscore1" runat="server" Text="0"></asp:Label>
                                    /<asp:Label ID="lbwick1" runat="server" Text="0"></asp:Label>
                                    &nbsp;&nbsp;
                                    Over: <asp:Label ID="lbover1" runat="server" Text="0.0"></asp:Label>
                                    
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RR.
                                    <asp:Label ID="lbrr1" runat="server" Text="0.0"></asp:Label>
                                    
                                </h3>
                            </div>
                            <div class="card-header">
                                <h5 class="card-title" style="text-align:left">
                                    Batting Order
                                </h5>
                            </div>
                            <div class="card-body">
                                <table class="table">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Player Name</th>
                                            <th scope="col">&nbsp;</th>
                                            <th scope="col">Run</th>
                                            <th scope="col">Ball</th>
                                            <th scope="col">4s</th>
                                            <th scope="col">6s</th>
                                            <th scope="col">Strike-Rate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- Team1 Batsmans -->
                                        <%for (int i = 0; i < bat1.Count; i++)
                                            {%>
                                        <tr>
                                            <th scope="row">
                                                <label><%=bat1[i].Name %></label>
                                            </th>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <label><%=bat1[i].Batruns %></label>
                                            </td>
                                            <td>
                                                <label><%=bat1[i].Balls %></label>
                                            </td>
                                            <td>
                                                <label><%=bat1[i].Fours %></label>
                                            </td>
                                            <td>
                                                <label><%=bat1[i].Sixes %></label>
                                            </td>
                                            <td>
                                                <label><%=bat1[i].Strikerate %></label>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!-- bowling order -->
                        <div class="card" style="border:groove;">
                            <div class="card-header">
                                <h5 class="auto-style9" style="text-align:left">
                                    Wide ball:&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lbwide1" runat="server" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; No ball:&nbsp;
                                    <asp:Label ID="lbnoball1" runat="server" Text="0"></asp:Label>
                                </h5>
                                <h4 class="card-title" style="text-align:left">
                                    Bowlers</h4>
                            </div>
                            <div class="card-body">
                                <table class="table">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Player Name</th>
                                            <th scope="col">Over</th>
                                            <th scope="col">Run</th>
                                            <th scope="col" class="auto-style1">Wicket</th>
                                            <th scope="col" class="auto-style2">&nbsp;</th>
                                            <th scope="col">&nbsp;</th>
                                            <th scope="col">Economy</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- Bowlers1 -->
                                        <%for (int i = 0; i < bowl1.Count; i++)
                                            {%>
                                        <tr>
                                            <th scope="row">
                                                <label><%=bowl1[i].Name %></label>
                                            </th>
                                            <td>
                                                <label><%=bowl1[i].Overs %></label>
                                            </td>
                                            <td>
                                                <label><%=bowl1[i].Bowlruns %></label>
                                            </td>
                                            <td>
                                                <label><%=bowl1[i].Wickets %></label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <label><%=bowl1[i].Economy %></label>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <!-- for team 2  -->
                    <div class="col col-md-6 support-article">
                        
                        <!-- Batting order -->
                        <div class="card" style="border:groove;">
                            <div class="card-header">
                                <h3 class="card-title" style="text-align:center">
                                    &nbsp;</h3>
                                <h3 class="card-title" style="text-align:center">
                                    <asp:Label ID="lbteam2" runat="server" Text="team2"></asp:Label>
                                    
                                </h3>
                                <h3 class="card-title" style="text-align:center">
                                    <asp:Label ID="lbscore2" runat="server" Text="0"></asp:Label>
                                    /<asp:Label ID="lbwick2" runat="server" Text="0"></asp:Label>
                                    &nbsp;&nbsp;
                                    Over: <asp:Label ID="lbover2" runat="server" Text="0.0"></asp:Label>
                                    
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RR.
                                    <asp:Label ID="lbrr2" runat="server" Text="0.0"></asp:Label>
                                    
                                </h3>
                            </div>
                            <div class="card-header">
                                <h5 class="card-title" style="text-align:left">
                                    Batting Order
                                </h5>
                            </div>
                            <div class="card-body">
                                <table class="table">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Player Name</th>
                                            <th scope="col">&nbsp;</th>
                                            <th scope="col">Run</th>
                                            <th scope="col">Ball</th>
                                            <th scope="col">4s</th>
                                            <th scope="col">6s</th>
                                            <th scope="col">Strike-Rate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- 1 -->
                                        <%for (int i = 0; i < bat2.Count; i++)
                                            {%>
                                        <tr>
                                            <th scope="row">
                                                <label><%=bat2[i].Name %></label>
                                            </th>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <label><%=bat2[i].Batruns %></label>
                                            </td>
                                            <td>
                                                <label><%=bat2[i].Balls %></label>
                                            </td>
                                            <td>
                                                <label><%=bat2[i].Fours %></label>
                                            </td>
                                            <td>
                                                <label><%=bat2[i].Sixes %></label>
                                            </td>
                                            <td>
                                                <label><%=bat2[i].Strikerate %></label>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <!-- bowling order -->
                        <div class="card" style="border:groove;">
                            <div class="card-header">
                                <h5 class="auto-style8" style="text-align:left">
                                    Wide ball:&nbsp;&nbsp;&nbsp; <asp:Label ID="lbwide2" runat="server" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; No ball:&nbsp;
                                    <asp:Label ID="lbnoball2" runat="server" Text="0"></asp:Label>
                                </h5>
                                <h4 class="card-title" style="text-align:left">
                                    Bowlers</h4>
                            </div>
                            <div class="card-body">
                                <table class="table">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Player Name</th>
                                            <th scope="col">Over</th>
                                            <th scope="col">Run</th>
                                            <th scope="col">Wicket</th>
                                            <th scope="col">&nbsp;</th>
                                            <th scope="col">&nbsp;</th>
                                            <th scope="col">Economy</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- 1 -->
                                        <%for (int i = 0; i < bowl2.Count; i++)
                                            {%>
                                        <tr>
                                            <th scope="row">
                                                <label><%=bowl2[i].Name %></label>
                                            </th>
                                            <td>
                                                <label><%=bowl2[i].Overs %></label>
                                            </td>
                                            <td>
                                                <label><%=bowl2[i].Bowlruns %></label>
                                            </td>
                                            <td>
                                                <label><%=bowl2[i].Wickets %></label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <label><%=bowl2[i].Economy %></label>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!-- end of row -->
                </div>
            </form>
        </div>
    </body>

    </html>