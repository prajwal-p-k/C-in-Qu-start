<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetunAsset.aspx.cs" Inherits="AssetManagement.RetunAsset" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Return Asset</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
    <style>
        body {
            background-color: #f0f8ff;
            font-family: 'Arial', sans-serif;
        }
        .container {
            max-width: 600px;
            background: #fff;
            padding: 20px 30px;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
        }
        h5 {
            font-size: 1.5rem;
            color: #007bff;
            margin-bottom: 20px;
        }
        label {
            font-weight: bold;
            color: #333;
        }
        .form-control {
            border-radius: 5px;
        }
        .btn-primary {
            background-color: #007bff;
            border: none;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        #lbl {
            margin-top: 10px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h5 class="text-center">Return Asset</h5>

            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <label for="assetType">Asset Type</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="same-size-dropdown" class="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <br /><br />
                    <label for="assetName">Asset Name</label>
                    <asp:DropDownList ID="DropDownList2" CssClass="same-size-dropdown" class="form-control" runat="server"></asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />

            <!-- Return Date -->
            <div class="form-group">
                <label for="assetpdate">Return Date</label>
                <input type="text" class="form-control" id="assetpdate" placeholder="dd/mm/yyyy" runat="server" />
            </div>

            <!-- Notes -->
            <div class="form-group">
                <label for="note1">Notes</label>
                <textarea class="form-control" id="note1" runat="server" rows="4" placeholder="Enter notes"></textarea>
            </div>

            <!-- Buttons -->
            <div class="d-flex justify-content-between">
                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Return Asset" OnClick="Button1_Click" />
                <asp:Button ID="Button2" class="btn btn-secondary" runat="server" Text="Close" OnClick="Button2_Click" />
            </div>

            <!-- Error Label -->
            <label id="lbl" runat="server" style="color:red"></label>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#assetpdate').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>
</body>
</html>
