<%@ Page Language="C#" Async="true" EnableEventValidation="false" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Me</title>
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="css/dialog.css" rel="stylesheet" />
    <link href="css/dialog-val.css" rel="stylesheet" />

    <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">-->
    <link href='http://fonts.googleapis.com/css?family=Slabo+27px' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/mystyle.css">
    <script src="js/modernizr.custom.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <section class="rain"></section>
            <div class="container">
                
                <div class="logo"></div>

                <div class="login button-wrap">
                    <div data-dialog="somedialog" class="trigger">
                        <img src="img/login.png" /><br />
                        <span>Login</span></div>
                </div>

                <div class="cloud">
                    <div id="cloud1">
                        <img src="img/cloud1.png" id="cloud1Image" /></div>
                    <div id="cloud2">
                        <img src="img/cloud2.png" id="cloud2Image" /></div>
                    <!--<div id="cloud3"></div>-->
                </div>


                <div class="footer">
                    <!--<img src="img/road5.png" id="roadImage"/>-->
                </div>
                <div class="carContainer">
                    <div class="car">
                        <img src="img/car.png"></div>
                    <div class="tyre">
                        <div id="tyre1">
                            <!--<img src="img/tyre.png" />-->
                        </div>
                        <div id="tyre2">
                            <img src="img/tyre.png" /></div>
                    </div>
                </div>

            </div>



            <!--login dialog box-->

            <div id="somedialog" class="dialog">
                <div class="dialog__overlay"></div>
                <div class="dialog__content">
                    <h2><strong>Howdy</strong>, login here</h2>
                    <div>
                        <div class="loginDetails">
                        <form class="loginForm">
                            <p><input type="text" runat="server" name="login" value="" id="txt_email" placeholder="Your Email" autofocus></p>
                            <p><input type="password" runat="server" name="password" value="" id="txt_password" placeholder="TT Password"></p>
                        </form>
                            </div>

                    
                        <asp:ScriptManager runat="server" />
                       
                        <asp:UpdatePanel runat="server" ID="login">
                            <ContentTemplate>
                                
                                <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="login" DynamicLayout="true">
                                    <ProgressTemplate>
                                        
                                <img src="~/images/car-loader.gif"  style="height:33px;" runat="server" ID="loader"  />
                                  </center>
                                </p>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <input type="button" class="action formButton" data-dialog-close value="CLOSE">
                                <asp:Button ID="Button1" class="formButton" runat="server" Text="SUBMIT" OnClick="Button1_Click" />
                                <p>
                                    <center><asp:Label runat="server" ID="lbl_error"></asp:Label></center>
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>
                </div>


            </div>
            <!-- container ends -->


            <script src="js/classie.js"></script>
            <script src="js/dialogFx.js"></script>

            <!--dialog box trigger-->

            <script>
                (function () {

                    var dlgtrigger = document.querySelector('[data-dialog]'),
                        somedialog = document.getElementById(dlgtrigger.getAttribute('data-dialog')),
                        dlg = new DialogFx(somedialog);

                    dlgtrigger.addEventListener('click', dlg.toggle.bind(dlg));

                })();
            </script>

        </div>
    </form>

   
</body>
    <script src="//code.jquery.com/jquery-1.11.2.min.js"></script>


    <%--BACKGROUND COLOR ACCRDN TO TYM--%>
    <script type="text/javascript">
        var currentTime = new Date().getHours();
        if (7 <= currentTime && currentTime < 17) {
            if (document.body) {
                document.body.style.backgroundColor = "rgb(175, 230, 255)";
            }
        }
        if (17 <= currentTime && currentTime < 22) {
            if (document.body) {
                document.body.style.backgroundColor = "rgb(247, 219, 157)";
            }
        }
        else {
            if (document.body) {
                document.body.style.backgroundColor = "rgb(55,55,55)";
            }
        }

</script>


<script>
    // number of drops created.
var nbDrop = 38; 

// function to generate a random number range.
function randRange( minNum, maxNum) {
  return (Math.floor(Math.random() * (maxNum - minNum + 1)) + minNum);
}

// function to generate drops
function createRain() {

	for( i=1;i<nbDrop;i++) {
	var dropLeft = randRange(0,1400);
	var dropTop = randRange(-1000,600);

	$('.rain').append('<div class="drop" id="drop'+i+'"></div>');
	$('#drop'+i).css('left',dropLeft);
	$('#drop'+i).css('top',dropTop);
	}

}
// Make it rain
createRain();</script>


</html>
