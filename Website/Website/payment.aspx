<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Website.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label ID="LabelPrice" CssClass="col-sm-1" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
        <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Proceed to Payment" OnClick="Button1_Click" />
    </form>
</asp:Content>
