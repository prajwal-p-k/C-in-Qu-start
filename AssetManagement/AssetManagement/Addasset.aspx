<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addasset.aspx.cs" Inherits="AssetManagement.Addasset" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Allot Asset</title>

    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">

    <!-- Bootstrap Datepicker CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />

    <style>
        body {
            background-color: #f7f9fc;
            font-family: 'Arial', sans-serif;
        }

        .container {
            max-width: 600px;
            background: #fff;
            padding: 25px 30px;
            border-radius: 10px;
            box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.1);
        }

        h5 {
            font-size: 1.6rem;
            color: #007bff;
            margin-bottom: 25px;
            font-weight: bold;
        }

        label {
            font-weight: bold;
            color: #555;
        }

        .form-control {
            border-radius: 6px;
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
    </style>
</head>


<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h5 class="text-center">Allot Asset</h5>

            <!-- Employee Name -->
            <div class="form-group">
                <label for="DropDownList1">Employee Name</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <!-- Asset Unique Number -->
            <div class="form-group">
                <label for="DropDownList2">Asset Unique Number</label>
                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>

            <%--<!-- Allot Date -->
            <div class="form-group">
                <label for="assetpdate">Allot Date</label>
                <input type="date" class="form-control" id="assetpdate" runat="server" onchange="validateForm()">

                <%--    <input type="date" class="form-control" id="assetpdate" runat="server">--%>
           <div class="form-group">
    <label for="assetpdate">Allot Date</label>
    <input type="text" class="form-control" id="assetpdate" runat="server" placeholder="dd/mm/yyyy" />
</div>



            <!-- Notes -->
            <div class="form-group">
                <label for="note1">Notes</label>
                <textarea class="form-control" id="note1" runat="server" rows="4" placeholder="Enter notes"></textarea>
            </div>

            <!-- Buttons -->
            <div class="d-flex justify-content-between">
                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Allot Asset" OnClick="Button1_Click" />
                <asp:Button ID="Button2" class="btn btn-secondary" runat="server" Text="Close" OnClick="Button2_Click" />
            </div>

            <!-- Error Label -->
            <label id="lbl" runat="server" class="text-danger"></label>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

<!-- Bootstrap JS -->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

<!-- Bootstrap Datepicker JS -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>

<script>
    

    $(document).ready(function () {
        // Initialize the datepicker
        $('#assetpdate').datepicker({
            format: 'dd/mm/yyyy', // Date format
            autoclose: true, // Automatically close the picker after selecting a date
            todayHighlight: true, // Highlight today's date
            orientation: "bottom" // Open the datepicker below the input
        });
    });
</script>

    <!-- jQuery (required for Bootstrap Datepicker) -->
   <%-- <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>



    <!-- Include Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>

    <script>
        function validateForm() {
            const employeeName = document.getElementById('<%= DropDownList1.ClientID %>').value;
            const assetNumber = document.getElementById('<%= DropDownList2.ClientID %>').value;
            const allotDate = document.getElementById('assetpdate').value;

            // Validate Employee Name Dropdown
            if (employeeName === "0") {
                alert("Please select an Employee.");
                return false;
            }

            // Validate Asset Unique Number Dropdown
            if (assetNumber === "0") {
                alert("Please select an Asset Unique Number.");
                return false;
            }

            // Validate Allot Date
            if (!allotDate) {
                alert("Please select an Allot Date.");
                return false;
            }

            return true; // Allow form submission

            function validateForm() {
                const employeeName = document.getElementById('<%= DropDownList1.ClientID %>').value;
                const assetNumber = document.getElementById('<%= DropDownList2.ClientID %>').value;
                const allotDateElement = document.getElementById('assetpdate');
                const allotDate = allotDateElement.value;

                // Validate Employee Name Dropdown
                if (employeeName === "0") {
                    alert("Please select an Employee.");
                    return false;
                }

                // Validate Asset Unique Number Dropdown
                if (assetNumber === "0") {
                    alert("Please select an Asset Unique Number.");
                    return false;
                }

                // Validate Allot Date
                if (!allotDate) {
                    alert("Please select an Allot Date.");
                    return false;
                }

                // Format the Allot Date in dd/mm/yyyy
                const dateParts = allotDate.split('-');
                if (dateParts.length === 3) {
                    const formattedDate = `${dateParts[2]}/${dateParts[1]}/${dateParts[0]}`;
                    alert(`Formatted Allot Date: ${formattedDate}`); // Optional: To show the formatted date.
                    allotDateElement.value = formattedDate; // Set the formatted date back to the input.
                }

                return true; // Allow form submission
            }
          
            $(document).ready(function () {
                // Initialize datepicker
                $('#assetpdate').datepicker({
                    format: 'dd/mm/yyyy', // Set format to dd/mm/yyyy
                    autoclose: true, // Close the picker automatically after selecting a date
                    todayHighlight: true, // Highlight today's date
                    orientation: "bottom" // Open picker below the input
                });
            });

            function validateForm() {
                const employeeName = document.getElementById('<%= DropDownList1.ClientID %>').value;
        const assetNumber = document.getElementById('<%= DropDownList2.ClientID %>').value;
        const allotDate = document.getElementById('assetpdate').value;

        // Validate Employee Name Dropdown
        if (employeeName === "0") {
            alert("Please select an Employee.");
            return false;
        }

        // Validate Asset Unique Number Dropdown
        if (assetNumber === "0") {
            alert("Please select an Asset Unique Number.");
            return false;
        }

        // Validate Allot Date
        if (!allotDate) {
            alert("Please select an Allot Date.");
            return false;
        }

        return true; // Allow form submission
    }


        }
    </script>--%>
</body>
</html>
