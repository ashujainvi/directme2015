<%@ Page Language="C#" AutoEventWireup="true" CodeFile="park.aspx.cs" Inherits="oponentsector" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Park now</title>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"/>
    <link href='http://fonts.googleapis.com/css?family=Slabo+27px' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" type="text/css" href="css/park.css"/>
     
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="container">
            <div class="logo"><img src="../img/logo.png" width="170" /> </div>

            <div class="heading"><h1>Select Parking lot type</h1>
            <p>Select a parking lot where you would like to park your car</p>
                <p>in <strong>Sector<strong runat="server" id="lbl_sector"></strong> </strong> </p>
                <h2 runat="server" id="parked_success" visible="false">Parked Successfully.</h2>
                <p>Go back to your <a href="garage.aspx"><strong>Garage</strong></a> </p>
                 <asp:Button Text="Want to earn more" ID="btn_earn_more" Visible="false" runat="server" OnClick="Unnamed_Click" />
            </div>
            <div class="cloud">
                <div id="cloud1"><img src="img/cloud1.png" id="cloud1Image" /></div>
                <div id="cloud2"><img src="img/cloud2.png" id="cloud2Image" /></div>
                
            </div>
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            
            <ContentTemplate>
                <asp:UpdateProgress runat="server">
                    <ProgressTemplate>
                        <img src="~/images/ajax-loader.gif"  style="height:33px;" runat="server"/>
                    </ProgressTemplate>
                </asp:UpdateProgress>
              <%--   <asp:Button runat="server" Text="Public" ID="btn_public" OnClick="btn_public_Click" />
                <asp:Button runat="server" Text="Private" ID="btn_private" OnClick="btn_private_Click" />--%>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        
       
                <asp:GridView runat="server" ID="grid_public" AutoGenerateColumns="false">
                    <Columns>
                        
                         <asp:BoundField HeaderText="Sector" DataField="sector_id"/>   
                        
                        <asp:TemplateField HeaderText="Is vacant" >
                            <ItemTemplate>
                                <%#IsVacant(Convert.ToBoolean(Eval("isvacant"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Is Allowed" >
                            <ItemTemplate>
                                <%#IsAllowed(Convert.ToBoolean(Eval("allowed"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate>
                               <asp:Button runat="server" Text='<%#IsVacant(Convert.ToBoolean(Eval("isvacant"))) == "Yes" ? "Choose":"Unavailable"%>' Enabled='<%#IsVacant(Convert.ToBoolean(Eval("isvacant"))) == "Yes" ? true:false %>' OnClick="btn_public_park" CommandArgument='<%#Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        <asp:GridView runat="server" ID="grid_private" AutoGenerateColumns="false">
            <Columns>
                        
                         <asp:BoundField HeaderText="Sector" DataField="sector_id"/>   
                <asp:BoundField HeaderText="Owner Name" DataField="UserName"/>   
                        

                        <asp:TemplateField HeaderText="Is vacant" >
                            <ItemTemplate>
                                <%#IsVacant(Convert.ToBoolean(Eval("isvacant"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Is Allowed" >
                            <ItemTemplate>
                                <%#IsAllowed(Convert.ToBoolean(Eval("allowed"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate>
                               <asp:Button runat="server" Text="Choose" OnClick="btn_private_park" CommandArgument='<%#Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
        </asp:GridView>
          
			<div class="footer">
				<!--<img src="img/road6.png" id="roadImage"/>-->
			</div>
            <div class="carContainer">
                <div class="car"><img src="img/car.png" ></div>                
            </div>
             
      
    </div>
       

   


		<!-- container ends -->
    </form>
    <script src="Scripts/jquery-2.1.3.js"></script>
</body>

</html>
