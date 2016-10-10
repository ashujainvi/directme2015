<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaderBoard.aspx.cs" Inherits="LeaderBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leaderboard</title>
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <link href="css/leaderboard.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Slabo+27px' rel='stylesheet' type='text/css' />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row heading">
                <h1>The Leaders</h1>
                <div>
                    <asp:GridView runat="server" ID="grid_leaders" class="table table-hover" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="grid_leaders_PageIndexChanging"  PageSize="10">

                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="User Name" />
                            <asp:BoundField DataField="networth" HeaderText="Collection" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
