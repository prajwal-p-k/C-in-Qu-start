<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home1.aspx.cs" Inherits="AssetManagement.Home1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asset Management</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css" />
</head>
<body>
    <form runat="server">
        <div class="container mt-5">
            <h1 class="text-center mb-4">Add Asset</h1>
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <div class="mb-3">
                        <label for="DropDownList1" class="form-label">Asset Type</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="DropDownList2" class="form-label">Asset Name</label>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="assetNo" class="form-label">Asset Unique Number</label>
                        <input type="text" id="assetNo" class="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="assetpdate" class="form-label">Purchase Date</label>
                        <input type="text" id="assetpdate" class="form-control datepicker" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="assetwdate" class="form-label">Warranty Date</label>
                        <input type="text" id="assetwdate" class="form-control datepicker" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="assetprice" class="form-label">Price</label>
                        <input type="number" id="assetprice" class="form-control" runat="server" />
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btnsubmitassetdata_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary" OnClick="btnClose_Click" />
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker({
                dateFormat: "dd/mm/yy"
            });

            $("#btnSubmit").on("click", function () {
                let purchaseDate = new Date($("#assetpdate").val().split("/").reverse().join("-"));
                let warrantyDateValue = $("#assetwdate").val();

                if (warrantyDateValue) {
                    let warrantyDate = new Date(warrantyDateValue.split("/").reverse().join("-"));
                    if (warrantyDate <= purchaseDate) {
                        alert("Warranty date must be greater than purchase date.");
                        return false;
                    }
                }
                return true;
            });
        });

    </script>
</body>
</html>
