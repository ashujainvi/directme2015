<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oponentsector.aspx.cs" Inherits="oponentsector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Oponent Sector</title>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"/>
    <link href='http://fonts.googleapis.com/css?family=Slabo+27px' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" type="text/css" href="css/opponentsector.css"/>
     <script>

        
         function div_click(div) {
             var c = $(div).attr('id');
             console.log(c);
             var d = $('#' + c);
             var sector = d.children("#hidden").attr("value");
           console.log(sector);
           $("#hidden_server").val(sector);
           console.log($("#hidden_server").attr("value"));
         }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
            <div class="logo"><img src="../img/logo.png" width="170" /> </div>

            <div class="heading"><h1>Select Sector</h1>
            <p>Select a sector where you would like to park your car</p>
                <p>and then, <strong>click Continue.</strong> </p>
            </div>
           <!-- <div class="cloud">
                <div id="cloud1"><img src="img/cloud1.png" id="cloud1Image" /></div>
                <div id="cloud2"><img src="img/cloud2.png" id="cloud2Image" /></div>
                
            </div>-->
        <asp:ScriptManager runat="server" />
     <%--   <asp:UpdatePanel runat="server">
            
            <ContentTemplate>
                <asp:UpdateProgress runat="server">
                    <ProgressTemplate>
                        <img src="~/images/ajax-loader.gif"  style="height:33px;" runat="server"/>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                 <asp:Button runat="server" Text="Public" ID="btn_public" OnClick="btn_public_Click" />
                <asp:Button runat="server" Text="Private" ID="btn_private" OnClick="btn_private_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>--%>
       
            <div class="buildingContainer">

                
                <div id="building1Div" class="building" onclick="div_click(this)">
                    <div class="arrowDown"><img src="img/arrowdown.png" width="32" /></div>
                    <img src="img/building/building1.png" class="buildingImage" style="width:200px;" />
                    <input type="hidden" id="hidden" value="1" />

                </div>
                <div id="building2Div" class="building" onclick="div_click(this)">
                    <div class="arrowDown"><img src="img/arrowdown.png" width="32" /></div>
                    <img src="img/building/building2.png" class="buildingImage" />
                    <input type="hidden" id="hidden" value="2" />
                </div>
                <div id="building3Div" class="building" onclick="div_click(this)">
                    <div class="arrowDown"><img src="img/arrowdown.png" width="32" /></div>
                    <img src="img/building/building3.png" class="buildingImage" style="width:200px;" />
                    <input type="hidden" id="hidden" value="3" />
                </div>
                <div id="building4Div" class="building" onclick="div_click(this)">
                    <div class="arrowDown"><img src="img/arrowdown.png" width="32" /></div>
                    <img src="img/building/building4.png" class="buildingImage" />
                    <input type="hidden" id="hidden" value="4" />
                </div>

            </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
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
                               <asp:Button runat="server" Text="Choose" OnClick="btn_public_park" CommandArgument='<%#Eval("id") %>' />
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
            </ContentTemplate>
        </asp:UpdatePanel>
        
			<div class="footer">
				<!--<img src="img/road6.png" id="roadImage"/>-->
			</div>
            <div class="carContainer">
                <div class="car"><img src="img/car.png" ></div>                
            </div>
             
        <div >
        <asp:Button  class="continue" runat="server" Text="Continue" OnClick="Unnamed_Click" />
            </div>

		</div>
        <asp:HiddenField runat="server" id="hidden_server" />

   


		<!-- container ends -->
    </form>
    <script src="Scripts/jquery-2.1.3.js"></script>
</body>

</html>
