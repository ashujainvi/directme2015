<%@ Page Language="C#" AutoEventWireup="true" CodeFile="garage.aspx.cs" EnableEventValidation="false" Inherits="garage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Garage</title>
    <link rel="stylesheet" type="text/css" href="css1/stylemodal.css" />
    <link href='http://fonts.googleapis.com/css?family=Dosis:200,400,700' rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="js/modernizr.custom.79639.js"></script>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"/>

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>


    <link href="css/garage.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Slabo+27px' rel='stylesheet' type='text/css' />


</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />


        <section class="rain"></section>

        <div class="container">
            <div class="helloMsg">
                <div class="herrbrueckers"></div>
                <h1 class="helloTxt">Howdy, <span id="name" style="text-transform: capitalize" runat="server"></span></h1>
            </div>


            <div class="logout">
                <img src="img/login.png" width="60" /><h4>logout</h4>
            </div>

            <%--     <div class="logo">
                <img src="img/logo.png" width="260" />
            </div>--%>



            <div class="leftContent">
                <div class="park light">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <h1>
                                <asp:LinkButton runat="server" OnClick="Unnamed_Click">Park Now</asp:LinkButton></h1>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="hvrGrow key key1 light " data-toggle="modal" data-target="#ViewParkedCarsModal">
                    <h1>Parked Cars</h1>
                </div>

                <div class="hvrGrow key key2 light" data-toggle="modal" data-target="#UsersParked">
                    <h1>My Parking</h1>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                         <asp:Button Text=">Previous Parking" class="hvrGrow key key2 light" OnClick="Unnamed_Click2"  runat="server" >
               
                </asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
             <%--   <div  data-toggle="modal" data-target="#PreviousParkingLog">
                   
                </div>--%>

            </div>



            <div class="rightInfo">
                <span>&#8377;<p runat="server" id="money"></p>
                </span>
            </div>
            <div class="rightContent">
                <div>
                    <a href="shop.aspx">
                        <img src="img/shop.png" /><h4>Shop</h4>
                    </a>
                </div>
                <div>
                    <a href="leaderboard.aspx" target="_blank">
                        <img src="img/leader.png" /><h4>Leaderboard</h4>
                    </a>
                </div>
                <div>
                    <a href="rules.aspx" target="_blank">
                        <img src="img/rules.png" />
                        <h4>Rules</h4>
                    </a>
                </div>

            </div>

            <div class="carContainer" data-toggle="modal" data-target="#ViewCarsModal">
                <div class="arrowDown">
                    <img src="img/arrowdown.png" width="32" />
                </div>
                <h2>View your cars.</h2>
                <img src="img/car.png" width="340" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%--======================ALL MODALS===========================================--%>
                    <!-- YOUR CARS Modal -->
                    <div class="modal fade" id="ViewCarsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h2 class="modal-title" id="myModalLabel">Your Cars</h2>

                                </div>
                                <div class="modal-body">

                                    <asp:GridView runat="server" class="table table-hover" ID="gris_cars_with_user" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="carname" HeaderText="Car Name" />
                                            <asp:BoundField DataField="cost" HeaderText="Cost" />
                                            <asp:BoundField DataField="base_revenue" HeaderText="Base Revenue" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button runat="server" CommandArgument='<%# Eval("carId") %>' Enabled='<%# GetCarStatus(Convert.ToInt32(Eval("carId")),Convert.ToInt32(Session["ttid"])) %>' Text='<%# GetCarStatus(Convert.ToInt32(Eval("carId")),Convert.ToInt32(Session["ttid"])) ? "Sell Car" :"Car Already Parked" %>' ID="btn_sell_car_modal" OnClick="btn_sell_car_modal_Click" />
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--modal ends--%>

                    <!-- Sell CAR Modal -->
                    <div class="modal fade" id="sell_car" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h2 class="modal-title" id="">Are you sure you want to sell this car..??? </h2>

                                </div>

                                <div class="modal-footer">
                                    <asp:Button Text="Confirm" class="btn btn-default" OnClick="btn_sell_car_Click" runat="server" />
                                    <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--modal ends--%>
                </ContentTemplate>
            </asp:UpdatePanel>




            <!-- Choose CAR Modal -->
            <div class="modal fade" id="ChooseCarsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h2 class="modal-title" id="myModalLabel">Please choose any car to park</h2>

                        </div>
                        <div class="modal-body">

                            <asp:GridView runat="server" class="table table-hover" ID="grid_choose_car" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="carname" HeaderText="Car Name" />
                                    <asp:BoundField DataField="cost" HeaderText="Cost" />
                                    <asp:BoundField DataField="base_revenue" HeaderText="Base Revenue" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button runat="server" Enabled='<%# GetCarStatus(Convert.ToInt32(Eval("carId")),Convert.ToInt32(Session["ttid"])) %>' CommandArgument='<%# Eval("carId") %>' Text="Choose Car" ID="btn_choose_car" OnClick="btn_choose_car_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <section id="ps-container" class="ps-container" style="min-width: 500px; max-width: 540px; min-height: 400px;">


                                <div class="ps-contentwrapper">
                                    <asp:Repeater runat="server" ID="d">
                                        <ItemTemplate>
                                            <div class="ps-content">
                                                <h2>Vehicle : <%#Eval("carname") %></h2>

                                                <p>
                                                    Revenue generated : <strong>&#8377;<%#Eval("base_revenue") %>/hour </strong>

                                                </p>
                                                <asp:LinkButton CommandArgument='<%#Eval("carId") %>' Enabled='<%# GetCarStatus(Convert.ToInt32(Eval("carId")),Convert.ToInt32(Session["ttid"])) %>' OnClick="btn_choose_car_Click" runat="server" ID="buy"><%# GetCarStatus(Convert.ToInt32(Eval("carId")),Convert.ToInt32(Session["ttid"])) ? "Choose this car" :"Car Already Parked" %></asp:LinkButton>






                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <%-- <div class="ps-content">
                    <h2>Vehicle 1 : The scooter</h2>
                    
                    <p>Revenue generated : <strong> &#8377;100/hour</strong>
                </div>

                <div class="ps-content">
                    <h2>Vehicle 2 : The scooter</h2>
                    
                    <p>Revenue generated : <strong> &#8377; 100/hour </strong>
                </div>

                <div class="ps-content">
                    <h2>Vehicle 3 : The scooter</h2>
                  
                    <p>Revenue generated : <strong> &#8377; 100/hour </strong>
                </div>--%>
                                </div>
                                <!-- /ps-contentwrapper -->

                                <div class="ps-slidewrapper">

                                    <div class="ps-slides">
                                        <%--<div style="background-image: url(images/1.png); background-size:contain;"></div>
					<div style="background-image: url(images/2.png); background-size: contain;"></div>
					<div style="background-image: url(images/3.png); background-size: contain;"></div>--%>

                                        <asp:Repeater runat="server" ID="a">
                                            <ItemTemplate>
                                                <div style="background-image: url(<%# Eval("car_icon") %>); background-size: contain;"></div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>



                                    <nav>
                                        <a href="#" class="ps-prev"></a>
                                        <a href="#" class="ps-next"></a>
                                    </nav>

                                </div>
                                <!-- /ps-slidewrapper -->

                            </section>
                            <!-- /ps-container -->

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%--modal ends--%>

            <!-- my parking Modal -->
            <div class="modal fade" id="PreviousParkingLog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h2 class="modal-title" id="myModalLabel">Previous Parking</h2>

                        </div>
                        <div class="modal-body">


                            <br />
                            <br />

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <h2>Your Parkings on Private Lanes</h2>
                                    <asp:GridView runat="server" ID="grid_previous" class="table table-hover" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="grid_previous_PageIndexChanging"  PageSize="3">

                                        <Columns>
                                            <asp:BoundField DataField="UserName" HeaderText="Lane Owner" />
                                            <asp:BoundField DataField="ParkedOn" HeaderText="Lane Type" />
                                            <asp:BoundField DataField="ParkingDate" HeaderText="Parked On" />
                                            <asp:BoundField DataField="IsSuccess" HeaderText="Status" />
                                            <asp:BoundField DataField="Revenue" HeaderText="Revenue" />
                                            <asp:BoundField DataField="Fine" HeaderText="Fine" />

                                        </Columns>
                                    </asp:GridView>

                                    <br />
                                    <h2>Your Parkings on Public Lanes</h2>
                                    <asp:GridView runat="server" ID="GridView_public_logs" class="table table-hover" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView_public_logs_PageIndexChanging"  PageSize="3">

                                        <Columns>


                                            <asp:BoundField DataField="ParkingDate" HeaderText="Parked On" />
                                            <asp:BoundField DataField="IsSuccess" HeaderText="Status" />
                                            <asp:BoundField DataField="Revenue" HeaderText="Revenue" />
                                            <asp:BoundField DataField="Fine" HeaderText="Fine" />

                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%--======================ALL MODALS===========================================--%>
            <!-- YOUR CARS Modal -->
            <div class="modal fade" id="UsersParked" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h2 class="modal-title" id="myModalLabel">Your Cars</h2>

                        </div>
                        <div class="modal-body">


                            <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField HeaderText="Car Owner" DataField="username" />


                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button Text="Fine" CommandArgument='<%#Eval("parking_id") %>' runat="server" ID="btn_fine" OnClick="btn_fine_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%--modal ends--%>



            <!--  parked cars Modal -->
            <div class="modal fade" id="ViewParkedCarsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h2 class="modal-title" id="myModalLabel">Cars Parked by you</h2>

                        </div>
                        <div class="modal-body">
                            <asp:GridView runat="server" class="table table-hover" ID="grid_view_parked_cars" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="index" HeaderText="S.No." />
                                    <asp:BoundField DataField="username" HeaderText="Lane Owner" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button Text="Remove" CommandArgument='<%#Eval("carid") %>' runat="server" OnClick="Unnamed_Click1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>


                            </asp:GridView>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%--modal ends--%>


            <%--POP_UP MODAL for no cars--%>

            <div class="modal fade" id="NoCarsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h2 class="modal-title" id="myModalLabel">Sorry, No Car</h2>

                        </div>
                        <div class="modal-body">
                            You have no cars to park, in your garage.
                              
                              <a href="Shop.aspx">Please buy a car.</a>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%--modal ends--%>
        </div>
        <%--container ends--%>
    </form>
</body>

<!-- Latest compiled and minified JavaScript -->
<script src="//code.jquery.com/jquery-1.11.2.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<!-- jQuery if needed -->

<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript">
    $(function () {

        Slider.init();

    });
</script>
<script>
    // number of drops created.
    var nbDrop = 108;

    // function to generate a random number range.
    function randRange(minNum, maxNum) {
        return (Math.floor(Math.random() * (maxNum - minNum + 1)) + minNum);
    }

    // function to generate drops
    function createRain() {

        for (i = 1; i < nbDrop; i++) {
            var dropLeft = randRange(3, 1400);
            var dropTop = randRange(-1000, 660);

            $('.rain').append('<div class="drop" id="drop' + i + '"></div>');
            $('#drop' + i).css('left', dropLeft);
            $('#drop' + i).css('top', dropTop);
        }

    }
    // Make it rain
    createRain();</script>


</html>
