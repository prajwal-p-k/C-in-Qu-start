<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AssetManagement.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Asset Management System - Login</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa;
        }
        .card {
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
        }
        .card h3 {
            color: #007bff;
        }
        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
        }
        body{
            background-color: currentColor;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1 class="text-center my-4" style="    color: #00c7ff;
">Asset Management System</h1>
        <div class="d-flex justify-content-center align-items-center vh-100" style="position: relative;
    top: -100px;">
            <div class="card shadow" style="width: 400px;">
                <div class="card-body">
                    <h3 class="text-center mb-4">Login</h3>
                    <!-- Display error message if msg=0 -->
                    <% 
                        if (Request.QueryString["msg"] == "0") 
                        { 
                    %>
                        <div class="alert alert-danger" role="alert">
                            Invalid phone number or password. Please try again.
                        </div>
                    <% 
                        } 
                    %>
                    <form id="loginForm" method="post" action="validate.aspx">
                        <div class="mb-3">
                            <label for="phoneInput" class="form-label">Phone Number:</label>
                            <input type="text" class="form-control" id="phoneInput" name="email" placeholder="9108023456" 
           oninput="this.value = this.value.replace(/[^0-9]/g, '').slice(0, 10);" required>
                            <div id="phoneError" class="text-danger mt-1" style="display: none;">Please enter your phone number.</div>
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Password</label>
                            <input type="password" class="form-control" id="password" name="pwd" placeholder="Enter your password" required>
                            <div id="passwordError" class="text-danger mt-1" style="display: none;">Please enter your password.</div>
                        </div>
                        <button type="button" class="btn btn-primary w-100" onclick="validateForm()">Login</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        function validateForm() {
            const phoneInput = document.getElementById('phoneInput');
            const passwordInput = document.getElementById('password');
            const phoneError = document.getElementById('phoneError');
            const passwordError = document.getElementById('passwordError');

            let valid = true;

            if (!phoneInput.value.trim()) {
                phoneError.style.display = 'block';
                valid = false;
            } else {
                phoneError.style.display = 'none';
            }

            if (!passwordInput.value.trim()) {
                passwordError.style.display = 'block';
                valid = false;
            } else {
                passwordError.style.display = 'none';
            }

            if (valid) {
                document.getElementById('loginForm').submit();
            }
        }
    </script>
</body>
</html>


