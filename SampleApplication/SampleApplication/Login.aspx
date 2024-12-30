<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SampleApplication.Login" %>



<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Login Form</title>
<!-- Bootstrap CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
<div class="container d-flex justify-content-center align-items-center vh-100">
<div class="card shadow" style="width: 400px;">
<div class="card-body">
<h3 class="text-center mb-4">Login</h3>
<form method="post" action="validate.aspx">
<div class="mb-3">
<label for="email" class="form-label">email:</label>
   <input type="email" class="form-control" id="email" name="email" placeholder="enter your email" required>
</div>
<div class="mb-3">
<label for="password" class="form-label">Password</label>
<input type="password" class="form-control" id="password" name="pwd" placeholder="Enter your password" required>
</div>
<button type="submit" class="btn btn-primary w-100">Login</button>
</form>
</div>
</div>
</div>
<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

