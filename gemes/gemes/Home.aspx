<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="gemes.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:CheckBox ID="ck1" runat="server" Text="kabbadi" OnCheckedChanged="ck1_CheckedChanged" />
         <br />
        <asp:CheckBox ID="ck2" runat="server" Text="Cricket" OnCheckedChanged="ck2_CheckedChanged" />
         <br />
        <asp:CheckBox ID="ck3" runat="server" Text="vally ball" OnCheckedChanged="ck3_CheckedChanged" />
        <br />
        <asp:CheckBox ID="ck4" runat="server" Text="table tannis" OnCheckedChanged="ck4_CheckedChanged" />
        <br />
        <asp:Button ID="btn1" runat="server" Text="submit" Width="143px" OnClick="btn1_Click" />
    </form>
</body>
</html>
