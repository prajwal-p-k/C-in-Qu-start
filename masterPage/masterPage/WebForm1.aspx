<%@ Page Title="" Language="C#" MasterPageFile="~/Asset.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="masterPage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>wel come to home page</h1>
</div>
<br />
<br />
<br />
<br />
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:LinkButton ID="lbllogout" runat="server" OnClick="lbllogout_Click">Logout</asp:LinkButton>
</asp:Content>

