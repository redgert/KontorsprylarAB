﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Website.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-inline">
        <div class="form-group">
            <label for="text">Username:</label>
            <input type="text" class="form-control" id="username">
        </div>
        <div class="form-group">
            <label for="pwd">Password:</label>
            <input type="password" class="form-control" id="password">
        </div>
        <input type="button" id="buttonsubmit" value="Submit" onclick="GetRequest();" />
        <script src="js/loginJS.js"></script>
    </form>
</asp:Content>
