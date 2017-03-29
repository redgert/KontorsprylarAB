<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Website.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <form id="myForm" runat="server">
        <div class="table-responsive">
            <asp:Table ID="orderHistoryTable" CssClass="table table-responsive" runat="server"></asp:Table>
        </div>

    </form>


</asp:Content>
