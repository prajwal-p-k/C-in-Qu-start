<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssetHistry.aspx.cs" Inherits="AssetManagement.ViewAssetHistry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>View Asset History</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }
        .container {
            margin-top: 50px;
            padding: 20px;
            background: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        h3 {
            color: #007bff;
            font-weight: bold;
            margin-bottom: 20px;
        }
        select {
            border-radius: 5px;
            padding: 10px;
        }
        table {
            margin-top: 20px;
            border-collapse: collapse;
        }
        th, td {
            text-align: center;
            padding: 10px;
        }
        th {
            background-color: #007bff;
            color: #fff;
        }
        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .btn-primary {
            background-color: #007bff;
            border: none;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        .alert {
            color: red;
            font-weight: bold;
            margin-top: 10px;
        }
        #Button1{
            position:relative;
            right: -1001px;
        }
    </style>
    <script>
        function checkHistory() {
            // Example logic; update as needed for actual functionality
            const hasHistory = false;
            if (!hasHistory) {
                alert("History is not allocated yet!");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <div class="container">
        <h3 class="text-center">View Asset History</h3>
        <form id="form1" runat="server">
            <!-- Dropdown for Accounts -->
            <div class="form-group">
                <label for="ddlAccounts">Select Account:</label>
                <asp:DropDownList 
                    ID="ddlAccounts" 
                    CssClass="form-control" 
                    runat="server" 
                    AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlAccounts_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <!-- GridView for Products -->
            <%--<div class="table-responsive">
                <asp:GridView 
                    ID="gvProducts" 
                    runat="server" 
                    CssClass="table table-bordered" 
                    AutoGenerateColumns="True">
                </asp:GridView>--%>
                               <asp:GridView 
    ID="gvProducts" 
    runat="server" 
    CssClass="table table-bordered" 
    AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="allocation_id" HeaderText="Allocation ID" SortExpression="allocation_id" />
        
        <asp:TemplateField HeaderText="Employee Name" SortExpression="employee_name">
            <ItemTemplate>
                <%# Eval("employee_name") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Allocation Date" SortExpression="allocation_date">
            <ItemTemplate>
                <%# Eval("allocation_date", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAllocationDate" runat="server" Text='<%# Eval("allocation_date", "{0:dd/MM/yyyy}") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Return Date" SortExpression="return_date">
            <ItemTemplate>
                <%# Eval("return_date", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtReturnDate" runat="server" Text='<%# Eval("return_date", "{0:dd/MM/yyyy}") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        <asp:BoundField DataField="note" HeaderText="Note" SortExpression="note" />
    </Columns>
</asp:GridView>

            </div>

            <!-- Buttons -->
            <div >
               <!-- <button type="button" class="btn btn-primary" onclick="checkHistory()">Next</button>  class="d-flex justify-content-between" -->
                <asp:Button ID="Button1" CssClass="btn btn-secondary " runat="server" Text="Close" OnClick="Button1_Click" />
            </div>
        </form>
    </div>

    <!-- Include Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
