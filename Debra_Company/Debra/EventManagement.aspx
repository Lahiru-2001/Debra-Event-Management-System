<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventManagement.aspx.cs" Inherits="Debra.EventManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       
        body, html {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 180vh;
            padding-top: 20px;
            background-image: url("images/concerts-music-crowds-wallpaper-preview.jpg");
            background-size: cover;
        }

        .row {
            width: 100%;
            max-width: 800px;
        }

        .card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            margin-bottom: 20px;
            background-color: lightgrey; 
        }

        .card-body {
            padding: 20px;
        }

        h4 {
            font-size: 1.5rem;
            margin-bottom: 20px;
            color: #000;
        }

        label {
            font-weight: bold;
            margin-bottom: 5px;
            color: #000;
            display: block; 
            width: 100%; 
        }

        .form-group {
            margin-bottom: 15px;
        }

        .input-group {
            display: flex;
        }

        .input-group .form-control {
            flex: 1;
        }

        .btn {
            padding: 10px 100px;
            border: none;
            border-radius: 5px;
            font-size: 1rem;
            cursor: pointer;
            display: inline-block; 
            margin-right: 5px; 
        }

        .btn-primary {
            background-color: #007bff;
            color: #fff;
        }

        .btn-success {
            background-color: #28a745;
            color: #fff;
        }

        .btn-warning {
            background-color: #ffc107;
            color: #000;
        }

        .btn-danger {
            background-color: #dc3545;
            color: #fff;
        }

        .table {
            width: 100%;
            margin-top: 20px;
        }

        .table th, .table td {
            padding: 10px;
            text-align: left;
            border-top: 1px solid #ddd;
        }

        .table thead th {
            background-color: #f8f9fa;
        }

        .centered {
            text-align: center;
        }

        .centered h4 {
            margin-bottom: 20px;
        }
        
        .button-group {
            display: flex;
            justify-content: space-between;
            margin-top: 15px;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Event Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Event ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Event Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Event Name" required></asp:TextBox>
                                </div>
                                <label>Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" required></asp:TextBox>
                                </div>
                                <label>Time</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Time" required></asp:TextBox>
                                </div>
                                <label>Place</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Place" required></asp:TextBox>
                                </div>
                                <label>Price</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Price" required></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="button-group">
                            <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" class="btn btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            <asp:Button ID="Button4" class="btn btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Current Event Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DebraDBConnectionString %>" ProviderName="<%$ ConnectionStrings:DebraDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [event_details]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView Class="table table-striped table-bordered" ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="event_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="event_id" HeaderText="event_id" ReadOnly="True" SortExpression="event_id" />
                                        <asp:BoundField DataField="event_name" HeaderText="event_name" SortExpression="event_name" />
                                        <asp:BoundField DataField="evant_date" HeaderText="evant_date" SortExpression="evant_date" />
                                        <asp:BoundField DataField="event_time" HeaderText="event_time" SortExpression="event_time" />
                                        <asp:BoundField DataField="event_place" HeaderText="event_place" SortExpression="event_place" />
                                        <asp:BoundField DataField="event_price" HeaderText="event_price" SortExpression="event_price" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
