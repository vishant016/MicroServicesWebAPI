<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="matchEnd.aspx.cs" Inherits="Client.matchEnd" %>


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
    <title>Match End</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="card" style="border:groove">
                        <div class="card-header bg-dark" style="color:white;">
                            <h3 class="card-title" style="text-align:center">Match Ending</h3>
                            <h4 class="card-subtitle" style="text-align:center"><asp:Label ID="lbmatchtitle" runat="server" Text="Match Title"></asp:Label></h4>
                            <p class="card-subtitle" style="text-align:center">&nbsp;</p>
                            <h4 class="card-subtitle" style="text-align:center"><asp:Label ID="lbteam1" runat="server" Text="Team1"></asp:Label> VS <asp:Label ID="lbteam2" runat="server" Text="team2"></asp:Label></h4>
                            <p class="card-subtitle" style="text-align:center">&nbsp;</p>
                        </div>
                        <div class="card-body">
                            <p>Winning Team:</p>
                            <asp:DropDownList ID="ddlwinteam" runat="server"></asp:DropDownList>
                            <p>Ending Comment:</p>
                            <asp:TextBox ID="taendcom" TextMode="multiline" Columns="50" Rows="2" runat="server" /><br/><br />
                            <asp:Button ID="EndBtn" runat="server" OnClick="EndBtn_Click" Text="End Match"
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