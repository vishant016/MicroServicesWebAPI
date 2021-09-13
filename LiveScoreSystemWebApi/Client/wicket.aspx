<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="wicket.aspx.cs" Inherits="Client.wicket" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <title>Wicket</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="card" style="border:groove">
                        <div class="card-header bg-dark" style="color:white;">
                            <h3 class="card-title" style="text-align:center">Wicket</h3>
                            <h4 class="card-subtitle" style="text-align:center"><asp:Label ID="lbmatchtitle" runat="server" Text="Match Title"></asp:Label></h4><br />
                            <h4 class="card-subtitle" style="text-align:center"><asp:Label ID="lbteam1" runat="server" Text="Team1"></asp:Label> VS <asp:Label ID="lbteam2" runat="server" Text="team2"></asp:Label></h4>
                            <p class="card-subtitle" style="text-align:center">&nbsp;</p>
                        </div>
                        <div class="card-body" style="text-align:center;">
                            <br />
                            <p>Select next batsman:</p>
                            <asp:DropDownList ID="ddlnextbat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlnextbat_SelectedIndexChanged">
                                <asp:ListItem Value="-1">Select Here</asp:ListItem>
                            </asp:DropDownList><br /><br />
                            <p>Select Striker:</p>
                            <asp:DropDownList ID="ddlbat" runat="server">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="GoBtn" runat="server" OnClick="GoBtn_Click" Text="Go"
                                    CssClass="btn btn-outline-dark btn-lg btn-block" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>