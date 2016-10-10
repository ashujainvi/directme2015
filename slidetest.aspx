<%@ Page Language="C#" AutoEventWireup="true" CodeFile="slidetest.aspx.cs" Inherits="slidetest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css1/style.css" />
		<link href='http://fonts.googleapis.com/css?family=Dosis:200,400,700' rel='stylesheet' type='text/css'/>
		<script type="text/javascript" src="js/modernizr.custom.79639.js"></script>
		<noscript><link rel="stylesheet" type="text/css" href="css1/noscript.css" /></noscript>
</head>
<body>
    <form id="form1" runat="server">
    <section id="ps-container" class="ps-container">
		
			
            <div class="ps-contentwrapper">

                <div class="ps-content">
                    <h2>Vehicle 1 : The scooter</h2>
                    
                    <p>Revenue generated : <strong> &#8377;100/hour</strong></p>
                </div>

                <div class="ps-content">
                    <h2>Vehicle 2 : The scooter</h2>
                    
                    <p>Revenue generated : <strong> &#8377; 100/hour </strong>
                </div>

                <div class="ps-content">
                    <h2>Vehicle 3 : The scooter</h2>
                   <span class="ps-price"> &#8377; 250</span>
                    <p>Revenue generated : <strong> &#8377; 100/hour </strong>
                </div>

               
            </div><!-- /ps-contentwrapper -->
			
			<div class="ps-slidewrapper">
			
				<div class="ps-slides">
					<div style="background-image: url(images/1.png); background-size:contain;"></div>
					<div style="background-image: url(images/2.png); background-size: contain;"></div>
					<div style="background-image: url(images/3.png); background-size: contain;"></div>
                    
				</div>
				
				<nav>
					<a href="#" class="ps-prev" ></a>
					<a href="#" class="ps-next" ></a>
				</nav>
				
			</div><!-- /ps-slidewrapper -->
			
		</section><!-- /ps-container -->
			
		<!-- jQuery if needed -->
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
		<script type="text/javascript" src="js/slider.js"></script>
		<script type="text/javascript">
		    $(function () {

		        Slider.init();

		    });
		</script>
    </form>
</body>
</html>
