<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="AssetManagement.ViewAllUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Users</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .table-container {
            width: 90%;
            max-width: 1200px;
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
            padding: 10px;
            text-align: left;
        }

        .table th {
            background-color: #007bff;
            color: white;
            text-transform: uppercase;
            font-size: 14px;
        }

        .table td {
            font-size: 14px;
            vertical-align: middle;
        }

        .redirect-btn {
            display: inline-block;
            margin-top: 20px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            text-decoration: none;
        }

        .redirect-btn:hover {
            background-color: #0056b3;
        }

        @media screen and (max-width: 768px) {
            .table th, .table td {
                font-size: 12px;
                padding: 8px;
            }

            .redirect-btn {
                font-size: 14px;
                padding: 8px 16px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="employee_id"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="employee_id" HeaderText="Employee ID" ReadOnly="True" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    
                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("role") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                    <asp:BoundField DataField="created_time" HeaderText="Created Time" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <a href="Home.aspx" class="redirect-btn">Close</a>
    </form>
</body>
</html>


