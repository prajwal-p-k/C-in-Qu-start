<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewallAsset.aspx.cs" Inherits="AssetManagement.ViewallAsset" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>View All Assets</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }

        .container {
            margin-top: 50px;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h3 {
            text-align: center;
            color: #007bff;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .table-responsive {
            margin-top: 20px;
            max-height: 500px;
            overflow-y: auto;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
        }

        th {
            background-color: #007bff;
            color: white;
            text-align: center;
        }

        td {
            text-align: center;
        }

        .btn {
            font-size: 16px;
            margin-top: 20px;
            width: 100%;
        }

        .btn-primary {
            background-color: #007bff;
            border: none;
            transition: background-color 0.3s ease;
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }

        @media (max-width: 768px) {
            .container {
                padding: 10px;
            }
        }
    </style>
</head>
<body>
    <div class="container">
        <h3>View All Assets</h3>
        <form id="form1" runat="server">
            <!-- Table Container -->
            <div class="table-responsive">
               <asp:GridView 
    ID="GridView1" 
    runat="server" 
    AutoGenerateColumns="False" 
    CssClass="table table-bordered table-striped"
    DataKeyNames="asset_id"
    OnRowEditing="GridView1_RowEditing" 
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowUpdating="GridView1_RowUpdating" 
    OnRowDeleting="GridView1_RowDeleting">
    <Columns>
        <asp:BoundField DataField="asset_id" HeaderText="Asset ID" ReadOnly="True" />
        <asp:BoundField DataField="unique_number" HeaderText="Unique Number" ReadOnly="True" />
        <asp:TemplateField HeaderText="Asset Name">
            <EditItemTemplate>
                <asp:TextBox ID="txtAssetName" runat="server" Text='<%# Bind("asset_name") %>' />
            </EditItemTemplate>
            <ItemTemplate>
                <%# Eval("asset_name") %>
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Purchase Date">
    <EditItemTemplate>
        <asp:TextBox ID="txtPurchaseDate" runat="server" Text='<%# Bind("purchase_date", "{0:dd/MM/yyyy}") %>' />
    </EditItemTemplate>
    <ItemTemplate>
        <%# Eval("purchase_date", "{0:dd/MM/yyyy}") %>
    </ItemTemplate>
</asp:TemplateField>

<%--<asp:TemplateField HeaderText="Warranty Period">
    <EditItemTemplate>
        <asp:TextBox ID="txtWarrantyPeriod" runat="server" 
            Text='<%# Bind("warranty_period", "{0:dd/MM/yyyy}") %>' />
    </EditItemTemplate>
    <ItemTemplate>
        <%# Eval("warranty_period", "{0:dd/MM/yyyy}") %>
    </ItemTemplate>
</asp:TemplateField>--%>
              <asp:TemplateField HeaderText="Warranty Period">
    <EditItemTemplate>
        <asp:TextBox ID="txtPurchaseDate" runat="server" Text='<%# Bind("warranty_period", "{0:dd/MM/yyyy}") %>' />
    </EditItemTemplate>
    <ItemTemplate>
        <%# Eval("warranty_period", "{0:dd/MM/yyyy}") %>
    </ItemTemplate>
</asp:TemplateField>


        <asp:TemplateField HeaderText="Price">
            <EditItemTemplate>
                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price") %>' />
            </EditItemTemplate>
            <ItemTemplate>
                <%# Eval("price") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>


            </div>

            <!-- Redirect Button -->
            <asp:Button 
                ID="btnHome" 
                runat="server" 
                Text="Go to Home" 
                CssClass="btn btn-primary" 
                OnClick="Button1_Click" />
        </form>
    </div>

    <!-- Include Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

