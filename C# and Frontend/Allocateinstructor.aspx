<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Allocateinstructor.aspx.cs" Inherits="Allocateinstructor" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 20px;
        }
        
        h2 {
            color: #333;
        }
        
        label {
            display: block;
            margin-top: 10px;
        }
        
        .form-container {
            max-width: 400px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        
        .form-container select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            margin-top: 5px;
        }
        
        .form-container button {
            background-color: #4CAF50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-top: 10px;
        }
        
        .form-container button:hover {
            background-color: #45a049;
        }
        
        /* Custom colors */
        body {
            color: #333;
        }
        
        h2 {
            color: #337ab7;
        }
        
        .form-container {
            border-color: #ddd;
            background-color: #f9f9f9;
        }
        
        .form-container select {
            border-color: #bbb;
        }
        
        .form-container button {
            background-color: #337ab7;
        }
        
        .form-container button:hover {
            background-color: #286090;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Assign Courses to Faculty</h2>

            <label for="FacultyList">Select Faculty:</label>
            <asp:DropDownList ID="FacultyList" runat="server"></asp:DropDownList>

            <label for="SectionList">Select Section:</label>
            <asp:DropDownList ID="SectionList" runat="server"></asp:DropDownList>

            <label for="CourseList">Select Course:</label>
            <asp:DropDownList ID="CourseList" runat="server"></asp:DropDownList>

            <asp:Button ID="AssignButton" runat="server" Text="Assign" OnClick="AssignButton_Click" />
        </div>
    </form>
</body>
</html>



