<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Website.successlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <p>SUCUESSFULLY LOGGED IN! WII </p>
        <asp:TextBox ID="TextBoxUserID" runat="server"></asp:TextBox>
    </form>
</asp:Content>
