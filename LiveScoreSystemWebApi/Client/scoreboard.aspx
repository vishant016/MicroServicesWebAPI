<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="scoreboard.aspx.cs" EnableEventValidation="false" Inherits="Client.scoreboard" %>

<%@import Namespace ="LiveScoreSystemWebApi" %>
<%@import Namespace="System" %>
<%@import Namespace="Client" %>
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

        <title>Update</title>
    </head>

    <body>
        <div class="container-fluid" style="padding-top:50px">

            <form id="form1" runat="server">

                <div class="row">
                    <div class="col col-md-2"></div>

                    <div class="col col-md-8 support-article">
                        <!-- top area -->
                        <div class="card" style="border:groove;">
                            <div class="card-header" style="text-align:center;">
                                <h4 class="card-title" style="text-align:center"><asp:Label ID="lbmatchtitle" runat="server" Text="Match Title"></asp:Label></h4><br />
                                <h4 class="card-subtitle" style="text-align:center"><asp:Label ID="lbteam1" runat="server" Text="Team1"></asp:Label> &nbsp;VS <asp:Label ID="lbteam2" runat="server" Text="team2"></asp:Label></h4>
                                <p class="card-subtitle" style="text-align:center">&nbsp;</p>
                                <asp:Label ID="lbtoss" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lbinning" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lbtarget" runat="server" Text=""></asp:Label>
                                <br />
                                <br />
                            </div>
                            <div class="card-body">
                                <table class="table table-striped">

                                    <thead class="thead-dark">

                                        <tr>
                                            <th scope="col">Team</th>
                                            <th scope="col">Score</th>
                                            <th scope="col">Over</th>
                                            <th scope="col">Run Rate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">
                                                <asp:Label ID="lbbatteam" runat="server" Text="Team1"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:Label ID="lbtscore" runat="server" Text="0"></asp:Label> / <asp:Label
                                                    ID="lbtwickets" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td> <asp:Label ID="lbtover" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                            <td> &nbsp;&nbsp; RR.<asp:Label ID="lbtrr" runat="server" Text="0.0">
                                                </asp:Label>
                                            </td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <br />

                        <!-- batting area -->
                        <div class="card" style="border:groove;">
                            <div class="card-body">
                                <table class="table table-striped">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Batsman</th>
                                            <th scope="col">Run</th>
                                            <th scope="col">Ball</th>
                                            <th scope="col">4</th>
                                            <th scope="col">6</th>
                                            <th scope="col">Strike-Rate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- stricker -->
                                        <tr>
                                            <th scope="row">
                                                <asp:Label ID="lbbat1name" runat="server" Text="Batsman1"></asp:Label><asp:Label ID="lbbat1strike" runat="server" Text="(*)"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:Label ID="lbbat1runs" runat="server" Text="R"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat1balls" runat="server" Text="B"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat1fours" runat="server" Text="4"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat1sixes" runat="server" Text="6"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat1strk" runat="server" Text="sr."></asp:Label>
                                            </td>
                                        </tr>
                                        <!-- Non-stricker -->
                                        <tr>
                                            <th scope="row">
                                                <asp:Label ID="lbbat2name" runat="server" Text="Batsman2"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:Label ID="lbbat2runs" runat="server" Text="R"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat2balls" runat="server" Text="B"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat2fours" runat="server" Text="4"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat2sixes" runat="server" Text="6"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbat2strk" runat="server" Text="sr."></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <br />

                        <!-- Current Bowler -->

                        <div class="card" style="border:groove;">
                            <div class="card-body">
                                <table class="table table-striped">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Bowler</th>
                                            <th scope="col">Over</th>
                                            <th scope="col">Run</th>
                                            <th scope="col">Wicket</th>
                                            <th scope="col">Economy</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">
                                                <asp:Label ID="lbbowl" runat="server" Text="Bowler"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:Label ID="lbbowlover" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbowlrun" runat="server" Text="R"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbowlwick" runat="server" Text="W"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbowleco" runat="server" Text="Economy"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <br />

                        <!-- Host side work -->

                        <div class="card" style="border:groove">
                            <div class="card-body">
                                <table class="table table-striped">

                                    <tbody>
                                        <tr>
                                            <th scope="row">Run on Ball </th>
                                            <td>
                                                <asp:DropDownList ID="ddlrun" runat="server">
                                                    <asp:ListItem Selected="True" Value="0">0 Run</asp:ListItem>
                                                    <asp:ListItem Value="1">1 Run</asp:ListItem>
                                                    <asp:ListItem Value="2">2 Run</asp:ListItem>
                                                    <asp:ListItem Value="3">3 Run</asp:ListItem>
                                                    <asp:ListItem Value="4">4 Run</asp:ListItem>
                                                    <asp:ListItem Value="6">6 Run</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Ball Type </th>
                                            <td>
                                                <asp:DropDownList ID="ddlballtype" runat="server">
                                                    <asp:ListItem Selected="True" Value="0">Normal Ball</asp:ListItem>
                                                    <asp:ListItem Value="1">Wide Ball</asp:ListItem>
                                                    <asp:ListItem Value="2">No Ball</asp:ListItem>
                                                    <asp:ListItem Value="3">Leg bye</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Wicket</th>
                                            <td>
                                                <asp:DropDownList ID="ddlwicket" runat="server">
                                                    <asp:ListItem Selected="True" Value="0">&nbsp;No wicket</asp:ListItem>
                                                    <asp:ListItem Value="1">&nbsp;Striker&#39;s Wicket</asp:ListItem>
                                                    <asp:ListItem Value="2">&nbsp;Striker run out</asp:ListItem>
                                                    <asp:ListItem Value="3">&nbsp;Non-Striker run out</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Commentory</th>
                                            <td>
                                                <asp:TextBox ID="tbcomment" runat="server" Height="55px" Width="516px"></asp:TextBox>
                                            </td>
                                        </tr>
                                         </tbody>
                                    
                                </table>
                                <br />
                                <!-- submit button (submit on every ball) -->
                                <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_ClickAsync" Text="Update" Height="55px" Width="137px"
                                    CssClass="btn btn-outline-dark btn-lg btn-block" />
                               
                                <!-- button 2 -->
                                <!-- *end match*  so that we can keep track of match wether it is over or not. -->
                                <asp:Button ID="EndBtn" runat="server" OnClick="EndBtn_Click" Text="End Match" Height="55px" Width="137px"
                                    CssClass="btn btn-outline-dark btn-lg btn-block" />

                            </div>

                        </div>

                        <!--Commentary-->
                        <div class="card" style="border:groove">
                            <div class="card-body">
                                <table class="table table-striped">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Over</th>
                                            <th scope="col">Commentary</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%for(int i=0; i<c.Count; i++){%>
                                                
                                        <tr>
                                            <td><label><%=c[i].Over.ToString()%></label></td>
                                            <td><label><%=c[i].Comment%></label></td>
                                        </tr>
                                        
                                        <%}%>   
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col col-md-2"></div>
                </div>

            </form>
        </div>
    </body>

    </html>