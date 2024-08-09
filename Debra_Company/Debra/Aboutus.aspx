<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Aboutus.aspx.cs" Inherits="Debra.Aboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
            background-image: url("images/desktop-wallpaper-crowd-concert-crowd-music-festival-and-hands-up.jpg");
            background-size: cover;
           
            position: relative;
        }

       
        body::after {
            content: "";
            background: rgba(0, 0, 0, 0.4); 
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            z-index: -1; 
        }

        section {
            padding: 0px 0;
            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center; 
            flex-direction: column; 
        }

        .img-fluid {
            max-width: 100%;
            height: auto;
            display: block;
            margin: 0 auto;
        }

        .container {
            max-width: 1200px;
            margin: 90px auto;
            padding: 50px 15px;
        }

        .row {
            display: flex;
            flex-wrap: wrap;
            margin: 0 -15px;
        }

        .col-12 {
            width: 100%;
            padding: 0 15px;
        }

        h2 {
            font-size: 2rem;
            color: #fff;
            margin-bottom: 20px;
        }

        p {
            font-size: 1.125rem;
            color: #fff;
            line-height: 1.6;
        }

       
        @media (max-width: 992px) {
            h2 {
                font-size: 1.75rem;
            }

            p {
                font-size: 1rem;
            }
        }

        @media (max-width: 768px) {
            h2 {
                font-size: 1.5rem;
            }

            p {
                font-size: 0.875rem;
            }
        }

        @media (max-width: 576px) {
            h2 {
                font-size: 1.25rem;
            }

            p {
                font-size: 0.75rem;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>About Us</h2>
                        <p><b>
                                Welcome to Debra, a premier event management company based in Singapore. We specialize in
                                organizing world-class musical shows featuring the globe's top musicians and bands. Our commitment to delivering exceptional entertainment experiences has made us a leader in the industry. Currently, you can purchase tickets through our main website and at event locations. To enhance your experience and streamline the ticketing process, we are expanding our system to integrate with partners in the entertainment business, social media platforms, and popular mobile apps. This expansion will enable us to offer seamless ticket sales, event management, and real-time sales tracking for our partners while ensuring Debra's ability to oversee all transactions and commissions. Join us in bringing unforgettable musical events to life.</b></p>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
