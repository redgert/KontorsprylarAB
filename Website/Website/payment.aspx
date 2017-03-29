<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Website.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label ID="LabelPrice" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="BUY NOW!!!!" />
    </form>
</asp:Content>
