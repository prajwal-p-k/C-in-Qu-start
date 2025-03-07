﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AssetManagement.Home"  %>

<!DOCTYPE html>
<html lang="en">
<head>
    <script src="jquery.js"></script>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Welcome to Asset Management System</title>
    <!-- Bootstrap CDN -->
    <script type="text/javascript">
</script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .nav-item {
            margin-right: 10px;
        }
        .button-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 20px;
            margin-top: 20px;
        }
        .button-container button {
            width: 200px;
            height: 50px;
            font-size: 16px;
        }
      
    </style>
</head>
<body>
    <div class="container"></div>

    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container-fluid">
            <h2 id="lblWelcome" runat="server" style="color:red;">Welcome!</h2>
          <div>
            <h1 id="lbl"></h1>
          </div>
    
          
        </div>
      </nav>
    <!-- Main Buttons -->
   
    <div class="container mt-5">
        <h1 class="text-center mb-4">Asset Management Dashboard</h1>
        <div class="row g-4">
    
          <!-- Card 1 -->
          <div class="col-md-4">
            <div class="card shadow-sm">
              <div class="card-body">
                <h5 class="card-title">Manage Assets</h5>
               <!-- <button 
                    class="btn btn-primary w-100 mb-2" 
                    id="addAssetBtn" target="#assetModal" >
                    onclick="window.location.href='Addasset.aspx';">
                       Add Asset
</button>
                   -->
                    <%--<button class="btn btn-primary w-100 mb-2" id="addAssetBtn" data-toggle="modal" data-target="#assetModal">Add Asset</button>--%>
                  <a href="Home1.aspx" class="btn btn-primary w-100 mb-2" id="allotAssetBtn1">Add Asset</a>
                 

               <a href="Addasset.aspx" class="btn btn-secondary w-100 mb-2" id="allotAssetBtn">Allot Asset</a>

                  <a href="RetunAsset.aspx" class="btn btn-primary w-100 mb-2" id="ReturnAssetBtn">Return Asset</a>


             <!--   <button class="btn btn-primary w-100" id="returnAssetBtn" data-toggle="modal" data-target="#returnAssetModal" >Return Asset</button> -->
              </div>
            </div>
          </div>
    
          <!-- Card 2 -->
          <div class="col-md-4">
            <div class="card shadow-sm">
              <div class="card-body">
                <h5 class="card-title">View Records</h5>
                  <a href="ViewAssetHistry.aspx" class="btn btn-secondary w-100 mb-2" id="HistoryAssetBtn">View Asset History</a>
             <%--   <button class="btn btn-secondary w-100 mb-2" id="viewHistoryBtn" data-toggle="modal" data-target="#viewAssetHistoryModal">View Asset History</button>--%>
                  <a href="ViewallAsset.aspx" class="btn btn-primary w-100 mb-2" id="AllAssetBtn">View All Assets</a>
                  <a href="ViewAllAllocations.aspx" class="btn btn-secondary w-100 mb-2" id="AllAllocationAssetBtn">View All Allocations</a>
              </div>
            </div>
          </div>
    
          <!-- Card 3 -->
          <div class="col-md-4">
            <div class="card shadow-sm">
              <div class="card-body">
                <h5 class="card-title">Manage Users</h5>
                <a href="Aset.aspx" class="btn btn-primary w-100 mb-2" id="AllAssetBtn">Add Users</a>
                  <a href="ViewAllUsers.aspx" class="btn btn-secondary w-100 mb-2" id="AllAssetBtn">View All Users</a>
                   <a href="login.aspx" class="btn btn-primary w-100 mb-2" id="AllAssetBtn">logout</a>
              <!--  <button class="btn btn-secondary w-100 mb-2" id="viewUsersBtn" data-toggle="modal" data-target="#viewAllUsersModal">View All Users</button> -->
                <!--<button class="btn btn-danger w-100" id="logoutBtn" runat="server">Logout</button> -->
                  
                  
                   

              </div>
            </div>
          </div>

            <!-- Card 4 -->
<div class="col-md-4">
  <div class="card shadow-sm">
    <div class="card-body">
      <h5 class="card-title">Support Records</h5>
        <a href="AddAssetType.aspx" class="btn btn-secondary w-100 mb-2" id="HistoryAssetBtn1">Asset Type</a>
   <%--   <button class="btn btn-secondary w-100 mb-2" id="viewHistoryBtn" data-toggle="modal" data-target="#viewAssetHistoryModal">View Asset History</button>--%>
        <a href="AddAssetItem.aspx" class="btn btn-primary w-100 mb-2" id="AllAssetBtn1"> Assets Items</a>
        <a href="AddRole.aspx" class="btn btn-secondary w-100 mb-2" id="AllAllocationAssetBtn1">Add Roles</a>
    </div>
  </div>
</div>
    
        </div>
      </div>
        
    <!-- Modals -->
    <form runat="server"   >
         <style>
        .same-size-dropdown {
            width: 100%;
            max-width: 300px;
        }
    </style>
    <div class="modal fade" id="assetModal" tabindex="-1" aria-labelledby="assetModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="assetModalLabel">Add Asset</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
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
                    <div class="form-group">
                            <label for="assetNo" >Asset Unique Number</label>
                            <input type="text" class="form-control" id="assetNo" placeholder="Enter asset number" runat="server">
                        </div>
                    <div class="form-group">
    <label for="assetpdate">Purchase Date</label>
    <input type="text" class="form-control" id="assetpdate" placeholder="dd/mm/yyyy" runat="server">
</div>
<div class="form-group">
    <label for="assetwdate">Warranty Date</label>
    <input type="text" class="form-control" id="assetwdate" placeholder="dd/mm/yyyy" runat="server">
</div>


                    <div class="form-group">
                        <label for="assetprice">Price</label>
                        <input type="number" class="form-control" id="assetprice" placeholder="Enter asset price" runat="server">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                   <!-- <button type="Submit" class="btn btn-primary" OnClick="Btnsubmitassetdata_Click">Save Asset</button> -->
                   <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Submit" OnClick="Btnsubmitassetdata_Click"  OnClientClick="return validateForm();" /> 
                   


                    <label id="lbl" runat="server"></label>
                </div>
            </div>
        </div>
    </div>
</form>

    <!-- Add User Modal -->
  <%-- <form id="userForm" method="post" action="Aset.aspx">
            <div class="form-group">
                <label for="userName">Name</label>
                <input type="text" class="form-control" id="userName" name="name" placeholder="Enter name" required>
            </div>
            <div class="form-group">
                <label for="userRole">Role</label>
                <select class="form-control" id="userRole" name="role" required>
                    <!-- Roles will be populated here dynamically -->
                </select>
            </div>
            <div class="form-group">
                <label for="userEmail">Email</label>
                <input type="email" class="form-control" id="userEmail" name="email" placeholder="Enter email" required>
            </div>
            <div class="form-group">
                <label for="userPhone">Phone</label>
                <input type="text" class="form-control" id="userPhone" name="phone" placeholder="Enter phone number" required>
            </div>
            <div class="form-group">
                <label for="userPassword">Password</label>
                <input type="password" class="form-control" id="userPassword" name="password" placeholder="Enter password" required>
            </div>
            <button type="submit" class="btn btn-primary">Add User</button>
        </form>--%>

        

<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
  <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <!-- Additional modals can be added for other actions -->
     <script>
         
         
         function validateDate(input) {
             var datePattern = /^(\d{2})\/(\d{2})\/(\d{4})$/; // Regular expression to match dd/mm/yyyy format
             var dateValue = input.value.trim();

             if (!datePattern.test(dateValue)) {
                 if (!input.dataset.formatAlertShown) { // Check if format alert has not been shown
                     alert("Date is not in correct format. Please enter the date in dd/mm/yyyy format.");
                     input.dataset.formatAlertShown = "true"; // Mark format alert as shown
                 }
                 input.value = ""; // Clear the invalid date input
                 input.focus(); // Focus the input for correction
                 return false; // Return false for invalid format
             } else {
                 // Reset the alert flag when the format is corrected
                 input.dataset.formatAlertShown = "false";
             }

             // Parse the date components to validate logical correctness
             var parts = dateValue.split('/');
             var day = parseInt(parts[0], 10);
             var month = parseInt(parts[1], 10);
             var year = parseInt(parts[2], 10);

             var dateObj = new Date(year, month - 1, day);
             if (
                 dateObj.getFullYear() !== year ||
                 dateObj.getMonth() + 1 !== month ||
                 dateObj.getDate() !== day
             ) {
                 alert("Invalid date. Please enter a valid date in dd/mm/yyyy format.");
                 input.value = ""; // Clear the invalid date input
                 return false; // Return false for invalid date
             }

             return true; // Return true for valid date
         }

         function validateWarrantyDate(purchaseDateInput, warrantyDateInput) {
             var purchaseDateValue = purchaseDateInput.value.trim();
             var warrantyDateValue = warrantyDateInput.value.trim();

             if (purchaseDateValue && warrantyDateValue) {
                 var purchaseParts = purchaseDateValue.split('/');
                 var warrantyParts = warrantyDateValue.split('/');

                 var purchaseDate = new Date(
                     parseInt(purchaseParts[2], 10),
                     parseInt(purchaseParts[1], 10) - 1,
                     parseInt(purchaseParts[0], 10)
                 );
                 var warrantyDate = new Date(
                     parseInt(warrantyParts[2], 10),
                     parseInt(warrantyParts[1], 10) - 1,
                     parseInt(warrantyParts[0], 10)
                 );

                 if (warrantyDate <= purchaseDate) {
                     alert("Warranty date must be greater than the purchase date.");
                     warrantyDateInput.value = ""; // Clear the invalid warranty date
                     return false; // Return false for invalid date relationship
                 }
             }

             return true; // Return true for valid date relationship
         }

         // Add event listeners to validate the date when the user changes the date field
         window.onload = function () {
             var assetDate = document.getElementById("assetpdate");
             var warrantyDate = document.getElementById("assetwdate");

             assetDate.addEventListener('blur', function () {
                 validateDate(assetDate); // Validate purchase date format
             });

             warrantyDate.addEventListener('blur', function () {
                 if (validateDate(warrantyDate)) { // Validate warranty date format
                     validateWarrantyDate(assetDate, warrantyDate); // Validate warranty > purchase date
                 }
             });
         };








         //feach the data for dropdown for asset allot

         $(document).ready(function () {
             // Fetch Employee Names
             $.ajax({
                 url: '/getEmployees', // Endpoint for fetching employee data
                 type: 'GET',
                 success: function (response) {
                     let employeeDropdown = $('#employeeId');
                     employeeDropdown.empty();
                     employeeDropdown.append('<option value="">Select Employee ID</option>');
                     response.forEach(function (employee) {
                         employeeDropdown.append(`<option value="${employee.employee_id}">${employee.name}</option>`);
                     });
                 },
                 error: function (error) {
                     console.error('Error fetching employees:', error);
                 }
             });

             // Fetch Assets
             $.ajax({
                 url: '/getAssets', // Endpoint for fetching asset data
                 type: 'GET',
                 success: function (response) {
                     let assetDropdown = $('#assetNoAllot');
                     assetDropdown.empty();
                     assetDropdown.append('<option value="">Select Asset Number</option>');
                     response.forEach(function (asset) {
                         assetDropdown.append(`<option value="${asset.unique_number}">${asset.unique_number}</option>`);
                     });
                 },
                 error: function (error) {
                     console.error('Error fetching assets:', error);
                 }
             });
         });
         // save the allot data
         $('#allotAssetModal .btn-primary').click(function () {
             const data = {
                 employee_id: $('#employeeId').val(),
                 unique_number: $('#assetNoAllot').val(),
                 allocation_date: $('#allocationDate').val(),
                 note: $('#note').val(),
                 alloted_by_employee_id: 1 // Example: Set to logged-in user's ID
             };

             $.ajax({
                 url: '/allotAsset', // Endpoint for saving allocation data
                 type: 'POST',
                 contentType: 'application/json',
                 data: JSON.stringify(data),
                 success: function (response) {
                     alert('Asset successfully allotted!');
                     $('#allotAssetModal').modal('hide');
                 },
                 error: function (error) {
                     console.error('Error allotting asset:', error);
                     alert('Failed to allot asset.');
                 }
             });
         });




         //empolyee data
         $(document).ready(function () {
             $('#addUserButton').on('click', function (e) {
                 e.preventDefault();  // Prevent the form from submitting the traditional way

                 var userData = {
                     name: $('#userName').val(),
                     role: $('#userRole').val(),
                     email: $('#userEmail').val(),
                     phone: $('#userPhone').val(),
                     password: $('#userPassword').val()
                 };

                 // Validate that no field is null or empty
                 if (!userData.name || !userData.role || !userData.email || !userData.phone || !userData.password) {
                     alert("All fields are required!");
                     return;
                 }

                 // Validate Phone Number (must be 10 digits)
                 var phoneRegex = /^\d{10}$/;
                 if (!phoneRegex.test(userData.phone)) {
                     alert("Please enter a valid 10-digit phone number.");
                     return;
                 }

                 // Validate Email (basic pattern to check the format)
                 var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[.][a-zA-Z]{2,}$/;
                 if (!emailRegex.test(userData.email)) {
                     alert("Please enter a valid email address.");
                     return;
                 }

                 // Validate Password (min 3 characters, max 20 characters, must include at least one letter, one number, and one special character)
                 var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{3,20}$/;
                 if (!passwordRegex.test(userData.password)) {
                     alert("Password must be between 3-20 characters and include at least one letter, one number, and one special character.");
                     return;
                 }

                 // Send the form data via AJAX
         //        $.ajax({
         //            url: 'Aset.aspx',  // Adjust URL as needed
         //            type: 'POST',
         //            data: userData,
         //            success: function (response) {
         //                console.log(response);
         //                // Handle successful response
         //                alert("User added successfully!");
         //                $('#userModal').modal('hide');  // Close the modal
         //            },
         //            error: function (xhr, status, error) {
         //                console.error(error);
         //                alert("An error occurred while adding the user.");
         //            }
         //        });
         //    });
         //});

                 $(document).ready(function () {
                     // Fetch roles using AJAX when the page loads
                     $.ajax({
                         url: 'Aset.aspx?action=getRoles',  // URL to fetch roles
                         type: 'GET',
                         success: function (data) {
                             var roles = JSON.parse(data);  // Parse the returned JSON data
                             var roleDropdown = $('#userRole');

                             // Clear existing options in the dropdown
                             roleDropdown.empty();

                             // Add a default option for role selection
                             roleDropdown.append('<option value="" disabled selected>Select role</option>');

                             // Populate the dropdown with roles from the database
                             $.each(roles, function (index, role) {
                                 roleDropdown.append('<option value="' + role.role_id + '">' + role.role_name + '</option>');
                             });
                         },
                         error: function (xhr, status, error) {
                             alert("Error fetching roles: " + error);  // Alert if there's an error
                         }
                     });
                 });


         


         function validateForm() {
             const assetType = document.getElementById('<%= DropDownList1.ClientID %>').value;
                 const assetName = document.getElementById('<%= DropDownList2.ClientID %>').value;
                 const assetNo = document.getElementById('assetNo').value.trim();
                 const assetPDate = document.getElementById('assetpdate').value;
                 const assetPrice = document.getElementById('assetprice').value;

                 if (assetType === "0") {
                     alert("Please select a valid Asset Type.");
                     return false;
                 }
                 if (assetName === "0") {
                     alert("Please select a valid Asset Name.");
                     return false;
                 }
                 if (!assetNo) {
                     alert("Please enter the Asset Unique Number.");
                     return false;
                 }
                 if (!assetPDate) {
                     alert("Please enter the Purchase Date.");
                     return false;
                 }
                 if (!assetPrice) {
                     alert("Please enter the Price.");
                     return false;
                 }

                 // If all validations pass
                 return true;
             }

         document.addEventListener("DOMContentLoaded", function () {
             const form = document.querySelector("form");
             form.addEventListener("submit", function (event) {
                 const purchaseDateInput = document.getElementById("assetpdate");
                 const warrantyDateInput = document.getElementById("assetwdate");

                 const purchaseDate = new Date(purchaseDateInput.value);
                 const warrantyDate = new Date(warrantyDateInput.value);

                 if (warrantyDate <= purchaseDate) {
                     event.preventDefault(); // Prevent form submission
                     //alert("Warranty date must be greater than the purchase date.");
                     warrantyDateInput.focus();
                 }
             });
         });

         document.getElementById('addUserButton').addEventListener('click', function () {
             const form = document.getElementById('userForm');
             const password = document.getElementById('userPassword').value;

             // Password validation regex
             const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{3,20}$/;

             if (!form.checkValidity()) {
                 form.reportValidity();
                 return;
             }

             if (!passwordRegex.test(password)) {
                 alert('Password must contain at least 3 characters, including one letter, one number, and one special character upto 20 characters.');
                 return;
             }

             alert('User added successfully!');
         });


         
         document.getElementById('assetType').addEventListener('change', function () {
             const assetType = this.value; // Get selected asset type
             const assetNameDropdown = document.getElementById('assetName');

             // Clear existing options
             assetNameDropdown.innerHTML = '<option value="">Select Asset Name</option>';

             // Add new options based on the selected asset type
             if (assetNamesByType[assetType]) {
                 assetNamesByType[assetType].forEach(name => {
                     const option = document.createElement('option');
                     option.value = name;
                     option.textContent = name;
                     assetNameDropdown.appendChild(option);
                 });
             }
         });

         document.querySelectorAll('.service-btn').forEach(button => {
             button.addEventListener('click', () => {
                 const targetId = button.getAttribute('data-target');
                 const targetElement = document.getElementById(targetId);

                 // Toggle visibility
                 if (targetElement.style.display === 'none' || targetElement.style.display === '') {
                     targetElement.style.display = 'block';
                 } else {
                     targetElement.style.display = 'none';
                 }
             });
         });
         

         document.querySelectorAll('.btn-option').forEach(function (btn) {
             btn.addEventListener('click', function (event) {
                 event.preventDefault(); // Prevent navigation
                 const buttonName = this.textContent; // Get button name
                 document.getElementById('searchBar').value = buttonName; // Insert into search bar
             });
         });


     </script>

    <!-- JavaScript dependencies -->
    
</body>
</html>

