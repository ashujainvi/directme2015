<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
        <title>Shop</title>
        <link rel="shortcut icon" href="../favicon.ico"/> 
        <link rel="stylesheet" type="text/css" href="css1/style.css" />
		<link href='http://fonts.googleapis.com/css?family=Dosis:200,400,700' rel='stylesheet' type='text/css'/>
		<script type="text/javascript" src="js/modernizr.custom.79639.js"></script>
		<noscript><link rel="stylesheet" type="text/css" href="css1/noscript.css" /></noscript>
</head>
<body>
    <form id="form1" runat="server">
    <section id="ps-container" class="ps-container">
		
			<div class="ps-header">
				<h1><img src="../img/logo.png" width="140" style="padding:20px;" />Choose your Car.</h1>
			</div><!-- /ps-header -->
			
        <asp:ScriptManager runat="server" />
            <div class="ps-contentwrapper">

                 <asp:Repeater runat="server" ID="d">
            <ItemTemplate>
                <div class="ps-content">
                    <h2>Vehicle : <%#Eval("carname") %></h2>
                    <span class="ps-price"> &#8377; <%#Eval("cost") %></span>
                    <p>Revenue generated : <strong> &#8377; <%#Eval("base_revenue") %>/hour </strong> prevents static sitting and provides enhanced seating comfort. Padded seat and back for enhanced seating comfort. Soft, hardwearing and easy care leather, which ages gracefully.</p>
                  
                             <asp:LinkButton CommandArgument='<%#Eval("carId") %>' OnClick="buy_Click" runat="server" ID="buy">Buy this car</asp:LinkButton>
                      
                    
                 
                  
                 
                </div>
            </ItemTemplate>
        </asp:Repeater>
           
            </div><!-- /ps-contentwrapper -->
			
			<div class="ps-slidewrapper">
			
				<div class="ps-slides">
                    <asp:Repeater runat="server" ID="a">
                        <ItemTemplate>
                            <div style="background-image: url(<%# Eval("car_icon") %>); background-size:contain;"></div>
                        </ItemTemplate>
                    </asp:Repeater>
			
				</div>
				
				<nav>
					<a href="#" class="ps-prev" ></a>
					<a href="#" class="ps-next" ></a>
				</nav>
				
			</div><!-- /ps-slidewrapper -->
			
		</section><!-- /ps-container -->
			
		<!-- jQuery if needed -->
        <script src="js/jquery-1.10.2.js"></script>
        <script src="Scripts/jquery-2.1.3.js"></script>
       <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>--%>
		<script type="text/javascript" src="js/slider.js"></script>
		<script type="text/javascript">
		    $(function () {

		        Slider.init();

		    });
		</script>
    </form>
</body>
</html>

