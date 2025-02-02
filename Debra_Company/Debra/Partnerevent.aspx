﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Partnerevent.aspx.cs" Inherits="Debra.Partnerevent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        
        body, html {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
            background-image: url("images/concerts-music-crowds-wallpaper-preview.jpg");
            background-size: cover;
            height: 100%; 
        }

        .container {
            max-width: 100%;
            margin: auto;
            padding: 20px;
            background-color: lightgrey; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
            border-radius: 8px;
            position: absolute; 
            top: 50%; 
            left: 50%; 
            transform: translate(-50%, -50%); 
        }

    
        h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #000; 
        }

       
        .table {
            width: 100%; 
            margin-bottom: 20px; 
            border-collapse: collapse; 
        }

        .table thead th {
            background-color: #84fa9c; 
            color: #000; 
            font-weight: bold;
            text-align: left;
            padding: 10px;
            border-bottom: 2px solid #e1e1e1; 
        }

        .table tbody tr:nth-child(even) {
            background-color: #f2f2f2; 
        }

        .table tbody td {
            padding: 10px;
            border-bottom: 1px solid #e1e1e1; 
            color: #333; 
        }

        .table tbody tr:hover {
            background-color: #e1e1e1; 
        }

       
        @media (max-width: 768px) {
            .container {
                width: 90%; 
            }
        }
    </style>
    <div class="container">
        <h2>Events Details</h2>
        <asp:GridView ID="GridViewEvents" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="event_id" HeaderText="Event ID" />
                <asp:BoundField DataField="event_name" HeaderText="Event Name" />
                <asp:BoundField DataField="evant_date" HeaderText="Event Date" />
                <asp:BoundField DataField="event_time" HeaderText="Event Time" />
                <asp:BoundField DataField="event_place" HeaderText="Event Place" />
                <asp:BoundField DataField="event_price" HeaderText="Event Price" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
