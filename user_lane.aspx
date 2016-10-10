<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_lane.aspx.cs" Inherits="user_lane" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="ButtonParking" runat="server" OnClick="ButtonParking_Click" Text="MyParking" />
             <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" >
            <Columns>
                 <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%#Eval("index")%>'> </asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%#Eval("username")%>'> </asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                      <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btn" runat="server" CommandArgument='<%#Eval("parking_id")+","+Eval("userid")+","+Eval("index")%>' Text="Fine User" OnClick="Fine_User"> </asp:Button>
                  </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
        </asp:GridView>

            <br />

        </div>
        <div>

            <asp:Button ID="ButtonCarspasked" runat="server" OnClick="ButtonCarspasked_Click" Text="MyCarsParked" />
            <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="false">
            <Columns>
                 <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%#Eval("index")%>'> </asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%#Eval("username")%>'> </asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btn" runat="server" CommandArgument='<%#Eval("carid")+","+Eval("parking_id")+","+Eval("username")%>' Text="Remove Car" OnClick="Remove"> </asp:Button>
                  </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
