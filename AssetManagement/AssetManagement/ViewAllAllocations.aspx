<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllAllocations.aspx.cs" Inherits="AssetManagement.ViewAllAllocations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Allocations</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            text-align: center;
        }

        .table-container {
            margin: auto;
            width: 80%;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            overflow-x: auto;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .table th {
            background-color: #007bff;
            color: white;
        }

        .redirect-btn {
            margin-top: 20px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .redirect-btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table-container">
           <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="allocation_id" HeaderText="Allocation ID" />
                   
                    <asp:BoundField DataField="name" HeaderText="Employee Name" />
                    <asp:BoundField DataField="unique_number" HeaderText="Asset Unique Number" />
                    <asp:BoundField DataField="allocation_date" HeaderText="Allocation Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="return_date" HeaderText="Return Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="note" HeaderText="Notes" />
                </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
    <Columns>
        <asp:BoundField DataField="allocation_id" HeaderText="Allocation ID" />
        <asp:BoundField DataField="name" HeaderText="Employee Name" />
        <asp:BoundField DataField="unique_number" HeaderText="Asset Unique Number" />
        <asp:BoundField DataField="allocation_date" HeaderText="Allocation Date" DataFormatString="{0:dd/MMyyyy}" />
        <asp:BoundField DataField="return_date" HeaderText="Return Date" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="status" HeaderText="Status" />
        <asp:BoundField DataField="note" HeaderText="Notes" />
    </Columns>
</asp:GridView>


            <asp:Button ID="btnHome" runat="server" Text="Go to Home" CssClass="redirect-btn" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>

