<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aset.aspx.cs" Inherits="AssetManagement.Aset" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
   <form id="form1" runat="server" onsubmit="return validateForm();">
    <div class="container mt-5">
        <h2 class="mb-4">Add User</h2>
        <asp:Panel ID="UserFormPanel" runat="server">
            <div class="form-group">
                <label for="userName">Name</label>
                <asp:TextBox ID="userName" CssClass="form-control" runat="server" Placeholder="Enter name" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="userRole">Role</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" required></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="userEmail">Email</label>
                <asp:TextBox ID="userEmail" CssClass="form-control" runat="server" TextMode="Email" Placeholder="Enter email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="userPhone">Phone</label>
                <asp:TextBox ID="userPhone" CssClass="form-control" runat="server" pattern="^\d{10}$" title="Please enter a valid 10-digit phone number" oninput="this.value = this.value.replace(/[^0-9]/g, '').slice(0, 10);" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="userPassword">Password</label>
                <asp:TextBox ID="userPassword" CssClass="form-control" runat="server" TextMode="Password" Placeholder="Enter password" required></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Add User" OnClick="btnSubmit_Click" />
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Close" OnClientClick="window.location.href='Home.aspx'; return false;" />

        </asp:Panel>
    </div>
</form>
<script type="text/javascript">
    // Validate the phone number to ensure it contains only digits
    function validatePhoneNumber() {
        var phoneNumber = document.getElementById('<%= userPhone.ClientID %>').value;
        var phoneRegex = /^[0-9]*$/; // Only digits allowed
        if (!phoneRegex.test(phoneNumber)) {
            alert("Phone number should only contain digits.");
            return false;
        }
        return true;
    }

    // Validate the email to ensure it's in the correct format
    function validateEmail() {
        var email = document.getElementById('<%= userEmail.ClientID %>').value;
        var emailRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/; // Basic email format validation
        if (!emailRegex.test(email)) {
            alert("Please enter a valid email address.");
            return false;
        }
        return true;
    }

    // Validate the password to meet the required criteria
    function validatePassword() {
        var password = document.getElementById('<%= userPassword.ClientID %>').value;
        var passwordRegex = /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[\W_]).{5,20}$/; // At least one letter, one number, one special char
        if (!passwordRegex.test(password)) {
            alert("Password must be between 5 and 20 characters and contain at least one letter, one number, and one special character.");
            return false;
        }
        return true;
    }

    // This function is called when the form is submitted to validate all fields
    function validateForm() {
        // Validate each field and return false to prevent form submission if any field is invalid
        if (!validatePhoneNumber()) {
            return false;
        }
        if (!validateEmail()) {
            return false;
        }
        if (!validatePassword()) {
            return false;
        }
        return true; // Allow form submission if all validations pass
    }
</script>

</body>
</html>
