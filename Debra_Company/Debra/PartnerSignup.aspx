﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PartnerSignup.aspx.cs" Inherits="Debra.PartnerSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body, html {
            height: 100%;
            margin: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

       
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; 
            padding-top: 10vh; 
            background-image: url("images/desktop-wallpaper-crowd-concert-crowd-music-festival-and-hands-up.jpg"); 
            background-size: cover; 
        }

       
        .card {
            width: 130%; 
            max-width: 400px; 
            background-color: #fbececfd; 
            border-radius: 8px; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
            overflow: hidden; 
        }

        
        .card-body {
            padding: 30px; 
        }

       
        .card-body img {
            display: block;
            margin: 0 auto 20px auto; 
        }

        
        .card-body h3 {
            text-align: center; 
            margin-bottom: 20px; 
            color: #333; 
        }

     
        .form-group {
            margin-bottom: 15px;
        }

        
        .card-body label {
            font-weight: bold; 
            color: #333; 
        }

        
        .form-control {
            width: 100%; 
            padding: 10px; 
            border: 1px solid #ccc; 
            border-radius: 4px; 
            box-sizing: border-box; 
        }

        
        .btn-primary {
            background-color: #007bff; 
            border: none; 
            color: #fff; 
            padding: 10px 150px;
            border-radius: 4px; 
            cursor: pointer; 
            font-size: 16px; 
            transition: background-color 0.3s; 
        }

       
        .btn-center {
            display: flex;
            justify-content: center;
            margin-top: 20px; 
        }

        .btn-primary:hover {
            background-color: #0056b3; 
        }

        
        .btn-info {
            background-color: #17a2b8; 
            border: none; 
            color: #fff; 
            padding: 10px 142px; 
            border-radius: 4px; 
            cursor: pointer; 
            font-size: 16px; 
            transition: background-color 0.3s; 
        }

        .btn-info:hover {
            background-color: #138496; 
        }

        hr {
            margin: 20px 0; 
            border: 0; 
            border-top: 1px solid #ccc; 
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/login_5087607.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Partner Registration</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Username:</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter username"></asp:TextBox>
                                </div>

                                <label>Email:</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Enter email"></asp:TextBox>
                                </div>

                                <label>User Password:</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group btn-center">
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"></asp:Button>
                                </div>

                                <div class="form-group btn-center">
                                    <a href="partnermainpage.aspx">
                                        <input class="btn btn-info" id="Button2" type="button" value="Login" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
