<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Website.successlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h2>Welcome to our shop!</h2>
        <asp:Label ID="LabelFirstName" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="LabelLastName" runat="server" Text="Label"></asp:Label>
    </form>
</asp:Content>
