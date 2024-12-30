<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="AssetManagement.AddRole" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Roles</title>
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
            <h2 class="mb-4">Manage Roles</h2>
            <div class="form-group">
                <label for="roleName">Add Role</label>
                <asp:TextBox ID="roleName" CssClass="form-control" runat="server" Placeholder="Enter Role Name" required></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary mb-4" runat="server" Text="Add Role" OnClick="btnSubmit_Click" />

            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" DataKeyNames="role_id" CssClass="table table-bordered"
                OnRowEditing="gvRoles_RowEditing" OnRowUpdating="gvRoles_RowUpdating"
                OnRowDeleting="gvRoles_RowDeleting" OnRowCancelingEdit="gvRoles_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="role_id" HeaderText="Role ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Role Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditRoleName" runat="server" Text='<%# Bind("role_name") %>' CssClass="form-control" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("role_name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
           <a href="Home.aspx" class="redirect-btn button accordion-button btn-blue">Close</a>

        </div>
        
    </form>
</body>
</html>
