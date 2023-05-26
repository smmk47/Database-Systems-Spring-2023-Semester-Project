<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentSection.aspx.cs" Inherits="StudentSection" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <style>
       

         body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        h1, h2 {
            color: #1a237e;
        }

        .form-control {
            display: block;
            width: 70%; /* Increased width from 50% to 70% */
            padding: 8px;
            border: 1px solid #1a237e;
            border-radius: 4px;
            background-color: #ffffff;
            font-size: 14px;
            margin-left: auto;
            margin-right: auto;
        }

        .btn {
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
        }

        .btn-primary {
            background-color: #1a237e;
            color: #ffffff;
        }

        .btn-primary:hover {
            background-color: #3f51b5;
            color: #ffffff;
        }

        .btn-danger {
            background-color: #b71c1c;
            color: #ffffff;
        }

        .btn-danger:hover {
            background-color: #c62828;
            color: #ffffff;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 16px;
            background-color: #ffffff;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Panel</h1>

        <h2>Search student</h2>
        <label for="txtSearch">RollNo:</label>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        <br /><br />

        <hr />
        <h2>Student Details</h2>
        <label for="lblStudentID">ID:</label>
        <asp:Label ID="lblStudentID" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblRollNo">Roll No:</label>
        <asp:Label ID="lblRollNo" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblName">Name:</label>
        <asp:Label ID="lblName" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblDOB">Date of Birth:</label>
        <asp:Label ID="lblDOB" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblEmail">Email:</label>
        <asp:Label ID="lblEmail" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblPhoneNo">Phone No:</label>
        <asp:Label ID="lblPhoneNo" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblDateOfAdmission">Date of Admission:</label>
        <asp:Label ID="lblDateOfAdmission" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblCGPA">CGPA:</label>
        <asp:Label ID="lblCGPA" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblCreditHours">Credit Hours:</label>
        <asp:Label ID="lblCreditHours" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblAddress">Address:</label>
        <asp:Label ID="lblAddress" runat="server" CssClass="form-control" />
        <br /><br />

        <h2>Add Student</h2>
        <label for="txtStudentID">ID:</label>
        <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtRollNoAdd">Roll No:</label>
        <asp:TextBox ID="txtRollNoAdd" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtFname">First Name:</label>
        <asp:TextBox ID="txtFname" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtLname">Last Name:</label>
        <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtDOB">Date of Birth:</label>
        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtEmailAdd">Email:</label>
        <asp:TextBox ID="txtEmailAdd" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        <br /><br />
        <label for="txtPhoneNo">Phone No:</label>
        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtDateOfAdmission">Date of Admission:</label>
        <asp:TextBox ID="txtDateOfAdmission" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtCGPA">CGPA:</label>
        <asp:TextBox ID="txtCGPA" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtCreditHours">Credit Hours:</label>
        <asp:TextBox ID="txtCreditHours" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtAddress">Address:</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
        <br /><br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        <hr />

        <h2>Delete Student Data</h2>
         <label for="txtRollNo">Roll No:</label>
         <asp:TextBox ID="txtRollNo" runat="server" CssClass="form-control" />
         <br /><br />
         <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
    </form>
</body>
</html>

