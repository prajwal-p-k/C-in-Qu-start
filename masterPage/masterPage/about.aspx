<%@ Page Title="" Language="C#" MasterPageFile="~/Asset.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="masterPage.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>welcome to about page</h4>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:LinkButton ID="btnlogout" runat="server" OnClick="btnlogout_Click">Logout</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder2">
</asp:Content>


