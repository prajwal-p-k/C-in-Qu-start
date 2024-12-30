<%@ Page Title="" Language="C#" MasterPageFile="~/Asset.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="masterPage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <p id="btnlogout">
    logout</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="email"></asp:Label>
<asp:TextBox ID="txtemail" runat="server" Width="257px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
<asp:TextBox ID="txtpwd" runat="server" Width="317px"></asp:TextBox>
<br />

<br />
<asp:Button ID="btnsub" runat="server" Text="submit" OnClick="btnsub_Click" />
<br />
<asp:Label ID="lblmsg" runat="server"></asp:Label>
<br />
<br />
<br />
<br />
</asp:Content>
