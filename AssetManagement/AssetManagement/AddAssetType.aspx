<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAssetType.aspx.cs" Inherits="AssetManagement.AddAssetType" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Asset Type</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
      <style>
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
        margin-left: 199px;
}

.btn-blue:hover {
    background-color: #0056b3; /* Darker blue for hover */
    text-decoration: none;
}

  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Add Asset Type</h2>
            <div class="form-group">
                <label for="assetTypeName">Asset Type Name</label>
                <asp:TextBox ID="assetTypeName" CssClass="form-control" runat="server" Placeholder="Enter Asset Type Name" required></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Add Asset Type" OnClick="btnSubmit_Click" />

            <!-- GridView to display existing asset types -->
            <h3 class="mt-5">Existing Asset Types</h3>
            <asp:GridView ID="gvAssetTypes" runat="server" CssClass="table table-striped" AutoGenerateColumns="False"
    OnRowEditing="gvAssetTypes_RowEditing"
    OnRowUpdating="gvAssetTypes_RowUpdating" OnRowCancelingEdit="gvAssetTypes_RowCancelingEdit"
    OnRowDeleting="gvAssetTypes_RowDeleting" DataKeyNames="type_name">
    <Columns>
        <asp:BoundField DataField="type_name" HeaderText="Asset Type Name" SortExpression="type_name" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

        </div>
        <a href="Home.aspx" class="redirect-btn button accordion-button btn-blue">Close</a>
    </form>
    
</body>
</html>
