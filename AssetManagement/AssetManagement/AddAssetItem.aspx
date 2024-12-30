<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAssetItem.aspx.cs" Inherits="AssetManagement.AddAssetItem" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Asset Item</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            padding-top: 50px;
        }
        .container {
            max-width: 800px;
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .alert {
            display: none;
        }
        
      .btn-blue {
    display: inline-block;
    background-color: #007bff; /* Bootstrap's blue */
    color: white;
    padding: 10px 20px;
    text-decoration: none;
    border: none;
    border-radius: 5px;
    font-size: 16px;
    text-align: center;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btn-blue:hover {
    background-color: #0056b3; /* Darker blue for hover */
    text-decoration: none;
}

 
    </style>
</head>
<body>
    <div class="container">
        <h2 class="text-center mb-4">Manage Asset Items</h2>

        <div id="message" class="alert alert-success"></div>

        <form id="form1" runat="server">
            <div class="mb-3">
                <label for="ddlAccounts" class="form-label">Select Asset Type</label>
                <asp:DropDownList ID="ddlAccounts" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtItemName" class="form-label">Item Name</label>
                <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" placeholder="Enter item name" />
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-primary" />
            </div>

            <asp:GridView ID="gvAssetItems" runat="server" AutoGenerateColumns="False" DataKeyNames="id" CssClass="table table-bordered"
                OnRowEditing="gvAssetItems_RowEditing" OnRowUpdating="gvAssetItems_RowUpdating"
                OnRowDeleting="gvAssetItems_RowDeleting" OnRowCancelingEdit="gvAssetItems_RowCancelingEdit"
                OnRowDataBound="gvAssetItems_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Item Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditItemName" runat="server" Text='<%# Bind("item_name") %>' CssClass="form-control" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("item_name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Asset Type">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditAssetType" runat="server" CssClass="form-control" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("asset_type_id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <a href="Home.aspx" class="redirect-btn button accordion-button btn-blue">Close</a>

        </form>
        
    </div>
    <script>
        function showMessage(message, isSuccess) {
            const messageDiv = document.getElementById("message");
            messageDiv.style.display = "block";
            messageDiv.className = isSuccess ? "alert alert-success" : "alert alert-danger";
            messageDiv.innerHTML = message;
        }
    </script>
</body>
</html>
